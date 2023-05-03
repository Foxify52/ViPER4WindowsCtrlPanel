using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
  public class frmEqualizer : Form
  {
    private IContainer components;
    private Label label_Equalizer_Enable;
    private OnOffSwitch onOffSwitch_Equalizer;
    private VSlider vSlider1;
    private VSlider vSlider2;
    private VSlider vSlider3;
    private VSlider vSlider4;
    private VSlider vSlider5;
    private VSlider vSlider6;
    private VSlider vSlider7;
    private VSlider vSlider8;
    private VSlider vSlider9;
    private VSlider vSlider10;
    private VSlider vSlider11;
    private VSlider vSlider12;
    private VSlider vSlider13;
    private VSlider vSlider14;
    private VSlider vSlider15;
    private VSlider vSlider16;
    private VSlider vSlider17;
    private VSlider vSlider18;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label14;
    private Label label15;
    private Label label16;
    private Label label17;
    private Label label18;
    private SingleButton singleButton_Preset;
    private SingleButton singleButton_OK;
    private Label label_dB_Max;
    private Label label_dB_Min;
    private Label label_dB_Zero;
    private CheckBox checkBox_RealtimeAdjust;
    private bool m_bEQEnabled;
    private float[] m_faEQBands = new float[18];
    private List<VSlider> m_ctlEQBandList = new List<VSlider>();
    private RuntimeUtils.ConfigProxy._ParamOfBaseSystem m_paramBaseSystem;
    private RuntimeUtils.ConfigProxy._ParamOfMusicMode m_paramMusicMode;
    private RuntimeUtils.ConfigProxy._ParamOfMovieMode m_paramMovieMode;
    private RuntimeUtils.ConfigProxy._ParamOfFreestyle m_paramFreestyle;
    private RuntimeUtils.ConfigProxy m_cpConfigProxy;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmEqualizer));
      this.label_Equalizer_Enable = new Label();
      this.onOffSwitch_Equalizer = new OnOffSwitch();
      this.vSlider1 = new VSlider();
      this.vSlider2 = new VSlider();
      this.vSlider3 = new VSlider();
      this.vSlider4 = new VSlider();
      this.vSlider5 = new VSlider();
      this.vSlider6 = new VSlider();
      this.vSlider7 = new VSlider();
      this.vSlider8 = new VSlider();
      this.vSlider9 = new VSlider();
      this.vSlider10 = new VSlider();
      this.vSlider11 = new VSlider();
      this.vSlider12 = new VSlider();
      this.vSlider13 = new VSlider();
      this.vSlider14 = new VSlider();
      this.vSlider15 = new VSlider();
      this.vSlider16 = new VSlider();
      this.vSlider17 = new VSlider();
      this.vSlider18 = new VSlider();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.label12 = new Label();
      this.label13 = new Label();
      this.label14 = new Label();
      this.label15 = new Label();
      this.label16 = new Label();
      this.label17 = new Label();
      this.label18 = new Label();
      this.singleButton_Preset = new SingleButton();
      this.singleButton_OK = new SingleButton();
      this.label_dB_Max = new Label();
      this.label_dB_Min = new Label();
      this.label_dB_Zero = new Label();
      this.checkBox_RealtimeAdjust = new CheckBox();
      this.SuspendLayout();
      this.label_Equalizer_Enable.AutoSize = true;
      this.label_Equalizer_Enable.Location = new Point(24, 22);
      this.label_Equalizer_Enable.Name = "label_Equalizer_Enable";
      this.label_Equalizer_Enable.Size = new Size(47, 12);
      this.label_Equalizer_Enable.TabIndex = 0;
      this.label_Equalizer_Enable.Text = "$ENABLE";
      this.onOffSwitch_Equalizer.BackColor = Color.Transparent;
      this.onOffSwitch_Equalizer.Location = new Point(24, 37);
      this.onOffSwitch_Equalizer.Name = "onOffSwitch_Equalizer";
      this.onOffSwitch_Equalizer.Size = new Size(107, 28);
      this.onOffSwitch_Equalizer.SwitchedOn = false;
      this.onOffSwitch_Equalizer.TabIndex = 1;
      this.vSlider1.BackColor = SystemColors.Control;
      this.vSlider1.Location = new Point(53, 83);
      this.vSlider1.MoveDelta = 1U;
      this.vSlider1.Name = "vSlider1";
      this.vSlider1.Position = 50U;
      this.vSlider1.Size = new Size(47, 204);
      this.vSlider1.TabIndex = 2;
      this.vSlider2.BackColor = SystemColors.Control;
      this.vSlider2.Location = new Point(106, 83);
      this.vSlider2.MoveDelta = 1U;
      this.vSlider2.Name = "vSlider2";
      this.vSlider2.Position = 50U;
      this.vSlider2.Size = new Size(47, 204);
      this.vSlider2.TabIndex = 3;
      this.vSlider3.BackColor = SystemColors.Control;
      this.vSlider3.Location = new Point(159, 83);
      this.vSlider3.MoveDelta = 1U;
      this.vSlider3.Name = "vSlider3";
      this.vSlider3.Position = 50U;
      this.vSlider3.Size = new Size(47, 204);
      this.vSlider3.TabIndex = 4;
      this.vSlider4.BackColor = SystemColors.Control;
      this.vSlider4.Location = new Point(212, 83);
      this.vSlider4.MoveDelta = 1U;
      this.vSlider4.Name = "vSlider4";
      this.vSlider4.Position = 50U;
      this.vSlider4.Size = new Size(47, 204);
      this.vSlider4.TabIndex = 5;
      this.vSlider5.BackColor = SystemColors.Control;
      this.vSlider5.Location = new Point(265, 83);
      this.vSlider5.MoveDelta = 1U;
      this.vSlider5.Name = "vSlider5";
      this.vSlider5.Position = 50U;
      this.vSlider5.Size = new Size(47, 204);
      this.vSlider5.TabIndex = 6;
      this.vSlider6.BackColor = SystemColors.Control;
      this.vSlider6.Location = new Point(318, 83);
      this.vSlider6.MoveDelta = 1U;
      this.vSlider6.Name = "vSlider6";
      this.vSlider6.Position = 50U;
      this.vSlider6.Size = new Size(47, 204);
      this.vSlider6.TabIndex = 7;
      this.vSlider7.BackColor = SystemColors.Control;
      this.vSlider7.Location = new Point(371, 83);
      this.vSlider7.MoveDelta = 1U;
      this.vSlider7.Name = "vSlider7";
      this.vSlider7.Position = 50U;
      this.vSlider7.Size = new Size(47, 204);
      this.vSlider7.TabIndex = 8;
      this.vSlider8.BackColor = SystemColors.Control;
      this.vSlider8.Location = new Point(424, 83);
      this.vSlider8.MoveDelta = 1U;
      this.vSlider8.Name = "vSlider8";
      this.vSlider8.Position = 50U;
      this.vSlider8.Size = new Size(47, 204);
      this.vSlider8.TabIndex = 9;
      this.vSlider9.BackColor = SystemColors.Control;
      this.vSlider9.Location = new Point(477, 83);
      this.vSlider9.MoveDelta = 1U;
      this.vSlider9.Name = "vSlider9";
      this.vSlider9.Position = 50U;
      this.vSlider9.Size = new Size(47, 204);
      this.vSlider9.TabIndex = 10;
      this.vSlider10.BackColor = SystemColors.Control;
      this.vSlider10.Location = new Point(530, 83);
      this.vSlider10.MoveDelta = 1U;
      this.vSlider10.Name = "vSlider10";
      this.vSlider10.Position = 50U;
      this.vSlider10.Size = new Size(47, 204);
      this.vSlider10.TabIndex = 11;
      this.vSlider11.BackColor = SystemColors.Control;
      this.vSlider11.Location = new Point(583, 83);
      this.vSlider11.MoveDelta = 1U;
      this.vSlider11.Name = "vSlider11";
      this.vSlider11.Position = 50U;
      this.vSlider11.Size = new Size(47, 204);
      this.vSlider11.TabIndex = 12;
      this.vSlider12.BackColor = SystemColors.Control;
      this.vSlider12.Location = new Point(636, 83);
      this.vSlider12.MoveDelta = 1U;
      this.vSlider12.Name = "vSlider12";
      this.vSlider12.Position = 50U;
      this.vSlider12.Size = new Size(47, 204);
      this.vSlider12.TabIndex = 13;
      this.vSlider13.BackColor = SystemColors.Control;
      this.vSlider13.Location = new Point(689, 83);
      this.vSlider13.MoveDelta = 1U;
      this.vSlider13.Name = "vSlider13";
      this.vSlider13.Position = 50U;
      this.vSlider13.Size = new Size(47, 204);
      this.vSlider13.TabIndex = 14;
      this.vSlider14.BackColor = SystemColors.Control;
      this.vSlider14.Location = new Point(742, 83);
      this.vSlider14.MoveDelta = 1U;
      this.vSlider14.Name = "vSlider14";
      this.vSlider14.Position = 50U;
      this.vSlider14.Size = new Size(47, 204);
      this.vSlider14.TabIndex = 15;
      this.vSlider15.BackColor = SystemColors.Control;
      this.vSlider15.Location = new Point(795, 83);
      this.vSlider15.MoveDelta = 1U;
      this.vSlider15.Name = "vSlider15";
      this.vSlider15.Position = 50U;
      this.vSlider15.Size = new Size(47, 204);
      this.vSlider15.TabIndex = 16;
      this.vSlider16.BackColor = SystemColors.Control;
      this.vSlider16.Location = new Point(848, 83);
      this.vSlider16.MoveDelta = 1U;
      this.vSlider16.Name = "vSlider16";
      this.vSlider16.Position = 50U;
      this.vSlider16.Size = new Size(47, 204);
      this.vSlider16.TabIndex = 17;
      this.vSlider17.BackColor = SystemColors.Control;
      this.vSlider17.Location = new Point(901, 83);
      this.vSlider17.MoveDelta = 1U;
      this.vSlider17.Name = "vSlider17";
      this.vSlider17.Position = 50U;
      this.vSlider17.Size = new Size(47, 204);
      this.vSlider17.TabIndex = 18;
      this.vSlider18.BackColor = SystemColors.Control;
      this.vSlider18.Location = new Point(954, 83);
      this.vSlider18.MoveDelta = 1U;
      this.vSlider18.Name = "vSlider18";
      this.vSlider18.Position = 50U;
      this.vSlider18.Size = new Size(47, 204);
      this.vSlider18.TabIndex = 19;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(69, 290);
      this.label1.Name = "label1";
      this.label1.Size = new Size(17, 12);
      this.label1.TabIndex = 20;
      this.label1.Text = "65";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(121, 290);
      this.label2.Name = "label2";
      this.label2.Size = new Size(17, 12);
      this.label2.TabIndex = 21;
      this.label2.Text = "93";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(173, 290);
      this.label3.Name = "label3";
      this.label3.Size = new Size(23, 12);
      this.label3.TabIndex = 22;
      this.label3.Text = "131";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(225, 290);
      this.label4.Name = "label4";
      this.label4.Size = new Size(23, 12);
      this.label4.TabIndex = 23;
      this.label4.Text = "185";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(279, 290);
      this.label5.Name = "label5";
      this.label5.Size = new Size(23, 12);
      this.label5.TabIndex = 24;
      this.label5.Text = "262";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(332, 290);
      this.label6.Name = "label6";
      this.label6.Size = new Size(23, 12);
      this.label6.TabIndex = 25;
      this.label6.Text = "370";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(384, 290);
      this.label7.Name = "label7";
      this.label7.Size = new Size(23, 12);
      this.label7.TabIndex = 26;
      this.label7.Text = "523";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(437, 290);
      this.label8.Name = "label8";
      this.label8.Size = new Size(23, 12);
      this.label8.TabIndex = 27;
      this.label8.Text = "740";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(487, 290);
      this.label9.Name = "label9";
      this.label9.Size = new Size(29, 12);
      this.label9.TabIndex = 28;
      this.label9.Text = "1.0k";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(540, 290);
      this.label10.Name = "label10";
      this.label10.Size = new Size(29, 12);
      this.label10.TabIndex = 29;
      this.label10.Text = "1.5k";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(593, 290);
      this.label11.Name = "label11";
      this.label11.Size = new Size(29, 12);
      this.label11.TabIndex = 30;
      this.label11.Text = "2.1k";
      this.label12.AutoSize = true;
      this.label12.Location = new Point(646, 290);
      this.label12.Name = "label12";
      this.label12.Size = new Size(29, 12);
      this.label12.TabIndex = 31;
      this.label12.Text = "3.0k";
      this.label13.AutoSize = true;
      this.label13.Location = new Point(699, 290);
      this.label13.Name = "label13";
      this.label13.Size = new Size(29, 12);
      this.label13.TabIndex = 32;
      this.label13.Text = "4.2k";
      this.label14.AutoSize = true;
      this.label14.Location = new Point(752, 290);
      this.label14.Name = "label14";
      this.label14.Size = new Size(29, 12);
      this.label14.TabIndex = 33;
      this.label14.Text = "6.0k";
      this.label15.AutoSize = true;
      this.label15.Location = new Point(806, 290);
      this.label15.Name = "label15";
      this.label15.Size = new Size(29, 12);
      this.label15.TabIndex = 34;
      this.label15.Text = "8.4k";
      this.label16.AutoSize = true;
      this.label16.Location = new Point(857, 290);
      this.label16.Name = "label16";
      this.label16.Size = new Size(35, 12);
      this.label16.TabIndex = 35;
      this.label16.Text = "11.8k";
      this.label17.AutoSize = true;
      this.label17.Location = new Point(910, 290);
      this.label17.Name = "label17";
      this.label17.Size = new Size(35, 12);
      this.label17.TabIndex = 36;
      this.label17.Text = "16.7k";
      this.label18.AutoSize = true;
      this.label18.Location = new Point(967, 290);
      this.label18.Name = "label18";
      this.label18.Size = new Size(23, 12);
      this.label18.TabIndex = 37;
      this.label18.Text = "20k";
      this.singleButton_Preset.BackColor = SystemColors.Control;
      this.singleButton_Preset.ButtonText = "$PRESET";
      this.singleButton_Preset.Location = new Point(171, 25);
      this.singleButton_Preset.Name = "singleButton_Preset";
      this.singleButton_Preset.Size = new Size(143, 40);
      this.singleButton_Preset.TabIndex = 38;
      this.singleButton_Preset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Preset_ButtonClickNotify);
      this.singleButton_OK.BackColor = SystemColors.Control;
      this.singleButton_OK.ButtonText = "$OK";
      this.singleButton_OK.Location = new Point(878, 25);
      this.singleButton_OK.Name = "singleButton_OK";
      this.singleButton_OK.Size = new Size(112, 40);
      this.singleButton_OK.TabIndex = 40;
      this.singleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_OK_ButtonClickNotify);
      this.label_dB_Max.AutoSize = true;
      this.label_dB_Max.Location = new Point(12, 101);
      this.label_dB_Max.Name = "label_dB_Max";
      this.label_dB_Max.Size = new Size(29, 12);
      this.label_dB_Max.TabIndex = 41;
      this.label_dB_Max.Text = "13dB";
      this.label_dB_Min.AutoSize = true;
      this.label_dB_Min.Location = new Point(12, 256);
      this.label_dB_Min.Name = "label_dB_Min";
      this.label_dB_Min.Size = new Size(41, 12);
      this.label_dB_Min.TabIndex = 42;
      this.label_dB_Min.Text = "-120dB";
      this.label_dB_Zero.AutoSize = true;
      this.label_dB_Zero.Location = new Point(12, 179);
      this.label_dB_Zero.Name = "label_dB_Zero";
      this.label_dB_Zero.Size = new Size(23, 12);
      this.label_dB_Zero.TabIndex = 43;
      this.label_dB_Zero.Text = "0dB";
      this.checkBox_RealtimeAdjust.AutoSize = true;
      this.checkBox_RealtimeAdjust.Location = new Point(386, 37);
      this.checkBox_RealtimeAdjust.Name = "checkBox_RealtimeAdjust";
      this.checkBox_RealtimeAdjust.Size = new Size(180, 16);
      this.checkBox_RealtimeAdjust.TabIndex = 44;
      this.checkBox_RealtimeAdjust.Text = "$EQUALIZER_REALTIME_ADJUST";
      this.checkBox_RealtimeAdjust.UseVisualStyleBackColor = true;
      this.checkBox_RealtimeAdjust.CheckedChanged += new EventHandler(this.checkBox_RealtimeAdjust_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1013, 324);
      this.Controls.Add((Control) this.checkBox_RealtimeAdjust);
      this.Controls.Add((Control) this.label_dB_Zero);
      this.Controls.Add((Control) this.label_dB_Min);
      this.Controls.Add((Control) this.label_dB_Max);
      this.Controls.Add((Control) this.singleButton_OK);
      this.Controls.Add((Control) this.singleButton_Preset);
      this.Controls.Add((Control) this.label18);
      this.Controls.Add((Control) this.label17);
      this.Controls.Add((Control) this.label16);
      this.Controls.Add((Control) this.label15);
      this.Controls.Add((Control) this.label14);
      this.Controls.Add((Control) this.label13);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.vSlider18);
      this.Controls.Add((Control) this.vSlider17);
      this.Controls.Add((Control) this.vSlider16);
      this.Controls.Add((Control) this.vSlider15);
      this.Controls.Add((Control) this.vSlider14);
      this.Controls.Add((Control) this.vSlider13);
      this.Controls.Add((Control) this.vSlider12);
      this.Controls.Add((Control) this.vSlider11);
      this.Controls.Add((Control) this.vSlider10);
      this.Controls.Add((Control) this.vSlider9);
      this.Controls.Add((Control) this.vSlider8);
      this.Controls.Add((Control) this.vSlider7);
      this.Controls.Add((Control) this.vSlider6);
      this.Controls.Add((Control) this.vSlider5);
      this.Controls.Add((Control) this.vSlider4);
      this.Controls.Add((Control) this.vSlider3);
      this.Controls.Add((Control) this.vSlider2);
      this.Controls.Add((Control) this.vSlider1);
      this.Controls.Add((Control) this.onOffSwitch_Equalizer);
      this.Controls.Add((Control) this.label_Equalizer_Enable);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (frmEqualizer);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$EQUALIZER";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void SetRealtimeParameters(
      RuntimeUtils.ConfigProxy._ParamOfBaseSystem paramBaseSystem,
      RuntimeUtils.ConfigProxy._ParamOfMusicMode paramMusicMode,
      RuntimeUtils.ConfigProxy._ParamOfMovieMode paramMovieMode,
      RuntimeUtils.ConfigProxy._ParamOfFreestyle paramFreestyle,
      RuntimeUtils.ConfigProxy cpConfigProxy)
    {
      this.m_paramBaseSystem = paramBaseSystem;
      this.m_paramMusicMode = paramMusicMode;
      this.m_paramMovieMode = paramMovieMode;
      this.m_paramFreestyle = paramFreestyle;
      this.m_cpConfigProxy = cpConfigProxy;
    }

    public frmEqualizer()
    {
      this.InitializeComponent();
      this.Text = GlobalMessages.EQUALIZER;
      this.label_Equalizer_Enable.Text = GlobalMessages.ENABLE;
      this.checkBox_RealtimeAdjust.Text = GlobalMessages.EQUALIZER_REALTIME_ADJUST;
      this.singleButton_Preset.ButtonText = GlobalMessages.PRESET;
      this.singleButton_OK.ButtonText = GlobalMessages.OK;
      this.m_ctlEQBandList.Add(this.vSlider1);
      this.m_ctlEQBandList.Add(this.vSlider2);
      this.m_ctlEQBandList.Add(this.vSlider3);
      this.m_ctlEQBandList.Add(this.vSlider4);
      this.m_ctlEQBandList.Add(this.vSlider5);
      this.m_ctlEQBandList.Add(this.vSlider6);
      this.m_ctlEQBandList.Add(this.vSlider7);
      this.m_ctlEQBandList.Add(this.vSlider8);
      this.m_ctlEQBandList.Add(this.vSlider9);
      this.m_ctlEQBandList.Add(this.vSlider10);
      this.m_ctlEQBandList.Add(this.vSlider11);
      this.m_ctlEQBandList.Add(this.vSlider12);
      this.m_ctlEQBandList.Add(this.vSlider13);
      this.m_ctlEQBandList.Add(this.vSlider14);
      this.m_ctlEQBandList.Add(this.vSlider15);
      this.m_ctlEQBandList.Add(this.vSlider16);
      this.m_ctlEQBandList.Add(this.vSlider17);
      this.m_ctlEQBandList.Add(this.vSlider18);
      for (int index = 0; index < this.m_ctlEQBandList.Count; ++index)
        this.m_ctlEQBandList[index].Tag = (object) index.ToString();
      for (int index = 0; index < this.m_faEQBands.Length; ++index)
        this.m_faEQBands[index] = 1f;
      this.m_bEQEnabled = false;
      this.UpdateUI();
      foreach (VSlider ctlEqBand in this.m_ctlEQBandList)
        ctlEqBand.PositionChangeNotify += new VSlider.PositionChangeEventDelegate(this.EQBandChanged);
      this.onOffSwitch_Equalizer.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.EQSwitchChange);
    }

    private void UpdateUI()
    {
      this.onOffSwitch_Equalizer.SwitchedOn = this.m_bEQEnabled;
      for (int index = 0; index < this.m_faEQBands.Length; ++index)
      {
        float faEqBand = this.m_faEQBands[index];
        uint num = (uint) (((double) faEqBand > 1.0 ? (double) ((faEqBand - 1f) / 4f * 0.5f + 0.5f) : (double) (faEqBand * 0.5f)) * 100.0);
        if (num > 100U)
          num = 100U;
        this.m_ctlEQBandList[index].Position = num;
      }
    }

    private void EQBandChanged(float fPercent, VSlider objSender)
    {
      if (objSender == null || objSender.Tag == null || !(objSender.Tag is string tag))
        return;
      int result = -1;
      if (!int.TryParse(tag, out result) || result < 0 || result >= this.m_faEQBands.Length)
        return;
      float num = (double) fPercent >= 0.5 ? (float) (((double) fPercent - 0.5) / 0.5 * 4.0 + 1.0) : fPercent / 0.5f;
      this.m_faEQBands[result] = num;
      if (!this.checkBox_RealtimeAdjust.Checked)
        return;
      if (this.m_paramBaseSystem.m_nEffectMode == 0U)
      {
        this.m_paramMusicMode.m_rpEqualizerBands[result] = num;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
        this.m_cpConfigProxy.SyncConfig();
      }
      if (this.m_paramBaseSystem.m_nEffectMode == 1U)
      {
        this.m_paramMovieMode.m_rpEqualizerBands[result] = num;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
        this.m_cpConfigProxy.SyncConfig();
      }
      if (this.m_paramBaseSystem.m_nEffectMode != 2U)
        return;
      this.m_paramFreestyle.m_rpEqualizerBands[result] = num;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void EQSwitchChange(bool bSwitchedOn, OnOffSwitch objSender)
    {
      this.m_bEQEnabled = bSwitchedOn;
      if (!this.checkBox_RealtimeAdjust.Checked)
        return;
      if (this.m_paramBaseSystem.m_nEffectMode == 0U)
      {
        this.m_paramMusicMode.m_bEqualizerEnabled = !this.m_bEQEnabled ? 0 : 1;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
        this.m_cpConfigProxy.SyncConfig();
      }
      if (this.m_paramBaseSystem.m_nEffectMode == 1U)
      {
        this.m_paramMovieMode.m_bEqualizerEnabled = !this.m_bEQEnabled ? 0 : 1;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
        this.m_cpConfigProxy.SyncConfig();
      }
      if (this.m_paramBaseSystem.m_nEffectMode != 2U)
        return;
      this.m_paramFreestyle.m_bEqualizerEnabled = !this.m_bEQEnabled ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    public void SetParameters(float[] faEQBands, bool bEQEnabled)
    {
      if (faEQBands == null || faEQBands.Length != this.m_faEQBands.Length)
        return;
      Array.Copy((Array) faEQBands, (Array) this.m_faEQBands, this.m_faEQBands.Length);
      this.m_bEQEnabled = bEQEnabled;
      this.UpdateUI();
    }

    public float[] GetParameter() => this.m_faEQBands;

    public bool GetEQEnabled() => this.m_bEQEnabled;

    private void singleButton_OK_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.OK;

    private void singleButton_Preset_ButtonClickNotify(SingleButton objSender)
    {
      frmEQPreset frmEqPreset = new frmEQPreset();
      frmEqPreset.SetPreset(this.m_faEQBands);
      if (frmEqPreset.ShowDialog() == DialogResult.Cancel)
        return;
      float[] preset = frmEqPreset.GetPreset();
      if (preset == null || preset.Length != this.m_faEQBands.Length)
        return;
      Array.Copy((Array) preset, (Array) this.m_faEQBands, this.m_faEQBands.Length);
      if (this.checkBox_RealtimeAdjust.Checked)
      {
        if (this.m_paramBaseSystem.m_nEffectMode == 0U)
        {
          Array.Copy((Array) this.m_faEQBands, (Array) this.m_paramMusicMode.m_rpEqualizerBands, this.m_faEQBands.Length);
          this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
          this.m_cpConfigProxy.SyncConfig();
        }
        if (this.m_paramBaseSystem.m_nEffectMode == 1U)
        {
          Array.Copy((Array) this.m_faEQBands, (Array) this.m_paramMovieMode.m_rpEqualizerBands, this.m_faEQBands.Length);
          this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
          this.m_cpConfigProxy.SyncConfig();
        }
        if (this.m_paramBaseSystem.m_nEffectMode == 2U)
        {
          Array.Copy((Array) this.m_faEQBands, (Array) this.m_paramFreestyle.m_rpEqualizerBands, this.m_faEQBands.Length);
          this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
          this.m_cpConfigProxy.SyncConfig();
        }
      }
      this.UpdateUI();
    }

    private void checkBox_RealtimeAdjust_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.checkBox_RealtimeAdjust.Checked)
        return;
      if (this.m_paramBaseSystem.m_nEffectMode == 0U)
      {
        this.m_paramMusicMode.m_bEqualizerEnabled = !this.m_bEQEnabled ? 0 : 1;
        Array.Copy((Array) this.m_faEQBands, (Array) this.m_paramMusicMode.m_rpEqualizerBands, this.m_faEQBands.Length);
        this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
        this.m_cpConfigProxy.SyncConfig();
      }
      if (this.m_paramBaseSystem.m_nEffectMode == 1U)
      {
        this.m_paramMovieMode.m_bEqualizerEnabled = !this.m_bEQEnabled ? 0 : 1;
        Array.Copy((Array) this.m_faEQBands, (Array) this.m_paramMovieMode.m_rpEqualizerBands, this.m_faEQBands.Length);
        this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
        this.m_cpConfigProxy.SyncConfig();
      }
      if (this.m_paramBaseSystem.m_nEffectMode != 2U)
        return;
      this.m_paramFreestyle.m_bEqualizerEnabled = !this.m_bEQEnabled ? 0 : 1;
      Array.Copy((Array) this.m_faEQBands, (Array) this.m_paramFreestyle.m_rpEqualizerBands, this.m_faEQBands.Length);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }
  }
}
