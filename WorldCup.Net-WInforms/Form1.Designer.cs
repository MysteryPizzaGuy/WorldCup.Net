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
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tcRankings = new System.Windows.Forms.TabControl();
            this.tabPlayerRankings = new System.Windows.Forms.TabPage();
            this.dgvPlayerRankings = new System.Windows.Forms.DataGridView();
            this.tabMatchRankings = new System.Windows.Forms.TabPage();
            this.dgvMatchRankings = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.PrintPlayerRankings = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            this.tcRankings.SuspendLayout();
            this.tabPlayerRankings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayerRankings)).BeginInit();
            this.tabMatchRankings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchRankings)).BeginInit();
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
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.tcRankings);
            this.panel1.Controls.Add(this.button3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseCompatibleTextRendering = true;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tcRankings
            // 
            resources.ApplyResources(this.tcRankings, "tcRankings");
            this.tcRankings.Controls.Add(this.tabPlayerRankings);
            this.tcRankings.Controls.Add(this.tabMatchRankings);
            this.tcRankings.Name = "tcRankings";
            this.tcRankings.SelectedIndex = 0;
            // 
            // tabPlayerRankings
            // 
            this.tabPlayerRankings.Controls.Add(this.dgvPlayerRankings);
            resources.ApplyResources(this.tabPlayerRankings, "tabPlayerRankings");
            this.tabPlayerRankings.Name = "tabPlayerRankings";
            this.tabPlayerRankings.UseVisualStyleBackColor = true;
            // 
            // dgvPlayerRankings
            // 
            this.dgvPlayerRankings.AllowUserToAddRows = false;
            this.dgvPlayerRankings.AllowUserToDeleteRows = false;
            this.dgvPlayerRankings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvPlayerRankings, "dgvPlayerRankings");
            this.dgvPlayerRankings.Name = "dgvPlayerRankings";
            this.dgvPlayerRankings.VisibleChanged += new System.EventHandler(this.dgvPlayerRankings_VisibleChanged);
            // 
            // tabMatchRankings
            // 
            this.tabMatchRankings.Controls.Add(this.dgvMatchRankings);
            resources.ApplyResources(this.tabMatchRankings, "tabMatchRankings");
            this.tabMatchRankings.Name = "tabMatchRankings";
            this.tabMatchRankings.UseVisualStyleBackColor = true;
            // 
            // dgvMatchRankings
            // 
            this.dgvMatchRankings.AllowUserToAddRows = false;
            this.dgvMatchRankings.AllowUserToDeleteRows = false;
            this.dgvMatchRankings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvMatchRankings, "dgvMatchRankings");
            this.dgvMatchRankings.Name = "dgvMatchRankings";
            this.dgvMatchRankings.VisibleChanged += new System.EventHandler(this.dgvMatchRankings_VisibleChangedAsync);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PrintPlayerRankings
            // 
            this.PrintPlayerRankings.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintPlayerRankings_PrintPage);
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(this.printPreviewDialog1, "printPreviewDialog1");
            this.printPreviewDialog1.Document = this.PrintPlayerRankings;
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pnlPlayers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboFavoriteTeam);
            this.Controls.Add(this.pnlFavoritePlayers);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosingAsync);
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.panel1.ResumeLayout(false);
            this.tcRankings.ResumeLayout(false);
            this.tabPlayerRankings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayerRankings)).EndInit();
            this.tabMatchRankings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchRankings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFavoriteTeam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlFavoritePlayers;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tcRankings;
        private System.Windows.Forms.TabPage tabPlayerRankings;
        private System.Windows.Forms.TabPage tabMatchRankings;
        private System.Windows.Forms.DataGridView dgvPlayerRankings;
        private System.Windows.Forms.DataGridView dgvMatchRankings;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument PrintPlayerRankings;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}

