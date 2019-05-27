using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Net
{
    public static class Configuration
    {
        public enum Language { English, Croatian }
        public static Language AppLanguage { get; set; }
        public static string FavoriteTeamCode { get; set; }
        private const string FILEPATH = "settings.txt";



        static public void SaveConfigurationToText()
        {

            string[] tosave = { $"LANG={AppLanguage}",
                                $"FTC={FavoriteTeamCode}" };
            File.WriteAllLines(FILEPATH, tosave);

        }
        static public bool Exists()
        {
            return File.Exists(FILEPATH);
        }
        static public void ReadConfigurationFromText()
        {
            string[] confLines = File.ReadAllLines(FILEPATH);

            foreach(string line in confLines)
            {
                switch (GetPropFromConfLine(line))
                {
                    case "LANG":
                        if (GetValueFromConfLine(line) == "English")
                        {
                            AppLanguage = Language.Croatian;
                        }
                        else {
                            AppLanguage = Language.English;
                        }
                        break;
                    case "FTC":
                        FavoriteTeamCode = GetValueFromConfLine(line);
                        break;
                    default:
                        break;
                }
            }

            
        }
        static string GetValueFromConfLine(string confLine)=> confLine.Substring(confLine.IndexOf('=') + 1);
        static string GetPropFromConfLine(string confLine) => confLine.Substring(0, confLine.IndexOf('='));
    }
}
