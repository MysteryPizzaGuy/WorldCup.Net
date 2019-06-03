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
        public Form1()
        {
            InitializeComponent();
            repo= RepoFactory.GenerateRepo();
            SetupPanelsDragAndDrop(new List<FlowLayoutPanel> { pnlPlayers, pnlFavoritePlayers });
            



        }

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
        void PlayerSetFavorite(bool isfavorite, TeamMatchesDataPlayer player)
        {
            player.isFavorite = isfavorite;
            if (isfavorite)
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


        private async void Form1_FormClosingAsync(object sender, FormClosingEventArgs e)
        {
            var w = (Form)sender;
            e.Cancel = true;
            if (repo.TeamMatchesData != null) {
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
                            Configuration.FavoritePlayers[FifaCode].Add(player.Name);
                        }
                    }
                }
            }
            Net.Configuration.SaveConfigurationToText();
            w.Close();
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
            if ((cboFavoriteTeam.SelectedIndex!=-1))
            {

                var playerlist = await ParsePlayersFromRepoAsync((cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode);
                playerlist.ForEach(x => LoadPlayerIntoPanel(x, pnlPlayers)); 
            }
        }

        private async void cboFavoriteTeam_DropDownAsync(object sender, EventArgs e)
        {
            (sender as ComboBox).DataSource = await repo.FetchTeamsAsync();
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
            var ctrl = sender as PlayerControl;
            ctrl.DoDragDrop(ctrl, DragDropEffects.Move);
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
            if ((sender as FlowLayoutPanel).Controls.Count >=3)
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
    }
}
