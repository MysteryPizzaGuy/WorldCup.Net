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
            this.TeamList = new System.Windows.Forms.ListBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtMaster = new System.Windows.Forms.TextBox();
            this.lblClone = new System.Windows.Forms.Label();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.lstTeamMatchesData = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // TeamList
            // 
            resources.ApplyResources(this.TeamList, "TeamList");
            this.TeamList.FormattingEnabled = true;
            this.TeamList.Name = "TeamList";
            // 
            // btnLoad
            // 
            resources.ApplyResources(this.btnLoad, "btnLoad");
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_ClickAsync);
            // 
            // txtMaster
            // 
            resources.ApplyResources(this.txtMaster, "txtMaster");
            this.txtMaster.Name = "txtMaster";
            // 
            // lblClone
            // 
            resources.ApplyResources(this.lblClone, "lblClone");
            this.lblClone.Name = "lblClone";
            // 
            // btnGetInfo
            // 
            resources.ApplyResources(this.btnGetInfo, "btnGetInfo");
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_ClickAsync);
            // 
            // lstTeamMatchesData
            // 
            resources.ApplyResources(this.lstTeamMatchesData, "lstTeamMatchesData");
            this.lstTeamMatchesData.FormattingEnabled = true;
            this.lstTeamMatchesData.Name = "lstTeamMatchesData";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstTeamMatchesData);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.lblClone);
            this.Controls.Add(this.txtMaster);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.TeamList);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox TeamList;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtMaster;
        private System.Windows.Forms.Label lblClone;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.ListBox lstTeamMatchesData;
    }
}

