using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
  public class frmAbout : Form
  {
    private IContainer components;
    private Label label_ControlPanelVersion;
    private Label label_DriverVersion;
    private Label label_CodeName;
    private Label label_LanVersion;
    private Label label_LanTranslator;
    private Label label_Copyright;
    private Label label_SupportForum;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmAbout));
      this.label_ControlPanelVersion = new Label();
      this.label_DriverVersion = new Label();
      this.label_CodeName = new Label();
      this.label_LanVersion = new Label();
      this.label_LanTranslator = new Label();
      this.label_Copyright = new Label();
      this.label_SupportForum = new Label();
      this.SuspendLayout();
      this.label_ControlPanelVersion.AutoSize = true;
      this.label_ControlPanelVersion.Location = new Point(12, 18);
      this.label_ControlPanelVersion.Name = "label_ControlPanelVersion";
      this.label_ControlPanelVersion.Size = new Size(131, 12);
      this.label_ControlPanelVersion.TabIndex = 0;
      this.label_ControlPanelVersion.Text = "$CONTROLPANEL_VERSION";
      this.label_DriverVersion.AutoSize = true;
      this.label_DriverVersion.Location = new Point(12, 40);
      this.label_DriverVersion.Name = "label_DriverVersion";
      this.label_DriverVersion.Size = new Size(95, 12);
      this.label_DriverVersion.TabIndex = 1;
      this.label_DriverVersion.Text = "$DRIVER_VERSION";
      this.label_CodeName.AutoSize = true;
      this.label_CodeName.Location = new Point(12, 62);
      this.label_CodeName.Name = "label_CodeName";
      this.label_CodeName.Size = new Size(65, 12);
      this.label_CodeName.TabIndex = 2;
      this.label_CodeName.Text = "$CODE_NAME";
      this.label_LanVersion.AutoSize = true;
      this.label_LanVersion.Location = new Point(12, 84);
      this.label_LanVersion.Name = "label_LanVersion";
      this.label_LanVersion.Size = new Size(107, 12);
      this.label_LanVersion.TabIndex = 3;
      this.label_LanVersion.Text = "$LANGUAGE_VERSION";
      this.label_LanTranslator.AutoSize = true;
      this.label_LanTranslator.Location = new Point(12, 106);
      this.label_LanTranslator.Name = "label_LanTranslator";
      this.label_LanTranslator.Size = new Size(125, 12);
      this.label_LanTranslator.TabIndex = 4;
      this.label_LanTranslator.Text = "$LANGUAGE_TRANSLATOR";
      this.label_Copyright.AutoSize = true;
      this.label_Copyright.Location = new Point(12, 140);
      this.label_Copyright.Name = "label_Copyright";
      this.label_Copyright.Size = new Size(65, 12);
      this.label_Copyright.TabIndex = 5;
      this.label_Copyright.Text = "$COPYRIGHT";
      this.label_SupportForum.AutoSize = true;
      this.label_SupportForum.Location = new Point(12, 162);
      this.label_SupportForum.Name = "label_SupportForum";
      this.label_SupportForum.Size = new Size(89, 12);
      this.label_SupportForum.TabIndex = 6;
      this.label_SupportForum.Text = "$SUPPORT_FORUM";
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(410, 190);
      this.Controls.Add((Control) this.label_SupportForum);
      this.Controls.Add((Control) this.label_Copyright);
      this.Controls.Add((Control) this.label_LanTranslator);
      this.Controls.Add((Control) this.label_LanVersion);
      this.Controls.Add((Control) this.label_CodeName);
      this.Controls.Add((Control) this.label_DriverVersion);
      this.Controls.Add((Control) this.label_ControlPanelVersion);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmAbout);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$ABOUT";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public frmAbout()
    {
      this.InitializeComponent();
      this.Text = GlobalMessages.ABOUT;
      this.label_ControlPanelVersion.Text = GlobalMessages.CONTROL_PANEL_VERSION + " : " + 1U.ToString() + "." + 0U.ToString() + "." + 5U.ToString();
      this.label_DriverVersion.Text = GlobalMessages.DRIVER_VERSION + " : " + RuntimeUtils.EffectDriver.GetVersion();
      this.label_CodeName.Text = GlobalMessages.CODE_NAME + " : " + RuntimeUtils.EffectDriver.GetCodeName();
      this.label_LanVersion.Text = GlobalMessages.LANGUAGE_VERSION + " : " + GlobalMessages.LANGUAGE_VERSION_STR;
      this.label_LanTranslator.Text = GlobalMessages.LANGUAGE_TRANSLATOR + " : " + GlobalMessages.LANGUAGE_TRANSLATOR_STR;
      this.label_Copyright.Text = GlobalMessages.COPYRIGHT;
      this.label_SupportForum.Text = GlobalMessages.SUPPORT_FORUM;
    }
  }
}
