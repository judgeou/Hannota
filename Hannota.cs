using System.Collections.Generic;

namespace 汉诺塔
{
    //存储、处理游戏的逻辑数据
    class Hannota   
    {
        //三根柱的圆盘数据
        public List<byte>[] Pillars;

        //箭头的位置
        public byte HanP;

        //箭头所拿着的盘子
        public byte HanT;

        //盘子总数（难度）
        public byte layers;

        //操作次数（放下）
        public int times;

        //初始化数据
        public Hannota(byte num)
        {
            if (num < 1)
                num = 1;
            if (num > 8)
                num = 8;
            HanP = 0;
            HanT = 0;
            layers = num;
            Pillars = new List<byte>[3];
            Pillars[0] = new List<byte>();
            Pillars[1] = new List<byte>();
            Pillars[2] = new List<byte>();
            for (; num > 0; num--)
            {
                Pillars[0].Add(num);
            }
            times = 0;
        }

        //箭头左移
        public void MoveLeft()
        {
            if (HanP == 0)
                HanP = 2;
            else
                HanP--;
        }

        //箭头右移
        public void MoveRight()
        {
            if (HanP == 2)
                HanP = 0;
            else
                HanP++;
        }

        //拿起盘子
        public void TakeUp()
        {
            if (HanT != 0)
                return;
            if (Pillars[HanP].Count== 0)
                return;
            int i = Pillars[HanP].Count;
            HanT = Pillars[HanP][i-1];
            Pillars[HanP].RemoveAt(i - 1);
        }

        //放下盘子
        public void PutDown()
        {
            if (HanT == 0)
                return;
            int i = Pillars[HanP].Count;
            if (i==0 || Pillars[HanP][i - 1] > HanT)
            {
                Pillars[HanP].Add(HanT);
                HanT = 0;
                times++;
            }
        }

        //游戏是否处于胜利状态
        public bool Win()
        {
            if (Pillars[2].Count == layers)
                return true;
            else
                return false;
        }
    }
}
