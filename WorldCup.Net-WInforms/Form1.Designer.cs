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
            this.TeamList = new System.Windows.Forms.ListBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtMaster = new System.Windows.Forms.TextBox();
            this.lblClone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TeamList
            // 
            this.TeamList.FormattingEnabled = true;
            this.TeamList.ItemHeight = 16;
            this.TeamList.Location = new System.Drawing.Point(32, 29);
            this.TeamList.Name = "TeamList";
            this.TeamList.Size = new System.Drawing.Size(305, 436);
            this.TeamList.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(481, 72);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(273, 161);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_ClickAsync);
            // 
            // txtMaster
            // 
            this.txtMaster.Location = new System.Drawing.Point(468, 239);
            this.txtMaster.Multiline = true;
            this.txtMaster.Name = "txtMaster";
            this.txtMaster.Size = new System.Drawing.Size(298, 88);
            this.txtMaster.TabIndex = 2;
            this.txtMaster.TextChanged += new System.EventHandler(this.txtMaster_TextChanged);
            // 
            // lblClone
            // 
            this.lblClone.AutoSize = true;
            this.lblClone.Location = new System.Drawing.Point(446, 389);
            this.lblClone.Name = "lblClone";
            this.lblClone.Size = new System.Drawing.Size(0, 17);
            this.lblClone.TabIndex = 3;
            this.lblClone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 500);
            this.Controls.Add(this.lblClone);
            this.Controls.Add(this.txtMaster);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.TeamList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox TeamList;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtMaster;
        private System.Windows.Forms.Label lblClone;
    }
}

