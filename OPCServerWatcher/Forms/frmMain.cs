using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using OPCServerWatcher.Classes;
using System.Threading;
using OPCDA.NET;
using OPC;
using System.Diagnostics;

namespace OPCServerWatcher
{
  /// <summary>
  /// Main Form
  /// </summary>
  public partial class frmMain : Form
  {

    #region "Variables"
    eOPCServerType theOPCServerType;
    string theOPCServerTopic;
    string theOPCServerProcessName;

    string theOPCServerDiagnostic = "";
    eOPCMonitoringStatus theOPCMonitorStatus = eOPCMonitoringStatus.Inactive;
    int theCycleTime;
    bool theStopFlag = false;
    Thread theThreadMonitor;
    bool theKeepAliveMonitorIsEnabled;

    bool theSchedulerIsEnabled;
    DateTime theSchedulerTime;
    DateTime theLastRestartTime;

    string strRuntimePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    string strConfigurationFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Configuration\\Configuration.xml";
    #endregion

    /// <summary>
    /// Delegate to update the screen status
    /// </summary>
    /// <param name="_theStatus"></param>
    delegate void UpdateStatusDelegate(eOPCMonitoringStatus _theStatus);

    /// <summary>
    /// Form initialization
    /// </summary>
    public frmMain()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Restart the application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mnuStripOptRestart_Click(object sender, EventArgs e)
    {
      theStopFlag = true;
      Application.Restart();
    }

    /// <summary>
    /// Close the main form and exit from application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mnuStripOptExit_Click(object sender, EventArgs e)
    {
      theStopFlag = true;
      Application.Exit();
    }

    /// <summary>
    /// Event called on main form load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmMain_Load(object sender, EventArgs e)
    {
      PreStartConfig();
    }

    /// <summary>
    /// Cyclic main thread task
    /// </summary>
    private void CheckOPCStatus()
    {
      while (theStopFlag == false)
      {
        Thread.Sleep(theCycleTime);
        if (tbOpcSrvMonitoringStatus.InvokeRequired)
        {
          UpdateStatusDelegate theDelegate = new UpdateStatusDelegate(UpdateStatus);
          Invoke(theDelegate, new object[] { theOPCMonitorStatus });
        }
      }
      theThreadMonitor.Abort();
    }

