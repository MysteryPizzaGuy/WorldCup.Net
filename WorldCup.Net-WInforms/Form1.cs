using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.Net;
namespace WorldCup.Net_WInforms
{
    public partial class Form1 : Form
    {
        ITeamRepo repo;
        public IList<PlayerControl> SelectedPlayers = new List<PlayerControl>();
        public Form1()
        {
            InitializeComponent();
            repo = RepoFactory.GenerateRepo();
            SetupPanelsDragAndDrop(new List<FlowLayoutPanel> { pnlPlayers, pnlFavoritePlayers });




        }
        int newSortColumn;
        ListSortDirection newColumnDirection = ListSortDirection.Ascending;

        private void SetupPanelsDragAndDrop(List<FlowLayoutPanel> list)
        {
            foreach (var pnl in list)
            {
                pnl.AllowDrop = true;

                pnl.DragEnter += PlayerPanels_DragEnter;

                pnl.DragDrop += PlayerPanels_DragDrop;

            }
        }

        private void PlayerPanels_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }
        void PlayerPanels_DragDrop(object sender, DragEventArgs e)
        {
            var pnl = (sender as Panel);
            if (pnl == pnlPlayers)
            {
                PlayerSetFavorite(false, (e.Data.GetData(typeof(PlayerControl)) as PlayerControl).Player);
            }
            else
            {
                PlayerSetFavorite(true, (e.Data.GetData(typeof(PlayerControl)) as PlayerControl).Player);

            }
        }
        public void PlayerSetFavorite(bool isfavorite, TeamMatchesDataPlayer player)
        {
            player.isFavorite = isfavorite;
            if (isfavorite && pnlFavoritePlayers.Controls.Count <= 2)
            {
                foreach (PlayerControl ctrl in pnlPlayers.Controls)
                {
                    if (ctrl.Player.Name == player.Name)
                    {
                        ctrl.Player = player;
                        ctrl.Parent = pnlFavoritePlayers;

                    }

                }
            }
            else
            {
                foreach (PlayerControl ctrl in pnlFavoritePlayers.Controls)
                {
                    if (ctrl.Player.Name == player.Name)
                    {
                        ctrl.Player = player;
                        ctrl.Parent = pnlPlayers;

                    }

                }
            }
        }


