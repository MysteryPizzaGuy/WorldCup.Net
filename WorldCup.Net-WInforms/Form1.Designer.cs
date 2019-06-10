namespace WorldCup.Net_WInforms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cboFavoriteTeam = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboFavoriteTeam
            // 
            this.cboFavoriteTeam.FormattingEnabled = true;
            resources.ApplyResources(this.cboFavoriteTeam, "cboFavoriteTeam");
            this.cboFavoriteTeam.Name = "cboFavoriteTeam";
            this.cboFavoriteTeam.DropDown += new System.EventHandler(this.cboFavoriteTeam_DropDownAsync);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.AllowDrop = true;
            resources.ApplyResources(this.pnlPlayers, "pnlPlayers");
            this.pnlPlayers.Name = "pnlPlayers";
            // 
            // pnlFavoritePlayers
            // 
            this.pnlFavoritePlayers.AllowDrop = true;
            resources.ApplyResources(this.pnlFavoritePlayers, "pnlFavoritePlayers");
            this.pnlFavoritePlayers.Name = "pnlFavoritePlayers";
            this.pnlFavoritePlayers.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlFavoritePlayers_ControlAdded);
            this.pnlFavoritePlayers.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlFavoritePlayers_ControlRemoved);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pnlFavoritePlayers);
            this.Controls.Add(this.pnlPlayers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboFavoriteTeam);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosingAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFavoriteTeam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlFavoritePlayers;
        private System.Windows.Forms.TextBox textBox1;
    }
}

