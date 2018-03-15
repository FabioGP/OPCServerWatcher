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
            tbOpcSrvMonitoringStatus.BackColor = Color.Gray;
            tbOpcSrvMonitoringStatus.ForeColor = Color.Black;
            break;
        }

        if (theOPCServer != null && theOPCServer.isConnectedDA)
        {
          theOPCServer.GetStatus(out curOPCSrvStatus);
          theOPCServerDiagnostic = curOPCSrvStatus.eServerState.ToString();
          switch (curOPCSrvStatus.eServerState)
          {
            case OPCDA.OpcServerState.Failed:
              tbOpcSrvDiagnostic.BackColor = Color.Red;
              tbOpcSrvDiagnostic.ForeColor = Color.White;
              break;
            case OPCDA.OpcServerState.NoConfig:
              tbOpcSrvDiagnostic.BackColor = Color.White;
              tbOpcSrvDiagnostic.ForeColor = Color.Black;
              break;
            case OPCDA.OpcServerState.Running:
              tbOpcSrvDiagnostic.BackColor = Color.DarkGreen;
              tbOpcSrvDiagnostic.ForeColor = Color.White;
              break;
            case OPCDA.OpcServerState.Suspended:
              tbOpcSrvDiagnostic.BackColor = Color.Yellow;
              tbOpcSrvDiagnostic.ForeColor = Color.Black;
              break;
            case OPCDA.OpcServerState.Test:
              tbOpcSrvDiagnostic.BackColor = Color.LightBlue;
              tbOpcSrvDiagnostic.ForeColor = Color.Black;
              break;
            default:
              tbOpcSrvDiagnostic.BackColor = Color.Transparent;
              tbOpcSrvDiagnostic.ForeColor = Color.DarkGray;
              break;
          }
        }
        else
        {
          tbOpcSrvDiagnostic.BackColor = Color.Transparent;
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
    private void ConfigurationWizard()
    {
      ///Variable that store the user input
      string userInput = "";

      ///Request the OPC Type
      userInput = UserDecision.ShowInputComboBox(theOPCServerType.ToString(), "Input the OPC server type",new string[] {eOPCServerType.DataFEED.ToString(), eOPCServerType.INAT.ToString(), eOPCServerType.KEPWare.ToString(), eOPCServerType.RsLinx.ToString(), eOPCServerType.SoftingS7.ToString() });
      if (userInput == "") { MessageBox.Show("This value cannot be empty..."); return; };
      theOPCServerType = (eOPCServerType)Enum.Parse(typeof(eOPCServerType), userInput);
      userInput = "";
      
      ///Request the OPC topic (address)
      userInput = UserDecision.ShowInputString(theOPCServerTopic, "Input the OPC topic (address)");
      if (userInput == "") { MessageBox.Show("This value cannot be empty..."); return; };
      theOPCServerTopic = userInput;
      userInput = "";

      ///Request the process name
      userInput = UserDecision.ShowInputString(theOPCServerProcessName, "Input the name of OPC process (Windows)");
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
    /// The user has selected the configuration wizard. So we need to stop the monitor and reconfigure it.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mnStripOptConfigWizard_Click(object sender, EventArgs e)
    {
      theStopFlag = true;
      ConfigurationWizard();
      PreStartConfig();
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

        newWriter.WriteStartElement("opcservertype", theOPCServerType.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteStartElement("opctopicname", theOPCServerTopic.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteStartElement("opcprocessname", theOPCServerProcessName.ToString());
        newWriter.WriteEndElement();

        newWriter.WriteStartElement("monitoringcycle", theCycleTime.ToString());
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
  }
}
