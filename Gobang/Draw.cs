using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace Gobang
{
    class Draw
    {
        Graphics g, mg;
        Pen pen, prePen;
        Brush blackBrush, whiteBrush,dotBrush;
        Panel p;
        BufferedGraphics myBuffer;
        int[] previewDot = { -1, -1 };

        private int[,] grid = new int[15, 15];
        private int[] LastDot = { -1, -1 };

        private bool status = false;

        private Bitmap bg;
        public Draw(Panel p)
        {
            this.p = p;
            g = p.CreateGraphics();
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(g, new Rectangle(0, 0, p.Width, p.Height));
            mg = myBuffer.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            pen = new Pen(Color.Black, 1);
            blackBrush = new SolidBrush(Color.Black);
            whiteBrush = new SolidBrush(Color.White);
            dotBrush = new SolidBrush(Color.Black);
            prePen = new Pen(Color.Red, 1);
            prePen.DashStyle = DashStyle.DashDot;
            reset();
            setBg(0);
        }

        public void setBg(int x)
        {
            pen.Color = Color.Black;
            switch (x % 7)
            {
                case 0:
                    bg = global::Gobang.Properties.Resources.bg0;
                    break;
                case 1:
                    pen.Color = Color.White;
                    bg = global::Gobang.Properties.Resources.bg1;
                    break;
                case 2:
                    bg = global::Gobang.Properties.Resources.bg2;
                    break;
                case 3:
                    bg = global::Gobang.Properties.Resources.bg3;
                    break;
                case 4:
                    bg = global::Gobang.Properties.Resources.bg4;
                    break;
                case 5:
                    bg = global::Gobang.Properties.Resources.bg5;
                    break;
                case 6:
                    pen.Color = Color.White;
                    bg = global::Gobang.Properties.Resources.bg6;
                    break;
                default:
                    bg = global::Gobang.Properties.Resources.bg0;
                    break;
            }
            dotBrush = new SolidBrush(pen.Color);
        }

        public void setDot(int i, int j, int dotColor)
        {
            LastDot[0] = i;
            LastDot[1] = j;
            grid[i, j] = dotColor;
            paint();
        }

        public void setPreview(int x, int y)
        {
            previewDot[0] = x;
            previewDot[1] = y;
            if (previewDot[0] >= 0 && previewDot[1] > 0)
            {
                paint();
            }
        }

        public void clearLast()
        {
            LastDot[0] = -1;
            LastDot[1] = -1;
        }
        public void reset()
        {
            for (int i = 0; i <= grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= grid.GetUpperBound(1); j++)
                {
                    grid[i, j] = DotColor.None;
                }
            }
        }

        public void re_draw()
        {
            myBuffer = BufferedGraphicsManager.Current.Allocate(g, new Rectangle(0, 0, p.Width, p.Height));
            mg = myBuffer.Graphics;
            paint();
        }

        public bool isLocation(ref int x, ref int y)
        {
            int width = p.Width / 16;
            int mx = x % width;
            int my = y % width;
            int xx = x / width;
            int xy = y / width;
            bool flag = true;
            if (mx * 3 > width * 2)
            {
                ++xx;
            }
            else if (3 * mx > width)
            {
                flag = false;
            }
            if (my * 3 > width * 2)
            {
                ++xy;
            }
            else if (3 * my > width)
            {
                flag = false;
            }
            if (flag && xx > 0 && xy > 0 && xx < 16 && xy < 16)
            {
                x = xx - 1;
                y = xy - 1;
            }
            return flag;
        }

        public void paint()
        {
            if (status) return;
            status = true;
            mg.Clear(Color.Black);

            mg.DrawImage(bg, new Rectangle(0, 0, p.Width, p.Height), new Rectangle(0, 0, bg.Width, bg.Height),GraphicsUnit.Pixel);

            int width = p.Width / 16;
            for (int i = 0; i < 15; i++)
            {
                mg.DrawLine(pen, new Point((i + 1) * width, width), new Point((i + 1) * width, width * 15));
                mg.DrawLine(pen, new Point(width, (i + 1) * width), new Point(width * 15, (i + 1) * width));
            }
            if (previewDot[0] >= 0 && previewDot[1] >= 0)
            {

                bool has;
                Rectangle xy = getPointByXY(previewDot[0], previewDot[1], out has);
                if (has)
                {
                    mg.DrawEllipse(prePen, xy);
                }
            }


            int x = width / 10;
            for (int i = 4; i < 15; i += 8)
            {
                for (int j = 4; j < 15; j += 8)
                {
                    mg.FillEllipse(dotBrush, new Rectangle(width * i - x, width * j - x, x * 2, x * 2));
                }
            }
            mg.FillEllipse(dotBrush, new Rectangle(width * 8 - x, width * 8 - x, x * 2, x * 2));


            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    switch (grid[i, j])
                    {
                        case DotColor.Black:
                            mg.FillEllipse(blackBrush, getPointRect(i, j));
                            break;
                        case DotColor.White:
                            mg.FillEllipse(whiteBrush, getPointRect(i, j));
                            break;
                        default:
                            break;
                    }
                }
            }
            myBuffer.Render(g);
            status = false;
        }



        private Rectangle getPointRect(int x, int y)
        {
            ++x;
            ++y;
            int width = p.Width / 16;
            return new Rectangle(x * width - width / 2, y * width - width / 2, width, width);
        }

        private Rectangle getPointByXY(int x, int y, out bool has)
        {
            Rectangle rect = new Rectangle();
            if (isLocation(ref x, ref y) && dotColorCheck(x, y, DotColor.None))
            {
                int width = p.Width / 16;
                rect.Height = width;
                rect.Width = width;
                rect.Location = new Point(x * width + width / 2, y * width + width / 2);
                has = true;
            }
            else
            {
                has = false;
            }
            return rect;
        }

        public bool dotColorCheck(int x, int y, int color)
        {
            return x >= 0 && x < 15 && y >= 0 && y < 15 && grid[x, y] == color;
        }
    }
}
