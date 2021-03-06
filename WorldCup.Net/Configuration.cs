﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace WorldCup.Net
{
    public static class Configuration
    {
        public enum Language { English, Croatian }
        public static Language AppLanguage { get; set; }
        public static string FavoriteTeamCode { get; set; }
        private const string FILEPATH = "..\\..\\..\\settings.txt";
        private const string FILEPATHFAV = "..\\..\\..\\settingsfav.txt";
        //public static string ImageResources="WorldCup.Net.Resources";
        public static string ResourcesPath= "..\\..\\..\\PlayerImages\\";
        public static bool Fullscreen = false;
        public static Image DefaultPlayerImage = new Bitmap((ResourcesPath + "defaultplayer.png"));

        public static Dictionary<string, List<string>> FavoritePlayers { get; set; } = new Dictionary<string, List<string>>();

        static public void AddImageToResources(TeamMatchesDataPlayer player)
        {
            if (!Directory.Exists(ResourcesPath))
            {
                Directory.CreateDirectory(ResourcesPath);
            }
            //if (File.Exists((ResourcesPath + player.Name + ".bmp")))
            //{
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream((ResourcesPath+player.Name+".png"), FileMode.Create, FileAccess.ReadWrite))
                    {
                        player.PlayerImage.Save(memory, ImageFormat.Png);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            //}
            //else
            //{
            //    player.PlayerImage.Save((ResourcesPath + player.Name + ".bmp"));
            //}
        }

        static public Image LoadImageFromResources(TeamMatchesDataPlayer player)
        {
            if (!File.Exists(ResourcesPath + player.Name + ".png"))
            {
                return DefaultPlayerImage;
            }
            else
            {
                return new Bitmap(ResourcesPath + player.Name + ".png");
            }
        }

        static public void SaveConfigurationToText(bool savefavoriteplayers)
        {
            string[] tosave = { $"LANG={AppLanguage}",
                                $"FTC={FavoriteTeamCode}",
                                $"FULL={Fullscreen}",
                                };
            if (savefavoriteplayers)
            {
                foreach (KeyValuePair<string, List<string>> entry in FavoritePlayers)
                {
                    var savelist = new List<string>();
                    StringBuilder ss = new StringBuilder();
                    foreach (var item in entry.Value)
                    {
                        ss.Append(item);
                        ss.Append(';');
                    }
                    savelist.Add($"FP_{entry.Key}={ss.ToString()}");
                    var savearray = savelist.ToArray();
                    File.WriteAllLines(FILEPATHFAV, savearray);


                }
            }
            File.WriteAllLines(FILEPATH, tosave);

        }
        static public bool Exists()
        {
            return File.Exists(FILEPATH);
        }
        static public void ReadConfigurationFromText(bool readfavorites)
        {
            if (File.Exists(FILEPATH))
            {
                string[] confLines = File.ReadAllLines(FILEPATH);


                foreach (string line in confLines)
                {
                    switch (GetPropFromConfLine(line))
                    {
                        case "LANG":
                            if (GetValueFromConfLine(line) == "Croatian")
                            {
                                AppLanguage = Language.Croatian;
                            }
                            else
                            {
                                AppLanguage = Language.English;
                            }
                            break;
                        case "FTC":
                            FavoriteTeamCode = GetValueFromConfLine(line);
                            break;
                        case "FULL":
                            Fullscreen = GetValueFromConfLine(line) == "1" ? true : false;
                            break;
                        default:
                            break;
                    }
                } 
            }
            if (readfavorites && File.Exists(FILEPATHFAV))
            {

                string[] favLines = File.ReadAllLines(FILEPATHFAV);
                foreach (var line in favLines)
                {
                    var fifacode = GetPropFromConfLine(line).Substring(GetPropFromConfLine(line).IndexOf('_') + 1);
                    FavoritePlayers[fifacode] = new List<string>();
                    foreach (var item in GetValueFromConfLine(line).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
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
