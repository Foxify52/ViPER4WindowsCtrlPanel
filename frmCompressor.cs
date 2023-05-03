using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
  public class frmCompressor : Form
  {
    private IContainer components;
    private OnOffSwitch onOffSwitch_Compressor;
    private Label label_Compressor_Enable;
    private GroupBox groupBox_Threshold;
    private HSlider hSlider_Threshold;
    private Label label_Threshold;
    private GroupBox groupBox_Knee;
    private Label label_Knee;
    private HSlider hSlider_Knee;
    private Label label_AutoKnee;
    private OnOffSwitch onOffSwitch_AutoKnee;
    private GroupBox groupBox_Ratio;
    private Label label_Ratio;
    private HSlider hSlider_Ratio;
    private GroupBox groupBox_Release;
    private OnOffSwitch onOffSwitch_AutoRelease;
    private Label label_AutoRelease;
    private Label label_Release;
    private HSlider hSlider_Release;
    private GroupBox groupBox_Attack;
    private OnOffSwitch onOffSwitch_AutoAttack;
    private Label label_AutoAttack;
    private Label label_Attack;
    private HSlider hSlider_Attack;
    private SingleButton singleButton_Cancel;
    private SingleButton singleButton_OK;
    private GroupBox groupBox_MakeUpGain;
    private Label label_Gain;
    private HSlider hSlider_Gain;
    private OnOffSwitch onOffSwitch_AutoGain;
    private Label label_AutoGain;
    private Label label_NoClip;
    private OnOffSwitch onOffSwitch_NoClip;
    private GroupBox groupBox_Misc;
    private Label label_KneeMult;
    private Label label_KneeMultValue;
    private HSlider hSlider_KneeMult;
    private Label label_Adapt;
    private Label label_AdaptValue;
    private HSlider hSlider_Adapt;
    private Label label_Crest;
    private Label label_CrestValue;
    private HSlider hSlider_Crest;
    private bool m_bCompressorEnabled;
    private float m_rThreshold;
    private float m_rKneewidth;
    private bool m_bAutoKnee = true;
    private float m_rRatio;
    private float m_rAttack = Parameters.LOG2PARAM(0.005f, 0.0001f, 0.2f);
    private bool m_bAutoAttack = true;
    private float m_rRelease = Parameters.LOG2PARAM(0.05f, 0.005f, 2f);
    private bool m_bAutoRelease = true;
    private float m_rMakeupGain;
    private bool m_bAutoGain = true;
    private bool m_bNoClip = true;
    private float m_rKneeMult = Parameters.LIN2PARAM(2f, 0.0f, 4f);
    private float m_rCrestTime = Parameters.LOG2PARAM(0.2f, 0.005f, 2f);
    private float m_rAdaptTime = Parameters.LOG2PARAM(2.5f, 1f, 4f);

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmCompressor));
      this.onOffSwitch_Compressor = new OnOffSwitch();
      this.label_Compressor_Enable = new Label();
      this.groupBox_Threshold = new GroupBox();
      this.label_Threshold = new Label();
      this.hSlider_Threshold = new HSlider();
      this.groupBox_Knee = new GroupBox();
      this.onOffSwitch_AutoKnee = new OnOffSwitch();
      this.label_AutoKnee = new Label();
      this.label_Knee = new Label();
      this.hSlider_Knee = new HSlider();
      this.groupBox_Ratio = new GroupBox();
      this.label_Ratio = new Label();
      this.hSlider_Ratio = new HSlider();
      this.groupBox_Release = new GroupBox();
      this.onOffSwitch_AutoRelease = new OnOffSwitch();
      this.label_AutoRelease = new Label();
      this.label_Release = new Label();
      this.hSlider_Release = new HSlider();
      this.groupBox_Attack = new GroupBox();
      this.onOffSwitch_AutoAttack = new OnOffSwitch();
      this.label_AutoAttack = new Label();
      this.label_Attack = new Label();
      this.hSlider_Attack = new HSlider();
      this.singleButton_Cancel = new SingleButton();
      this.singleButton_OK = new SingleButton();
      this.groupBox_MakeUpGain = new GroupBox();
      this.onOffSwitch_AutoGain = new OnOffSwitch();
      this.label_AutoGain = new Label();
      this.label_Gain = new Label();
      this.hSlider_Gain = new HSlider();
      this.label_NoClip = new Label();
      this.onOffSwitch_NoClip = new OnOffSwitch();
      this.groupBox_Misc = new GroupBox();
      this.label_Adapt = new Label();
      this.label_AdaptValue = new Label();
      this.hSlider_Adapt = new HSlider();
      this.label_Crest = new Label();
      this.label_CrestValue = new Label();
      this.hSlider_Crest = new HSlider();
      this.label_KneeMult = new Label();
      this.label_KneeMultValue = new Label();
      this.hSlider_KneeMult = new HSlider();
      this.groupBox_Threshold.SuspendLayout();
      this.groupBox_Knee.SuspendLayout();
      this.groupBox_Ratio.SuspendLayout();
      this.groupBox_Release.SuspendLayout();
      this.groupBox_Attack.SuspendLayout();
      this.groupBox_MakeUpGain.SuspendLayout();
      this.groupBox_Misc.SuspendLayout();
      this.SuspendLayout();
      this.onOffSwitch_Compressor.BackColor = Color.Transparent;
      this.onOffSwitch_Compressor.Location = new Point(12, 29);
      this.onOffSwitch_Compressor.Name = "onOffSwitch_Compressor";
      this.onOffSwitch_Compressor.Size = new Size(107, 28);
      this.onOffSwitch_Compressor.SwitchedOn = false;
      this.onOffSwitch_Compressor.TabIndex = 3;
      this.onOffSwitch_Compressor.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.onOffSwitch_Compressor_SwitchChangeNotify);
      this.label_Compressor_Enable.AutoSize = true;
      this.label_Compressor_Enable.Location = new Point(12, 14);
      this.label_Compressor_Enable.Name = "label_Compressor_Enable";
      this.label_Compressor_Enable.Size = new Size(47, 12);
      this.label_Compressor_Enable.TabIndex = 2;
      this.label_Compressor_Enable.Text = "$ENABLE";
      this.groupBox_Threshold.Controls.Add((Control) this.label_Threshold);
      this.groupBox_Threshold.Controls.Add((Control) this.hSlider_Threshold);
      this.groupBox_Threshold.Location = new Point(12, 73);
      this.groupBox_Threshold.Name = "groupBox_Threshold";
      this.groupBox_Threshold.Size = new Size(548, 61);
      this.groupBox_Threshold.TabIndex = 4;
      this.groupBox_Threshold.TabStop = false;
      this.groupBox_Threshold.Text = "$COMPRESSOR_THRESHOLD";
      this.label_Threshold.AutoSize = true;
      this.label_Threshold.Location = new Point(475, 29);
      this.label_Threshold.Name = "label_Threshold";
      this.label_Threshold.Size = new Size(23, 12);
      this.label_Threshold.TabIndex = 5;
      this.label_Threshold.Text = "0dB";
      this.hSlider_Threshold.BackColor = SystemColors.Control;
      this.hSlider_Threshold.Location = new Point(6, 20);
      this.hSlider_Threshold.MoveDelta = 1U;
      this.hSlider_Threshold.Name = "hSlider_Threshold";
      this.hSlider_Threshold.Position = 0U;
      this.hSlider_Threshold.PositionFloat = 0.0f;
      this.hSlider_Threshold.Size = new Size(463, 29);
      this.hSlider_Threshold.TabIndex = 5;
      this.hSlider_Threshold.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_Threshold_PositionChangeNotify);
      this.groupBox_Knee.Controls.Add((Control) this.onOffSwitch_AutoKnee);
      this.groupBox_Knee.Controls.Add((Control) this.label_AutoKnee);
      this.groupBox_Knee.Controls.Add((Control) this.label_Knee);
      this.groupBox_Knee.Controls.Add((Control) this.hSlider_Knee);
      this.groupBox_Knee.Location = new Point(12, 140);
      this.groupBox_Knee.Name = "groupBox_Knee";
      this.groupBox_Knee.Size = new Size(271, 115);
      this.groupBox_Knee.TabIndex = 5;
      this.groupBox_Knee.TabStop = false;
      this.groupBox_Knee.Text = "$COMPRESSOR_KNEEWIDTH";
      this.onOffSwitch_AutoKnee.BackColor = Color.Transparent;
      this.onOffSwitch_AutoKnee.Location = new Point(22, 41);
      this.onOffSwitch_AutoKnee.Name = "onOffSwitch_AutoKnee";
      this.onOffSwitch_AutoKnee.Size = new Size(49, 22);
      this.onOffSwitch_AutoKnee.SwitchedOn = false;
      this.onOffSwitch_AutoKnee.TabIndex = 6;
      this.onOffSwitch_AutoKnee.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.onOffSwitch_AutoKnee_SwitchChangeNotify);
      this.label_AutoKnee.AutoSize = true;
      this.label_AutoKnee.Location = new Point(20, 26);
      this.label_AutoKnee.Name = "label_AutoKnee";
      this.label_AutoKnee.Size = new Size(125, 12);
      this.label_AutoKnee.TabIndex = 6;
      this.label_AutoKnee.Text = "$COMPRESSOR_AUTOKNEE";
      this.label_Knee.AutoSize = true;
      this.label_Knee.Location = new Point(198, 81);
      this.label_Knee.Name = "label_Knee";
      this.label_Knee.Size = new Size(23, 12);
      this.label_Knee.TabIndex = 5;
      this.label_Knee.Text = "0dB";
      this.hSlider_Knee.BackColor = SystemColors.Control;
      this.hSlider_Knee.Location = new Point(7, 72);
      this.hSlider_Knee.MoveDelta = 1U;
      this.hSlider_Knee.Name = "hSlider_Knee";
      this.hSlider_Knee.Position = 0U;
      this.hSlider_Knee.PositionFloat = 0.0f;
      this.hSlider_Knee.Size = new Size(185, 31);
      this.hSlider_Knee.TabIndex = 5;
      this.hSlider_Knee.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_Knee_PositionChangeNotify);
      this.groupBox_Ratio.Controls.Add((Control) this.label_Ratio);
      this.groupBox_Ratio.Controls.Add((Control) this.hSlider_Ratio);
      this.groupBox_Ratio.Location = new Point(289, 140);
      this.groupBox_Ratio.Name = "groupBox_Ratio";
      this.groupBox_Ratio.Size = new Size(271, 115);
      this.groupBox_Ratio.TabIndex = 6;
      this.groupBox_Ratio.TabStop = false;
      this.groupBox_Ratio.Text = "$COMPRESSOR_RATIO";
      this.label_Ratio.AutoSize = true;
      this.label_Ratio.Location = new Point(198, 54);
      this.label_Ratio.Name = "label_Ratio";
      this.label_Ratio.Size = new Size(41, 12);
      this.label_Ratio.TabIndex = 5;
      this.label_Ratio.Text = "1.00:1";
      this.hSlider_Ratio.BackColor = SystemColors.Control;
      this.hSlider_Ratio.Location = new Point(7, 45);
      this.hSlider_Ratio.MoveDelta = 1U;
      this.hSlider_Ratio.Name = "hSlider_Ratio";
      this.hSlider_Ratio.Position = 0U;
      this.hSlider_Ratio.PositionFloat = 0.0f;
      this.hSlider_Ratio.Size = new Size(185, 31);
      this.hSlider_Ratio.TabIndex = 5;
      this.hSlider_Ratio.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_Ratio_PositionChangeNotify);
      this.groupBox_Release.Controls.Add((Control) this.onOffSwitch_AutoRelease);
      this.groupBox_Release.Controls.Add((Control) this.label_AutoRelease);
      this.groupBox_Release.Controls.Add((Control) this.label_Release);
      this.groupBox_Release.Controls.Add((Control) this.hSlider_Release);
      this.groupBox_Release.Location = new Point(289, 261);
      this.groupBox_Release.Name = "groupBox_Release";
      this.groupBox_Release.Size = new Size(271, 115);
      this.groupBox_Release.TabIndex = 8;
      this.groupBox_Release.TabStop = false;
      this.groupBox_Release.Text = "$COMPRESSOR_RELEASE";
      this.onOffSwitch_AutoRelease.BackColor = Color.Transparent;
      this.onOffSwitch_AutoRelease.Location = new Point(22, 41);
      this.onOffSwitch_AutoRelease.Name = "onOffSwitch_AutoRelease";
      this.onOffSwitch_AutoRelease.Size = new Size(49, 22);
      this.onOffSwitch_AutoRelease.SwitchedOn = false;
      this.onOffSwitch_AutoRelease.TabIndex = 6;
      this.onOffSwitch_AutoRelease.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.onOffSwitch_AutoRelease_SwitchChangeNotify);
      this.label_AutoRelease.AutoSize = true;
      this.label_AutoRelease.Location = new Point(20, 26);
      this.label_AutoRelease.Name = "label_AutoRelease";
      this.label_AutoRelease.Size = new Size(143, 12);
      this.label_AutoRelease.TabIndex = 6;
      this.label_AutoRelease.Text = "$COMPRESSOR_AUTORELEASE";
      this.label_Release.AutoSize = true;
      this.label_Release.Location = new Point(198, 81);
      this.label_Release.Name = "label_Release";
      this.label_Release.Size = new Size(41, 12);
      this.label_Release.TabIndex = 5;
      this.label_Release.Text = "5.00ms";
      this.hSlider_Release.BackColor = SystemColors.Control;
      this.hSlider_Release.Location = new Point(7, 72);
      this.hSlider_Release.MoveDelta = 1U;
      this.hSlider_Release.Name = "hSlider_Release";
      this.hSlider_Release.Position = 0U;
      this.hSlider_Release.PositionFloat = 0.0f;
      this.hSlider_Release.Size = new Size(185, 31);
      this.hSlider_Release.TabIndex = 5;
      this.hSlider_Release.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_Release_PositionChangeNotify);
      this.groupBox_Attack.Controls.Add((Control) this.onOffSwitch_AutoAttack);
      this.groupBox_Attack.Controls.Add((Control) this.label_AutoAttack);
      this.groupBox_Attack.Controls.Add((Control) this.label_Attack);
      this.groupBox_Attack.Controls.Add((Control) this.hSlider_Attack);
      this.groupBox_Attack.Location = new Point(12, 261);
      this.groupBox_Attack.Name = "groupBox_Attack";
      this.groupBox_Attack.Size = new Size(271, 115);
      this.groupBox_Attack.TabIndex = 7;
      this.groupBox_Attack.TabStop = false;
      this.groupBox_Attack.Text = "$COMPRESSOR_ATTACK";
      this.onOffSwitch_AutoAttack.BackColor = Color.Transparent;
      this.onOffSwitch_AutoAttack.Location = new Point(22, 41);
      this.onOffSwitch_AutoAttack.Name = "onOffSwitch_AutoAttack";
      this.onOffSwitch_AutoAttack.Size = new Size(49, 22);
      this.onOffSwitch_AutoAttack.SwitchedOn = false;
      this.onOffSwitch_AutoAttack.TabIndex = 6;
      this.onOffSwitch_AutoAttack.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.onOffSwitch_AutoAttack_SwitchChangeNotify);
      this.label_AutoAttack.AutoSize = true;
      this.label_AutoAttack.Location = new Point(20, 26);
      this.label_AutoAttack.Name = "label_AutoAttack";
      this.label_AutoAttack.Size = new Size(137, 12);
      this.label_AutoAttack.TabIndex = 6;
      this.label_AutoAttack.Text = "$COMPRESSOR_AUTOATTACK";
      this.label_Attack.AutoSize = true;
      this.label_Attack.Location = new Point(198, 81);
      this.label_Attack.Name = "label_Attack";
      this.label_Attack.Size = new Size(41, 12);
      this.label_Attack.TabIndex = 5;
      this.label_Attack.Text = "0.10ms";
      this.hSlider_Attack.BackColor = SystemColors.Control;
      this.hSlider_Attack.Location = new Point(7, 72);
      this.hSlider_Attack.MoveDelta = 1U;
      this.hSlider_Attack.Name = "hSlider_Attack";
      this.hSlider_Attack.Position = 0U;
      this.hSlider_Attack.PositionFloat = 0.0f;
      this.hSlider_Attack.Size = new Size(185, 31);
      this.hSlider_Attack.TabIndex = 5;
      this.hSlider_Attack.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_Attack_PositionChangeNotify);
      this.singleButton_Cancel.BackColor = SystemColors.Control;
      this.singleButton_Cancel.ButtonText = "$CANCEL";
      this.singleButton_Cancel.Location = new Point(448, 20);
      this.singleButton_Cancel.Name = "singleButton_Cancel";
      this.singleButton_Cancel.Size = new Size(112, 40);
      this.singleButton_Cancel.TabIndex = 9;
      this.singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Cancel_ButtonClickNotify);
      this.singleButton_OK.BackColor = SystemColors.Control;
      this.singleButton_OK.ButtonText = "$OK";
      this.singleButton_OK.Location = new Point(328, 20);
      this.singleButton_OK.Name = "singleButton_OK";
      this.singleButton_OK.Size = new Size(112, 40);
      this.singleButton_OK.TabIndex = 10;
      this.singleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_OK_ButtonClickNotify);
      this.groupBox_MakeUpGain.Controls.Add((Control) this.onOffSwitch_AutoGain);
      this.groupBox_MakeUpGain.Controls.Add((Control) this.label_AutoGain);
      this.groupBox_MakeUpGain.Controls.Add((Control) this.label_Gain);
      this.groupBox_MakeUpGain.Controls.Add((Control) this.hSlider_Gain);
      this.groupBox_MakeUpGain.Location = new Point(12, 516);
      this.groupBox_MakeUpGain.Name = "groupBox_MakeUpGain";
      this.groupBox_MakeUpGain.Size = new Size(548, 110);
      this.groupBox_MakeUpGain.TabIndex = 11;
      this.groupBox_MakeUpGain.TabStop = false;
      this.groupBox_MakeUpGain.Text = "$COMPRESSOR_MAKEUPGAIN";
      this.onOffSwitch_AutoGain.BackColor = Color.Transparent;
      this.onOffSwitch_AutoGain.Location = new Point(22, 41);
      this.onOffSwitch_AutoGain.Name = "onOffSwitch_AutoGain";
      this.onOffSwitch_AutoGain.Size = new Size(49, 22);
      this.onOffSwitch_AutoGain.SwitchedOn = false;
      this.onOffSwitch_AutoGain.TabIndex = 8;
      this.onOffSwitch_AutoGain.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.onOffSwitch_AutoGain_SwitchChangeNotify);
      this.label_AutoGain.AutoSize = true;
      this.label_AutoGain.Location = new Point(20, 26);
      this.label_AutoGain.Name = "label_AutoGain";
      this.label_AutoGain.Size = new Size(125, 12);
      this.label_AutoGain.TabIndex = 7;
      this.label_AutoGain.Text = "$COMPRESSOR_AUTOGAIN";
      this.label_Gain.AutoSize = true;
      this.label_Gain.Location = new Point(475, 79);
      this.label_Gain.Name = "label_Gain";
      this.label_Gain.Size = new Size(23, 12);
      this.label_Gain.TabIndex = 5;
      this.label_Gain.Text = "0dB";
      this.hSlider_Gain.BackColor = SystemColors.Control;
      this.hSlider_Gain.Location = new Point(7, 71);
      this.hSlider_Gain.MoveDelta = 1U;
      this.hSlider_Gain.Name = "hSlider_Gain";
      this.hSlider_Gain.Position = 0U;
      this.hSlider_Gain.PositionFloat = 0.0f;
      this.hSlider_Gain.Size = new Size(462, 29);
      this.hSlider_Gain.TabIndex = 5;
      this.hSlider_Gain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_Gain_PositionChangeNotify);
      this.label_NoClip.AutoSize = true;
      this.label_NoClip.Location = new Point(163, 14);
      this.label_NoClip.Name = "label_NoClip";
      this.label_NoClip.Size = new Size(113, 12);
      this.label_NoClip.TabIndex = 12;
      this.label_NoClip.Text = "$COMPRESSOR_NOCLIP";
      this.onOffSwitch_NoClip.BackColor = Color.Transparent;
      this.onOffSwitch_NoClip.Location = new Point(165, 29);
      this.onOffSwitch_NoClip.Name = "onOffSwitch_NoClip";
      this.onOffSwitch_NoClip.Size = new Size(107, 28);
      this.onOffSwitch_NoClip.SwitchedOn = false;
      this.onOffSwitch_NoClip.TabIndex = 13;
      this.onOffSwitch_NoClip.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.onOffSwitch_NoClip_SwitchChangeNotify);
      this.groupBox_Misc.Controls.Add((Control) this.label_Adapt);
      this.groupBox_Misc.Controls.Add((Control) this.label_AdaptValue);
      this.groupBox_Misc.Controls.Add((Control) this.hSlider_Adapt);
      this.groupBox_Misc.Controls.Add((Control) this.label_Crest);
      this.groupBox_Misc.Controls.Add((Control) this.label_CrestValue);
      this.groupBox_Misc.Controls.Add((Control) this.hSlider_Crest);
      this.groupBox_Misc.Controls.Add((Control) this.label_KneeMult);
      this.groupBox_Misc.Controls.Add((Control) this.label_KneeMultValue);
      this.groupBox_Misc.Controls.Add((Control) this.hSlider_KneeMult);
      this.groupBox_Misc.Location = new Point(12, 382);
      this.groupBox_Misc.Name = "groupBox_Misc";
      this.groupBox_Misc.Size = new Size(548, 128);
      this.groupBox_Misc.TabIndex = 14;
      this.groupBox_Misc.TabStop = false;
      this.groupBox_Misc.Text = "$COMPRESSOR_MISC";
      this.label_Adapt.AutoSize = true;
      this.label_Adapt.Location = new Point(297, 76);
      this.label_Adapt.Name = "label_Adapt";
      this.label_Adapt.Size = new Size(131, 12);
      this.label_Adapt.TabIndex = 12;
      this.label_Adapt.Text = "$COMPRESSOR_ADAPTTIME";
      this.label_AdaptValue.AutoSize = true;
      this.label_AdaptValue.Location = new Point(475, 100);
      this.label_AdaptValue.Name = "label_AdaptValue";
      this.label_AdaptValue.Size = new Size(41, 12);
      this.label_AdaptValue.TabIndex = 11;
      this.label_AdaptValue.Text = "0.00ms";
      this.hSlider_Adapt.BackColor = SystemColors.Control;
      this.hSlider_Adapt.Location = new Point(284, 91);
      this.hSlider_Adapt.MoveDelta = 1U;
      this.hSlider_Adapt.Name = "hSlider_Adapt";
      this.hSlider_Adapt.Position = 0U;
      this.hSlider_Adapt.PositionFloat = 0.0f;
      this.hSlider_Adapt.Size = new Size(185, 31);
      this.hSlider_Adapt.TabIndex = 10;
      this.hSlider_Adapt.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_Adapt_PositionChangeNotify);
      this.label_Crest.AutoSize = true;
      this.label_Crest.Location = new Point(297, 20);
      this.label_Crest.Name = "label_Crest";
      this.label_Crest.Size = new Size(131, 12);
      this.label_Crest.TabIndex = 9;
      this.label_Crest.Text = "$COMPRESSOR_CRESTTIME";
      this.label_CrestValue.AutoSize = true;
      this.label_CrestValue.Location = new Point(475, 44);
      this.label_CrestValue.Name = "label_CrestValue";
      this.label_CrestValue.Size = new Size(41, 12);
      this.label_CrestValue.TabIndex = 8;
      this.label_CrestValue.Text = "0.00ms";
      this.hSlider_Crest.BackColor = SystemColors.Control;
      this.hSlider_Crest.Location = new Point(284, 35);
      this.hSlider_Crest.MoveDelta = 1U;
      this.hSlider_Crest.Name = "hSlider_Crest";
      this.hSlider_Crest.Position = 0U;
      this.hSlider_Crest.PositionFloat = 0.0f;
      this.hSlider_Crest.Size = new Size(185, 31);
      this.hSlider_Crest.TabIndex = 7;
      this.hSlider_Crest.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_Crest_PositionChangeNotify);
      this.label_KneeMult.AutoSize = true;
      this.label_KneeMult.Location = new Point(20, 43);
      this.label_KneeMult.Name = "label_KneeMult";
      this.label_KneeMult.Size = new Size(125, 12);
      this.label_KneeMult.TabIndex = 6;
      this.label_KneeMult.Text = "$COMPRESSOR_KNEEMULT";
      this.label_KneeMultValue.AutoSize = true;
      this.label_KneeMultValue.Location = new Point(198, 67);
      this.label_KneeMultValue.Name = "label_KneeMultValue";
      this.label_KneeMultValue.Size = new Size(35, 12);
      this.label_KneeMultValue.TabIndex = 5;
      this.label_KneeMultValue.Text = "2.00x";
      this.hSlider_KneeMult.BackColor = SystemColors.Control;
      this.hSlider_KneeMult.Location = new Point(7, 58);
      this.hSlider_KneeMult.MoveDelta = 1U;
      this.hSlider_KneeMult.Name = "hSlider_KneeMult";
      this.hSlider_KneeMult.Position = 0U;
      this.hSlider_KneeMult.PositionFloat = 0.0f;
      this.hSlider_KneeMult.Size = new Size(185, 31);
      this.hSlider_KneeMult.TabIndex = 5;
      this.hSlider_KneeMult.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_KneeMult_PositionChangeNotify);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(574, 637);
      this.Controls.Add((Control) this.groupBox_Misc);
      this.Controls.Add((Control) this.onOffSwitch_NoClip);
      this.Controls.Add((Control) this.label_NoClip);
      this.Controls.Add((Control) this.groupBox_MakeUpGain);
      this.Controls.Add((Control) this.singleButton_OK);
      this.Controls.Add((Control) this.singleButton_Cancel);
      this.Controls.Add((Control) this.groupBox_Release);
      this.Controls.Add((Control) this.groupBox_Attack);
      this.Controls.Add((Control) this.groupBox_Ratio);
      this.Controls.Add((Control) this.groupBox_Knee);
      this.Controls.Add((Control) this.groupBox_Threshold);
      this.Controls.Add((Control) this.onOffSwitch_Compressor);
      this.Controls.Add((Control) this.label_Compressor_Enable);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (frmCompressor);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$COMPRESSOR";
      this.groupBox_Threshold.ResumeLayout(false);
      this.groupBox_Threshold.PerformLayout();
      this.groupBox_Knee.ResumeLayout(false);
      this.groupBox_Knee.PerformLayout();
      this.groupBox_Ratio.ResumeLayout(false);
      this.groupBox_Ratio.PerformLayout();
      this.groupBox_Release.ResumeLayout(false);
      this.groupBox_Release.PerformLayout();
      this.groupBox_Attack.ResumeLayout(false);
      this.groupBox_Attack.PerformLayout();
      this.groupBox_MakeUpGain.ResumeLayout(false);
      this.groupBox_MakeUpGain.PerformLayout();
      this.groupBox_Misc.ResumeLayout(false);
      this.groupBox_Misc.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public bool CompressorEnabled
    {
      get => this.m_bCompressorEnabled;
      set
      {
        this.m_bCompressorEnabled = value;
        this.UpdateUI();
      }
    }

    public float Threshold
    {
      get => this.m_rThreshold;
      set
      {
        this.m_rThreshold = value;
        this.UpdateUI();
      }
    }

    public float KneeWidth
    {
      get => this.m_rKneewidth;
      set
      {
        this.m_rKneewidth = value;
        this.UpdateUI();
      }
    }

    public bool AutoKnee
    {
      get => this.m_bAutoKnee;
      set
      {
        this.m_bAutoKnee = value;
        this.UpdateUI();
      }
    }

    public float Ratio
    {
      get => this.m_rRatio;
      set
      {
        this.m_rRatio = value;
        this.UpdateUI();
      }
    }

    public float AttackTime
    {
      get => this.m_rAttack;
      set
      {
        this.m_rAttack = value;
        this.UpdateUI();
      }
    }

    public bool AutoAttack
    {
      get => this.m_bAutoAttack;
      set
      {
        this.m_bAutoAttack = value;
        this.UpdateUI();
      }
    }

    public float ReleaseTime
    {
      get => this.m_rRelease;
      set
      {
        this.m_rRelease = value;
        this.UpdateUI();
      }
    }

    public bool AutoRelease
    {
      get => this.m_bAutoRelease;
      set
      {
        this.m_bAutoRelease = value;
        this.UpdateUI();
      }
    }

    public float MakeupGain
    {
      get => this.m_rMakeupGain;
      set
      {
        this.m_rMakeupGain = value;
        this.UpdateUI();
      }
    }

    public bool AutoGain
    {
      get => this.m_bAutoGain;
      set
      {
        this.m_bAutoGain = value;
        this.UpdateUI();
      }
    }

    public bool NoClip
    {
      get => this.m_bNoClip;
      set
      {
        this.m_bNoClip = value;
        this.UpdateUI();
      }
    }

    public float KneeMult
    {
      get => this.m_rKneeMult;
      set
      {
        this.m_rKneeMult = value;
        this.UpdateUI();
      }
    }

    public float CrestTime
    {
      get => this.m_rCrestTime;
      set
      {
        this.m_rCrestTime = value;
        this.UpdateUI();
      }
    }

    public float AdaptTime
    {
      get => this.m_rAdaptTime;
      set
      {
        this.m_rAdaptTime = value;
        this.UpdateUI();
      }
    }

    public frmCompressor()
    {
      this.InitializeComponent();
      this.Text = GlobalMessages.COMPRESSOR;
      this.singleButton_OK.ButtonText = GlobalMessages.OK;
      this.singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
      this.label_Compressor_Enable.Text = GlobalMessages.ENABLE;
      this.label_NoClip.Text = GlobalMessages.COMPRESSOR_NOCLIP;
      this.groupBox_Threshold.Text = GlobalMessages.COMPRESSOR_THRESHOLD;
      this.groupBox_Knee.Text = GlobalMessages.COMPRESSOR_KNEEWIDTH;
      this.label_AutoKnee.Text = GlobalMessages.COMPRESSOR_AUTOKNEE;
      this.groupBox_Ratio.Text = GlobalMessages.COMPRESSOR_RATIO;
      this.groupBox_Attack.Text = GlobalMessages.COMPRESSOR_ATTACK;
      this.label_AutoAttack.Text = GlobalMessages.COMPRESSOR_AUTOATTACK;
      this.groupBox_Release.Text = GlobalMessages.COMPRESSOR_RELEASE;
      this.label_AutoRelease.Text = GlobalMessages.COMPRESSOR_AUTORELEASE;
      this.groupBox_Misc.Text = GlobalMessages.COMPRESSOR_MISC;
      this.label_KneeMult.Text = GlobalMessages.COMPRESSOR_KNEEMULT;
      this.label_Crest.Text = GlobalMessages.COMPRESSOR_CRESTTIME;
      this.label_Adapt.Text = GlobalMessages.COMPRESSOR_ADAPTTIME;
      this.groupBox_MakeUpGain.Text = GlobalMessages.COMPRESSOR_MAKEUPGAIN;
      this.label_AutoGain.Text = GlobalMessages.COMPRESSOR_AUTOGAIN;
      this.UpdateUI();
    }

    private void UpdateUI()
    {
      this.onOffSwitch_Compressor.SwitchedOn = this.m_bCompressorEnabled;
      this.onOffSwitch_NoClip.SwitchedOn = this.m_bNoClip;
      this.onOffSwitch_AutoKnee.SwitchedOn = this.m_bAutoKnee;
      this.onOffSwitch_AutoAttack.SwitchedOn = this.m_bAutoAttack;
      this.onOffSwitch_AutoRelease.SwitchedOn = this.m_bAutoRelease;
      this.onOffSwitch_AutoGain.SwitchedOn = this.m_bAutoGain;
      this.hSlider_Threshold.Position = (uint) ((double) this.m_rThreshold * 100.0);
      this.hSlider_Knee.Position = (uint) ((double) this.m_rKneewidth * 100.0);
      this.hSlider_Ratio.Position = (uint) ((double) this.m_rRatio * 100.0);
      this.hSlider_Attack.Position = (uint) ((double) this.m_rAttack * 100.0);
      this.hSlider_Release.Position = (uint) ((double) this.m_rRelease * 100.0);
      this.hSlider_KneeMult.Position = (uint) ((double) this.m_rKneeMult * 100.0);
      this.hSlider_Crest.Position = (uint) ((double) this.m_rCrestTime * 100.0);
      this.hSlider_Adapt.Position = (uint) ((double) this.m_rAdaptTime * 100.0);
      this.hSlider_Gain.Position = (uint) ((double) this.m_rMakeupGain * 100.0);
    }

    private void onOffSwitch_Compressor_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender) => this.m_bCompressorEnabled = bSwitchedOn;

    private void onOffSwitch_NoClip_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender) => this.m_bNoClip = bSwitchedOn;

    private void onOffSwitch_AutoKnee_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender) => this.m_bAutoKnee = bSwitchedOn;

    private void onOffSwitch_AutoAttack_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender) => this.m_bAutoAttack = bSwitchedOn;

    private void onOffSwitch_AutoRelease_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender) => this.m_bAutoRelease = bSwitchedOn;

    private void onOffSwitch_AutoGain_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender) => this.m_bAutoGain = bSwitchedOn;

    private void hSlider_Threshold_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rThreshold = fPercent;
      this.label_Threshold.Text = (20.0 * Math.Log10(Math.Pow(10.0, (double) fPercent * -60.0 / 20.0))).ToString("F02") + "dB";
    }

    private void hSlider_Knee_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rKneewidth = fPercent;
      this.label_Knee.Text = (20.0 * Math.Log10(Math.Pow(10.0, (double) fPercent * 60.0 / 20.0))).ToString("F02") + "dB";
    }

    private void hSlider_Ratio_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rRatio = fPercent;
      if ((double) fPercent > 0.99000000953674316)
        this.label_Ratio.Text = "oo:1";
      else
        this.label_Ratio.Text = (1.0 / (1.0 - (double) fPercent)).ToString("F02") + ":1";
    }

    private void hSlider_Attack_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rAttack = fPercent;
      this.label_Attack.Text = ((double) Parameters.PARAM2LOG(fPercent, 0.0001f, 0.2f) * 1000.0).ToString("F02") + "ms";
    }

    private void hSlider_Release_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rRelease = fPercent;
      this.label_Release.Text = ((double) Parameters.PARAM2LOG(fPercent, 0.005f, 2f) * 1000.0).ToString("F02") + "ms";
    }

    private void hSlider_KneeMult_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rKneeMult = fPercent;
      this.label_KneeMultValue.Text = Parameters.PARAM2LIN(fPercent, 0.0f, 4f).ToString("F02") + "x";
    }

    private void hSlider_Crest_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rCrestTime = fPercent;
      this.label_CrestValue.Text = ((double) Parameters.PARAM2LOG(fPercent, 0.005f, 2f) * 1000.0).ToString("F02") + "ms";
    }

    private void hSlider_Adapt_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rAdaptTime = fPercent;
      this.label_AdaptValue.Text = ((double) Parameters.PARAM2LOG(fPercent, 1f, 4f) * 1000.0).ToString("F02") + "ms";
    }

    private void hSlider_Gain_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rMakeupGain = fPercent;
      this.label_Gain.Text = (20.0 * Math.Log10(Math.Pow(10.0, (double) fPercent * 60.0 / 20.0))).ToString("F02") + "dB";
    }

    private void singleButton_OK_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.OK;

    private void singleButton_Cancel_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.Cancel;
  }
}
