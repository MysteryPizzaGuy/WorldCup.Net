using System;
using System.Collections.Generic;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace WorldCup.Net_WPF
{
    /// <summary>
    /// Interaction logic for PlayerOnField.xaml
    /// </summary>
    public partial class PlayerOnField : UserControl
    {
        public TeamMatchesDataPlayer Player { get; set; }
        public PlayerOnField(TeamMatchesDataPlayer player)
        {
            Player = player;
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GridContainer.DataContext = Player;
            BitmapImage bitmap = new BitmapImage();

            using (var ms = new MemoryStream())
            {
                Player.PlayerImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                var bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = ms;
                bi.EndInit();
                PlayerImage.Source = bi;
            }

        }
    }
}
