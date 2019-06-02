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
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Net.Configuration.SaveConfigurationToText();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string fifacode = (cboFavoriteTeam.SelectedItem as TeamFifaData).FifaCode;
            var teamdatafetched = (await repo.FetchTeamMatchesDataAsyc(fifacode)).First();
            Net.TeamStatistics teamstatistics;
            if (teamdatafetched.HomeTeam.Code == fifacode)
            {
                teamstatistics = teamdatafetched.HomeTeamStatistics;
            }
            else
            {
                teamstatistics = teamdatafetched.AwayTeamStatistics;
            }
            var playerlist = teamstatistics.StartingEleven.Union(teamstatistics.Substitutes).ToList();
            foreach (var player in playerlist)
            {
                var control = new PlayerControl();
                control.SetPlayerName(player.Name);
                control.SetPlayerNumber(player.ShirtNumber);
                control.SetPlayerPosition(player.Position);
                control.SetPlayerCaptain(player.Captain);
                pnlPlayers.Controls.Add(control);
            }
        }

        private async void cboFavoriteTeam_DropDownAsync(object sender, EventArgs e)
        {
            (sender as ComboBox).DataSource = await repo.FetchTeamsAsync();
        }
    }
}
