using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace 汉诺塔
{
    public partial class Form1 : Form
    {
        public static byte layers = 3;
        private Hannota han;
        private DrawHan dh;

        public Form1()
        {
            han = new Hannota(layers);
            dh = new DrawHan(han);
            dh.Update();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void draw(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.DrawImage(dh.bmp, 0, 0);
            g.Dispose();
        }

        private void Start(object sender, EventArgs e)
        {
            dh.Dispose();
            han = new Hannota(layers);
            dh = new DrawHan(han);
            dh.Update();
            draw(null,null);
        }


        private void 难度设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new SetLayers().ShowDialog() == DialogResult.OK)
                Start(null, null);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否退出游戏?","退出",MessageBoxButtons.OKCancel) == DialogResult.OK)
                Dispose();
        }

        private void 游戏说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Help().ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void control(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                han.TakeUp();
            if (e.KeyCode == Keys.Down)
                han.PutDown();
            if (e.KeyCode == Keys.Left)
                han.MoveLeft();
            if (e.KeyCode == Keys.Right)
                han.MoveRight();
            dh.Update();
            draw(null, null);
            if (han.Win())
            {
                MessageBox.Show(string.Format("游戏完成！ 您移动了 {0} 次", han.times), "胜利");
                Start(null,null);
            }
        }

        //这是一个有待启用的功能
        public void AutoMove(byte start, byte end)
        {
            if (start != han.HanP)
            {
                han.HanP = start;
                dh.Update();
                draw(null, null);
                Thread.Sleep(500);
            }
            han.TakeUp();
            dh.Update();
            draw(null, null);
            Thread.Sleep(500);
            han.HanP = end;
            dh.Update();
            draw(null, null);
            Thread.Sleep(500);
            han.PutDown();
            dh.Update();
            draw(null, null);
        }
    }
}
