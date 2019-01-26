using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Suren
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Test();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var surapp = new SurenApplication();
            surapp.Start();
        }

        static void Test()
        {
            var exps = "-900-(60-(7-2)*2)*2-5+5";
            double v = -900 - (60 - (7 - 2) * 2) * 2 - 5 + 5;
            HExpression hExpression = HExpression.Parse(exps);
            if (hExpression == null)
            {
                Console.WriteLine("Error");
                return;
            }
            var d = hExpression.Execute(null);
            if (d == v)
            {
                Console.WriteLine("RIGHT");
                Console.WriteLine("\a");
            }
            else
            {
                Console.WriteLine("right={0} != {1}", v, d);
                Console.WriteLine("WONG");
            }
        }
    }
}
