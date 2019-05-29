using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup.Net_WInforms
{
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            while (label1.Width < System.Windows.Forms.TextRenderer.MeasureText(label1.Text,
                    new Font(label1.Font.FontFamily, label1.Font.Size, label1.Font.Style)).Width)
            {
                label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size - 0.5f, label1.Font.Style);
            }
        }
    }
}