    /// <summary>
    /// This is our layout update routine, that keeps refreshing the screen on each cycle of our thread monitor
    /// </summary>
    /// <param name="_curStatus"></param>
    private void UpdateStatus(eOPCMonitoringStatus _curStatus)
    {
      int cResult;
      OpcServer theOPCServer = new OpcServer();
      try
      {
        OPCDA.SERVERSTATUS curOPCSrvStatus;
        cResult = theOPCServer.Connect(theOPCServerTopic);

        if (theKeepAliveMonitorIsEnabled)
        {
          tbKeepAliveConfigStatus.BackColor = Color.DarkGreen;
          tbKeepAliveConfigStatus.ForeColor = Color.White;
          tbKeepAliveConfigStatus.Text = "Enabled";
        }
        else
        {
          tbKeepAliveConfigStatus.BackColor = Color.LightGray;
          tbKeepAliveConfigStatus.ForeColor = Color.DarkGray;
          tbKeepAliveConfigStatus.Text = "Disabled";
        }

        if (theSchedulerIsEnabled)
        {
          tbSchedulerConfigStatus.BackColor = Color.DarkGreen;
          tbSchedulerConfigStatus.ForeColor = Color.White;
          tbSchedulerConfigStatus.Text = "Enabled";
          tbSchedulerTimeConfigured.Text = theSchedulerTime.TimeOfDay.ToString();
        }
        else
        {
          tbSchedulerConfigStatus.BackColor = Color.LightGray;
          tbSchedulerConfigStatus.ForeColor = Color.DarkGray;
          tbSchedulerConfigStatus.Text = "Disabled";
          tbSchedulerTimeConfigured.Text = "";
        }

        switch (cResult)
        {
          case HRESULTS.E_FAIL:
            theOPCMonitorStatus = eOPCMonitoringStatus.Failed;
            break;
          case HRESULTS.OPC_E_NOTFOUND:
            theOPCMonitorStatus = eOPCMonitoringStatus.Failed;
            break;
          case HRESULTS.CONNECT_E_ADVISELIMIT:
            theOPCMonitorStatus = eOPCMonitoringStatus.Expired;
            break;
          case HRESULTS.CONNECT_E_NOCONNECTION:
            theOPCMonitorStatus = eOPCMonitoringStatus.NoConnection;
            break;
          case HRESULTS.S_OK:
            theOPCMonitorStatus = eOPCMonitoringStatus.Connected;
            break;
          case HRESULTS.S_FALSE:
            theOPCMonitorStatus = eOPCMonitoringStatus.Failed;
            break;
          default:
            theOPCMonitorStatus = eOPCMonitoringStatus.Undefined;
            theOPCServerDiagnostic = "";
            break;
        }

        switch (theOPCMonitorStatus)
        {
          case eOPCMonitoringStatus.Inactive:
            tbOpcSrvMonitoringStatus.BackColor = Color.LightGray;
            tbOpcSrvMonitoringStatus.ForeColor = Color.DarkGray;
            break;
          case eOPCMonitoringStatus.Undefined:
            tbOpcSrvMonitoringStatus.BackColor = Color.LightGray;
            tbOpcSrvMonitoringStatus.ForeColor = Color.DarkGray;
            break;
          case eOPCMonitoringStatus.Connecting:
            tbOpcSrvMonitoringStatus.BackColor = Color.LightGreen;
            tbOpcSrvMonitoringStatus.ForeColor = Color.Black;
            break;
          case eOPCMonitoringStatus.Connected:
            tbOpcSrvMonitoringStatus.BackColor = Color.DarkGreen;
            tbOpcSrvMonitoringStatus.ForeColor = Color.White;
            break;
          case eOPCMonitoringStatus.Expired:
            tbOpcSrvMonitoringStatus.BackColor = Color.Yellow;
            tbOpcSrvMonitoringStatus.ForeColor = Color.Black;
            break;
          case eOPCMonitoringStatus.Disconnected:
            tbOpcSrvMonitoringStatus.BackColor = Color.LightCoral;
            tbOpcSrvMonitoringStatus.ForeColor = Color.Black;
            break;
          case eOPCMonitoringStatus.Failed:
            tbOpcSrvMonitoringStatus.BackColor = Color.Red;
            tbOpcSrvMonitoringStatus.ForeColor = Color.White;
            break;
          case eOPCMonitoringStatus.Restarting:
            tbOpcSrvMonitoringStatus.BackColor = Color.LightBlue;
            tbOpcSrvMonitoringStatus.ForeColor = Color.Black;
            break;
          default:
            tbOpcSrvMonitoringStatus.BackColor = Color.LightGray;
            tbOpcSrvMonitoringStatus.ForeColor = Color.Black;
            break;
        }

        if (theSchedulerIsEnabled == true && 
            DateTime.Now.TimeOfDay >= theSchedulerTime.TimeOfDay &&
            DateTime.Now.Day > theLastRestartTime.Day)
        {
          while (OPCServerProcessIsRunning())
          {
            KillWindowsProcess();
            Thread.Sleep(1000);
          }
          theLastRestartTime = DateTime.Now;
        }


        if (theOPCServer != null && theOPCServer.isConnectedDA)
        {
          theOPCServer.GetStatus(out curOPCSrvStatus);
          if (curOPCSrvStatus.eServerState.ToString() == "0") { theOPCServerDiagnostic = "License Expired"; } else { theOPCServerDiagnostic = curOPCSrvStatus.eServerState.ToString(); }
          switch (curOPCSrvStatus.eServerState)
          {
            case OPCDA.OpcServerState.Failed:
              tbOpcSrvDiagnostic.BackColor = Color.Red;
              tbOpcSrvDiagnostic.ForeColor = Color.White;
              if (theKeepAliveMonitorIsEnabled)
              {
                while (OPCServerProcessIsRunning())
                {
                  KillWindowsProcess();
                  Thread.Sleep(1000);
                }
              }
              break;
            case OPCDA.OpcServerState.Suspended:
              tbOpcSrvDiagnostic.BackColor = Color.Yellow;
              tbOpcSrvDiagnostic.ForeColor = Color.Black;

              if (theKeepAliveMonitorIsEnabled)
              {
                while (OPCServerProcessIsRunning())
                {
                  KillWindowsProcess();
                  Thread.Sleep(1000);
                }
              }
              break;
            case OPCDA.OpcServerState.NoConfig:
              tbOpcSrvDiagnostic.BackColor = Color.White;
              tbOpcSrvDiagnostic.ForeColor = Color.Black;
              break;
            case OPCDA.OpcServerState.Running:
              tbOpcSrvDiagnostic.BackColor = Color.DarkGreen;
              tbOpcSrvDiagnostic.ForeColor = Color.White;
              break;
            case OPCDA.OpcServerState.Test:
              tbOpcSrvDiagnostic.BackColor = Color.LightBlue;
              tbOpcSrvDiagnostic.ForeColor = Color.Black;
              break;
            default:
              tbOpcSrvDiagnostic.BackColor = Color.Yellow;
              tbOpcSrvDiagnostic.ForeColor = Color.Black;

              if (theKeepAliveMonitorIsEnabled)
              {
                while (OPCServerProcessIsRunning())
                {
                  KillWindowsProcess();
                  Thread.Sleep(1000);
                }
              }

              break;
          }
        }
        else
        {
          tbOpcSrvDiagnostic.BackColor = Color.Gainsboro;
          tbOpcSrvDiagnostic.ForeColor = Color.DarkGray;
        }

      }
      catch
      {
        theOPCMonitorStatus = eOPCMonitoringStatus.Exception;
        theOPCServerDiagnostic = "";

        tbOpcSrvMonitoringStatus.BackColor = Color.Red;
        tbOpcSrvMonitoringStatus.ForeColor = Color.White;
      }
      finally
      {
        tbOpcSrvMonitoringStatus.Text = theOPCMonitorStatus.ToString();
        tbOpcSrvDiagnostic.Text = theOPCServerDiagnostic;
      }
    }

