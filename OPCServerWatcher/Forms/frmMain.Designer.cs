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
      this.mnStripOptConfigKeepAlive = new System.Windows.Forms.ToolStripMenuItem();
      this.mnStripOptConfigScheduler = new System.Windows.Forms.ToolStripMenuItem();
      this.iconTrayOPCServerWatcher = new System.Windows.Forms.NotifyIcon(this.components);
      this.gbKeepAliveMonitor = new System.Windows.Forms.GroupBox();
      this.tbKeepAliveConfigStatus = new System.Windows.Forms.TextBox();
      this.lblKeepAliveConfigStatus = new System.Windows.Forms.Label();
      this.tbOpcSrvDiagnostic = new System.Windows.Forms.TextBox();
      this.lbOpcSrvDiagnostic = new System.Windows.Forms.Label();
      this.tbOpcSrvMonitoringStatus = new System.Windows.Forms.TextBox();
      this.tbOpcSrvMonitoringCycle = new System.Windows.Forms.TextBox();
      this.tbOpcSrvProcessName = new System.Windows.Forms.TextBox();
      this.tbOpcSrvTopic = new System.Windows.Forms.TextBox();
      this.tbOpcSrvType = new System.Windows.Forms.TextBox();
      this.lblOpcSrvMonitoringStatus = new System.Windows.Forms.Label();
      this.lblOpcSrvMonitoringCycle = new System.Windows.Forms.Label();
      this.lblOpcSrvProcessName = new System.Windows.Forms.Label();
      this.lblOpcSrvTopic = new System.Windows.Forms.Label();
      this.lblOpcSrvType = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.tbSchedulerConfigStatus = new System.Windows.Forms.TextBox();
      this.lblSchedulerConfigStatus = new System.Windows.Forms.Label();
      this.tbSchedulerTimeConfigured = new System.Windows.Forms.TextBox();
      this.lblSchedulerTimeConfigured = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      this.gbKeepAliveMonitor.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnStripOptMenu,
            this.mnStripOptConfigKeepAlive,
            this.mnStripOptConfigScheduler});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(426, 24);
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
      // mnStripOptConfigKeepAlive
      // 
      this.mnStripOptConfigKeepAlive.Name = "mnStripOptConfigKeepAlive";
      this.mnStripOptConfigKeepAlive.Size = new System.Drawing.Size(139, 20);
      this.mnStripOptConfigKeepAlive.Text = "Monitor Configuration";
      this.mnStripOptConfigKeepAlive.Click += new System.EventHandler(this.mnStripOptConfigKeepAlive_Click);
      // 
      // mnStripOptConfigScheduler
      // 
      this.mnStripOptConfigScheduler.Name = "mnStripOptConfigScheduler";
      this.mnStripOptConfigScheduler.Size = new System.Drawing.Size(148, 20);
      this.mnStripOptConfigScheduler.Text = "Scheduler Configuration";
      this.mnStripOptConfigScheduler.Click += new System.EventHandler(this.mnStripOptConfigScheduler_Click);
      // 
      // iconTrayOPCServerWatcher
      // 
      this.iconTrayOPCServerWatcher.Icon = ((System.Drawing.Icon)(resources.GetObject("iconTrayOPCServerWatcher.Icon")));
      this.iconTrayOPCServerWatcher.Text = "OPC Server Watcher 2.0";
      this.iconTrayOPCServerWatcher.Visible = true;
      this.iconTrayOPCServerWatcher.DoubleClick += new System.EventHandler(this.iconTrayOPCServerWatcher_DoubleClick);
      // 
      // gbKeepAliveMonitor
      // 
      this.gbKeepAliveMonitor.BackColor = System.Drawing.Color.WhiteSmoke;
      this.gbKeepAliveMonitor.Controls.Add(this.tbKeepAliveConfigStatus);
      this.gbKeepAliveMonitor.Controls.Add(this.lblKeepAliveConfigStatus);
      this.gbKeepAliveMonitor.Controls.Add(this.tbOpcSrvDiagnostic);
      this.gbKeepAliveMonitor.Controls.Add(this.lbOpcSrvDiagnostic);
      this.gbKeepAliveMonitor.Controls.Add(this.tbOpcSrvMonitoringStatus);
      this.gbKeepAliveMonitor.Controls.Add(this.tbOpcSrvMonitoringCycle);
      this.gbKeepAliveMonitor.Controls.Add(this.tbOpcSrvProcessName);
      this.gbKeepAliveMonitor.Controls.Add(this.tbOpcSrvTopic);
      this.gbKeepAliveMonitor.Controls.Add(this.tbOpcSrvType);
      this.gbKeepAliveMonitor.Controls.Add(this.lblOpcSrvMonitoringStatus);
      this.gbKeepAliveMonitor.Controls.Add(this.lblOpcSrvMonitoringCycle);
      this.gbKeepAliveMonitor.Controls.Add(this.lblOpcSrvProcessName);
      this.gbKeepAliveMonitor.Controls.Add(this.lblOpcSrvTopic);
      this.gbKeepAliveMonitor.Controls.Add(this.lblOpcSrvType);
      this.gbKeepAliveMonitor.Location = new System.Drawing.Point(8, 32);
      this.gbKeepAliveMonitor.Name = "gbKeepAliveMonitor";
      this.gbKeepAliveMonitor.Size = new System.Drawing.Size(408, 228);
      this.gbKeepAliveMonitor.TabIndex = 13;
      this.gbKeepAliveMonitor.TabStop = false;
      this.gbKeepAliveMonitor.Text = "Keep Alive Monitor";
      // 
      // tbKeepAliveConfigStatus
      // 
      this.tbKeepAliveConfigStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbKeepAliveConfigStatus.Location = new System.Drawing.Point(188, 24);
      this.tbKeepAliveConfigStatus.Multiline = true;
      this.tbKeepAliveConfigStatus.Name = "tbKeepAliveConfigStatus";
      this.tbKeepAliveConfigStatus.ReadOnly = true;
      this.tbKeepAliveConfigStatus.Size = new System.Drawing.Size(208, 24);
      this.tbKeepAliveConfigStatus.TabIndex = 26;
      this.tbKeepAliveConfigStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblKeepAliveConfigStatus
      // 
      this.lblKeepAliveConfigStatus.Location = new System.Drawing.Point(12, 24);
      this.lblKeepAliveConfigStatus.Name = "lblKeepAliveConfigStatus";
      this.lblKeepAliveConfigStatus.Size = new System.Drawing.Size(172, 24);
      this.lblKeepAliveConfigStatus.TabIndex = 25;
      this.lblKeepAliveConfigStatus.Text = "Configuration Status";
      this.lblKeepAliveConfigStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tbOpcSrvDiagnostic
      // 
      this.tbOpcSrvDiagnostic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvDiagnostic.Location = new System.Drawing.Point(188, 192);
      this.tbOpcSrvDiagnostic.Multiline = true;
      this.tbOpcSrvDiagnostic.Name = "tbOpcSrvDiagnostic";
      this.tbOpcSrvDiagnostic.ReadOnly = true;
      this.tbOpcSrvDiagnostic.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvDiagnostic.TabIndex = 24;
      this.tbOpcSrvDiagnostic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lbOpcSrvDiagnostic
      // 
      this.lbOpcSrvDiagnostic.Location = new System.Drawing.Point(12, 192);
      this.lbOpcSrvDiagnostic.Name = "lbOpcSrvDiagnostic";
      this.lbOpcSrvDiagnostic.Size = new System.Drawing.Size(172, 24);
      this.lbOpcSrvDiagnostic.TabIndex = 23;
      this.lbOpcSrvDiagnostic.Text = "OPC Server Diagnostic";
      this.lbOpcSrvDiagnostic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tbOpcSrvMonitoringStatus
      // 
      this.tbOpcSrvMonitoringStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvMonitoringStatus.Location = new System.Drawing.Point(188, 164);
      this.tbOpcSrvMonitoringStatus.Multiline = true;
      this.tbOpcSrvMonitoringStatus.Name = "tbOpcSrvMonitoringStatus";
      this.tbOpcSrvMonitoringStatus.ReadOnly = true;
      this.tbOpcSrvMonitoringStatus.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvMonitoringStatus.TabIndex = 22;
      this.tbOpcSrvMonitoringStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tbOpcSrvMonitoringCycle
      // 
      this.tbOpcSrvMonitoringCycle.Enabled = false;
      this.tbOpcSrvMonitoringCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvMonitoringCycle.Location = new System.Drawing.Point(188, 136);
      this.tbOpcSrvMonitoringCycle.Multiline = true;
      this.tbOpcSrvMonitoringCycle.Name = "tbOpcSrvMonitoringCycle";
      this.tbOpcSrvMonitoringCycle.ReadOnly = true;
      this.tbOpcSrvMonitoringCycle.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvMonitoringCycle.TabIndex = 21;
      this.tbOpcSrvMonitoringCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tbOpcSrvProcessName
      // 
      this.tbOpcSrvProcessName.Enabled = false;
      this.tbOpcSrvProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvProcessName.Location = new System.Drawing.Point(188, 108);
      this.tbOpcSrvProcessName.Multiline = true;
      this.tbOpcSrvProcessName.Name = "tbOpcSrvProcessName";
      this.tbOpcSrvProcessName.ReadOnly = true;
      this.tbOpcSrvProcessName.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvProcessName.TabIndex = 20;
      this.tbOpcSrvProcessName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tbOpcSrvTopic
      // 
      this.tbOpcSrvTopic.Enabled = false;
      this.tbOpcSrvTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvTopic.Location = new System.Drawing.Point(188, 80);
      this.tbOpcSrvTopic.Multiline = true;
      this.tbOpcSrvTopic.Name = "tbOpcSrvTopic";
      this.tbOpcSrvTopic.ReadOnly = true;
      this.tbOpcSrvTopic.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvTopic.TabIndex = 19;
      this.tbOpcSrvTopic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // tbOpcSrvType
      // 
      this.tbOpcSrvType.Enabled = false;
      this.tbOpcSrvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbOpcSrvType.Location = new System.Drawing.Point(188, 52);
      this.tbOpcSrvType.Multiline = true;
      this.tbOpcSrvType.Name = "tbOpcSrvType";
      this.tbOpcSrvType.ReadOnly = true;
      this.tbOpcSrvType.Size = new System.Drawing.Size(208, 24);
      this.tbOpcSrvType.TabIndex = 18;
      this.tbOpcSrvType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblOpcSrvMonitoringStatus
      // 
      this.lblOpcSrvMonitoringStatus.Location = new System.Drawing.Point(12, 164);
      this.lblOpcSrvMonitoringStatus.Name = "lblOpcSrvMonitoringStatus";
      this.lblOpcSrvMonitoringStatus.Size = new System.Drawing.Size(172, 24);
      this.lblOpcSrvMonitoringStatus.TabIndex = 17;
      this.lblOpcSrvMonitoringStatus.Text = "Monitoring Status";
      this.lblOpcSrvMonitoringStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblOpcSrvMonitoringCycle
      // 
      this.lblOpcSrvMonitoringCycle.Location = new System.Drawing.Point(12, 136);
      this.lblOpcSrvMonitoringCycle.Name = "lblOpcSrvMonitoringCycle";
      this.lblOpcSrvMonitoringCycle.Size = new System.Drawing.Size(172, 24);
      this.lblOpcSrvMonitoringCycle.TabIndex = 16;
      this.lblOpcSrvMonitoringCycle.Text = "Monitoring Cycle";
      this.lblOpcSrvMonitoringCycle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblOpcSrvProcessName
      // 
      this.lblOpcSrvProcessName.Location = new System.Drawing.Point(12, 108);
      this.lblOpcSrvProcessName.Name = "lblOpcSrvProcessName";
      this.lblOpcSrvProcessName.Size = new System.Drawing.Size(172, 24);
      this.lblOpcSrvProcessName.TabIndex = 15;
      this.lblOpcSrvProcessName.Text = "Windows Process Name";
      this.lblOpcSrvProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblOpcSrvTopic
      // 
      this.lblOpcSrvTopic.Location = new System.Drawing.Point(12, 80);
      this.lblOpcSrvTopic.Name = "lblOpcSrvTopic";
      this.lblOpcSrvTopic.Size = new System.Drawing.Size(172, 24);
      this.lblOpcSrvTopic.TabIndex = 14;
      this.lblOpcSrvTopic.Text = "OPC Topic Address (Instance)";
      this.lblOpcSrvTopic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblOpcSrvType
      // 
      this.lblOpcSrvType.Location = new System.Drawing.Point(12, 52);
      this.lblOpcSrvType.Name = "lblOpcSrvType";
      this.lblOpcSrvType.Size = new System.Drawing.Size(172, 24);
      this.lblOpcSrvType.TabIndex = 13;
      this.lblOpcSrvType.Text = "OPC Server Type";
      this.lblOpcSrvType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
      this.groupBox1.Controls.Add(this.tbSchedulerConfigStatus);
      this.groupBox1.Controls.Add(this.lblSchedulerConfigStatus);
      this.groupBox1.Controls.Add(this.tbSchedulerTimeConfigured);
      this.groupBox1.Controls.Add(this.lblSchedulerTimeConfigured);
      this.groupBox1.Location = new System.Drawing.Point(8, 264);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(408, 86);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Scheduler";
      // 
      // tbSchedulerConfigStatus
      // 
      this.tbSchedulerConfigStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbSchedulerConfigStatus.Location = new System.Drawing.Point(188, 24);
      this.tbSchedulerConfigStatus.Multiline = true;
      this.tbSchedulerConfigStatus.Name = "tbSchedulerConfigStatus";
      this.tbSchedulerConfigStatus.ReadOnly = true;
      this.tbSchedulerConfigStatus.Size = new System.Drawing.Size(208, 24);
      this.tbSchedulerConfigStatus.TabIndex = 26;
      this.tbSchedulerConfigStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblSchedulerConfigStatus
      // 
      this.lblSchedulerConfigStatus.Location = new System.Drawing.Point(12, 24);
      this.lblSchedulerConfigStatus.Name = "lblSchedulerConfigStatus";
      this.lblSchedulerConfigStatus.Size = new System.Drawing.Size(172, 24);
      this.lblSchedulerConfigStatus.TabIndex = 25;
      this.lblSchedulerConfigStatus.Text = "Configuration Status";
      this.lblSchedulerConfigStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tbSchedulerTimeConfigured
      // 
      this.tbSchedulerTimeConfigured.Enabled = false;
      this.tbSchedulerTimeConfigured.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbSchedulerTimeConfigured.Location = new System.Drawing.Point(188, 52);
      this.tbSchedulerTimeConfigured.Multiline = true;
      this.tbSchedulerTimeConfigured.Name = "tbSchedulerTimeConfigured";
      this.tbSchedulerTimeConfigured.ReadOnly = true;
      this.tbSchedulerTimeConfigured.Size = new System.Drawing.Size(208, 24);
      this.tbSchedulerTimeConfigured.TabIndex = 18;
      this.tbSchedulerTimeConfigured.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblSchedulerTimeConfigured
      // 
      this.lblSchedulerTimeConfigured.Location = new System.Drawing.Point(12, 52);
      this.lblSchedulerTimeConfigured.Name = "lblSchedulerTimeConfigured";
      this.lblSchedulerTimeConfigured.Size = new System.Drawing.Size(172, 24);
      this.lblSchedulerTimeConfigured.TabIndex = 13;
      this.lblSchedulerTimeConfigured.Text = "Time Configured";
      this.lblSchedulerTimeConfigured.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // frmMain
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoScroll = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.WhiteSmoke;
      this.ClientSize = new System.Drawing.Size(426, 357);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.gbKeepAliveMonitor);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MainMenuStrip = this.menuStrip1;
      this.MaximumSize = new System.Drawing.Size(442, 396);
      this.MinimumSize = new System.Drawing.Size(442, 396);
      this.Name = "frmMain";
      this.Opacity = 0.85D;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "OPC Server Watcher 2.0";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.gbKeepAliveMonitor.ResumeLayout(false);
      this.gbKeepAliveMonitor.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mnStripOptMenu;
    private System.Windows.Forms.ToolStripMenuItem mnuStripOptRestart;
    private System.Windows.Forms.ToolStripMenuItem mnuStripOptExit;
    private System.Windows.Forms.ToolStripMenuItem mnStripOptConfigKeepAlive;
    private System.Windows.Forms.NotifyIcon iconTrayOPCServerWatcher;
    private System.Windows.Forms.GroupBox gbKeepAliveMonitor;
    private System.Windows.Forms.TextBox tbKeepAliveConfigStatus;
    private System.Windows.Forms.Label lblKeepAliveConfigStatus;
    private System.Windows.Forms.TextBox tbOpcSrvDiagnostic;
    private System.Windows.Forms.Label lbOpcSrvDiagnostic;
    private System.Windows.Forms.TextBox tbOpcSrvMonitoringStatus;
    private System.Windows.Forms.TextBox tbOpcSrvMonitoringCycle;
    private System.Windows.Forms.TextBox tbOpcSrvProcessName;
    private System.Windows.Forms.TextBox tbOpcSrvTopic;
    private System.Windows.Forms.TextBox tbOpcSrvType;
    private System.Windows.Forms.Label lblOpcSrvMonitoringStatus;
    private System.Windows.Forms.Label lblOpcSrvMonitoringCycle;
    private System.Windows.Forms.Label lblOpcSrvProcessName;
    private System.Windows.Forms.Label lblOpcSrvTopic;
    private System.Windows.Forms.Label lblOpcSrvType;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox tbSchedulerConfigStatus;
    private System.Windows.Forms.Label lblSchedulerConfigStatus;
    private System.Windows.Forms.TextBox tbSchedulerTimeConfigured;
    private System.Windows.Forms.Label lblSchedulerTimeConfigured;
    private System.Windows.Forms.ToolStripMenuItem mnStripOptConfigScheduler;
  }
}