        private void Form1_FormClosingAsync(object sender, FormClosingEventArgs e)
        {
            var w = (Form)sender;
            e.Cancel = true;
            FillFavoritePlayersFromCurrentState();
            //Fill Favorite Team from Current State
            if (cboFavoriteTeam.SelectedItem != null)
            {
                Configuration.FavoriteTeamCode = (cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode;
            }
            Net.Configuration.SaveConfigurationToText();
            e.Cancel = false;
        }

        private void FillFavoritePlayersFromCurrentState()
        {
            if (repo.TeamMatchesData != null)
            {
                foreach (var FifaCode in repo.TeamMatchesData.Keys)
                {
                    var matchdata = repo.TeamMatchesData[FifaCode].First();
                    TeamStatistics teamstatistics;
                    if (matchdata.HomeTeam.Code == FifaCode)
                    {
                        teamstatistics = matchdata.HomeTeamStatistics;
                    }
                    else
                    {
                        teamstatistics = matchdata.AwayTeamStatistics;
                    }
                    foreach (var player in teamstatistics.StartingEleven.Union(teamstatistics.Substitutes).ToList())
                    {
                        if (player.isFavorite)
                        {
                            if (!Configuration.FavoritePlayers.ContainsKey(FifaCode))
                            {
                                Configuration.FavoritePlayers[FifaCode] = new List<string>();
                            }

                            if (!Configuration.FavoritePlayers[FifaCode].Contains(player.Name))
                            {
                                Configuration.FavoritePlayers[FifaCode].Add(player.Name);
                            }
                        }
                        else
                        {
                            if (!Configuration.FavoritePlayers.ContainsKey(FifaCode))
                            {
                                Configuration.FavoritePlayers[FifaCode] = new List<string>();
                            }
                            if (Configuration.FavoritePlayers[FifaCode].Contains(player.Name))
                            {
                                Configuration.FavoritePlayers[FifaCode].Remove(player.Name);
                            }
                        }
                    }
                }
            }
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            foreach (PlayerControl control in pnlPlayers.Controls)
            {
                control.MouseDown -= PlayerControl_MouseDown;
                control.Dispose();

            }
            foreach (PlayerControl control in pnlFavoritePlayers.Controls)
            {
                control.MouseDown -= PlayerControl_MouseDown;
                control.Dispose();

            }
            pnlPlayers.Controls.Clear();
            pnlFavoritePlayers.Controls.Clear();
            if ((cboFavoriteTeam.SelectedIndex != -1))
            {

                var playerlist = await ParsePlayersFromRepoAsync((cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode);
                playerlist.ForEach(x => LoadPlayerIntoPanel(x, pnlPlayers));
            }
        }

        private async void cboFavoriteTeam_DropDownAsync(object sender, EventArgs e)
        {
            if ((sender as ComboBox).DataSource == null)
            {
                try
                {
                    (sender as ComboBox).DataSource = await repo.FetchTeamsAsync();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }


        private void LoadPlayerIntoPanel(TeamMatchesDataPlayer player, FlowLayoutPanel pnl)
        {
            var control = new PlayerControl(player);
            control.Width = 350;
            control.MouseDown += PlayerControl_MouseDown;
            pnl.Controls.Add(control);
            PlayerSetFavorite(player.isFavorite, player);

        }

        private void PlayerControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Form.ModifierKeys == Keys.Control)
            {
                var ctrl = sender as PlayerControl;
                if (!SelectedPlayers.Contains(ctrl) && SelectedPlayers.Count <= 2)
                {
                    SelectedPlayers.Add(ctrl);
                    ctrl.BackColor = Color.Aqua;
                }
                else
                {
                    SelectedPlayers.Remove(ctrl);
                    ctrl.BackColor = SystemColors.Control;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                var ctrl = sender as PlayerControl;
                if (SelectedPlayers.Count != 0)
                {
                    foreach (var selctr in SelectedPlayers)
                    {
                        selctr.DoDragDrop(selctr, DragDropEffects.Move);
                    }
                }
                else
                {
                    ctrl.DoDragDrop(ctrl, DragDropEffects.Move);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                (sender as PlayerControl).ContextMenuStrip.Show((sender as PlayerControl), new Point(e.X, e.Y));
            }
        }

        private async Task<List<TeamMatchesDataPlayer>> ParsePlayersFromRepoAsync(string teamfifacode)
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

        private void pnlFavoritePlayers_ControlAdded(object sender, ControlEventArgs e)
        {
            if ((sender as FlowLayoutPanel).Controls.Count >= 3)
            {
                (sender as FlowLayoutPanel).AllowDrop = false;
            }

        }

        private void pnlFavoritePlayers_ControlRemoved(object sender, ControlEventArgs e)
        {
            if ((sender as FlowLayoutPanel).Controls.Count <= 2)
            {
                (sender as FlowLayoutPanel).AllowDrop = true;
            }
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                cboFavoriteTeam.DataSource = await repo.FetchTeamsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (Configuration.FavoriteTeamCode != null && Configuration.FavoriteTeamCode != String.Empty)
            {
                //try
                //{

                //}
                //catch (Exception ex)
                //{

                //    MessageBox.Show(ex.ToString());
                //}
                cboFavoriteTeam.SelectedIndex = cboFavoriteTeam.Items.IndexOf((cboFavoriteTeam.DataSource as IList<TeamFifaData>).Where((x) => x.FifaCode == Configuration.FavoriteTeamCode).Single());
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            pnlPlayers.Visible = false;
            pnlFavoritePlayers.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            pnlPlayers.Visible = true;
            pnlFavoritePlayers.Visible = true;
        }

        public class PlayerForRankings
        {
            public Image Image { get; set; }
            public string Name { get; set; } = "Name not Added";
            public int Appearances { get; set; } = 0;
            public int YellowCards { get; set; } = 0;
            public int GoalsScored { get; set; } = 0;
        }
        //Napraviti rang listu broja posjetitelja za određenu utakmicu - potrebno prikazati lokaciju, broj posjetitelja, naziv
        //domaćina(“home_team”) i naziv gosta(“away_team”).
        public class MatchForRankings
        {
            public string Location { get; set; }
            public long? Visitors { get; set; }
            public string Home_team { get; set; }
            public string Away_team { get; set; }
        }
        private void FetchTeamofPlayersForRankings(TeamMatchesData MatchesData, string TeamCode, IDictionary<string, PlayerForRankings> PlayersForRankings)
        {
            IEnumerable<TeamMatchesDataPlayer> players;
            TeamEvent[] events;

            if (MatchesData.HomeTeam.Code == TeamCode)
            {
                players = MatchesData.HomeTeamStatistics.StartingEleven.Union(MatchesData.HomeTeamStatistics.Substitutes);

                foreach (var player in players)
                {
                    if (PlayersForRankings.ContainsKey(player.Name))
                    {
                        PlayersForRankings[player.Name].Appearances++;
                    }
                    else
                    {
                        PlayersForRankings[player.Name] = new PlayerForRankings()
                        {
                            Name = player.Name,
                            Image = player.PlayerImage
                        };
                        PlayersForRankings[player.Name].Appearances++;
                    }

                }
                events = MatchesData.HomeTeamEvents;
            }
            else
            {
                players = MatchesData.AwayTeamStatistics.StartingEleven.Union(MatchesData.AwayTeamStatistics.Substitutes);
                foreach (var player in players)
                {
                    if (PlayersForRankings.ContainsKey(player.Name))
                    {
                        PlayersForRankings[player.Name].Appearances++;
                    }
                    else
                    {
                        PlayersForRankings[player.Name] = new PlayerForRankings()
                        {
                            Name = player.Name,
                            Image = player.PlayerImage
                        };
                        PlayersForRankings[player.Name].Appearances++;
                    }

                }
                events = MatchesData.AwayTeamEvents;
            }
            foreach (var playerevent in events)
            {
                switch (playerevent.TypeOfEvent)
                {
                    case "yellow-card":
                        PlayersForRankings[playerevent.Player].YellowCards++;
                        break;
                    case "goal":
                        PlayersForRankings[playerevent.Player].GoalsScored++;
                        break;
                    default:
                        break;
                }
            }

        }

        private IList<MatchForRankings> FetchMatchesofTeamForRankings(IList<TeamMatchesData> MatchesData, string TeamCode)
        {
            IList<MatchForRankings> MatchesForRankings = new List<MatchForRankings>();
            foreach (var Match in MatchesData)
            {
                MatchesForRankings.Add(new MatchForRankings()
                {
                    Location = Match.Location,
                    Visitors = Match.Attendance,
                    Home_team = Match.HomeTeamCountry,
                    Away_team = Match.AwayTeamCountry

                }
                );
            }
            return MatchesForRankings;
        }

        private async void dgvPlayerRankings_VisibleChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.Visible)
            {
                if ((cboFavoriteTeam.SelectedIndex != -1))
                {
                    //broj zabijenih golova, broj žutih kartona – potrebno ispisati puno ime
                    //igrača i prikazati igračevu sliku uz broj pojavljivanja
                    //var playerlist = await ParsePlayersFromRepoAsync((cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode);
                    //BindingList<TeamMatchesDataPlayer> tobind = new BindingList<TeamMatchesDataPlayer>(playerlist);
                    //dgv.DataSource = tobind;
                    //dgv.Columns[1].Visible = false;
                    //dgv.Columns[2].Visible = false;

                    var TeamMatchData = await repo.FetchTeamMatchesDataAsyc((cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode);
                    IDictionary<string, PlayerForRankings> playersrankinglist = new Dictionary<string, PlayerForRankings>();
                    TeamMatchData.ToList().ForEach((x) => FetchTeamofPlayersForRankings(x, (cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode, playersrankinglist));
                    dgv.DataSource = new MySortableBindingList<PlayerForRankings>(playersrankinglist.Values.ToList());
                    dgv.ReadOnly = true;
                    dgv.RowTemplate.Height = 48;
                    dgv.Columns[0].Width = 48;
                    (dgv.Columns[0] as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    if (Configuration.AppLanguage == Configuration.Language.Croatian)
                    {
                            dgv.Columns[0].HeaderText = "Slika";
                            dgv.Columns[1].HeaderText = "Ime";
                            dgv.Columns[2].HeaderText = "Pojavljivanja";
                            dgv.Columns[3].HeaderText = "Zuti Kartoni";
                            dgv.Columns[4].HeaderText = "Zabijeni Golovi";
                            
                    }

                }
            }
        }

        private async void dgvMatchRankings_VisibleChangedAsync(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.Visible)
            {
                if (cboFavoriteTeam.SelectedIndex != -1)
                {
                    var TeamMatchData = await repo.FetchTeamMatchesDataAsyc((cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode);
                    var data = FetchMatchesofTeamForRankings(TeamMatchData, (cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode);
                    dgv.DataSource = new MySortableBindingList<MatchForRankings>(data);
                    dgv.ReadOnly = true;
                    if (Configuration.AppLanguage == Configuration.Language.Croatian)
                    {
                        dgv.Columns[0].HeaderText = "Lokacija";
                        dgv.Columns[1].HeaderText = "Posjetitelji";
                        dgv.Columns[2].HeaderText = "Domacini";
                        dgv.Columns[3].HeaderText = "Gosti";
                    }
                }
            }
        }
        Bitmap bmp;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataGridView grid;
            if (tabPlayerRankings.Visible==true)
            {
                grid = dgvPlayerRankings;
            }
            else
            {
                grid = dgvMatchRankings;
            }
            int height = grid.Height;
            int tcheight = tcRankings.Height;
            tcRankings.Height= (grid.RowCount * grid.RowTemplate.Height) * 2+200; 
            grid.Height = (grid.RowCount * grid.RowTemplate.Height)*2;
            bmp = new Bitmap(grid.Width, grid.Height);
            grid.DrawToBitmap(bmp, new Rectangle(0, 0, grid.Width, grid.Height));
            grid.Height = height;
            tcRankings.Height = tcheight;
            printPreviewDialog1.ShowDialog();
        }

        private void PrintPlayerRankings_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}