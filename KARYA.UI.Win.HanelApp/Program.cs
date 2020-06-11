using KARYA.HanelApp.UI.Win.Forms.General;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KARYA.HanelApp.UI.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// //dsflsdiflsdlf
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");

            Application.Run(new Main());
        }
    }
}
