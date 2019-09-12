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
using System.Windows.Shapes;
using WorldCup.Net;

namespace WorldCup.Net_WPF
{
    /// <summary>
    /// Interaction logic for MatchupDetails.xaml
    /// </summary>
    public partial class MatchupDetails : Window
    {
        public TeamFifaData Favorite { get; set; }
        public TeamFifaData Opposition { get; set; }
        public MatchupDetails(TeamFifaData favorite,TeamFifaData opposition)
        {
            Favorite = favorite;
            Opposition = opposition;
            InitializeComponent();
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TeamDataStack.DataContext = Favorite;
        }

        private void OppositionTeamDataStack_Loaded(object sender, RoutedEventArgs e)
        {
            OppositionTeamDataStack.DataContext = Opposition;
        }
    }
}
