namespace LOL_Mastery_Tool
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable. yeah
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnClose = new System.Windows.Forms.Button();
            this.edtData = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbBuilds = new System.Windows.Forms.ListBox();
            this.Builds = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.bgwColorChecker = new System.ComponentModel.BackgroundWorker();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x800ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x640ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TrayIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Courier New", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(189, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 17);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // edtData
            // 
            this.edtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtData.Enabled = false;
            this.edtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtData.Location = new System.Drawing.Point(12, 39);
            this.edtData.Multiline = true;
            this.edtData.Name = "edtData";
            this.edtData.Size = new System.Drawing.Size(194, 46);
            this.edtData.TabIndex = 1;
            this.edtData.Text = "00000000000000000\r\n0000000000000000\r\n0000000000000000";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Location = new System.Drawing.Point(12, 446);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(90, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MiniDude22\'s Mastery Tool";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mastery Data:";
            // 
            // lbBuilds
            // 
            this.lbBuilds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBuilds.FormattingEnabled = true;
            this.lbBuilds.Location = new System.Drawing.Point(12, 108);
            this.lbBuilds.Name = "lbBuilds";
            this.lbBuilds.Size = new System.Drawing.Size(194, 303);
            this.lbBuilds.Sorted = true;
            this.lbBuilds.TabIndex = 6;
            this.lbBuilds.SelectedIndexChanged += new System.EventHandler(this.lbBuilds_SelectedIndexChanged);
            this.lbBuilds.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbBuilds_MouseMove);
            // 
            // Builds
            // 
            this.Builds.AutoSize = true;
            this.Builds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(173)))), ((int)(((byte)(104)))));
            this.Builds.Location = new System.Drawing.Point(9, 92);
            this.Builds.Name = "Builds";
            this.Builds.Size = new System.Drawing.Size(38, 13);
            this.Builds.TabIndex = 7;
            this.Builds.Text = "Builds:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(116, 446);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(12, 417);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(116, 417);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // bgwColorChecker
            // 
            this.bgwColorChecker.WorkerReportsProgress = true;
            this.bgwColorChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwColorChecker_DoWork);
            this.bgwColorChecker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwColorChecker_ProgressChanged);
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.BalloonTipText = "Has minimized and will remain hidden, until you access a Mastery Page in your LoL" +
                " Client.";
            this.TrayIcon.BalloonTipTitle = "LoL Mastery Manager";
            this.TrayIcon.ContextMenuStrip = this.TrayIconMenuStrip;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "MiniDude22\'s LOL Mastery Manager";
            this.TrayIcon.Visible = true;
            // 
            // TrayIconMenuStrip
            // 
            this.TrayIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.TrayIconMenuStrip.Name = "TrayIconMenuStrip";
            this.TrayIconMenuStrip.Size = new System.Drawing.Size(153, 92);
            this.TrayIconMenuStrip.Text = "MiniDude22\'s LOL Mastery Manager";
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x800ToolStripMenuItem,
            this.x640ToolStripMenuItem});
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            // 
            // x800ToolStripMenuItem
            // 
            this.x800ToolStripMenuItem.Name = "x800ToolStripMenuItem";
            this.x800ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.x800ToolStripMenuItem.Text = "1280 x 800";
            this.x800ToolStripMenuItem.Click += new System.EventHandler(this.x800ToolStripMenuItem_Click);
            // 
            // x640ToolStripMenuItem
            // 
            this.x640ToolStripMenuItem.Name = "x640ToolStripMenuItem";
            this.x640ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.x640ToolStripMenuItem.Text = "1024 x 640";
            this.x640ToolStripMenuItem.Click += new System.EventHandler(this.x640ToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolTip
            // 
            this.toolTip.Active = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::LOL_Mastery_Tool.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(218, 478);
            this.Controls.Add(this.Builds);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lbBuilds);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.edtData);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniDude22\'s Mastery Tool";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(234)))));
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.TrayIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox edtData;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbBuilds;
        private System.Windows.Forms.Label Builds;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.ComponentModel.BackgroundWorker bgwColorChecker;
        private System.Windows.Forms.ContextMenuStrip TrayIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x800ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x640ToolStripMenuItem;
    }
}

