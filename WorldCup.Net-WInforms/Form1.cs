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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
