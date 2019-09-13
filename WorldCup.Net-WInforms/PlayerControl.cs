using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using WorldCup.Net;

namespace WorldCup.Net_WInforms
{
    public partial class PlayerControl : UserControl
    {
        private PictureBox picPlayer;
        private Label lblName;
        private Label lblNumber;
        private Label lblPosition;
        private Label lblCaptain;
        private CheckBox chkCaptain;
        private PictureBox picFavoriteStar;
        private ContextMenuStrip contextMenuStrip1;
        private IContainer components;
        private ToolStripMenuItem MenuItemFavorite;
        private Net.TeamMatchesDataPlayer player;
        public Net.TeamMatchesDataPlayer Player { get => this.player; set
            {
                this.player = value;
                RefreshControlData(player);
            }
        }

        public PlayerControl(Net.TeamMatchesDataPlayer player)
        {
            InitializeComponent();
            this.player = player;
            RefreshControlData(player);
            if (this.player.isFavorite)
            {
                MenuItemFavorite.Text = "Remove From Favorites";
            }
        }

        private void RefreshControlData(Net.TeamMatchesDataPlayer player)
        {
            lblName.Text = player.Name;
            lblNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position;
            bool isCaptain = player.Captain.HasValue ? player.Captain.Value : false;
            chkCaptain.Checked = isCaptain;
            picPlayer.Image = player.PlayerImage;
            if (player.isFavorite ==false)
            {
                picFavoriteStar.Image =Properties.Resources.starempty;
            }
            else
            {
                picFavoriteStar.Image = Properties.Resources.starfilled;

            }

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            while (lblName.Width < System.Windows.Forms.TextRenderer.MeasureText(lblName.Text,
                    new Font(lblName.Font.FontFamily, lblName.Font.Size, lblName.Font.Style)).Width)
            {
                lblName.Font = new Font(lblName.Font.FontFamily, lblName.Font.Size - 0.5f, lblName.Font.Style);
            }
        }

        private void picPlayer_Click(object sender, EventArgs e)
        {
            var diag = new OpenFileDialog();
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picPlayer.Image = Image.FromFile(diag.FileName);
                player.PlayerImage = picPlayer.Image;
                Configuration.AddImageToResources(player);
            }
        }



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            this.lblName = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.chkCaptain = new System.Windows.Forms.CheckBox();
            this.picFavoriteStar = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemFavorite = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picFavoriteStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(61, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            this.lblName.TextChanged += new System.EventHandler(this.label1_TextChanged);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(61, 33);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(35, 13);
            this.lblNumber.TabIndex = 2;
            this.lblNumber.Text = "label2";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(139, 33);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(35, 13);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "label3";
            // 
            // lblCaptain
            // 
            this.lblCaptain.AutoSize = true;
            this.lblCaptain.Location = new System.Drawing.Point(191, 33);
            this.lblCaptain.Name = "lblCaptain";
            this.lblCaptain.Size = new System.Drawing.Size(43, 13);
            this.lblCaptain.TabIndex = 4;
            this.lblCaptain.Text = "Captain";
            // 
            // chkCaptain
            // 
            this.chkCaptain.AutoSize = true;
            this.chkCaptain.Enabled = false;
            this.chkCaptain.Location = new System.Drawing.Point(253, 33);
            this.chkCaptain.Name = "chkCaptain";
            this.chkCaptain.Size = new System.Drawing.Size(15, 14);
            this.chkCaptain.TabIndex = 5;
            this.chkCaptain.UseVisualStyleBackColor = true;
            // 
            // picFavoriteStar
            // 
            this.picFavoriteStar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picFavoriteStar.Image = ((System.Drawing.Image)(resources.GetObject("picFavoriteStar.Image")));
            this.picFavoriteStar.InitialImage = ((System.Drawing.Image)(resources.GetObject("picFavoriteStar.InitialImage")));
            this.picFavoriteStar.Location = new System.Drawing.Point(334, 14);
            this.picFavoriteStar.Name = "picFavoriteStar";
            this.picFavoriteStar.Size = new System.Drawing.Size(32, 32);
            this.picFavoriteStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFavoriteStar.TabIndex = 6;
            this.picFavoriteStar.TabStop = false;
            // 
            // picPlayer
            // 
            this.picPlayer.Image = global::WorldCup.Net_WInforms.Properties.Resources.defaultplayer;
            this.picPlayer.Location = new System.Drawing.Point(3, 4);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(52, 52);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer.TabIndex = 0;
            this.picPlayer.TabStop = false;
            this.picPlayer.Click += new System.EventHandler(this.picPlayer_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFavorite});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 26);
            // 
            // MenuItemFavorite
            // 
            this.MenuItemFavorite.Name = "MenuItemFavorite";
            this.MenuItemFavorite.Size = new System.Drawing.Size(161, 22);
            this.MenuItemFavorite.Text = "Add To Favorites";
            this.MenuItemFavorite.Click += new System.EventHandler(this.MenuItemFavorite_Click);
            // 
            // PlayerControl
            // 
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.picFavoriteStar);
            this.Controls.Add(this.chkCaptain);
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picPlayer);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(369, 60);
            this.ParentChanged += new System.EventHandler(this.PlayerControl_ParentChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picFavoriteStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void MenuItemFavorite_Click(object sender, EventArgs e)
        {
            var parent = this.ParentForm as Form1;
            if (parent.SelectedPlayers.Count == 0)
            {
                parent.PlayerSetFavorite(!player.isFavorite, player);
                if (player.isFavorite == true)
                {
                    MenuItemFavorite.Text = "Remove From Favorites";
                }
                else
                {
                    MenuItemFavorite.Text = "Add to Favorites";

                }
            }
            else
            {
                foreach (var ctrl in parent.SelectedPlayers)
                {
                    parent.PlayerSetFavorite(!ctrl.player.isFavorite, ctrl.player);
                    if (ctrl.player.isFavorite == true)
                    {
                        ctrl.MenuItemFavorite.Text = "Remove From Favorites";
                    }
                    else
                    {
                        ctrl.MenuItemFavorite.Text = "Add to Favorites";

                    }
                }
            }
        }

        private void PlayerControl_ParentChanged(object sender, EventArgs e)
        {
            if (this.player.isFavorite)
            {
                MenuItemFavorite.Text = "Remove From Favorites";
            }
            else { MenuItemFavorite.Text = "Add Favorites"; }
        }
    }
}
