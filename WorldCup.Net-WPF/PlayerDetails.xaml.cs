using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCup.Net;
namespace WorldCup.Net_WPF
{
    /// <summary>
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Window
    {
        public long? ShirtNumber { get; set; }
        public string PlayerName { get; set; }
        public string Captain { get; set; }
        public string Position { get; set; }
        public int GoalsScoredinMatch { get; set; }
        public int YellowCards { get; set; }
        public PlayerDetails(PlayerDisplay.PlayerDetailsData pd,TeamMatchesDataPlayer Player )
        {
            ShirtNumber = pd.ShirtNumber;
            PlayerName = pd.PlayerName;
            Captain = pd.Captain;
            Position = pd.Position;
            GoalsScoredinMatch = pd.GoalsScoredinMatch;
            YellowCards = pd.YellowCards;
            InitializeComponent();
            MainGrid.DataContext = this;
            using (var ms = new MemoryStream())
            {
                if (Player.PlayerImage != null)
                {
                    Player.PlayerImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Position = 0;

                    var bi = new BitmapImage();
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.StreamSource = ms;
                    bi.EndInit();
                    PlayerImage.ImageSource = bi;
                }
                else
                {
                    PlayerImage.ImageSource = new BitmapImage(new Uri("../../../PlayerImages/defaultplayer.png", UriKind.Relative));
                }

            }
        }
    }
}
