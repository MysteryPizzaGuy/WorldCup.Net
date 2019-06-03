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
        public static Dictionary<string, List<string>> FavoritePlayers { get; set; } = new Dictionary<string, List<string>>();


        static public void SaveConfigurationToText()
        {

            string[] tosave = { $"LANG={AppLanguage}",
                                $"FTC={FavoriteTeamCode}",
                                };
            foreach (KeyValuePair<string, List<string>> entry in FavoritePlayers)
            {
                var savelist = tosave.ToList();
                StringBuilder ss = new StringBuilder();
                foreach (var item in entry.Value)
                {
                    ss.Append(item);
                    ss.Append(';');
                }
                savelist.Add($"FP_{entry.Key}={ss.ToString()}");
                tosave = savelist.ToArray();

                
            }
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
                        var fifacode = GetPropFromConfLine(line).Substring(GetPropFromConfLine(line).IndexOf('_') + 1);
                        FavoritePlayers[fifacode] = new List<string>();
                        foreach (var item in GetValueFromConfLine(line).Split(';'))
                        {
                            FavoritePlayers[fifacode].Add(item);
                        }
                        break;
                }
            }

            
        }
        static string GetValueFromConfLine(string confLine)=> confLine.Substring(confLine.IndexOf('=') + 1);
        static string GetPropFromConfLine(string confLine) => confLine.Substring(0, confLine.IndexOf('='));
    }
}
