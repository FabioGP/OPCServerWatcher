namespace OPCServerWatcher
{
  partial class frmMain
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.mnStripOptMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuStripOptRestart = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuStripOptExit = new System.Windows.Forms.ToolStripMenuItem();
      this.mnStripOptConfigWizard = new System.Windows.Forms.ToolStripMenuItem();
      this.lblOpcSrvType = new System.Windows.Forms.Label();
      this.lblOpcSrvTopic = new System.Windows.Forms.Label();
      this.lblOpcSrvProcessName = new System.Windows.Forms.Label();
      this.lblOpcSrvMonitoringCycle = new System.Windows.Forms.Label();
      this.lblOpcSrvMonitoringStatus = new System.Windows.Forms.Label();
      this.tbOpcSrvType = new System.Windows.Forms.TextBox();
      this.tbOpcSrvTopic = new System.Windows.Forms.TextBox();
      this.tbOpcSrvProcessName = new System.Windows.Forms.TextBox();
      this.tbOpcSrvMonitoringCycle = new System.Windows.Forms.TextBox();
      this.tbOpcSrvMonitoringStatus = new System.Windows.Forms.TextBox();
      this.tbOpcSrvDiagnostic = new System.Windows.Forms.TextBox();
      this.lbOpcSrvDiagnostic = new System.Windows.Forms.Label();
      this.iconTrayOPCServerWatcher = new System.Windows.Forms.NotifyIcon(this.components);
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnStripOptMenu,
            this.mnStripOptConfigWizard});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(424, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "mnuStrip";
      // 
      // mnStripOptMenu
      // 
      this.mnStripOptMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStripOptRestart,
            this.mnuStripOptExit});
      this.mnStripOptMenu.Name = "mnStripOptMenu";
      this.mnStripOptMenu.Size = new System.Drawing.Size(50, 20);
      this.mnStripOptMenu.Text = "Menu";
      // 
      // mnuStripOptRestart
      // 
      this.mnuStripOptRestart.Name = "mnuStripOptRestart";
      this.mnuStripOptRestart.Size = new System.Drawing.Size(110, 22);
      this.mnuStripOptRestart.Text = "Restart";
      this.mnuStripOptRestart.Click += new System.EventHandler(this.mnuStripOptRestart_Click);
      // 
      // mnuStripOptExit
      // 
      this.mnuStripOptExit.Name = "mnuStripOptExit";
      this.mnuStripOptExit.Size = new System.Drawing.Size(110, 22);
      this.mnuStripOptExit.Text = "Exit";
      this.mnuStripOptExit.Click += new System.EventHandler(this.mnuStripOptExit_Click);
      // 
      // mnStripOptConfigWizard
      // 
      this.mnStripOptConfigWizard.Name = "mnStripOptConfigWizard";
      this.mnStripOptConfigWizard.Size = new System.Drawing.Size(132, 20);
      this.mnStripOptConfigWizard.Text = "Configuration Wizard";
      this.mnStripOptConfigWizard.Click += new System.EventHandler(this.mnStripOptConfigWizard_Click);
      // 
      // lblOpcSrvType
      // 
      this.lblOpcSrvType.Location = new System.Drawing.Point(12, 36);
      this.lblOpcSrvType.Name = "lblOpcSrvType";
      this.lblOpcSrvType.Size = new System.Drawing.Size(188, 24);
      this.lblOpcSrvType.TabIndex = 1;
      this.lblOpcSrvType.Text = "OPC Server Type";
      this.lblOpcSrvType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblOpcSrvTopic
      // 
      this.lblOpcSrvTopic.Location = new System.Drawing.Point(12, 64);
      this.lblOpcSrvTopic.Name = "lblOpcSrvTopic";
      this.lblOpcSrvTopic.Size = new System.Drawing.Size(188, 24);
      this.lblOpcSrvTopic.TabIndex = 2;
      this.lblOpcSrvTopic.Text = "OPC Topic Address (Instance)";
      this.lblOpcSrvTopic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblOpcSrvProcessName
      // 
      this.lblOpcSrvProcessName.Location = new System.Drawing.Point(12, 92);
      this.lblOpcSrvProcessName.Name = "lblOpcSrvProcessName";
      this.lblOpcSrvProcessName.Size = new System.Drawing.Size(188, 24);
      this.lblOpcSrvProcessName.TabIndex = 3;
      this.lblOpcSrvProcessName.Text = "Windows Process Name";
      this.lblOpcSrvProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblOpcSrvMonitoringCycle
      // 
      this.lblOpcSrvMonitoringCycle.Location = new System.Drawing.Point(12, 120);
      this.lblOpcSrvMonitoringCycle.Name = "lblOpcSrvMonitoringCycle";
      this.lblOpcSrvMonitoringCycle.Size = new System.Drawing.Size(188, 24);
      this.lblOpcSrvMonitoringCycle.TabIndex = 4;
      this.lblOpcSrvMonitoringCycle.Text = "Monitoring Cycle";
      this.lblOpcSrvMonitoringCycle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblOpcSrvMonitoringStatus
      // 
      this.lblOpcSrvMonitoringStatus.Location = new System.Drawing.Point(12, 148);
      this.lblOpcSrvMonitoringStatus.Name = "lblOpcSrvMonitoringStatus";
      this.lblOpcSrvMonitoringStatus.Size = new System.Drawing.Size(188, 24);
      this.lblOpcSrvMonitoringStatus.TabIndex = 5;
      this.lblOpcSrvMonitoringStatus.Text = "Monitoring Status";
      this.lblOpcSrvMonitoringStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tbOpcSrvType
      // 
      this.tbOpcSrvType.Enabled = false;
      this.tbOpcSrvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvType.Location = new System.Drawing.Point(204, 36);
      this.tbOpcSrvType.Multiline = true;
      this.tbOpcSrvType.Name = "tbOpcSrvType";
      this.tbOpcSrvType.ReadOnly = true;
      this.tbOpcSrvType.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvType.TabIndex = 6;
      this.tbOpcSrvType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tbOpcSrvTopic
      // 
      this.tbOpcSrvTopic.Enabled = false;
      this.tbOpcSrvTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvTopic.Location = new System.Drawing.Point(204, 64);
      this.tbOpcSrvTopic.Multiline = true;
      this.tbOpcSrvTopic.Name = "tbOpcSrvTopic";
      this.tbOpcSrvTopic.ReadOnly = true;
      this.tbOpcSrvTopic.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvTopic.TabIndex = 7;
      this.tbOpcSrvTopic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tbOpcSrvProcessName
      // 
      this.tbOpcSrvProcessName.Enabled = false;
      this.tbOpcSrvProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvProcessName.Location = new System.Drawing.Point(204, 92);
      this.tbOpcSrvProcessName.Multiline = true;
      this.tbOpcSrvProcessName.Name = "tbOpcSrvProcessName";
      this.tbOpcSrvProcessName.ReadOnly = true;
      this.tbOpcSrvProcessName.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvProcessName.TabIndex = 8;
      this.tbOpcSrvProcessName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tbOpcSrvMonitoringCycle
      // 
      this.tbOpcSrvMonitoringCycle.Enabled = false;
      this.tbOpcSrvMonitoringCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvMonitoringCycle.Location = new System.Drawing.Point(204, 120);
      this.tbOpcSrvMonitoringCycle.Multiline = true;
      this.tbOpcSrvMonitoringCycle.Name = "tbOpcSrvMonitoringCycle";
      this.tbOpcSrvMonitoringCycle.ReadOnly = true;
      this.tbOpcSrvMonitoringCycle.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvMonitoringCycle.TabIndex = 9;
      this.tbOpcSrvMonitoringCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tbOpcSrvMonitoringStatus
      // 
      this.tbOpcSrvMonitoringStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvMonitoringStatus.Location = new System.Drawing.Point(204, 148);
      this.tbOpcSrvMonitoringStatus.Multiline = true;
      this.tbOpcSrvMonitoringStatus.Name = "tbOpcSrvMonitoringStatus";
      this.tbOpcSrvMonitoringStatus.ReadOnly = true;
      this.tbOpcSrvMonitoringStatus.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvMonitoringStatus.TabIndex = 10;
      this.tbOpcSrvMonitoringStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tbOpcSrvDiagnostic
      // 
      this.tbOpcSrvDiagnostic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvDiagnostic.Location = new System.Drawing.Point(204, 176);
      this.tbOpcSrvDiagnostic.Multiline = true;
      this.tbOpcSrvDiagnostic.Name = "tbOpcSrvDiagnostic";
      this.tbOpcSrvDiagnostic.ReadOnly = true;
      this.tbOpcSrvDiagnostic.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvDiagnostic.TabIndex = 12;
      this.tbOpcSrvDiagnostic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lbOpcSrvDiagnostic
      // 
      this.lbOpcSrvDiagnostic.Location = new System.Drawing.Point(12, 176);
      this.lbOpcSrvDiagnostic.Name = "lbOpcSrvDiagnostic";
      this.lbOpcSrvDiagnostic.Size = new System.Drawing.Size(188, 24);
      this.lbOpcSrvDiagnostic.TabIndex = 11;
      this.lbOpcSrvDiagnostic.Text = "OPC Server Diagnostic";
      this.lbOpcSrvDiagnostic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // iconTrayOPCServerWatcher
      // 
      this.iconTrayOPCServerWatcher.Icon = ((System.Drawing.Icon)(resources.GetObject("iconTrayOPCServerWatcher.Icon")));
      this.iconTrayOPCServerWatcher.Text = "OPC Server Watcher 2.0";
      this.iconTrayOPCServerWatcher.Visible = true;
      this.iconTrayOPCServerWatcher.DoubleClick += new System.EventHandler(this.iconTrayOPCServerWatcher_DoubleClick);
      // 
      // frmMain
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoScroll = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(424, 212);
      this.Controls.Add(this.tbOpcSrvDiagnostic);
      this.Controls.Add(this.lbOpcSrvDiagnostic);
      this.Controls.Add(this.tbOpcSrvMonitoringStatus);
      this.Controls.Add(this.tbOpcSrvMonitoringCycle);
      this.Controls.Add(this.tbOpcSrvProcessName);
      this.Controls.Add(this.tbOpcSrvTopic);
      this.Controls.Add(this.tbOpcSrvType);
      this.Controls.Add(this.lblOpcSrvMonitoringStatus);
      this.Controls.Add(this.lblOpcSrvMonitoringCycle);
      this.Controls.Add(this.lblOpcSrvProcessName);
      this.Controls.Add(this.lblOpcSrvTopic);
      this.Controls.Add(this.lblOpcSrvType);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MainMenuStrip = this.menuStrip1;
      this.MaximumSize = new System.Drawing.Size(440, 251);
      this.MinimumSize = new System.Drawing.Size(440, 251);
      this.Name = "frmMain";
      this.Opacity = 0.85D;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "OPC Server Watcher 2.0";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mnStripOptMenu;
    private System.Windows.Forms.ToolStripMenuItem mnuStripOptRestart;
    private System.Windows.Forms.ToolStripMenuItem mnuStripOptExit;
    private System.Windows.Forms.Label lblOpcSrvType;
    private System.Windows.Forms.Label lblOpcSrvTopic;
    private System.Windows.Forms.Label lblOpcSrvProcessName;
    private System.Windows.Forms.Label lblOpcSrvMonitoringCycle;
    private System.Windows.Forms.Label lblOpcSrvMonitoringStatus;
    private System.Windows.Forms.ToolStripMenuItem mnStripOptConfigWizard;
    private System.Windows.Forms.TextBox tbOpcSrvType;
    private System.Windows.Forms.TextBox tbOpcSrvTopic;
    private System.Windows.Forms.TextBox tbOpcSrvProcessName;
    private System.Windows.Forms.TextBox tbOpcSrvMonitoringCycle;
    private System.Windows.Forms.TextBox tbOpcSrvMonitoringStatus;
    private System.Windows.Forms.TextBox tbOpcSrvDiagnostic;
    private System.Windows.Forms.Label lbOpcSrvDiagnostic;
    private System.Windows.Forms.NotifyIcon iconTrayOPCServerWatcher;
  }
}

