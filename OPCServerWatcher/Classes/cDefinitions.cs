using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OPCServerWatcher.Classes
{
  enum eOPCServerType
  {
    SoftingS7 = 1,
    RsLinx = 2,
    INAT = 3,
    DataFEED = 4,
    KEPWare = 5
  }

  enum eOPCServerStatus
  {
    Exception = -99,
    Undefined = -1,
    Inactive = 0,
    Stopped = 1,
    Running = 2,
    Expired = 3
  }

  enum eOPCMonitoringStatus
  {
    Exception = -99,
    Undefined = -1,
    Failed = 0,
    Inactive = 1,
    Disconnected = 2,
    Connecting = 3,
    Connected = 4,
    Expired = 5,
    Restarting = 6,
    NoConnection = 7
  }

  public static class UserDecision
  {
    public static string ShowInputString(string defaultvalue, string title)
    {
      Form prompt = new Form()
      {
        Width = 400,
        Height = 110,
        FormBorderStyle = FormBorderStyle.FixedSingle,
        Text = title,
        StartPosition = FormStartPosition.CenterScreen
      };
      TextBox textBox = new TextBox() { Left = 10, Top = 5, Width = 360, Text = defaultvalue };
      Button confirmation = new Button() { Text = "Ok", Left = 10, Width = 360, Top = 35, DialogResult = DialogResult.OK };
      confirmation.Click += (sender, e) => { prompt.Close(); };
      prompt.Controls.Add(textBox);
      prompt.Controls.Add(confirmation);
      prompt.AcceptButton = confirmation;

      return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
    }

    public static string ShowInputComboBox(string defaultvalue, string title, string[] options)
    {
      Form prompt = new Form()
      {
        Width = 400,
        Height = 110,
        FormBorderStyle = FormBorderStyle.FixedSingle,
        Text = title,
        StartPosition = FormStartPosition.CenterScreen
      };
      ComboBox newComboBox = new ComboBox() { Left = 10, Top = 5, Width = 360 };
      newComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      newComboBox.Items.AddRange(options);
      newComboBox.Text = defaultvalue;

      Button confirmation = new Button() { Text = "Ok", Left = 10, Width = 360, Top = 35, DialogResult = DialogResult.OK };
      confirmation.Click += (sender, e) => { prompt.Close(); };
      prompt.Controls.Add(newComboBox);
      prompt.Controls.Add(confirmation);
      prompt.AcceptButton = confirmation;

      return prompt.ShowDialog() == DialogResult.OK ? newComboBox.Text : "";
    }
  }
}
