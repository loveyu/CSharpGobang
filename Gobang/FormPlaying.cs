using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//添加的命名空间引用
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
                PlayerColor.Text = "黑方";
            }
            else
            {
                PlayerColor.Text = "白方";
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
                SetLabel(LabelPlayStatus, "等待对方棋子");
            }
            else
            {
                SetLabel(LabelPlayStatus, "请落棋");
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
            SetLabel(LabelPlayStatus, "请开始新一局游戏");
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
            //字符串格式：Talk,桌号,对话内容
            service.SendToServer(string.Format("Talk,{0},{1}", tableIndex, textBox1.Text));
        }
        //对话内容改变时触发的事件
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //字符串格式：Talk,桌号,对话内容
                service.SendToServer(string.Format("Talk,{0},{1}", tableIndex, textBox1.Text));
            }
        }
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            string str =
                "\n本游戏每两人为一组。游戏玩法:\n\n" +
                "\t每人轮流放一颗自己的棋子，谁的棋子最先五点一线即算赢。\n\n" +
                "\t每场游戏20分。\n";
            MessageBox.Show(str, "帮助信息");
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            draw.setBg((new Random()).Next(100));
            //检测谁先开始
            start_status[0] = true;
            if (!start_status[1])
            {
                start_status[2] = true;
                LabelPlayStatus.Text = "等待玩家进入游戏";
            }
            else
            {
                LabelPlayStatus.Text = "等待对方下棋子";
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
                    SetLabel(LabelPlayStatus, "游戏已开始，请落子");
                }
                else if (start_status[0])
                {
                    SetLabel(LabelPlayStatus, "等待对方落子");
                }
                else
                {
                    SetLabel(LabelPlayStatus, "对方已准备，请点击开始");
                }
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //关闭窗体前触发的事件
        private void FormPlaying_FormClosing(object sender, FormClosingEventArgs e)
        {
            //格式：GetUp,桌号,座位号
            service.SendToServer(string.Format("GetUp,{0},{1}", tableIndex, side));
        }
        //FormRoom中的线程调用此方法关闭此窗体
        public void StopFormPlaying()
        {
            Application.Exit();
        }

        //参数格式：座位号，labelSide显示的信息，listbox显示的信息
        public void SetTableSideText(string sideString, string labelSideString, string listBoxString)
        {
            string s = "白方";
            if (sideString == "0")
            {
                s = "黑方：";
            }
            labelSideString = Regex.Replace(labelSideString,@"--[\s\S]+$","]");
            Console.WriteLine(labelSideString);
            //判断自己是黑方还是白方
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
        //参数格式：grade0为黑方成绩，grade1为白方成绩
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
            service.SetListBox(string.Format("{0}说：{1}", talkMan, str));
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
                //发送格式：UnsetDot,桌号,座位号,行,列,颜色
                service.SendToServer(string.Format(
                   "setDot,{0},{1},{2},{3},{4}", tableIndex, side, x, y, color));
            }
        }

    }
}