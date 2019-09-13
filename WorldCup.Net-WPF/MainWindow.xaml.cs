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

namespace WorldCup.Net_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ITeamRepo repo;
        TeamFifaData SelectedFavoriteTeam;
        public MainWindow()
        {
            //if (WorldCup.Net.Configuration.Exists())
            //{
            //    WorldCup.Net.Configuration.ReadConfigurationFromText(false);
            //    if (Net.Configuration.AppLanguage==Configuration.Language.Croatian)
            //    {
            //        TranslationSource.Instance.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("hr");
            //    }
            //    else
            //    {
            //        TranslationSource.Instance.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("");

            //    }


            //}
            //else
            //{

            //}
            repo = RepoFactory.GenerateRepo();
            
            InitializeComponent();
        }

        private async Task<List<TeamMatchesDataPlayer>> ParsePlayersFromRepoAsync(string teamfifacode)
        {
            try
            {
                var teamdatafetched = (await repo.FetchTeamMatchesDataAsyc(teamfifacode)).First();
                Net.TeamStatistics teamstatistics;
                if (teamdatafetched.HomeTeam.Code == teamfifacode)
                {
                    teamstatistics = teamdatafetched.HomeTeamStatistics;
                }
                else
                {
                    teamstatistics = teamdatafetched.AwayTeamStatistics;
                }
                return teamstatistics.StartingEleven.Union(teamstatistics.Substitutes).ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                throw;
            }
        }


        private async void CboFavoriteTeam_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var Teams = await repo.FetchTeamsAsync();
                cboFavoriteTeam.ItemsSource = Teams;
                if (Configuration.FavoriteTeamCode != String.Empty && Configuration.FavoriteTeamCode !=null && Configuration.FavoriteTeamCode!= "")
                {
                    SelectedFavoriteTeam = Teams.Where(x => x.FifaCode == Configuration.FavoriteTeamCode).First();
                    cboFavoriteTeam.SelectedItem = SelectedFavoriteTeam;
                    LoadOppositiontoFavorite();
                }
                else
                {
                    cboFavoriteTeam.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void LoadOppositiontoFavorite()
        {

            try
            {
                var Teams = await repo.FetchTeamsAsync();
                var Teammatches = await repo.FetchTeamMatchesDataAsyc(SelectedFavoriteTeam.FifaCode);
                IList<TeamFifaData> Opposition = new List<TeamFifaData>();
                foreach (var Match in Teammatches)
                {
                    if (Match.AwayTeam.Code != SelectedFavoriteTeam.FifaCode)
                    {
                        Opposition.Add(Teams.Where(x => Match.AwayTeam.Code == x.FifaCode).First());
                    }
                    else
                    {
                        Opposition.Add(Teams.Where(x => Match.HomeTeam.Code == x.FifaCode).First());
                    }
                }
                cboOppositeTeam.ItemsSource = Opposition;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void CboFavoriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedFavoriteTeam = cboFavoriteTeam.SelectedItem as TeamFifaData;
            Configuration.FavoriteTeamCode = (cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode;
            LoadOppositiontoFavorite();
            SoccerCanvas.Children.Clear();
        }

        private void BtnMatchupDetails_Click(object sender, RoutedEventArgs e)
        {
            MatchupDetails md = new MatchupDetails(cboFavoriteTeam.SelectedItem as TeamFifaData, cboOppositeTeam.SelectedItem as TeamFifaData);
            md.Show();
        }



        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            BackgroundImage.ImageSource= new BitmapImage(new Uri("../../../PlayerImages/Soccer_Field.png", UriKind.Relative));
        }
        public double ImageWidth { get; set; }
        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           
        }

        private async void CboOppositeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cboOppositeTeam.SelectedIndex == -1 ||cboFavoriteTeam.SelectedIndex ==-1)
            {
                return;
            }
            SoccerCanvas.Children.Clear();

            string favoritecode = (cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode;
            string oppositioncode = (cboOppositeTeam.SelectedItem as TeamFifaData).FifaCode;
            bool home = false;
            var MatchesData = await repo.FetchTeamMatchesDataAsyc(favoritecode);
            TeamMatchesData MatchData = null;
            TeamStatistics fav = new TeamStatistics();
            TeamStatistics opp=new TeamStatistics();
            foreach (var Match in MatchesData)
            {
                if (Match.AwayTeam.Code == oppositioncode)
                {
                    home = true;
                    opp = Match.AwayTeamStatistics;
                    fav = Match.HomeTeamStatistics;
                    MatchData = Match;
                }
                else if (Match.HomeTeam.Code == oppositioncode)
                {
                    home = false;
                    opp = Match.HomeTeamStatistics;
                    fav = Match.AwayTeamStatistics;
                    MatchData = Match;

                }
            }
            int[] sequence = new int[] { 2, 3, 1, 4, 0, 0, 0};
            Dictionary<string, int[]> dicseq = new Dictionary<string, int[]>();

            int g = 0;
            int d = 0;
            int m = 0;
            int f = 0;

            foreach (var player in fav.StartingEleven)
            {
                
                PlayerDisplay pd = new PlayerDisplay(player,MatchData);
                SoccerCanvas.Children.Add(pd);
                switch (player.Position)
                {
                    case "Goalie":
                        Grid.SetRow(pd, sequence[g]);
                        Grid.SetColumn(pd, 0);
                        g++;
                        break;
                    case "Defender":
                        Grid.SetRow(pd, sequence[d]);
                        Grid.SetColumn(pd, 1);
                        d++;
                        break;
                    case "Midfield":
                        Grid.SetRow(pd, sequence[m]);
                        Grid.SetColumn(pd, 2);
                        m++;
                        break;
                    case "Forward":
                        Grid.SetRow(pd, sequence[f]);
                        Grid.SetColumn(pd, 3);
                        f++;
                        break;
                    default:
                        break;
                }

            }
            g = 0;
            d = 0;
            m = 0;
            f = 0;
            foreach (var player in opp.StartingEleven)
            {
                PlayerDisplay pd = new PlayerDisplay(player, MatchData);
                SoccerCanvas.Children.Add(pd);
                switch (player.Position)
                {
                    case "Goalie":
                        Grid.SetRow(pd, sequence[g]);
                        Grid.SetColumn(pd, 7);
                        g++;
                        break;
                    case "Defender":
                        Grid.SetRow(pd, sequence[d]);
                        Grid.SetColumn(pd, 6);
                        d++;
                        break;
                    case "Midfield":
                        Grid.SetRow(pd, sequence[m]);
                        Grid.SetColumn(pd, 5);
                        m++;
                        break;
                    case "Forward":
                        Grid.SetRow(pd, sequence[f]);
                        Grid.SetColumn(pd, 4);
                        f++;
                        break;
                    default:
                        break;
                }
            }

        }

        private void MainWindowFOrm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNoCancel);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Configuration.SaveConfigurationToText(false);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow s = new SettingsWindow();
            s.Show();
        }
    }
}
