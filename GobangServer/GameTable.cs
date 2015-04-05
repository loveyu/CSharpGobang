//-------------------GameTable.cs-----------------//
using System;
using System.Timers;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
namespace GobangServer
{
    class GameTable
    {
        private const int None = -1;       //������
        private const int Black = 0;       //��ɫ����
        private const int White = 1;       //��ɫ����
        public Player[] gamePlayer;         //һ���壬��Ϸ˫����
        private int[,] grid = new int[15, 15];       //15*15�ķ���
        private System.Timers.Timer timer;       //���ڶ�ʱ�������ӣ��Ǵ�������޷�ֱ��ʹ�ÿؼ���
        private int NextdotColor = 0;            //Ӧ�ò��������ӻ��ǰ�����
        private ListBox listbox;
        Random rnd = new Random();                  //����������ӵ�λ�á�
        Service service;
        public GameTable(ListBox listbox)
        {
            gamePlayer = new Player[2];
            gamePlayer[0] = new Player();
            gamePlayer[1] = new Player();
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = false;
            this.listbox = listbox;
            service = new Service(listbox);
            ResetGrid();
        }
        public void ResetGrid()
        {
            for (int i = 0; i <= grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= grid.GetUpperBound(1); j++)
                {
                    grid[i, j] = None;
                }
            }
        }
        public void StartTimer()
        {
            timer.Start();
        }
        public void StopTimer()
        {
            timer.Stop();
        }
        public void SetTimerLevel(int interval)
        {
            timer.Interval = interval;
        }
        private void timer_Elapsed(object sender, EventArgs e)
        {
            int x, y;
            //�������һ������û�����ӵĵ�Ԫ��λ��
            do
            {
                x = rnd.Next(15);  //����һ��С��15�ķǸ�����
                y = rnd.Next(15);
            } while (grid[x, y] != None);
            //��������:x����,y����,��ɫ
            
            //ע�����ӷ��͹���
            //SetDot(x, y, NextdotColor);
            NextdotColor = (NextdotColor + 1) % 2;
        }
        public bool CheckWin(int dotColor) {
            //��������
            int i, j, count1,count2,count3,count4;
            for (i = 0; i < 15; i++) {
                count1 = 0;
                count2 = 0;
                for (j = 0; j < 15; j++) {
                    if (grid[i, j] != dotColor)
                    {
                        count1 = 0;
                    }
                    else
                    {
                        count1++;
                        if (count1 == 5) return true;
                    }
                    if (grid[j, i] != dotColor)
                    {
                        count2 = 0;
                    }
                    else
                    {
                        count2++;
                        if (count2 == 5) return true;
                    }
                }
            }
            //б����
            for (i = 0; i < 12; i++) {
                count1 = 0;
                count2 = 0;
                count3 = 0;
                count4 = 0;
                for (j = 0; j < 15 - i; j++) {

                    //��������
                    if (grid[j, j+i] != dotColor)
                    {
                        count1 = 0;
                    }
                    else
                    {
                        count1++;
                        if (count1 == 5) return true;
                    }
                    //��������
                    if (grid[14-i-j, j] != dotColor)
                    {
                        count2 = 0;
                    }
                    else
                    {
                        count2++;
                        if (count2 == 5) return true;
                    }
                    //��������
                    if(grid[j+i,j] != dotColor){
                        count3 = 0;
                    }
                    else
                    {
                        count3++;
                        if (count3 == 5) return true;
                    }
                    //��������
                    if (grid[14-j,i+j] != dotColor)
                    {
                        count4 = 0;
                    }
                    else
                    {
                        count4++;
                        if (count4 == 5) return true;
                    }
                }
            }
                return false;
        }
        public void SetDot(int i, int j, int dotColor)
        {
            //�������û����Ͳ�����������Ϣ�����ж��Ƿ�����������
            //���͸�ʽ��SetDot,��,��,��ɫ
            grid[i, j] = dotColor;
            service.SendToBoth(this, string.Format("SetDot,{0},{1},{2}", i, j, dotColor));
            if (CheckWin(dotColor))
            {
                ShowWin(dotColor);
            }
            /*----------�����жϵ�ǰ���Ƿ������ڵ�----------*/
            /*
            int k1, k2;   //k1:ѭ����ֵ��k2:ѭ����ֵ
            if (i == 0)
            {
                //��������У�ֻ��Ҫ�ж��±ߵĵ�
                k1 = k2 = 1;
            }
            else if (i == grid.GetUpperBound(0))
            {
                //��������һ�У�ֻ��Ҫ�ж��ϱߵĵ�
                k1 = k2 = grid.GetUpperBound(0) - 1;
            }
            else
            {
                //������м���У��������ߵĵ㶼Ҫ�ж�
                k1 = i - 1; k2 = i + 1;
            }
            for (int x = k1; x <= k2; x += 2)
            {
                if (grid[x, j] == dotColor)
                {
                    ShowWin(dotColor);
                }
            }
             */
            /*-------------�����жϵ�ǰ���Ƿ������ڵ�------------------*/
            /*
            if (j == 0)
            {
                k1 = k2 = 1;
            }
            else if (j == grid.GetUpperBound(1))
            {
                k1 = k2 = grid.GetUpperBound(1) - 1;
            }
            else
            {
                k1 = j - 1; k2 = j + 1;
            }
            for (int y = k1; y <= k2; y += 2)
            {
                if (grid[i, y] == dotColor)
                {
                    ShowWin(dotColor);
                }
            }
            */
        }
        //�������ڵ����ɫΪdotColor
        private void ShowWin(int dotColor)
        {
            timer.Enabled = false;
            gamePlayer[0].started = false;
            gamePlayer[1].started = false;
            gamePlayer[dotColor].grade += 20;
            this.ResetGrid();
            //���͸�ʽ��Win,���ڵ����ɫ,�ڷ��ɼ�,�׷��ɼ�
            service.SendToBoth(this, string.Format("Win,{0},{1},{2}",
                dotColor, gamePlayer[0].grade, gamePlayer[1].grade));
        }
        public void UnsetDot(int i, int j, int color)
        {
            //�������û�������ȥ���ӵ���Ϣ
            //��ʽ��UnsetDot,��,��,�ڷ��ɼ�,�׷��ɼ�
            grid[i, j] = None;
            gamePlayer[color].grade++;
            string str = string.Format("UnsetDot,{0},{1},{2},{3}",
                i, j, gamePlayer[0].grade, gamePlayer[1].grade);
            service.SendToBoth(this, str);
        }
    }
}
