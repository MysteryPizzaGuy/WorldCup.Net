using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            if (WorldCup.Net.Configuration.Exists())
            {
                WorldCup.Net.Configuration.ReadConfigurationFromText(true);
                LanguageAssign(Net.Configuration.AppLanguage);


            }
            else
            {
                LanguageInput();
            }

            Application.Run(new Form1());
        }
        static void LanguageInput()
        {
            switch (MessageBox.Show(
                          "Press 'Yes' for English, 'No' for Croatian.",
                          "Language Option", MessageBoxButtons.YesNo))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        System.Globalization.CultureInfo.CreateSpecificCulture("");
                    WorldCup.Net.Configuration.AppLanguage = WorldCup.Net.Configuration.Language.English;


                    break;
                case System.Windows.Forms.DialogResult.No:
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        System.Globalization.CultureInfo.CreateSpecificCulture("hr");
                    WorldCup.Net.Configuration.AppLanguage = WorldCup.Net.Configuration.Language.Croatian;

                    break;
            }
        }
        static void LanguageAssign(WorldCup.Net.Configuration.Language lang)
        {
            if (lang==WorldCup.Net.Configuration.Language.Croatian)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                        System.Globalization.CultureInfo.CreateSpecificCulture("hr");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                       System.Globalization.CultureInfo.CreateSpecificCulture("");
            }
        }
    }
}
