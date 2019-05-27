using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup.Net_WInforms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetCompatibleTextRenderingDefault(false);
            switch (MessageBox.Show(
                   "Press 'Yes' for English, 'No' for Croatian.",
                   "Language Option", MessageBoxButtons.YesNo))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        System.Globalization.CultureInfo.CreateSpecificCulture("");
                    break;
                case System.Windows.Forms.DialogResult.No:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        System.Globalization.CultureInfo.CreateSpecificCulture("hr");
                    break;
            }
            Application.Run(new Form1());
        }
    }
}
