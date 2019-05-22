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
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLoad_ClickAsync(object sender, EventArgs e)
        {
            ITeamRepo repo = RepoFactory.GenerateRepo();
            repo.Target = "http://worldcup.sfg.io/teams/results";
            var ListofTeams = await repo.FetchTeamsAsync();
            ListofTeams.ToList().ForEach(x => TeamList.Items.Add(x.Country));
        }

        private void txtMaster_TextChanged(object sender, EventArgs e)
        {
            lblClone.Text = txtMaster.Text;
        }
    }
}
