using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
  public class frmCheckUpdate : Form
  {
    private const string m_szCheckUpdateLink = "http://vipersaudio.com/swupdate/viper4windows/version.bin";
    private string m_szDownloadLink = "";
    private IContainer components;
    private Label label_CodeName;
    private Label label_DriverVersion;
    private Label label_ControlPanelVersion;
    private GroupBox groupBox_VersionFromInternet;
    private Label label_CodeName_Net;
    private Label label_DriverVerion_Net;
    private Label label_ControlPanelVersion_Net;
    private SingleButton singleButton_Check;
    private SingleButton singleButton_Copy;

    public frmCheckUpdate()
    {
      this.InitializeComponent();
      this.Text = GlobalMessages.CHECK_UPDATE;
      this.label_ControlPanelVersion.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : " + 1U.ToString() + "." + 0U.ToString() + "." + 5U.ToString();
      this.label_DriverVersion.Text = GlobalMessages.DRIVER_VERSION + " : " + RuntimeUtils.EffectDriver.GetVersion();
      this.label_CodeName.Text = GlobalMessages.CODE_NAME + " : " + RuntimeUtils.EffectDriver.GetCodeName();
      this.groupBox_VersionFromInternet.Text = GlobalMessages.VERSION_FROM_INTERNET;
      this.label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
      this.label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
      this.label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
      this.singleButton_Check.ButtonText = GlobalMessages.CHECK;
      this.singleButton_Copy.ButtonText = GlobalMessages.COPY_DOWNLOAD_LINK;
      this.singleButton_Copy.Enabled = false;
    }

    private void singleButton_Check_ButtonClickNotify(SingleButton objSender)
    {
      string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
      string path = baseDirectory.EndsWith("\\") ? baseDirectory + "version.txt" : baseDirectory + "\\version.txt";
      try
      {
        this.singleButton_Check.Enabled = false;
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create("http://vipersaudio.com/swupdate/viper4windows/version.bin");
        HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
        Stream responseStream = response.GetResponseStream();
        Stream stream = (Stream) new FileStream(path, FileMode.Create);
        byte[] buffer = new byte[1024];
        for (int count = responseStream.Read(buffer, 0, buffer.Length); count > 0; count = responseStream.Read(buffer, 0, buffer.Length))
          stream.Write(buffer, 0, count);
        stream.Flush();
        stream.Close();
        responseStream.Close();
        response.Close();
        httpWebRequest.Abort();
        StreamReader streamReader = new StreamReader(path, Encoding.Unicode);
        string str1 = streamReader.ReadLine();
        string str2 = streamReader.ReadLine();
        string str3 = streamReader.ReadLine();
        string str4 = streamReader.ReadLine();
        streamReader.Close();
        System.IO.File.Delete(path);
        if (str1 == null || str2 == null || str3 == null || str4 == null)
        {
          this.label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
          this.label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
          this.label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
          this.singleButton_Check.Enabled = true;
          this.singleButton_Copy.Enabled = false;
        }
        else if (str1.Split('.').Length != 3)
        {
          this.label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
          this.label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
          this.label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
          this.singleButton_Check.Enabled = true;
          this.singleButton_Copy.Enabled = false;
        }
        else if (str2.Split('.').Length != 3)
        {
          this.label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
          this.label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
          this.label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
          this.singleButton_Check.Enabled = true;
          this.singleButton_Copy.Enabled = false;
        }
        else if (str3 == "" || str4.Length < 32)
        {
          this.label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
          this.label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
          this.label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
          this.singleButton_Check.Enabled = true;
          this.singleButton_Copy.Enabled = false;
        }
        else
        {
          this.label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : " + str1;
          this.label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : " + str2;
          this.label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : " + str3;
          this.m_szDownloadLink = str4;
          this.singleButton_Check.Enabled = true;
          this.singleButton_Copy.Enabled = true;
        }
      }
      catch
      {
        System.IO.File.Delete(path);
        this.label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
        this.label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
        this.label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
        this.singleButton_Check.Enabled = true;
        this.singleButton_Copy.Enabled = false;
      }
    }

    private void singleButton_Copy_ButtonClickNotify(SingleButton objSender)
    {
      Clipboard.Clear();
      Clipboard.SetText(this.m_szDownloadLink);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmCheckUpdate));
      this.label_CodeName = new Label();
      this.label_DriverVersion = new Label();
      this.label_ControlPanelVersion = new Label();
      this.groupBox_VersionFromInternet = new GroupBox();
      this.label_CodeName_Net = new Label();
      this.label_DriverVerion_Net = new Label();
      this.label_ControlPanelVersion_Net = new Label();
      this.singleButton_Check = new SingleButton();
      this.singleButton_Copy = new SingleButton();
      this.groupBox_VersionFromInternet.SuspendLayout();
      this.SuspendLayout();
      this.label_CodeName.AutoSize = true;
      this.label_CodeName.Location = new Point(12, 63);
      this.label_CodeName.Name = "label_CodeName";
      this.label_CodeName.Size = new Size(65, 12);
      this.label_CodeName.TabIndex = 5;
      this.label_CodeName.Text = "$CODE_NAME";
      this.label_DriverVersion.AutoSize = true;
      this.label_DriverVersion.Location = new Point(12, 41);
      this.label_DriverVersion.Name = "label_DriverVersion";
      this.label_DriverVersion.Size = new Size(95, 12);
      this.label_DriverVersion.TabIndex = 4;
      this.label_DriverVersion.Text = "$DRIVER_VERSION";
      this.label_ControlPanelVersion.AutoSize = true;
      this.label_ControlPanelVersion.Location = new Point(12, 19);
      this.label_ControlPanelVersion.Name = "label_ControlPanelVersion";
      this.label_ControlPanelVersion.Size = new Size(131, 12);
      this.label_ControlPanelVersion.TabIndex = 3;
      this.label_ControlPanelVersion.Text = "$CONTROLPANEL_VERSION";
      this.groupBox_VersionFromInternet.Controls.Add((Control) this.label_CodeName_Net);
      this.groupBox_VersionFromInternet.Controls.Add((Control) this.label_DriverVerion_Net);
      this.groupBox_VersionFromInternet.Controls.Add((Control) this.label_ControlPanelVersion_Net);
      this.groupBox_VersionFromInternet.Location = new Point(14, 97);
      this.groupBox_VersionFromInternet.Name = "groupBox_VersionFromInternet";
      this.groupBox_VersionFromInternet.Size = new Size(332, 96);
      this.groupBox_VersionFromInternet.TabIndex = 6;
      this.groupBox_VersionFromInternet.TabStop = false;
      this.groupBox_VersionFromInternet.Text = "$VERSION_FROM_INTERNET";
      this.label_CodeName_Net.AutoSize = true;
      this.label_CodeName_Net.Location = new Point(17, 70);
      this.label_CodeName_Net.Name = "label_CodeName_Net";
      this.label_CodeName_Net.Size = new Size(65, 12);
      this.label_CodeName_Net.TabIndex = 8;
      this.label_CodeName_Net.Text = "$CODE_NAME";
      this.label_DriverVerion_Net.AutoSize = true;
      this.label_DriverVerion_Net.Location = new Point(17, 48);
      this.label_DriverVerion_Net.Name = "label_DriverVerion_Net";
      this.label_DriverVerion_Net.Size = new Size(95, 12);
      this.label_DriverVerion_Net.TabIndex = 7;
      this.label_DriverVerion_Net.Text = "$DRIVER_VERSION";
      this.label_ControlPanelVersion_Net.AutoSize = true;
      this.label_ControlPanelVersion_Net.Location = new Point(17, 26);
      this.label_ControlPanelVersion_Net.Name = "label_ControlPanelVersion_Net";
      this.label_ControlPanelVersion_Net.Size = new Size(131, 12);
      this.label_ControlPanelVersion_Net.TabIndex = 6;
      this.label_ControlPanelVersion_Net.Text = "$CONTROLPANEL_VERSION";
      this.singleButton_Check.BackColor = SystemColors.Control;
      this.singleButton_Check.ButtonText = "$CHECK";
      this.singleButton_Check.Location = new Point(239, 19);
      this.singleButton_Check.Name = "singleButton_Check";
      this.singleButton_Check.Size = new Size(112, 40);
      this.singleButton_Check.TabIndex = 7;
      this.singleButton_Check.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Check_ButtonClickNotify);
      this.singleButton_Copy.BackColor = SystemColors.Control;
      this.singleButton_Copy.ButtonText = "$COPY_DOWNLOAD_LINK";
      this.singleButton_Copy.Location = new Point(14, 199);
      this.singleButton_Copy.Name = "singleButton_Copy";
      this.singleButton_Copy.Size = new Size(166, 40);
      this.singleButton_Copy.TabIndex = 8;
      this.singleButton_Copy.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Copy_ButtonClickNotify);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(363, 250);
      this.Controls.Add((Control) this.singleButton_Copy);
      this.Controls.Add((Control) this.singleButton_Check);
      this.Controls.Add((Control) this.groupBox_VersionFromInternet);
      this.Controls.Add((Control) this.label_CodeName);
      this.Controls.Add((Control) this.label_DriverVersion);
      this.Controls.Add((Control) this.label_ControlPanelVersion);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (frmCheckUpdate);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$CHECK_UPDATE";
      this.groupBox_VersionFromInternet.ResumeLayout(false);
      this.groupBox_VersionFromInternet.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
