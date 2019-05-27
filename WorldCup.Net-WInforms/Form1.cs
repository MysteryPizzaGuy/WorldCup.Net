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

        private async void btnLoad_ClickAsync(object sender, EventArgs e)
        {
            var ListofTeams = await repo.FetchTeamsAsync();
            TeamList.DataSource = ListofTeams;

        }



        private async void btnGetInfo_ClickAsync(object sender, EventArgs e)
        {
            string FifaCode = (TeamList.SelectedItem as TeamFifaData).FifaCode;
            var MatchesData = await repo.FetchTeamMatchesDataAsyc(FifaCode);
            MatchesData.ToList().ForEach(x => lstTeamMatchesData.Items.Add(x));
        }
    }
}
