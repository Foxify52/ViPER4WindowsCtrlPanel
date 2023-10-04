using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
    public class FrmCompressorLite : Form
    {
        private readonly IContainer components;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmCompressorLite));
            onOffSwitch_Compressor = new OnOffSwitch();
            label_Compressor_Enable = new Label();
            groupBox_Threshold = new GroupBox();
            label_Threshold = new Label();
            hSlider_Threshold = new HSlider();
            groupBox_Knee = new GroupBox();
            onOffSwitch_AutoKnee = new OnOffSwitch();
            label_AutoKnee = new Label();
            label_Knee = new Label();
            hSlider_Knee = new HSlider();
            groupBox_Ratio = new GroupBox();
            label_Ratio = new Label();
            hSlider_Ratio = new HSlider();
            groupBox_Release = new GroupBox();
            onOffSwitch_AutoRelease = new OnOffSwitch();
            label_AutoRelease = new Label();
            label_Release = new Label();
            hSlider_Release = new HSlider();
            groupBox_Attack = new GroupBox();
            onOffSwitch_AutoAttack = new OnOffSwitch();
            label_AutoAttack = new Label();
            label_Attack = new Label();
            hSlider_Attack = new HSlider();
            singleButton_Cancel = new SingleButton();
            singleButton_OK = new SingleButton();
            groupBox_MakeUpGain = new GroupBox();
            onOffSwitch_AutoGain = new OnOffSwitch();
            label_AutoGain = new Label();
            label_Gain = new Label();
            hSlider_Gain = new HSlider();
            groupBox_Threshold.SuspendLayout();
            groupBox_Knee.SuspendLayout();
            groupBox_Ratio.SuspendLayout();
            groupBox_Release.SuspendLayout();
            groupBox_Attack.SuspendLayout();
            groupBox_MakeUpGain.SuspendLayout();
            SuspendLayout();
            onOffSwitch_Compressor.BackColor = Color.Transparent;
            onOffSwitch_Compressor.Location = new Point(12, 29);
            onOffSwitch_Compressor.Name = "onOffSwitch_Compressor";
            onOffSwitch_Compressor.Size = new Size(107, 28);
            onOffSwitch_Compressor.SwitchedOn = false;
            onOffSwitch_Compressor.TabIndex = 3;
            onOffSwitch_Compressor.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(OnOffSwitch_Compressor_SwitchChangeNotify);
            label_Compressor_Enable.AutoSize = true;
            label_Compressor_Enable.Location = new Point(12, 14);
            label_Compressor_Enable.Name = "label_Compressor_Enable";
            label_Compressor_Enable.Size = new Size(47, 12);
            label_Compressor_Enable.TabIndex = 2;
            label_Compressor_Enable.Text = "$ENABLE";
            groupBox_Threshold.Controls.Add(label_Threshold);
            groupBox_Threshold.Controls.Add(hSlider_Threshold);
            groupBox_Threshold.Location = new Point(12, 73);
            groupBox_Threshold.Name = "groupBox_Threshold";
            groupBox_Threshold.Size = new Size(548, 82);
            groupBox_Threshold.TabIndex = 4;
            groupBox_Threshold.TabStop = false;
            groupBox_Threshold.Text = "$COMPRESSOR_THRESHOLD";
            label_Threshold.AutoSize = true;
            label_Threshold.Location = new Point(475, 37);
            label_Threshold.Name = "label_Threshold";
            label_Threshold.Size = new Size(23, 12);
            label_Threshold.TabIndex = 5;
            label_Threshold.Text = "0dB";
            hSlider_Threshold.BackColor = SystemColors.Control;
            hSlider_Threshold.Location = new Point(6, 20);
            hSlider_Threshold.MoveDelta = 1U;
            hSlider_Threshold.Name = "hSlider_Threshold";
            hSlider_Threshold.Position = 0U;
            hSlider_Threshold.PositionFloat = 0.0f;
            hSlider_Threshold.Size = new Size(463, 47);
            hSlider_Threshold.TabIndex = 5;
            hSlider_Threshold.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(HSlider_Threshold_PositionChangeNotify);
            groupBox_Knee.Controls.Add(onOffSwitch_AutoKnee);
            groupBox_Knee.Controls.Add(label_AutoKnee);
            groupBox_Knee.Controls.Add(label_Knee);
            groupBox_Knee.Controls.Add(hSlider_Knee);
            groupBox_Knee.Location = new Point(12, 173);
            groupBox_Knee.Name = "groupBox_Knee";
            groupBox_Knee.Size = new Size(271, 115);
            groupBox_Knee.TabIndex = 5;
            groupBox_Knee.TabStop = false;
            groupBox_Knee.Text = "$COMPRESSOR_KNEEWIDTH";
            onOffSwitch_AutoKnee.BackColor = Color.Transparent;
            onOffSwitch_AutoKnee.Location = new Point(22, 41);
            onOffSwitch_AutoKnee.Name = "onOffSwitch_AutoKnee";
            onOffSwitch_AutoKnee.Size = new Size(49, 22);
            onOffSwitch_AutoKnee.SwitchedOn = false;
            onOffSwitch_AutoKnee.TabIndex = 6;
            onOffSwitch_AutoKnee.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(OnOffSwitch_AutoKnee_SwitchChangeNotify);
            label_AutoKnee.AutoSize = true;
            label_AutoKnee.Location = new Point(20, 26);
            label_AutoKnee.Name = "label_AutoKnee";
            label_AutoKnee.Size = new Size(125, 12);
            label_AutoKnee.TabIndex = 6;
            label_AutoKnee.Text = "$COMPRESSOR_AUTOKNEE";
            label_Knee.AutoSize = true;
            label_Knee.Location = new Point(198, 81);
            label_Knee.Name = "label_Knee";
            label_Knee.Size = new Size(23, 12);
            label_Knee.TabIndex = 5;
            label_Knee.Text = "0dB";
            hSlider_Knee.BackColor = SystemColors.Control;
            hSlider_Knee.Location = new Point(7, 72);
            hSlider_Knee.MoveDelta = 1U;
            hSlider_Knee.Name = "hSlider_Knee";
            hSlider_Knee.Position = 0U;
            hSlider_Knee.PositionFloat = 0.0f;
            hSlider_Knee.Size = new Size(185, 31);
            hSlider_Knee.TabIndex = 5;
            hSlider_Knee.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(HSlider_Knee_PositionChangeNotify);
            groupBox_Ratio.Controls.Add(label_Ratio);
            groupBox_Ratio.Controls.Add(hSlider_Ratio);
            groupBox_Ratio.Location = new Point(289, 173);
            groupBox_Ratio.Name = "groupBox_Ratio";
            groupBox_Ratio.Size = new Size(271, 115);
            groupBox_Ratio.TabIndex = 6;
            groupBox_Ratio.TabStop = false;
            groupBox_Ratio.Text = "$COMPRESSOR_RATIO";
            label_Ratio.AutoSize = true;
            label_Ratio.Location = new Point(198, 52);
            label_Ratio.Name = "label_Ratio";
            label_Ratio.Size = new Size(41, 12);
            label_Ratio.TabIndex = 5;
            label_Ratio.Text = "1.00:1";
            hSlider_Ratio.BackColor = SystemColors.Control;
            hSlider_Ratio.Location = new Point(7, 43);
            hSlider_Ratio.MoveDelta = 1U;
            hSlider_Ratio.Name = "hSlider_Ratio";
            hSlider_Ratio.Position = 0U;
            hSlider_Ratio.PositionFloat = 0.0f;
            hSlider_Ratio.Size = new Size(185, 31);
            hSlider_Ratio.TabIndex = 5;
            hSlider_Ratio.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(HSlider_Ratio_PositionChangeNotify);
            groupBox_Release.Controls.Add(onOffSwitch_AutoRelease);
            groupBox_Release.Controls.Add(label_AutoRelease);
            groupBox_Release.Controls.Add(label_Release);
            groupBox_Release.Controls.Add(hSlider_Release);
            groupBox_Release.Location = new Point(289, 294);
            groupBox_Release.Name = "groupBox_Release";
            groupBox_Release.Size = new Size(271, 115);
            groupBox_Release.TabIndex = 8;
            groupBox_Release.TabStop = false;
            groupBox_Release.Text = "$COMPRESSOR_RELEASE";
            onOffSwitch_AutoRelease.BackColor = Color.Transparent;
            onOffSwitch_AutoRelease.Location = new Point(22, 41);
            onOffSwitch_AutoRelease.Name = "onOffSwitch_AutoRelease";
            onOffSwitch_AutoRelease.Size = new Size(49, 22);
            onOffSwitch_AutoRelease.SwitchedOn = false;
            onOffSwitch_AutoRelease.TabIndex = 6;
            onOffSwitch_AutoRelease.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(OnOffSwitch_AutoRelease_SwitchChangeNotify);
            label_AutoRelease.AutoSize = true;
            label_AutoRelease.Location = new Point(20, 26);
            label_AutoRelease.Name = "label_AutoRelease";
            label_AutoRelease.Size = new Size(143, 12);
            label_AutoRelease.TabIndex = 6;
            label_AutoRelease.Text = "$COMPRESSOR_AUTORELEASE";
            label_Release.AutoSize = true;
            label_Release.Location = new Point(198, 81);
            label_Release.Name = "label_Release";
            label_Release.Size = new Size(41, 12);
            label_Release.TabIndex = 5;
            label_Release.Text = "5.00ms";
            hSlider_Release.BackColor = SystemColors.Control;
            hSlider_Release.Location = new Point(7, 72);
            hSlider_Release.MoveDelta = 1U;
            hSlider_Release.Name = "hSlider_Release";
            hSlider_Release.Position = 0U;
            hSlider_Release.PositionFloat = 0.0f;
            hSlider_Release.Size = new Size(185, 31);
            hSlider_Release.TabIndex = 5;
            hSlider_Release.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(HSlider_Release_PositionChangeNotify);
            groupBox_Attack.Controls.Add(onOffSwitch_AutoAttack);
            groupBox_Attack.Controls.Add(label_AutoAttack);
            groupBox_Attack.Controls.Add(label_Attack);
            groupBox_Attack.Controls.Add(hSlider_Attack);
            groupBox_Attack.Location = new Point(12, 294);
            groupBox_Attack.Name = "groupBox_Attack";
            groupBox_Attack.Size = new Size(271, 115);
            groupBox_Attack.TabIndex = 7;
            groupBox_Attack.TabStop = false;
            groupBox_Attack.Text = "$COMPRESSOR_ATTACK";
            onOffSwitch_AutoAttack.BackColor = Color.Transparent;
            onOffSwitch_AutoAttack.Location = new Point(22, 41);
            onOffSwitch_AutoAttack.Name = "onOffSwitch_AutoAttack";
            onOffSwitch_AutoAttack.Size = new Size(49, 22);
            onOffSwitch_AutoAttack.SwitchedOn = false;
            onOffSwitch_AutoAttack.TabIndex = 6;
            onOffSwitch_AutoAttack.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(OnOffSwitch_AutoAttack_SwitchChangeNotify);
            label_AutoAttack.AutoSize = true;
            label_AutoAttack.Location = new Point(20, 26);
            label_AutoAttack.Name = "label_AutoAttack";
            label_AutoAttack.Size = new Size(137, 12);
            label_AutoAttack.TabIndex = 6;
            label_AutoAttack.Text = "$COMPRESSOR_AUTOATTACK";
            label_Attack.AutoSize = true;
            label_Attack.Location = new Point(198, 81);
            label_Attack.Name = "label_Attack";
            label_Attack.Size = new Size(41, 12);
            label_Attack.TabIndex = 5;
            label_Attack.Text = "0.10ms";
            hSlider_Attack.BackColor = SystemColors.Control;
            hSlider_Attack.Location = new Point(7, 72);
            hSlider_Attack.MoveDelta = 1U;
            hSlider_Attack.Name = "hSlider_Attack";
            hSlider_Attack.Position = 0U;
            hSlider_Attack.PositionFloat = 0.0f;
            hSlider_Attack.Size = new Size(185, 31);
            hSlider_Attack.TabIndex = 5;
            hSlider_Attack.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(HSlider_Attack_PositionChangeNotify);
            singleButton_Cancel.BackColor = SystemColors.Control;
            singleButton_Cancel.ButtonText = "$CANCEL";
            singleButton_Cancel.Location = new Point(448, 20);
            singleButton_Cancel.Name = "singleButton_Cancel";
            singleButton_Cancel.Size = new Size(112, 40);
            singleButton_Cancel.TabIndex = 9;
            singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Cancel_ButtonClickNotify);
            singleButton_OK.BackColor = SystemColors.Control;
            singleButton_OK.ButtonText = "$OK";
            singleButton_OK.Location = new Point(328, 20);
            singleButton_OK.Name = "singleButton_OK";
            singleButton_OK.Size = new Size(112, 40);
            singleButton_OK.TabIndex = 10;
            singleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_OK_ButtonClickNotify);
            groupBox_MakeUpGain.Controls.Add(onOffSwitch_AutoGain);
            groupBox_MakeUpGain.Controls.Add(label_AutoGain);
            groupBox_MakeUpGain.Controls.Add(label_Gain);
            groupBox_MakeUpGain.Controls.Add(hSlider_Gain);
            groupBox_MakeUpGain.Location = new Point(12, 415);
            groupBox_MakeUpGain.Name = "groupBox_MakeUpGain";
            groupBox_MakeUpGain.Size = new Size(548, 121);
            groupBox_MakeUpGain.TabIndex = 11;
            groupBox_MakeUpGain.TabStop = false;
            groupBox_MakeUpGain.Text = "$COMPRESSOR_MAKEUPGAIN";
            onOffSwitch_AutoGain.BackColor = Color.Transparent;
            onOffSwitch_AutoGain.Location = new Point(22, 41);
            onOffSwitch_AutoGain.Name = "onOffSwitch_AutoGain";
            onOffSwitch_AutoGain.Size = new Size(49, 22);
            onOffSwitch_AutoGain.SwitchedOn = false;
            onOffSwitch_AutoGain.TabIndex = 8;
            onOffSwitch_AutoGain.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(OnOffSwitch_AutoGain_SwitchChangeNotify);
            label_AutoGain.AutoSize = true;
            label_AutoGain.Location = new Point(20, 26);
            label_AutoGain.Name = "label_AutoGain";
            label_AutoGain.Size = new Size(125, 12);
            label_AutoGain.TabIndex = 7;
            label_AutoGain.Text = "$COMPRESSOR_AUTOGAIN";
            label_Gain.AutoSize = true;
            label_Gain.Location = new Point(475, 88);
            label_Gain.Name = "label_Gain";
            label_Gain.Size = new Size(23, 12);
            label_Gain.TabIndex = 5;
            label_Gain.Text = "0dB";
            hSlider_Gain.BackColor = SystemColors.Control;
            hSlider_Gain.Location = new Point(7, 71);
            hSlider_Gain.MoveDelta = 1U;
            hSlider_Gain.Name = "hSlider_Gain";
            hSlider_Gain.Position = 0U;
            hSlider_Gain.PositionFloat = 0.0f;
            hSlider_Gain.Size = new Size(462, 47);
            hSlider_Gain.TabIndex = 5;
            hSlider_Gain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(HSlider_Gain_PositionChangeNotify);
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 556);
            Controls.Add(groupBox_MakeUpGain);
            Controls.Add(singleButton_OK);
            Controls.Add(singleButton_Cancel);
            Controls.Add(groupBox_Release);
            Controls.Add(groupBox_Attack);
            Controls.Add(groupBox_Ratio);
            Controls.Add(groupBox_Knee);
            Controls.Add(groupBox_Threshold);
            Controls.Add(onOffSwitch_Compressor);
            Controls.Add(label_Compressor_Enable);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = nameof(FrmCompressorLite);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$COMPRESSOR";
            groupBox_Threshold.ResumeLayout(false);
            groupBox_Threshold.PerformLayout();
            groupBox_Knee.ResumeLayout(false);
            groupBox_Knee.PerformLayout();
            groupBox_Ratio.ResumeLayout(false);
            groupBox_Ratio.PerformLayout();
            groupBox_Release.ResumeLayout(false);
            groupBox_Release.PerformLayout();
            groupBox_Attack.ResumeLayout(false);
            groupBox_Attack.PerformLayout();
            groupBox_MakeUpGain.ResumeLayout(false);
            groupBox_MakeUpGain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        public bool CompressorEnabled
        {
            get => m_bCompressorEnabled;
            set
            {
                m_bCompressorEnabled = value;
                UpdateUI();
            }
        }

        public float Threshold
        {
            get => m_rThreshold;
            set
            {
                m_rThreshold = value;
                UpdateUI();
            }
        }

        public float KneeWidth
        {
            get => m_rKneewidth;
            set
            {
                m_rKneewidth = value;
                UpdateUI();
            }
        }

        public bool AutoKnee
        {
            get => m_bAutoKnee;
            set
            {
                m_bAutoKnee = value;
                UpdateUI();
            }
        }

        public float Ratio
        {
            get => m_rRatio;
            set
            {
                m_rRatio = value;
                UpdateUI();
            }
        }

        public float AttackTime
        {
            get => m_rAttack;
            set
            {
                m_rAttack = value;
                UpdateUI();
            }
        }

        public bool AutoAttack
        {
            get => m_bAutoAttack;
            set
            {
                m_bAutoAttack = value;
                UpdateUI();
            }
        }

        public float ReleaseTime
        {
            get => m_rRelease;
            set
            {
                m_rRelease = value;
                UpdateUI();
            }
        }

        public bool AutoRelease
        {
            get => m_bAutoRelease;
            set
            {
                m_bAutoRelease = value;
                UpdateUI();
            }
        }

        public float MakeupGain
        {
            get => m_rMakeupGain;
            set
            {
                m_rMakeupGain = value;
                UpdateUI();
            }
        }

        public bool AutoGain
        {
            get => m_bAutoGain;
            set
            {
                m_bAutoGain = value;
                UpdateUI();
            }
        }

        public FrmCompressorLite()
        {
            InitializeComponent();
            Text = GlobalMessages.COMPRESSOR;
            singleButton_OK.ButtonText = GlobalMessages.OK;
            singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
            label_Compressor_Enable.Text = GlobalMessages.ENABLE;
            groupBox_Threshold.Text = GlobalMessages.COMPRESSOR_THRESHOLD;
            groupBox_Knee.Text = GlobalMessages.COMPRESSOR_KNEEWIDTH;
            label_AutoKnee.Text = GlobalMessages.COMPRESSOR_AUTOKNEE;
            groupBox_Ratio.Text = GlobalMessages.COMPRESSOR_RATIO;
            groupBox_Attack.Text = GlobalMessages.COMPRESSOR_ATTACK;
            label_AutoAttack.Text = GlobalMessages.COMPRESSOR_AUTOATTACK;
            groupBox_Release.Text = GlobalMessages.COMPRESSOR_RELEASE;
            label_AutoRelease.Text = GlobalMessages.COMPRESSOR_AUTORELEASE;
            groupBox_MakeUpGain.Text = GlobalMessages.COMPRESSOR_MAKEUPGAIN;
            label_AutoGain.Text = GlobalMessages.COMPRESSOR_AUTOGAIN;
            UpdateUI();
        }

        private void UpdateUI()
        {
            onOffSwitch_Compressor.SwitchedOn = m_bCompressorEnabled;
            onOffSwitch_AutoKnee.SwitchedOn = m_bAutoKnee;
            onOffSwitch_AutoAttack.SwitchedOn = m_bAutoAttack;
            onOffSwitch_AutoRelease.SwitchedOn = m_bAutoRelease;
            onOffSwitch_AutoGain.SwitchedOn = m_bAutoGain;
            hSlider_Threshold.Position = (uint)(m_rThreshold * 100.0);
            hSlider_Knee.Position = (uint)(m_rKneewidth * 100.0);
            hSlider_Ratio.Position = (uint)(m_rRatio * 100.0);
            hSlider_Attack.Position = (uint)(m_rAttack * 100.0);
            hSlider_Release.Position = (uint)(m_rRelease * 100.0);
            hSlider_Gain.Position = (uint)(m_rMakeupGain * 100.0);
        }

        private void OnOffSwitch_Compressor_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_bCompressorEnabled = bSwitchedOn;
        }

        private void OnOffSwitch_AutoKnee_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_bAutoKnee = bSwitchedOn;
        }

        private void OnOffSwitch_AutoAttack_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_bAutoAttack = bSwitchedOn;
        }

        private void OnOffSwitch_AutoRelease_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_bAutoRelease = bSwitchedOn;
        }

        private void OnOffSwitch_AutoGain_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_bAutoGain = bSwitchedOn;
        }

        private void HSlider_Threshold_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_rThreshold = fPercent;
            label_Threshold.Text = (20.0 * Math.Log10(Math.Pow(10.0, (double)fPercent * -60.0 / 20.0))).ToString("F02") + "dB";
        }

        private void HSlider_Knee_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_rKneewidth = fPercent;
            label_Knee.Text = (20.0 * Math.Log10(Math.Pow(10.0, (double)fPercent * 60.0 / 20.0))).ToString("F02") + "dB";
        }

        private void HSlider_Ratio_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_rRatio = fPercent;
            if ((double)fPercent > 0.99000000953674316)
                label_Ratio.Text = "oo:1";
            else
                label_Ratio.Text = (1.0 / (1.0 - (double)fPercent)).ToString("F02") + ":1";
        }

        private void HSlider_Attack_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_rAttack = fPercent;
            label_Attack.Text = ((double)Parameters.PARAM2LOG(fPercent, 0.0001f, 0.2f) * 1000.0).ToString("F02") + "ms";
        }

        private void HSlider_Release_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_rRelease = fPercent;
            label_Release.Text = ((double)Parameters.PARAM2LOG(fPercent, 0.005f, 2f) * 1000.0).ToString("F02") + "ms";
        }

        private void HSlider_Gain_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_rMakeupGain = fPercent;
            label_Gain.Text = (20.0 * Math.Log10(Math.Pow(10.0, (double)fPercent * 60.0 / 20.0))).ToString("F02") + "dB";
        }

        private void SingleButton_OK_ButtonClickNotify(SingleButton objSender)
        {
            DialogResult = DialogResult.OK;
        }

        private void SingleButton_Cancel_ButtonClickNotify(SingleButton objSender)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
