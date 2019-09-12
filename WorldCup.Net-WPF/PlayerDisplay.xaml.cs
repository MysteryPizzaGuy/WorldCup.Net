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
        public PlayerDisplay(TeamMatchesDataPlayer player)
        {
            Player = player;
            InitializeComponent();
            DataContainer.DataContext = Player;
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

        private void DataContainer_Loaded(object sender, RoutedEventArgs e)
        {
           

        }
    }
}
