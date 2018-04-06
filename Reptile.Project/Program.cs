using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reptile.Project
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // if (System.DateTime.Now.Year <= 2017 && System.DateTime.Now.Month < 6 && System.DateTime.Now.Day < 15)
            Application.Run(new Form1());
        }
    }
}