    /// <summary>
    /// Function that returns if the process is running or not
    /// </summary>
    /// <returns></returns>
    public bool OPCServerProcessIsRunning()
    {
      bool fResult = false;
      try
      {
        foreach (Process proc in Process.GetProcessesByName(theOPCServerProcessName))
        {
          fResult = true;
          break;
        }
      }
      catch
      {
        //Nothing to do
      }
      return fResult;
    }

    /// <summary>
    /// Function that Kill the current OPC Process
    /// </summary>
    public void  KillWindowsProcess()
    {
      try
      {
        foreach (Process proc in Process.GetProcessesByName(theOPCServerProcessName))
        {
          proc.Kill();
        }
      }
      catch (Exception ex)
      {
        //Nothing to do
      }
    }

    /// <summary>
    /// It's the moment to stop our monitoring and load the configuration from XML file
    /// We gonna use this time to update the basic info of OPC server as well.
    /// </summary>
    private void PreStartConfig()
    {
      theStopFlag = true;
      if (theThreadMonitor != null && theThreadMonitor.IsAlive)
      {
        theThreadMonitor.Abort();
        theThreadMonitor = null;
      }

      //Read configuration file...
      LoadConfigurationFile();

      //set the current configuration properties on the screen...
      tbOpcSrvType.Text = theOPCServerType.ToString();
      tbOpcSrvTopic.Text = theOPCServerTopic;
      tbOpcSrvProcessName.Text = theOPCServerProcessName;
      tbOpcSrvMonitoringCycle.Text = theCycleTime.ToString() + " [ms]";

      //Is time to start ou main routine of thread...
      theStopFlag = false;
      theThreadMonitor = new Thread(CheckOPCStatus);
      theThreadMonitor.Start();
    }

