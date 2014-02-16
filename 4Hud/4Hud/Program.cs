using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _4Hud
{
    static class Program
    {
        public static int ColorStyleStyle = 0;


        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                bool update = false;
                bool restart = false;

                foreach (string s in args)
                {
                    if (s == "-update")
                        update = true;
                    else if (s == "-restart")
                        restart = true;
                }

                if (update)
                {
                    Application.Run(new Form1(restart));
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }
            catch { }
        }
    }
}
