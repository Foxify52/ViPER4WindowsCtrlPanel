using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
  public class frmReverbPreset : Form
  {
    private float m_rReverbSize;
    private float m_rReverbPredelay;
    private float m_rReverbDamping;
    private float m_rReverbDensity;
    private float m_rReverbBandwidth = 1f;
    private float m_rReverbDecay;
    private float m_rReverbEarlyMix;
    private float m_rReverbMix;
    private IContainer components;
    private SingleButton singleButton_Cancel;
    private SingleButton singleButton_Load;
    private ButtonBox buttonBox_Preset;

    public float ReverbSize
    {
      get => this.m_rReverbSize;
      set => this.m_rReverbSize = value;
    }

    public float ReverbPredelay
    {
      get => this.m_rReverbPredelay;
      set => this.m_rReverbPredelay = value;
    }

    public float ReverbDamping
    {
      get => this.m_rReverbDamping;
      set => this.m_rReverbDamping = value;
    }

    public float ReverbDensity
    {
      get => this.m_rReverbDensity;
      set => this.m_rReverbDensity = value;
    }

    public float ReverbBandwidth
    {
      get => this.m_rReverbBandwidth;
      set => this.m_rReverbBandwidth = value;
    }

    public float ReverbDecay
    {
      get => this.m_rReverbDecay;
      set => this.m_rReverbDecay = value;
    }

    public float ReverbEarlyMix
    {
      get => this.m_rReverbEarlyMix;
      set => this.m_rReverbEarlyMix = value;
    }

    public float ReverbMix
    {
      get => this.m_rReverbMix;
      set => this.m_rReverbMix = value;
    }

    public frmReverbPreset()
    {
      this.InitializeComponent();
      this.Text = GlobalMessages.REVERB_PRESET;
      this.singleButton_Load.ButtonText = GlobalMessages.LOAD_PRESET;
      this.singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_LIVINGROOM, (object) "0"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_BATHROOM, (object) "1"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_BATHROOM_BATHING, (object) "2"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_BEDROOM, (object) "3"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_THEATER, (object) "4"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_AUDITORIUM, (object) "5"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_UNDERGROUND_PLAZA, (object) "6"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_UNDERGROUND_PARKING, (object) "7"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_SCENE_SHOW, (object) "8"));
      this.buttonBox_Preset.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.PresetSelected);
    }

    private void Apply01Preset()
    {
      this.m_rReverbDamping = 0.3f;
      this.m_rReverbDensity = 0.3f;
      this.m_rReverbBandwidth = 0.96f;
      this.m_rReverbPredelay = 0.2f;
      this.m_rReverbSize = 0.15f;
      this.m_rReverbDecay = 0.41f;
      this.m_rReverbMix = 0.36f;
      this.m_rReverbEarlyMix = 0.51f;
    }

    private void Apply02Preset()
    {
      this.m_rReverbDamping = 0.65f;
      this.m_rReverbDensity = 0.8f;
      this.m_rReverbBandwidth = 1f;
      this.m_rReverbPredelay = 0.0f;
      this.m_rReverbSize = 0.05f;
      this.m_rReverbDecay = 0.26f;
      this.m_rReverbMix = 0.51f;
      this.m_rReverbEarlyMix = 0.59f;
    }

    private void Apply03Preset()
    {
      this.m_rReverbDamping = 0.65f;
      this.m_rReverbDensity = 0.8f;
      this.m_rReverbBandwidth = 0.11f;
      this.m_rReverbPredelay = 0.0f;
      this.m_rReverbSize = 0.05f;
      this.m_rReverbDecay = 0.26f;
      this.m_rReverbMix = 0.51f;
      this.m_rReverbEarlyMix = 0.59f;
    }

    private void Apply04Preset()
    {
      this.m_rReverbDamping = 0.3f;
      this.m_rReverbDensity = 0.3f;
      this.m_rReverbBandwidth = 0.8f;
      this.m_rReverbPredelay = 0.14f;
      this.m_rReverbSize = 0.08f;
      this.m_rReverbDecay = 0.41f;
      this.m_rReverbMix = 0.29f;
      this.m_rReverbEarlyMix = 0.41f;
    }

    private void Apply05Preset()
    {
      this.m_rReverbDamping = 0.65f;
      this.m_rReverbDensity = 0.3f;
      this.m_rReverbBandwidth = 0.25f;
      this.m_rReverbPredelay = 0.0f;
      this.m_rReverbSize = 0.51f;
      this.m_rReverbDecay = 0.06f;
      this.m_rReverbMix = 0.39f;
      this.m_rReverbEarlyMix = 0.5f;
    }

    private void Apply06Preset()
    {
      this.m_rReverbDamping = 0.65f;
      this.m_rReverbDensity = 0.16f;
      this.m_rReverbBandwidth = 1f;
      this.m_rReverbPredelay = 0.37f;
      this.m_rReverbSize = 0.6f;
      this.m_rReverbDecay = 0.26f;
      this.m_rReverbMix = 0.51f;
      this.m_rReverbEarlyMix = 0.59f;
    }

    private void Apply07Preset()
    {
      this.m_rReverbDamping = 0.65f;
      this.m_rReverbDensity = 0.3f;
      this.m_rReverbBandwidth = 0.0f;
      this.m_rReverbPredelay = 0.0f;
      this.m_rReverbSize = 1f;
      this.m_rReverbDecay = 0.0f;
      this.m_rReverbMix = 0.39f;
      this.m_rReverbEarlyMix = 0.5f;
    }

    private void Apply08Preset()
    {
      this.m_rReverbDamping = 0.65f;
      this.m_rReverbDensity = 0.16f;
      this.m_rReverbBandwidth = 0.91f;
      this.m_rReverbPredelay = 0.18f;
      this.m_rReverbSize = 1f;
      this.m_rReverbDecay = 0.0f;
      this.m_rReverbMix = 0.59f;
      this.m_rReverbEarlyMix = 0.33f;
    }

    private void Apply09Preset()
    {
      this.m_rReverbDamping = 0.65f;
      this.m_rReverbDensity = 0.33f;
      this.m_rReverbBandwidth = 0.15f;
      this.m_rReverbPredelay = 0.0f;
      this.m_rReverbSize = 0.81f;
      this.m_rReverbDecay = 0.0f;
      this.m_rReverbMix = 0.4f;
      this.m_rReverbEarlyMix = 0.25f;
    }

    private void PresetSelected(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem.Tag == null || !(itCurrItem.Tag is string))
        return;
      string tag = itCurrItem.Tag as string;
      if (tag == "")
        return;
      int result = -1;
      if (!int.TryParse(tag, out result))
        return;
      switch (result)
      {
        case 0:
          this.Apply01Preset();
          break;
        case 1:
          this.Apply02Preset();
          break;
        case 2:
          this.Apply03Preset();
          break;
        case 3:
          this.Apply04Preset();
          break;
        case 4:
          this.Apply05Preset();
          break;
        case 5:
          this.Apply06Preset();
          break;
        case 6:
          this.Apply07Preset();
          break;
        case 7:
          this.Apply08Preset();
          break;
        case 8:
          this.Apply09Preset();
          break;
      }
    }

    private void singleButton_Load_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.OK;

    private void singleButton_Cancel_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.Cancel;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmReverbPreset));
      this.singleButton_Cancel = new SingleButton();
      this.singleButton_Load = new SingleButton();
      this.buttonBox_Preset = new ButtonBox();
      this.SuspendLayout();
      this.singleButton_Cancel.BackColor = SystemColors.Control;
      this.singleButton_Cancel.ButtonText = "$CANCEL";
      this.singleButton_Cancel.Location = new Point(193, 303);
      this.singleButton_Cancel.Name = "singleButton_Cancel";
      this.singleButton_Cancel.Size = new Size(112, 40);
      this.singleButton_Cancel.TabIndex = 5;
      this.singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Cancel_ButtonClickNotify);
      this.singleButton_Load.BackColor = SystemColors.Control;
      this.singleButton_Load.ButtonText = "$LOAD_PRESET";
      this.singleButton_Load.Location = new Point(193, 12);
      this.singleButton_Load.Name = "singleButton_Load";
      this.singleButton_Load.Size = new Size(112, 40);
      this.singleButton_Load.TabIndex = 4;
      this.singleButton_Load.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Load_ButtonClickNotify);
      this.buttonBox_Preset.BackColor = SystemColors.Control;
      this.buttonBox_Preset.Location = new Point(12, 12);
      this.buttonBox_Preset.Name = "buttonBox_Preset";
      this.buttonBox_Preset.Size = new Size(175, 331);
      this.buttonBox_Preset.TabIndex = 3;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(318, 355);
      this.Controls.Add((Control) this.singleButton_Cancel);
      this.Controls.Add((Control) this.singleButton_Load);
      this.Controls.Add((Control) this.buttonBox_Preset);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmReverbPreset);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$REVERB_PRESET";
      this.ResumeLayout(false);
    }
  }
}