    /// <summary>
    /// Configuration wizard to support the user on OPC setup
    /// </summary>
    private void ConfigurationWizardKeepAliveMonitor()
    {
      ///Variable that store the user input
      string userInput = "";

      string defaultEnable = "";
      if (theKeepAliveMonitorIsEnabled) { defaultEnable = "Yes"; } else { defaultEnable = "No"; }
      ///Request if the keep alive monitor will be enabled
      userInput = UserDecision.ShowInputComboBox(defaultEnable, "Enable auto-restart by server state?", new string[] { "Yes", "No" });
      if (userInput == "") { MessageBox.Show("This value cannot be empty..."); return; };
      switch (userInput)
      {
        case "Yes":
          theKeepAliveMonitorIsEnabled = true;
          break;
        case "No":
          theKeepAliveMonitorIsEnabled = false;
          break;
        default:
          theKeepAliveMonitorIsEnabled = false;
          MessageBox.Show("Invalid value!");
          return;
      }
      userInput = "";

      ///Request the OPC Type
      userInput = UserDecision.ShowInputComboBox(theOPCServerType.ToString(), "Input the OPC server type",new string[] {eOPCServerType.DataFEED.ToString(), eOPCServerType.INAT.ToString(), eOPCServerType.KEPWare.ToString(), eOPCServerType.RsLinx.ToString(), eOPCServerType.SoftingS7.ToString() });
      if (userInput == "") { MessageBox.Show("This value cannot be empty..."); return; };
      theOPCServerType = (eOPCServerType)Enum.Parse(typeof(eOPCServerType), userInput);
      userInput = "";

      ///Request the OPC topic (address)
      string defaultTopicConfig;
      switch (theOPCServerType)
      {
        case eOPCServerType.DataFEED:
          defaultTopicConfig = "Softing.OPC.DF.S7.DA.1";
          break;
        case eOPCServerType.INAT:
          defaultTopicConfig = "INAT TcpIpH1 OPC Server";
          break;
        case eOPCServerType.KEPWare:
          defaultTopicConfig = "";
          break;
        case eOPCServerType.RsLinx:
          defaultTopicConfig = "RsLinx OPC Server";
          break;
        case eOPCServerType.SoftingS7:
          defaultTopicConfig = "Softing.OPC.S7.DA.1";
          break;
        default:
          defaultTopicConfig = "";
          break;
      }
      userInput = UserDecision.ShowInputString(defaultTopicConfig, "Input the OPC topic (address)");
      if (userInput == "") { MessageBox.Show("This value cannot be empty..."); return; };
      theOPCServerTopic = userInput;
      userInput = "";

      ///Request the process name
      string defaultProcessName;
      switch (theOPCServerType)
      {
        case eOPCServerType.DataFEED:
          defaultProcessName = "OSF_Service";
          break;
        case eOPCServerType.INAT:
          defaultProcessName = "TCPIPH1";
          break;
        case eOPCServerType.KEPWare:
          defaultProcessName = "";
          break;
        case eOPCServerType.RsLinx:
          defaultProcessName = "RSLINX";
          break;
        case eOPCServerType.SoftingS7:
          defaultProcessName = "S7OPCsvc";
          break;
        default:
          defaultProcessName = "";
          break;
      }
      userInput = UserDecision.ShowInputString(defaultProcessName, "Input the name of OPC process (Windows)");
      if (userInput == "") { MessageBox.Show("This value cannot be empty..."); return; };
      theOPCServerProcessName = userInput;
      userInput = "";

      ///Request the cycle timer
      userInput = UserDecision.ShowInputString(theCycleTime.ToString(), "Input the cycle timer in [ms]");
      int newCycleTimer;
      if (userInput == "") { MessageBox.Show("This value cannot be empty..."); return; };
      if (int.TryParse(userInput, out newCycleTimer) == false) { MessageBox.Show("Input value was not valid. Please use just numbers..."); return; };
      theCycleTime = newCycleTimer;
      userInput = "";

      //Save the new configurtaion and restart the application.
      GenerateConfigurationFile();
    }

    /// <summary>
    /// Configuration wizard to support the user on scheduler configuration
    /// </summary>
    private void ConfigurationWizardScheduler()
    {
      ///Variable that store the user input
      string userInput = "";

      string defaultEnable = "";
      if (theSchedulerIsEnabled) { defaultEnable = "Yes"; } else { defaultEnable = "No"; }
      ///Request if the scheduler will be enabled
        userInput = UserDecision.ShowInputComboBox(defaultEnable, "Enable scheduler?", new string[] { "Yes", "No"});
      if (userInput == "") { MessageBox.Show("This value cannot be empty..."); return; };
      switch (userInput)
      {
        case "Yes":
          theSchedulerIsEnabled = true;
          break;
        case "No":
          theSchedulerIsEnabled = false;
          break;
        default:
          theSchedulerIsEnabled = false;
          MessageBox.Show("Invalid value!");
          return;
      }
      userInput = "";

      ///Request the OPC topic (address)
      DateTime newUserDate;
      newUserDate = UserDecision.ShowTimePicker(DateTime.Now.ToString(), "Input the time:");
      theSchedulerTime = newUserDate;
      userInput = "";

      //Save the new configurtaion and restart the application.
      GenerateConfigurationFile();
    }

