using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
  public class frmEQPreset : Form
  {
    private readonly float[] m_faEQPreset_Flat = new float[18]
    {
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f
    };
    private readonly float[] m_faEQPreset_SuperBass = new float[18]
    {
      3.5f,
      2.5f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f
    };
    private readonly float[] m_faEQPreset_SoftBass = new float[18]
    {
      3.5f,
      1f,
      0.5f,
      0.5f,
      0.7f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1f,
      1.1f,
      1.1f,
      1.2f,
      1.2f,
      1.3f,
      1.4f,
      1f
    };
    private readonly float[] m_faEQPreset_Rock = new float[18]
    {
      2f,
      3f,
      2f,
      0.7f,
      0.7f,
      0.8f,
      1f,
      1f,
      1f,
      1f,
      0.8f,
      0.8f,
      1.3f,
      2f,
      2f,
      1.5f,
      1f,
      1f
    };
    private readonly float[] m_faEQPreset_RandB = new float[18]
    {
      1f,
      1.5f,
      2f,
      2.2f,
      0.8f,
      0.8f,
      1f,
      1.4f,
      0.8f,
      1f,
      1.2f,
      1.4f,
      1.6f,
      2f,
      0.8f,
      1f,
      1.4f,
      1.4f
    };
    private readonly float[] m_faEQPreset_Classic = new float[18]
    {
      1f,
      1.2f,
      1.8f,
      2.2f,
      2.5f,
      3f,
      2f,
      0.8f,
      0.7f,
      0.7f,
      0.7f,
      0.7f,
      0.8f,
      1f,
      1.5f,
      1.8f,
      2f,
      2f
    };
    private readonly float[] m_faEQPreset_Pop = new float[18]
    {
      2f,
      1.8f,
      1.7f,
      1.6f,
      1.5f,
      1.4f,
      1.2f,
      0.8f,
      0.7f,
      0.6f,
      0.7f,
      0.8f,
      1f,
      1.2f,
      1.4f,
      1.6f,
      1.8f,
      1.8f
    };
    private readonly float[] m_faEQPreset_Jazz = new float[18]
    {
      1f,
      1f,
      1f,
      1f,
      1.5f,
      1.8f,
      2f,
      2f,
      2f,
      1.6f,
      1f,
      0.8f,
      0.6f,
      0.9f,
      1.2f,
      1.2f,
      1.3f,
      1.3f
    };
    private readonly float[] m_faEQPreset_Blues = new float[18]
    {
      0.7f,
      0.8f,
      0.9f,
      1f,
      1.2f,
      1.5f,
      1.2f,
      1f,
      1f,
      1f,
      0.8f,
      0.8f,
      0.8f,
      0.7f,
      0.7f,
      0.7f,
      0.65f,
      0.5f
    };
    private readonly float[] m_faEQPreset_Electronic = new float[18]
    {
      1.8f,
      1f,
      0.8f,
      0.6f,
      0.4f,
      0.4f,
      0.6f,
      0.8f,
      1f,
      1f,
      0.8f,
      0.8f,
      1.2f,
      1.4f,
      1.6f,
      1.6f,
      1.6f,
      1.6f
    };
    private readonly float[] m_faEQPreset_Vocal = new float[18]
    {
      0.8f,
      0.8f,
      0.8f,
      0.8f,
      0.8f,
      0.8f,
      1f,
      1.2f,
      1.6f,
      2f,
      2f,
      1.6f,
      1.4f,
      1.2f,
      1f,
      0.8f,
      0.6f,
      0.6f
    };
    private float[] m_faEQPreset = new float[18];
    private IContainer components;
    private ButtonBox buttonBox_Preset;
    private SingleButton singleButton_Load;
    private SingleButton singleButton_Cancel;

    public frmEQPreset()
    {
      this.InitializeComponent();
      this.Text = GlobalMessages.EQUALIZER_PRESET;
      this.singleButton_Load.ButtonText = GlobalMessages.LOAD_PRESET;
      this.singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_FLAT, (object) "0"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_SUPERBASS, (object) "1"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_SOFTBASS, (object) "2"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_ROCK, (object) "3"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_RANDB, (object) "4"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_CLASSIC, (object) "5"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_POP, (object) "6"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_JAZZ, (object) "7"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_BLUES, (object) "8"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_ELECTRONIC, (object) "9"));
      this.buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_VOCAL, (object) "10"));
      this.buttonBox_Preset.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.PresetSelected);
      for (int index = 0; index < this.m_faEQPreset.Length; ++index)
        this.m_faEQPreset[index] = 1f;
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
          Array.Copy((Array) this.m_faEQPreset_Flat, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 1:
          Array.Copy((Array) this.m_faEQPreset_SuperBass, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 2:
          Array.Copy((Array) this.m_faEQPreset_SoftBass, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 3:
          Array.Copy((Array) this.m_faEQPreset_Rock, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 4:
          Array.Copy((Array) this.m_faEQPreset_RandB, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 5:
          Array.Copy((Array) this.m_faEQPreset_Classic, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 6:
          Array.Copy((Array) this.m_faEQPreset_Pop, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 7:
          Array.Copy((Array) this.m_faEQPreset_Jazz, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 8:
          Array.Copy((Array) this.m_faEQPreset_Blues, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 9:
          Array.Copy((Array) this.m_faEQPreset_Electronic, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
        case 10:
          Array.Copy((Array) this.m_faEQPreset_Vocal, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
          break;
      }
    }

    public void SetPreset(float[] faPreset)
    {
      if (faPreset == null || faPreset.Length != this.m_faEQPreset.Length)
        return;
      Array.Copy((Array) faPreset, (Array) this.m_faEQPreset, this.m_faEQPreset.Length);
    }

    public float[] GetPreset() => this.m_faEQPreset;

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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmEQPreset));
      this.buttonBox_Preset = new ButtonBox();
      this.singleButton_Load = new SingleButton();
      this.singleButton_Cancel = new SingleButton();
      this.SuspendLayout();
      this.buttonBox_Preset.BackColor = SystemColors.Control;
      this.buttonBox_Preset.Location = new Point(12, 12);
      this.buttonBox_Preset.Name = "buttonBox_Preset";
      this.buttonBox_Preset.Size = new Size(175, 331);
      this.buttonBox_Preset.TabIndex = 0;
      this.singleButton_Load.BackColor = SystemColors.Control;
      this.singleButton_Load.ButtonText = "$LOAD_PRESET";
      this.singleButton_Load.Location = new Point(193, 12);
      this.singleButton_Load.Name = "singleButton_Load";
      this.singleButton_Load.Size = new Size(112, 40);
      this.singleButton_Load.TabIndex = 1;
      this.singleButton_Load.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Load_ButtonClickNotify);
      this.singleButton_Cancel.BackColor = SystemColors.Control;
      this.singleButton_Cancel.ButtonText = "$CANCEL";
      this.singleButton_Cancel.Location = new Point(193, 303);
      this.singleButton_Cancel.Name = "singleButton_Cancel";
      this.singleButton_Cancel.Size = new Size(112, 40);
      this.singleButton_Cancel.TabIndex = 2;
      this.singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Cancel_ButtonClickNotify);
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
      this.Name = nameof (frmEQPreset);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$EQUALIZER_PRESET";
      this.ResumeLayout(false);
    }
  }
}
