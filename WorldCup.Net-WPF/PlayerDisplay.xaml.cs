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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorldCup.Net;
namespace WorldCup.Net_WPF
{
    /// <summary>
    /// Interaction logic for PlayerDisplay.xaml
    /// </summary>
    public partial class PlayerDisplay : UserControl
    {
        public TeamMatchesDataPlayer Player { get; set; }
        public TeamMatchesData TeamMatchData { get; set; }
        public PlayerDisplay(TeamMatchesDataPlayer player,TeamMatchesData TeamMatchData)
        {
            Player = player;
            this.TeamMatchData = TeamMatchData;
            InitializeComponent();

            DataContainer.DataContext = Player;
            using (var ms = new MemoryStream())
            {
                if (player.PlayerImage != null)
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

        private void DataContainer_Loaded(object sender, RoutedEventArgs e)
        {
           

        }
        public class PlayerDetailsData
        {
            public long? ShirtNumber { get; set; }
            public string PlayerName { get; set; }
            public string Captain { get; set; }
            public string Position { get; set; }
            public int GoalsScoredinMatch { get; set; } = 0;
            public int YellowCards { get; set; } = 0;
        }
        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerDetailsData pd = new PlayerDetailsData();
            bool newBool = Player.Captain ?? false;

            if (newBool)
            {
                pd.Captain = "Captain";
            }
            else
            {
                pd.Captain = "Not Captain";
            }
            pd.PlayerName = Player.Name;
            pd.ShirtNumber = Player.ShirtNumber;
            pd.Position = Player.Position;

            foreach (var ev in TeamMatchData.AwayTeamEvents.Union(TeamMatchData.HomeTeamEvents))
            {
                if (ev.Player==Player.Name)
                {
                    switch (ev.TypeOfEvent)
                    {
                        case "yellow-card":
                            pd.YellowCards++;
                            break;
                        case "goal":
                            pd.GoalsScoredinMatch++;
                            break;
                        case "goal-penalty":
                            pd.GoalsScoredinMatch++;
                            break;
                        default:
                            break;
                    }
                }
            }

            PlayerDetails det = new PlayerDetails(pd,Player);
            det.Show();
            

        }

    }
}