    /// <summary>
    /// We need to minimize the form on close button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        e.Cancel = true;
        WindowState = FormWindowState.Minimized;
        iconTrayOPCServerWatcher.Visible = true;
        Hide();
      }
    }

    /// <summary>
    /// Save the user settings into a XML configuration file
    /// </summary>
    private void GenerateConfigurationFile()
    {
      XmlWriterSettings theSettings = new XmlWriterSettings();
      theSettings.Indent = true;
      theSettings.Encoding = Encoding.UTF8;

      using (XmlWriter newWriter = XmlWriter.Create(strConfigurationFile, theSettings))
      {
        newWriter.WriteStartDocument();
        newWriter.WriteStartElement("configuration");

        newWriter.WriteStartElement("opcservertype");
        newWriter.WriteValue(theOPCServerType.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteStartElement("opctopicname");
        newWriter.WriteValue(theOPCServerTopic.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteStartElement("opcprocessname");
        newWriter.WriteValue(theOPCServerProcessName.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteStartElement("monitoringcycle");
        newWriter.WriteValue(theCycleTime.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteStartElement("monitoringenabled");
        newWriter.WriteValue(theKeepAliveMonitorIsEnabled.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteStartElement("schedulerenabled");
        newWriter.WriteValue(theSchedulerIsEnabled.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteStartElement("schedulertime");
        newWriter.WriteValue(theSchedulerTime.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteEndElement();
        newWriter.WriteEndDocument();
      }
      theSettings = null;
    }

    /// <summary>
    /// Read the current configuration from XML file
    /// </summary>
    private void LoadConfigurationFile()
    {
      XmlDocument configFile = new XmlDocument();
      configFile.Load(strConfigurationFile);

      XmlNode curNode;
      curNode = configFile.SelectSingleNode("/configuration/opcservertype");
      if (curNode != null) { theOPCServerType = (eOPCServerType)Enum.Parse(typeof(eOPCServerType), curNode.InnerText); }
      curNode = null;

      curNode = configFile.SelectSingleNode("/configuration/opctopicname");
      if (curNode != null) { theOPCServerTopic = curNode.InnerText; }
      curNode = null;

      curNode = configFile.SelectSingleNode("/configuration/opcprocessname");
      if (curNode != null) { theOPCServerProcessName = curNode.InnerText; }
      curNode = null;

      curNode = configFile.SelectSingleNode("/configuration/monitoringcycle");
      if (curNode != null) { theCycleTime = int.Parse(curNode.InnerText); }
      curNode = null;

      curNode = configFile.SelectSingleNode("/configuration/monitoringenabled");
      if (curNode != null) { theKeepAliveMonitorIsEnabled = bool.Parse(curNode.InnerText); }
      curNode = null;

      curNode = configFile.SelectSingleNode("/configuration/schedulerenabled");
      if (curNode != null) { theSchedulerIsEnabled = bool.Parse(curNode.InnerText); }
      curNode = null;

      curNode = configFile.SelectSingleNode("/configuration/schedulertime");
      if (curNode != null) { theSchedulerTime = DateTime.Parse(curNode.InnerText); }
      curNode = null;
      configFile = null;
    }

    /// <summary>
    /// On double click over tray icon, the form should be opened
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void iconTrayOPCServerWatcher_DoubleClick(object sender, EventArgs e)
    {
      WindowState = FormWindowState.Normal;
      Show();
    }

    /// <summary>
    /// User has selected the Monitoring Configuration
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mnStripOptConfigKeepAlive_Click(object sender, EventArgs e)
    {
      theStopFlag = true;
      ConfigurationWizardKeepAliveMonitor();
      PreStartConfig();
    }

    /// <summary>
    /// User has selected the Scheduler Configuration
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mnStripOptConfigScheduler_Click(object sender, EventArgs e)
    {
      theStopFlag = true;
      ConfigurationWizardScheduler();
      PreStartConfig();
    }
  }
}
