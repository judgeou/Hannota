using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 汉诺塔
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            lock (new Object()) { Application.Run(new Form1()); }
        }
    }
}
