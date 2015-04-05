using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//��ӵ������ռ�����
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace Gobang
{
    public partial class FormPlaying : Form
    {
        private int tableIndex;
        private int side;
        private bool[] start_status = { false, false, false };
        private Service service;
        delegate void LabelDelegate(Label label, string str);
        delegate void ButtonDelegate(Button button, bool flag);
        delegate void SetDotDelegate(int i, int j, int dotColor);
        LabelDelegate labelDelegate;
        ButtonDelegate buttonDelegate;
        Draw draw;
        public FormPlaying(int TableIndex, int Side, StreamWriter sw)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            draw = new Draw(painter);

            this.tableIndex = TableIndex;
            this.side = Side;
            labelDelegate = new LabelDelegate(SetLabel);
            buttonDelegate = new ButtonDelegate(SetButton);
            service = new Service(listBox1, sw);
            if (side == 0)
            {
                PlayerColor.Text = "�ڷ�";
            }
            else
            {
                PlayerColor.Text = "�׷�";
            }
        }
        private void FormPlaying_Load(object sender, EventArgs e)
        {
            labelSide0.Text = "";
            labelSide1.Text = "";
            labelGrade0.Text = "0";
            labelGrade1.Text = "0";
            FormPlaying_Resize(null, null);
        }
        public void SetLabel(Label label, string str)
        {
            if (label.InvokeRequired == true)
            {
                this.Invoke(labelDelegate, label, str);
            }
            else
            {
                label.Text = str;
            }
        }
        private void SetButton(Button button, bool flag)
        {
            if (button.InvokeRequired == true)
            {
                this.Invoke(buttonDelegate, button, flag);
            }
            else
            {
                button.Enabled = flag;
            }
        }

        public void SetDot(int i, int j, int dotColor)
        {
            service.SetListBox(string.Format("{0},{1},{2}", i, j, dotColor));
            draw.setDot(i, j, dotColor);

            if (start_status[2])
            {
                SetLabel(LabelPlayStatus, "�ȴ��Է�����");
            }
            else
            {
                SetLabel(LabelPlayStatus, "������");
            }
            start_status[2] = !start_status[2];
            painter.Invalidate();
        }

        private bool isMe()
        {
            return start_status[0] && start_status[1] && start_status[2];
        }

        public void Restart(string str)
        {
            start_status[0] = false;
            start_status[1] = false;
            start_status[2] = false;
            draw.clearLast();
            SetLabel(LabelPlayStatus, "�뿪ʼ��һ����Ϸ");
            MessageBox.Show(str, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ResetGrid();
            SetButton(buttonStart, true);
        }
        private void ResetGrid()
        {
            draw.reset();
            painter.Invalidate();
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            //�ַ�����ʽ��Talk,����,�Ի�����
            service.SendToServer(string.Format("Talk,{0},{1}", tableIndex, textBox1.Text));
        }
        //�Ի����ݸı�ʱ�������¼�
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //�ַ�����ʽ��Talk,����,�Ի�����
                service.SendToServer(string.Format("Talk,{0},{1}", tableIndex, textBox1.Text));
            }
        }
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            string str =
                "\n����Ϸÿ����Ϊһ�顣��Ϸ�淨:\n\n" +
                "\tÿ��������һ���Լ������ӣ�˭�������������һ�߼���Ӯ��\n\n" +
                "\tÿ����Ϸ20�֡�\n";
            MessageBox.Show(str, "������Ϣ");
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            draw.setBg((new Random()).Next(100));
            //���˭�ȿ�ʼ
            start_status[0] = true;
            if (!start_status[1])
            {
                start_status[2] = true;
                LabelPlayStatus.Text = "�ȴ���ҽ�����Ϸ";
            }
            else
            {
                LabelPlayStatus.Text = "�ȴ��Է�������";
            }
            service.SendToServer(string.Format("Start,{0},{1}", tableIndex, side));
            this.buttonStart.Enabled = false;
            painter.Invalidate();
        }
        public void Start_Message(int start_side)
        {
            if (side != start_side)
            {
                start_status[1] = true;
                if (start_status[2])
                {
                    SetLabel(LabelPlayStatus, "��Ϸ�ѿ�ʼ��������");
                }
                else if (start_status[0])
                {
                    SetLabel(LabelPlayStatus, "�ȴ��Է�����");
                }
                else
                {
                    SetLabel(LabelPlayStatus, "�Է���׼����������ʼ");
                }
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //�رմ���ǰ�������¼�
        private void FormPlaying_FormClosing(object sender, FormClosingEventArgs e)
        {
            //��ʽ��GetUp,����,��λ��
            service.SendToServer(string.Format("GetUp,{0},{1}", tableIndex, side));
        }
        //FormRoom�е��̵߳��ô˷����رմ˴���
        public void StopFormPlaying()
        {
            Application.Exit();
        }

        //������ʽ����λ�ţ�labelSide��ʾ����Ϣ��listbox��ʾ����Ϣ
        public void SetTableSideText(string sideString, string labelSideString, string listBoxString)
        {
            string s = "�׷�";
            if (sideString == "0")
            {
                s = "�ڷ���";
            }
            labelSideString = Regex.Replace(labelSideString,@"--[\s\S]+$","]");
            Console.WriteLine(labelSideString);
            //�ж��Լ��Ǻڷ����ǰ׷�
            if (sideString == side.ToString())
            {
                SetLabel(labelSide1, s + labelSideString);
            }
            else
            {
                SetLabel(labelSide0, s + labelSideString);
            }
            service.SetListBox(listBoxString);
        }
        //������ʽ��grade0Ϊ�ڷ��ɼ���grade1Ϊ�׷��ɼ�
        public void SetGradeText(string str0, string str1)
        {
            if (side == DotColor.Black)
            {
                SetLabel(labelGrade1, str0);
                SetLabel(labelGrade0, str1);
            }
            else
            {
                SetLabel(labelGrade0, str0);
                SetLabel(labelGrade1, str1);
            }
        }
        public void ShowTalk(string talkMan, string str)
        {
            service.SetListBox(string.Format("{0}˵��{1}", talkMan, str));
        }
        public void ShowMessage(string str)
        {
            service.SetListBox(str);
        }

        private void FormPlaying_Resize(object sender, EventArgs e)
        {
            int width = leftBox.Width;
            int height = leftBox.Height;
            int p_w;
            if (width > height)
            {
                p_w = height - 10;
            }
            else
            {
                p_w = width - 10;
            }
            painter.Width = p_w;
            painter.Height = p_w;
            painter.Left = (width - p_w) / 2;
            painter.Top = (height - p_w) / 2;
            painter_Resize(sender, e);
        }

        private void painter_Resize(object sender, EventArgs e)
        {
            if (draw != null)
            {
                draw.re_draw();
            }
        }

        private void painter_Paint(object sender, PaintEventArgs e)
        {
            draw.re_draw();
        }

        private void painter_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMe())
            {
                draw.setPreview(e.X, e.Y);
            }
            else
            {
                draw.setPreview(-1, -1);
            }
        }

        private void painter_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isMe()) return;
            int x = e.X;
            int y = e.Y;
            if (draw.isLocation(ref x, ref y) && draw.dotColorCheck(x, y, DotColor.None))
            {
                int color = side;
                //���͸�ʽ��UnsetDot,����,��λ��,��,��,��ɫ
                service.SendToServer(string.Format(
                   "setDot,{0},{1},{2},{3},{4}", tableIndex, side, x, y, color));
            }
        }

    }
}