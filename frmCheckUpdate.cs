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
    public class FrmCheckUpdate : Form
    {
        private const string m_szCheckUpdateLink = "http://vipersaudio.com/swupdate/viper4windows/version.bin";
        private string m_szDownloadLink = "";
        private readonly IContainer components;
        private Label label_CodeName;
        private Label label_DriverVersion;
        private Label label_ControlPanelVersion;
        private GroupBox groupBox_VersionFromInternet;
        private Label label_CodeName_Net;
        private Label label_DriverVerion_Net;
        private Label label_ControlPanelVersion_Net;
        private SingleButton singleButton_Check;
        private SingleButton singleButton_Copy;

        public FrmCheckUpdate()
        {
            InitializeComponent();
            Text = GlobalMessages.CHECK_UPDATE;
            label_ControlPanelVersion.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : " + 1U.ToString() + "." + 0U.ToString() + "." + 5U.ToString();
            label_DriverVersion.Text = GlobalMessages.DRIVER_VERSION + " : " + RuntimeUtils.EffectDriver.GetVersion();
            label_CodeName.Text = GlobalMessages.CODE_NAME + " : " + RuntimeUtils.EffectDriver.GetCodeName();
            groupBox_VersionFromInternet.Text = GlobalMessages.VERSION_FROM_INTERNET;
            label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
            label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
            label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
            singleButton_Check.ButtonText = GlobalMessages.CHECK;
            singleButton_Copy.ButtonText = GlobalMessages.COPY_DOWNLOAD_LINK;
            singleButton_Copy.Enabled = false;
        }

        private void SingleButton_Check_ButtonClickNotify(SingleButton objSender)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = baseDirectory.EndsWith("\\") ? baseDirectory + "version.txt" : baseDirectory + "\\version.txt";
            try
            {
                singleButton_Check.Enabled = false;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://vipersaudio.com/swupdate/viper4windows/version.bin");
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                Stream stream = new FileStream(path, FileMode.Create);
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
                File.Delete(path);
                if (str1 == null || str2 == null || str3 == null || str4 == null)
                {
                    label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
                    label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
                    label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
                    singleButton_Check.Enabled = true;
                    singleButton_Copy.Enabled = false;
                }
                else if (str1.Split('.').Length != 3)
                {
                    label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
                    label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
                    label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
                    singleButton_Check.Enabled = true;
                    singleButton_Copy.Enabled = false;
                }
                else if (str2.Split('.').Length != 3)
                {
                    label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
                    label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
                    label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
                    singleButton_Check.Enabled = true;
                    singleButton_Copy.Enabled = false;
                }
                else if (str3 == "" || str4.Length < 32)
                {
                    label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
                    label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
                    label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
                    singleButton_Check.Enabled = true;
                    singleButton_Copy.Enabled = false;
                }
                else
                {
                    label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : " + str1;
                    label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : " + str2;
                    label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : " + str3;
                    m_szDownloadLink = str4;
                    singleButton_Check.Enabled = true;
                    singleButton_Copy.Enabled = true;
                }
            }
            catch
            {
                File.Delete(path);
                label_ControlPanelVersion_Net.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : N/A";
                label_DriverVerion_Net.Text = GlobalMessages.DRIVER_VERSION + " : N/A";
                label_CodeName_Net.Text = GlobalMessages.CODE_NAME + " : N/A";
                singleButton_Check.Enabled = true;
                singleButton_Copy.Enabled = false;
            }
        }

        private void SingleButton_Copy_ButtonClickNotify(SingleButton objSender)
        {
            Clipboard.Clear();
            Clipboard.SetText(m_szDownloadLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmCheckUpdate));
            label_CodeName = new Label();
            label_DriverVersion = new Label();
            label_ControlPanelVersion = new Label();
            groupBox_VersionFromInternet = new GroupBox();
            label_CodeName_Net = new Label();
            label_DriverVerion_Net = new Label();
            label_ControlPanelVersion_Net = new Label();
            singleButton_Check = new SingleButton();
            singleButton_Copy = new SingleButton();
            groupBox_VersionFromInternet.SuspendLayout();
            SuspendLayout();
            label_CodeName.AutoSize = true;
            label_CodeName.Location = new Point(12, 63);
            label_CodeName.Name = "label_CodeName";
            label_CodeName.Size = new Size(65, 12);
            label_CodeName.TabIndex = 5;
            label_CodeName.Text = "$CODE_NAME";
            label_DriverVersion.AutoSize = true;
            label_DriverVersion.Location = new Point(12, 41);
            label_DriverVersion.Name = "label_DriverVersion";
            label_DriverVersion.Size = new Size(95, 12);
            label_DriverVersion.TabIndex = 4;
            label_DriverVersion.Text = "$DRIVER_VERSION";
            label_ControlPanelVersion.AutoSize = true;
            label_ControlPanelVersion.Location = new Point(12, 19);
            label_ControlPanelVersion.Name = "label_ControlPanelVersion";
            label_ControlPanelVersion.Size = new Size(131, 12);
            label_ControlPanelVersion.TabIndex = 3;
            label_ControlPanelVersion.Text = "$CONTROLPANEL_VERSION";
            groupBox_VersionFromInternet.Controls.Add(label_CodeName_Net);
            groupBox_VersionFromInternet.Controls.Add(label_DriverVerion_Net);
            groupBox_VersionFromInternet.Controls.Add(label_ControlPanelVersion_Net);
            groupBox_VersionFromInternet.Location = new Point(14, 97);
            groupBox_VersionFromInternet.Name = "groupBox_VersionFromInternet";
            groupBox_VersionFromInternet.Size = new Size(332, 96);
            groupBox_VersionFromInternet.TabIndex = 6;
            groupBox_VersionFromInternet.TabStop = false;
            groupBox_VersionFromInternet.Text = "$VERSION_FROM_INTERNET";
            label_CodeName_Net.AutoSize = true;
            label_CodeName_Net.Location = new Point(17, 70);
            label_CodeName_Net.Name = "label_CodeName_Net";
            label_CodeName_Net.Size = new Size(65, 12);
            label_CodeName_Net.TabIndex = 8;
            label_CodeName_Net.Text = "$CODE_NAME";
            label_DriverVerion_Net.AutoSize = true;
            label_DriverVerion_Net.Location = new Point(17, 48);
            label_DriverVerion_Net.Name = "label_DriverVerion_Net";
            label_DriverVerion_Net.Size = new Size(95, 12);
            label_DriverVerion_Net.TabIndex = 7;
            label_DriverVerion_Net.Text = "$DRIVER_VERSION";
            label_ControlPanelVersion_Net.AutoSize = true;
            label_ControlPanelVersion_Net.Location = new Point(17, 26);
            label_ControlPanelVersion_Net.Name = "label_ControlPanelVersion_Net";
            label_ControlPanelVersion_Net.Size = new Size(131, 12);
            label_ControlPanelVersion_Net.TabIndex = 6;
            label_ControlPanelVersion_Net.Text = "$CONTROLPANEL_VERSION";
            singleButton_Check.BackColor = SystemColors.Control;
            singleButton_Check.ButtonText = "$CHECK";
            singleButton_Check.Location = new Point(239, 19);
            singleButton_Check.Name = "singleButton_Check";
            singleButton_Check.Size = new Size(112, 40);
            singleButton_Check.TabIndex = 7;
            singleButton_Check.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Check_ButtonClickNotify);
            singleButton_Copy.BackColor = SystemColors.Control;
            singleButton_Copy.ButtonText = "$COPY_DOWNLOAD_LINK";
            singleButton_Copy.Location = new Point(14, 199);
            singleButton_Copy.Name = "singleButton_Copy";
            singleButton_Copy.Size = new Size(166, 40);
            singleButton_Copy.TabIndex = 8;
            singleButton_Copy.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Copy_ButtonClickNotify);
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 250);
            Controls.Add(singleButton_Copy);
            Controls.Add(singleButton_Check);
            Controls.Add(groupBox_VersionFromInternet);
            Controls.Add(label_CodeName);
            Controls.Add(label_DriverVersion);
            Controls.Add(label_ControlPanelVersion);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = nameof(FrmCheckUpdate);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$CHECK_UPDATE";
            groupBox_VersionFromInternet.ResumeLayout(false);
            groupBox_VersionFromInternet.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
