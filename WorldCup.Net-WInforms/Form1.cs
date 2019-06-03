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
            pnlPlayers.AllowDrop = true;
            pnlFavoritePlayers.AllowDrop = true;
            pnlPlayers.DragEnter += PlayerPanels_DragEnter;
            pnlFavoritePlayers.DragEnter += PlayerPanels_DragEnter;
            pnlPlayers.DragDrop+= PlayerPanels_DragDrop;
            pnlFavoritePlayers.DragDrop += PlayerPanels_DragDrop;



        }
        private void PlayerPanels_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }
        void PlayerPanels_DragDrop(object sender, DragEventArgs e)
        {
            ((PlayerControl)e.Data.GetData(typeof(PlayerControl))).Parent = (Panel)sender;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Net.Configuration.SaveConfigurationToText();
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
            var control = new PlayerControl();
            control.SetPlayerName(player.Name);
            control.SetPlayerNumber(player.ShirtNumber);
            control.SetPlayerPosition(player.Position);
            control.SetPlayerCaptain(player.Captain);
            control.Width = 350;
            control.MouseDown += PlayerControl_MouseDown;
            pnl.Controls.Add(control);
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


      
    }
}
