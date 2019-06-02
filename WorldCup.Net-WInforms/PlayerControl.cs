﻿using System;
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
    public partial class PlayerControl : UserControl
    {
        private PictureBox picPlayer;
        private Label lblName;
        private Label lblNumber;
        private Label lblPosition;
        private Label lblCaptain;
        private CheckBox chkCaptain;
        private PictureBox picFavoriteStar;
        private bool favorite = false;

        public PlayerControl()
        {
            InitializeComponent();
        }

        public void SetPlayerName(string name)
        {
            lblName.Text = name;
        }
        public void SetPlayerNumber(long? number)
        {
            lblNumber.Text = number.ToString();
        }
        public void SetPlayerPosition(string position)
        {
            lblPosition.Text = position;
        }
        public void SetPlayerCaptain(bool? iscaptain)
        {
            bool isCaptain = iscaptain.HasValue ? iscaptain.Value : false;
            chkCaptain.Checked = isCaptain;
        }


        private void label1_TextChanged(object sender, EventArgs e)
        {
            while (lblName.Width < System.Windows.Forms.TextRenderer.MeasureText(lblName.Text,
                    new Font(lblName.Font.FontFamily, lblName.Font.Size, lblName.Font.Style)).Width)
            {
                lblName.Font = new Font(lblName.Font.FontFamily, lblName.Font.Size - 0.5f, lblName.Font.Style);
            }
        }




        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.chkCaptain = new System.Windows.Forms.CheckBox();
            this.picFavoriteStar = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFavoriteStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
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
            this.lblCaptain.Location = new System.Drawing.Point(212, 33);
            this.lblCaptain.Name = "lblCaptain";
            this.lblCaptain.Size = new System.Drawing.Size(35, 13);
            this.lblCaptain.TabIndex = 4;
            this.lblCaptain.Text = "label4";
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
            this.picFavoriteStar.Image = global::WorldCup.Net_WInforms.Properties.Resources.starempty;
            this.picFavoriteStar.InitialImage = global::WorldCup.Net_WInforms.Properties.Resources.starempty;
            this.picFavoriteStar.Location = new System.Drawing.Point(334, 14);
            this.picFavoriteStar.Name = "picFavoriteStar";
            this.picFavoriteStar.Size = new System.Drawing.Size(32, 32);
            this.picFavoriteStar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFavoriteStar.TabIndex = 6;
            this.picFavoriteStar.TabStop = false;
            // 
            // picPlayer
            // 
            this.picPlayer.Location = new System.Drawing.Point(3, 4);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(52, 52);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer.TabIndex = 0;
            this.picPlayer.TabStop = false;
            // 
            // PlayerControl
            // 
            this.Controls.Add(this.picFavoriteStar);
            this.Controls.Add(this.chkCaptain);
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picPlayer);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(369, 60);
            ((System.ComponentModel.ISupportInitialize)(this.picFavoriteStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        
    }
}
