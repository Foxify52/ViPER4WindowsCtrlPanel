using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
    public class FrmAbout : Form
    {
        private readonly IContainer components;
        private Label label_ControlPanelVersion;
        private Label label_DriverVersion;
        private Label label_CodeName;
        private Label label_LanVersion;
        private Label label_LanTranslator;
        private Label label_Copyright;
        private Label label_SupportForum;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmAbout));
            label_ControlPanelVersion = new Label();
            label_DriverVersion = new Label();
            label_CodeName = new Label();
            label_LanVersion = new Label();
            label_LanTranslator = new Label();
            label_Copyright = new Label();
            label_SupportForum = new Label();
            SuspendLayout();
            label_ControlPanelVersion.AutoSize = true;
            label_ControlPanelVersion.Location = new Point(12, 18);
            label_ControlPanelVersion.Name = "label_ControlPanelVersion";
            label_ControlPanelVersion.Size = new Size(131, 12);
            label_ControlPanelVersion.TabIndex = 0;
            label_ControlPanelVersion.Text = "$CONTROLPANEL_VERSION";
            label_DriverVersion.AutoSize = true;
            label_DriverVersion.Location = new Point(12, 40);
            label_DriverVersion.Name = "label_DriverVersion";
            label_DriverVersion.Size = new Size(95, 12);
            label_DriverVersion.TabIndex = 1;
            label_DriverVersion.Text = "$DRIVER_VERSION";
            label_CodeName.AutoSize = true;
            label_CodeName.Location = new Point(12, 62);
            label_CodeName.Name = "label_CodeName";
            label_CodeName.Size = new Size(65, 12);
            label_CodeName.TabIndex = 2;
            label_CodeName.Text = "$CODE_NAME";
            label_LanVersion.AutoSize = true;
            label_LanVersion.Location = new Point(12, 84);
            label_LanVersion.Name = "label_LanVersion";
            label_LanVersion.Size = new Size(107, 12);
            label_LanVersion.TabIndex = 3;
            label_LanVersion.Text = "$LANGUAGE_VERSION";
            label_LanTranslator.AutoSize = true;
            label_LanTranslator.Location = new Point(12, 106);
            label_LanTranslator.Name = "label_LanTranslator";
            label_LanTranslator.Size = new Size(125, 12);
            label_LanTranslator.TabIndex = 4;
            label_LanTranslator.Text = "$LANGUAGE_TRANSLATOR";
            label_Copyright.AutoSize = true;
            label_Copyright.Location = new Point(12, 140);
            label_Copyright.Name = "label_Copyright";
            label_Copyright.Size = new Size(65, 12);
            label_Copyright.TabIndex = 5;
            label_Copyright.Text = "$COPYRIGHT";
            label_SupportForum.AutoSize = true;
            label_SupportForum.Location = new Point(12, 162);
            label_SupportForum.Name = "label_SupportForum";
            label_SupportForum.Size = new Size(89, 12);
            label_SupportForum.TabIndex = 6;
            label_SupportForum.Text = "$SUPPORT_FORUM";
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 190);
            Controls.Add(label_SupportForum);
            Controls.Add(label_Copyright);
            Controls.Add(label_LanTranslator);
            Controls.Add(label_LanVersion);
            Controls.Add(label_CodeName);
            Controls.Add(label_DriverVersion);
            Controls.Add(label_ControlPanelVersion);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = nameof(FrmAbout);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$ABOUT";
            ResumeLayout(false);
            PerformLayout();
        }

        public FrmAbout()
        {
            InitializeComponent();
            Text = GlobalMessages.ABOUT;
            label_ControlPanelVersion.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : " + 1U.ToString() + "." + 0U.ToString() + "." + 5U.ToString();
            label_DriverVersion.Text = GlobalMessages.DRIVER_VERSION + " : " + RuntimeUtils.EffectDriver.GetVersion();
            label_CodeName.Text = GlobalMessages.CODE_NAME + " : " + RuntimeUtils.EffectDriver.GetCodeName();
            label_LanVersion.Text = GlobalMessages.LANGUAGE_VERSION + " : " + GlobalMessages.LANGUAGE_VERSION_STR;
            label_LanTranslator.Text = GlobalMessages.LANGUAGE_TRANSLATOR + " : " + GlobalMessages.LANGUAGE_TRANSLATOR_STR;
            label_Copyright.Text = GlobalMessages.COPYRIGHT;
            label_SupportForum.Text = GlobalMessages.SUPPORT_FORUM;
        }
    }
}
