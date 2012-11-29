using System;
using System.Drawing;
using 汉诺塔.Properties;

namespace 汉诺塔
{
    class DrawHan : IDisposable
    {
        //需要绘制到画面上的位图
        public Bitmap bmp;

        public Hannota han;
        public Graphics gra;
        public Point[] arrowP;
        public Point[] takeP;
        public Bitmap[] lines;
        public int[] pos;

        //构造方法，初始化绘图数据
        public DrawHan(Hannota h)
        {
            han = h;
            bmp = new Bitmap(639, 287);
            gra = Graphics.FromImage(bmp);
            gra.Clear(Color.White);
            arrowP = new Point[3] { new Point(75, 0), new Point(295, 0), new Point(505,0) };
            takeP = new Point[3] { new Point(0, 60), new Point(220, 60), new Point(429, 60) };
            pos = new int[3] { 0, 220, 429 };
            lines = new Bitmap[8] { Resources._8, Resources._7, Resources._6, Resources._5, Resources._4, Resources._3, Resources._2, Resources._1, };
        }

        //通过Hannota对象来更新图像
        public void Update()
        {
            gra.Clear(Color.White);
            //画三根柱
            gra.DrawLine(new Pen(Color.Black, 11), 595 / 6, 80, 595 / 6, 287);
            gra.DrawLine(new Pen(Color.Black, 11), 639 / 2, 80, 639 / 2, 287);
            gra.DrawLine(new Pen(Color.Black, 11), 3173 / 6, 80, 3173 / 6, 287);
            //画箭头
            gra.DrawImage(Resources.arrow, arrowP[han.HanP]);
            //画柱子上的圆盘（难点）
            for (byte i = 0; i <= 2; i++)
            {
                int len = han.Pillars[i].Count;
                for (byte j = 0; len != 0; j++)
                {
                    if (j >= len)
                        break;
                    gra.DrawImage(lines[han.Pillars[i][j] - 1], pos[i], 270 - j * 15);
                }
            }
            //画箭头下的盘子
            if (han.HanT != 0)
                gra.DrawImage(lines[han.HanT-1], takeP[han.HanP]);
        }

        //释放资源
        public void Dispose()
        {
            bmp.Dispose();
            gra.Dispose();
            foreach (var item in lines)
            {
                item.Dispose();
            }
        }
    }
}
