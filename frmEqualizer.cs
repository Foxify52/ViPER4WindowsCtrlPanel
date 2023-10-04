using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
    public class FrmEqualizer : Form
    {
        private readonly IContainer components;
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
        private readonly float[] m_faEQBands = new float[18];
        private readonly List<VSlider> m_ctlEQBandList = new List<VSlider>();
        private RuntimeUtils.ConfigProxy.ParamOfBaseSystem m_paramBaseSystem;
        private RuntimeUtils.ConfigProxy.ParamOfMusicMode m_paramMusicMode;
        private RuntimeUtils.ConfigProxy.ParamOfMovieMode m_paramMovieMode;
        private RuntimeUtils.ConfigProxy.ParamOfFreestyle m_paramFreestyle;
        private RuntimeUtils.ConfigProxy m_cpConfigProxy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmEqualizer));
            label_Equalizer_Enable = new Label();
            onOffSwitch_Equalizer = new OnOffSwitch();
            vSlider1 = new VSlider();
            vSlider2 = new VSlider();
            vSlider3 = new VSlider();
            vSlider4 = new VSlider();
            vSlider5 = new VSlider();
            vSlider6 = new VSlider();
            vSlider7 = new VSlider();
            vSlider8 = new VSlider();
            vSlider9 = new VSlider();
            vSlider10 = new VSlider();
            vSlider11 = new VSlider();
            vSlider12 = new VSlider();
            vSlider13 = new VSlider();
            vSlider14 = new VSlider();
            vSlider15 = new VSlider();
            vSlider16 = new VSlider();
            vSlider17 = new VSlider();
            vSlider18 = new VSlider();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            singleButton_Preset = new SingleButton();
            singleButton_OK = new SingleButton();
            label_dB_Max = new Label();
            label_dB_Min = new Label();
            label_dB_Zero = new Label();
            checkBox_RealtimeAdjust = new CheckBox();
            SuspendLayout();
            label_Equalizer_Enable.AutoSize = true;
            label_Equalizer_Enable.Location = new Point(24, 22);
            label_Equalizer_Enable.Name = "label_Equalizer_Enable";
            label_Equalizer_Enable.Size = new Size(47, 12);
            label_Equalizer_Enable.TabIndex = 0;
            label_Equalizer_Enable.Text = "$ENABLE";
            onOffSwitch_Equalizer.BackColor = Color.Transparent;
            onOffSwitch_Equalizer.Location = new Point(24, 37);
            onOffSwitch_Equalizer.Name = "onOffSwitch_Equalizer";
            onOffSwitch_Equalizer.Size = new Size(107, 28);
            onOffSwitch_Equalizer.SwitchedOn = false;
            onOffSwitch_Equalizer.TabIndex = 1;
            vSlider1.BackColor = SystemColors.Control;
            vSlider1.Location = new Point(53, 83);
            vSlider1.MoveDelta = 1U;
            vSlider1.Name = "vSlider1";
            vSlider1.Position = 50U;
            vSlider1.Size = new Size(47, 204);
            vSlider1.TabIndex = 2;
            vSlider2.BackColor = SystemColors.Control;
            vSlider2.Location = new Point(106, 83);
            vSlider2.MoveDelta = 1U;
            vSlider2.Name = "vSlider2";
            vSlider2.Position = 50U;
            vSlider2.Size = new Size(47, 204);
            vSlider2.TabIndex = 3;
            vSlider3.BackColor = SystemColors.Control;
            vSlider3.Location = new Point(159, 83);
            vSlider3.MoveDelta = 1U;
            vSlider3.Name = "vSlider3";
            vSlider3.Position = 50U;
            vSlider3.Size = new Size(47, 204);
            vSlider3.TabIndex = 4;
            vSlider4.BackColor = SystemColors.Control;
            vSlider4.Location = new Point(212, 83);
            vSlider4.MoveDelta = 1U;
            vSlider4.Name = "vSlider4";
            vSlider4.Position = 50U;
            vSlider4.Size = new Size(47, 204);
            vSlider4.TabIndex = 5;
            vSlider5.BackColor = SystemColors.Control;
            vSlider5.Location = new Point(265, 83);
            vSlider5.MoveDelta = 1U;
            vSlider5.Name = "vSlider5";
            vSlider5.Position = 50U;
            vSlider5.Size = new Size(47, 204);
            vSlider5.TabIndex = 6;
            vSlider6.BackColor = SystemColors.Control;
            vSlider6.Location = new Point(318, 83);
            vSlider6.MoveDelta = 1U;
            vSlider6.Name = "vSlider6";
            vSlider6.Position = 50U;
            vSlider6.Size = new Size(47, 204);
            vSlider6.TabIndex = 7;
            vSlider7.BackColor = SystemColors.Control;
            vSlider7.Location = new Point(371, 83);
            vSlider7.MoveDelta = 1U;
            vSlider7.Name = "vSlider7";
            vSlider7.Position = 50U;
            vSlider7.Size = new Size(47, 204);
            vSlider7.TabIndex = 8;
            vSlider8.BackColor = SystemColors.Control;
            vSlider8.Location = new Point(424, 83);
            vSlider8.MoveDelta = 1U;
            vSlider8.Name = "vSlider8";
            vSlider8.Position = 50U;
            vSlider8.Size = new Size(47, 204);
            vSlider8.TabIndex = 9;
            vSlider9.BackColor = SystemColors.Control;
            vSlider9.Location = new Point(477, 83);
            vSlider9.MoveDelta = 1U;
            vSlider9.Name = "vSlider9";
            vSlider9.Position = 50U;
            vSlider9.Size = new Size(47, 204);
            vSlider9.TabIndex = 10;
            vSlider10.BackColor = SystemColors.Control;
            vSlider10.Location = new Point(530, 83);
            vSlider10.MoveDelta = 1U;
            vSlider10.Name = "vSlider10";
            vSlider10.Position = 50U;
            vSlider10.Size = new Size(47, 204);
            vSlider10.TabIndex = 11;
            vSlider11.BackColor = SystemColors.Control;
            vSlider11.Location = new Point(583, 83);
            vSlider11.MoveDelta = 1U;
            vSlider11.Name = "vSlider11";
            vSlider11.Position = 50U;
            vSlider11.Size = new Size(47, 204);
            vSlider11.TabIndex = 12;
            vSlider12.BackColor = SystemColors.Control;
            vSlider12.Location = new Point(636, 83);
            vSlider12.MoveDelta = 1U;
            vSlider12.Name = "vSlider12";
            vSlider12.Position = 50U;
            vSlider12.Size = new Size(47, 204);
            vSlider12.TabIndex = 13;
            vSlider13.BackColor = SystemColors.Control;
            vSlider13.Location = new Point(689, 83);
            vSlider13.MoveDelta = 1U;
            vSlider13.Name = "vSlider13";
            vSlider13.Position = 50U;
            vSlider13.Size = new Size(47, 204);
            vSlider13.TabIndex = 14;
            vSlider14.BackColor = SystemColors.Control;
            vSlider14.Location = new Point(742, 83);
            vSlider14.MoveDelta = 1U;
            vSlider14.Name = "vSlider14";
            vSlider14.Position = 50U;
            vSlider14.Size = new Size(47, 204);
            vSlider14.TabIndex = 15;
            vSlider15.BackColor = SystemColors.Control;
            vSlider15.Location = new Point(795, 83);
            vSlider15.MoveDelta = 1U;
            vSlider15.Name = "vSlider15";
            vSlider15.Position = 50U;
            vSlider15.Size = new Size(47, 204);
            vSlider15.TabIndex = 16;
            vSlider16.BackColor = SystemColors.Control;
            vSlider16.Location = new Point(848, 83);
            vSlider16.MoveDelta = 1U;
            vSlider16.Name = "vSlider16";
            vSlider16.Position = 50U;
            vSlider16.Size = new Size(47, 204);
            vSlider16.TabIndex = 17;
            vSlider17.BackColor = SystemColors.Control;
            vSlider17.Location = new Point(901, 83);
            vSlider17.MoveDelta = 1U;
            vSlider17.Name = "vSlider17";
            vSlider17.Position = 50U;
            vSlider17.Size = new Size(47, 204);
            vSlider17.TabIndex = 18;
            vSlider18.BackColor = SystemColors.Control;
            vSlider18.Location = new Point(954, 83);
            vSlider18.MoveDelta = 1U;
            vSlider18.Name = "vSlider18";
            vSlider18.Position = 50U;
            vSlider18.Size = new Size(47, 204);
            vSlider18.TabIndex = 19;
            label1.AutoSize = true;
            label1.Location = new Point(69, 290);
            label1.Name = "label1";
            label1.Size = new Size(17, 12);
            label1.TabIndex = 20;
            label1.Text = "65";
            label2.AutoSize = true;
            label2.Location = new Point(121, 290);
            label2.Name = "label2";
            label2.Size = new Size(17, 12);
            label2.TabIndex = 21;
            label2.Text = "93";
            label3.AutoSize = true;
            label3.Location = new Point(173, 290);
            label3.Name = "label3";
            label3.Size = new Size(23, 12);
            label3.TabIndex = 22;
            label3.Text = "131";
            label4.AutoSize = true;
            label4.Location = new Point(225, 290);
            label4.Name = "label4";
            label4.Size = new Size(23, 12);
            label4.TabIndex = 23;
            label4.Text = "185";
            label5.AutoSize = true;
            label5.Location = new Point(279, 290);
            label5.Name = "label5";
            label5.Size = new Size(23, 12);
            label5.TabIndex = 24;
            label5.Text = "262";
            label6.AutoSize = true;
            label6.Location = new Point(332, 290);
            label6.Name = "label6";
            label6.Size = new Size(23, 12);
            label6.TabIndex = 25;
            label6.Text = "370";
            label7.AutoSize = true;
            label7.Location = new Point(384, 290);
            label7.Name = "label7";
            label7.Size = new Size(23, 12);
            label7.TabIndex = 26;
            label7.Text = "523";
            label8.AutoSize = true;
            label8.Location = new Point(437, 290);
            label8.Name = "label8";
            label8.Size = new Size(23, 12);
            label8.TabIndex = 27;
            label8.Text = "740";
            label9.AutoSize = true;
            label9.Location = new Point(487, 290);
            label9.Name = "label9";
            label9.Size = new Size(29, 12);
            label9.TabIndex = 28;
            label9.Text = "1.0k";
            label10.AutoSize = true;
            label10.Location = new Point(540, 290);
            label10.Name = "label10";
            label10.Size = new Size(29, 12);
            label10.TabIndex = 29;
            label10.Text = "1.5k";
            label11.AutoSize = true;
            label11.Location = new Point(593, 290);
            label11.Name = "label11";
            label11.Size = new Size(29, 12);
            label11.TabIndex = 30;
            label11.Text = "2.1k";
            label12.AutoSize = true;
            label12.Location = new Point(646, 290);
            label12.Name = "label12";
            label12.Size = new Size(29, 12);
            label12.TabIndex = 31;
            label12.Text = "3.0k";
            label13.AutoSize = true;
            label13.Location = new Point(699, 290);
            label13.Name = "label13";
            label13.Size = new Size(29, 12);
            label13.TabIndex = 32;
            label13.Text = "4.2k";
            label14.AutoSize = true;
            label14.Location = new Point(752, 290);
            label14.Name = "label14";
            label14.Size = new Size(29, 12);
            label14.TabIndex = 33;
            label14.Text = "6.0k";
            label15.AutoSize = true;
            label15.Location = new Point(806, 290);
            label15.Name = "label15";
            label15.Size = new Size(29, 12);
            label15.TabIndex = 34;
            label15.Text = "8.4k";
            label16.AutoSize = true;
            label16.Location = new Point(857, 290);
            label16.Name = "label16";
            label16.Size = new Size(35, 12);
            label16.TabIndex = 35;
            label16.Text = "11.8k";
            label17.AutoSize = true;
            label17.Location = new Point(910, 290);
            label17.Name = "label17";
            label17.Size = new Size(35, 12);
            label17.TabIndex = 36;
            label17.Text = "16.7k";
            label18.AutoSize = true;
            label18.Location = new Point(967, 290);
            label18.Name = "label18";
            label18.Size = new Size(23, 12);
            label18.TabIndex = 37;
            label18.Text = "20k";
            singleButton_Preset.BackColor = SystemColors.Control;
            singleButton_Preset.ButtonText = "$PRESET";
            singleButton_Preset.Location = new Point(171, 25);
            singleButton_Preset.Name = "singleButton_Preset";
            singleButton_Preset.Size = new Size(143, 40);
            singleButton_Preset.TabIndex = 38;
            singleButton_Preset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Preset_ButtonClickNotify);
            singleButton_OK.BackColor = SystemColors.Control;
            singleButton_OK.ButtonText = "$OK";
            singleButton_OK.Location = new Point(878, 25);
            singleButton_OK.Name = "singleButton_OK";
            singleButton_OK.Size = new Size(112, 40);
            singleButton_OK.TabIndex = 40;
            singleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_OK_ButtonClickNotify);
            label_dB_Max.AutoSize = true;
            label_dB_Max.Location = new Point(12, 101);
            label_dB_Max.Name = "label_dB_Max";
            label_dB_Max.Size = new Size(29, 12);
            label_dB_Max.TabIndex = 41;
            label_dB_Max.Text = "13dB";
            label_dB_Min.AutoSize = true;
            label_dB_Min.Location = new Point(12, 256);
            label_dB_Min.Name = "label_dB_Min";
            label_dB_Min.Size = new Size(41, 12);
            label_dB_Min.TabIndex = 42;
            label_dB_Min.Text = "-120dB";
            label_dB_Zero.AutoSize = true;
            label_dB_Zero.Location = new Point(12, 179);
            label_dB_Zero.Name = "label_dB_Zero";
            label_dB_Zero.Size = new Size(23, 12);
            label_dB_Zero.TabIndex = 43;
            label_dB_Zero.Text = "0dB";
            checkBox_RealtimeAdjust.AutoSize = true;
            checkBox_RealtimeAdjust.Location = new Point(386, 37);
            checkBox_RealtimeAdjust.Name = "checkBox_RealtimeAdjust";
            checkBox_RealtimeAdjust.Size = new Size(180, 16);
            checkBox_RealtimeAdjust.TabIndex = 44;
            checkBox_RealtimeAdjust.Text = "$EQUALIZER_REALTIME_ADJUST";
            checkBox_RealtimeAdjust.UseVisualStyleBackColor = true;
            checkBox_RealtimeAdjust.CheckedChanged += new EventHandler(CheckBox_RealtimeAdjust_CheckedChanged);
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 324);
            Controls.Add(checkBox_RealtimeAdjust);
            Controls.Add(label_dB_Zero);
            Controls.Add(label_dB_Min);
            Controls.Add(label_dB_Max);
            Controls.Add(singleButton_OK);
            Controls.Add(singleButton_Preset);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(vSlider18);
            Controls.Add(vSlider17);
            Controls.Add(vSlider16);
            Controls.Add(vSlider15);
            Controls.Add(vSlider14);
            Controls.Add(vSlider13);
            Controls.Add(vSlider12);
            Controls.Add(vSlider11);
            Controls.Add(vSlider10);
            Controls.Add(vSlider9);
            Controls.Add(vSlider8);
            Controls.Add(vSlider7);
            Controls.Add(vSlider6);
            Controls.Add(vSlider5);
            Controls.Add(vSlider4);
            Controls.Add(vSlider3);
            Controls.Add(vSlider2);
            Controls.Add(vSlider1);
            Controls.Add(onOffSwitch_Equalizer);
            Controls.Add(label_Equalizer_Enable);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = nameof(FrmEqualizer);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$EQUALIZER";
            ResumeLayout(false);
            PerformLayout();
        }

        public void SetRealtimeParameters(
          RuntimeUtils.ConfigProxy.ParamOfBaseSystem paramBaseSystem,
          RuntimeUtils.ConfigProxy.ParamOfMusicMode paramMusicMode,
          RuntimeUtils.ConfigProxy.ParamOfMovieMode paramMovieMode,
          RuntimeUtils.ConfigProxy.ParamOfFreestyle paramFreestyle,
          RuntimeUtils.ConfigProxy cpConfigProxy)
        {
            m_paramBaseSystem = paramBaseSystem;
            m_paramMusicMode = paramMusicMode;
            m_paramMovieMode = paramMovieMode;
            m_paramFreestyle = paramFreestyle;
            m_cpConfigProxy = cpConfigProxy;
        }

        public FrmEqualizer()
        {
            InitializeComponent();
            Text = GlobalMessages.EQUALIZER;
            label_Equalizer_Enable.Text = GlobalMessages.ENABLE;
            checkBox_RealtimeAdjust.Text = GlobalMessages.EQUALIZER_REALTIME_ADJUST;
            singleButton_Preset.ButtonText = GlobalMessages.PRESET;
            singleButton_OK.ButtonText = GlobalMessages.OK;
            m_ctlEQBandList.Add(vSlider1);
            m_ctlEQBandList.Add(vSlider2);
            m_ctlEQBandList.Add(vSlider3);
            m_ctlEQBandList.Add(vSlider4);
            m_ctlEQBandList.Add(vSlider5);
            m_ctlEQBandList.Add(vSlider6);
            m_ctlEQBandList.Add(vSlider7);
            m_ctlEQBandList.Add(vSlider8);
            m_ctlEQBandList.Add(vSlider9);
            m_ctlEQBandList.Add(vSlider10);
            m_ctlEQBandList.Add(vSlider11);
            m_ctlEQBandList.Add(vSlider12);
            m_ctlEQBandList.Add(vSlider13);
            m_ctlEQBandList.Add(vSlider14);
            m_ctlEQBandList.Add(vSlider15);
            m_ctlEQBandList.Add(vSlider16);
            m_ctlEQBandList.Add(vSlider17);
            m_ctlEQBandList.Add(vSlider18);
            for (int index = 0; index < m_ctlEQBandList.Count; ++index)
                m_ctlEQBandList[index].Tag = index.ToString();
            for (int index = 0; index < m_faEQBands.Length; ++index)
                m_faEQBands[index] = 1f;
            m_bEQEnabled = false;
            UpdateUI();
            foreach (VSlider ctlEqBand in m_ctlEQBandList)
                ctlEqBand.PositionChangeNotify += new VSlider.PositionChangeEventDelegate(EQBandChanged);
            onOffSwitch_Equalizer.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(EQSwitchChange);
        }

        private void UpdateUI()
        {
            onOffSwitch_Equalizer.SwitchedOn = m_bEQEnabled;
            for (int index = 0; index < m_faEQBands.Length; ++index)
            {
                float faEqBand = m_faEQBands[index];
                uint num = (uint)(((double)faEqBand > 1.0 ? (double)((faEqBand - 1f) / 4f * 0.5f + 0.5f) : (double)(faEqBand * 0.5f)) * 100.0);
                if (num > 100U)
                    num = 100U;
                m_ctlEQBandList[index].Position = num;
            }
        }

        private void EQBandChanged(float fPercent, VSlider objSender)
        {
            if (objSender == null || objSender.Tag == null || !(objSender.Tag is string tag))
                return;
            if (!int.TryParse(tag, out int result) || result < 0 || result >= m_faEQBands.Length)
                return;
            float num = (double)fPercent >= 0.5 ? (float)(((double)fPercent - 0.5) / 0.5 * 4.0 + 1.0) : fPercent / 0.5f;
            m_faEQBands[result] = num;
            if (!checkBox_RealtimeAdjust.Checked)
                return;
            if (m_paramBaseSystem.m_nEffectMode == 0U)
            {
                m_paramMusicMode.m_rpEqualizerBands[result] = num;
                m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
                m_cpConfigProxy.SyncConfig();
            }
            if (m_paramBaseSystem.m_nEffectMode == 1U)
            {
                m_paramMovieMode.m_rpEqualizerBands[result] = num;
                m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
                m_cpConfigProxy.SyncConfig();
            }
            if (m_paramBaseSystem.m_nEffectMode != 2U)
                return;
            m_paramFreestyle.m_rpEqualizerBands[result] = num;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void EQSwitchChange(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_bEQEnabled = bSwitchedOn;
            if (!checkBox_RealtimeAdjust.Checked)
                return;
            if (m_paramBaseSystem.m_nEffectMode == 0U)
            {
                m_paramMusicMode.m_bEqualizerEnabled = !m_bEQEnabled ? 0 : 1;
                m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
                m_cpConfigProxy.SyncConfig();
            }
            if (m_paramBaseSystem.m_nEffectMode == 1U)
            {
                m_paramMovieMode.m_bEqualizerEnabled = !m_bEQEnabled ? 0 : 1;
                m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
                m_cpConfigProxy.SyncConfig();
            }
            if (m_paramBaseSystem.m_nEffectMode != 2U)
                return;
            m_paramFreestyle.m_bEqualizerEnabled = !m_bEQEnabled ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        public void SetParameters(float[] faEQBands, bool bEQEnabled)
        {
            if (faEQBands == null || faEQBands.Length != m_faEQBands.Length)
                return;
            Array.Copy(faEQBands, m_faEQBands, m_faEQBands.Length);
            m_bEQEnabled = bEQEnabled;
            UpdateUI();
        }

        public float[] GetParameter()
        {
            return m_faEQBands;
        }

        public bool GetEQEnabled()
        {
            return m_bEQEnabled;
        }

        private void SingleButton_OK_ButtonClickNotify(SingleButton objSender)
        {
            DialogResult = DialogResult.OK;
        }

        private void SingleButton_Preset_ButtonClickNotify(SingleButton objSender)
        {
            FrmEQPreset frmEqPreset = new FrmEQPreset();
            frmEqPreset.SetPreset(m_faEQBands);
            if (frmEqPreset.ShowDialog() == DialogResult.Cancel)
                return;
            float[] preset = frmEqPreset.GetPreset();
            if (preset == null || preset.Length != m_faEQBands.Length)
                return;
            Array.Copy(preset, m_faEQBands, m_faEQBands.Length);
            if (checkBox_RealtimeAdjust.Checked)
            {
                if (m_paramBaseSystem.m_nEffectMode == 0U)
                {
                    Array.Copy(m_faEQBands, m_paramMusicMode.m_rpEqualizerBands, m_faEQBands.Length);
                    m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
                    m_cpConfigProxy.SyncConfig();
                }
                if (m_paramBaseSystem.m_nEffectMode == 1U)
                {
                    Array.Copy(m_faEQBands, m_paramMovieMode.m_rpEqualizerBands, m_faEQBands.Length);
                    m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
                    m_cpConfigProxy.SyncConfig();
                }
                if (m_paramBaseSystem.m_nEffectMode == 2U)
                {
                    Array.Copy(m_faEQBands, m_paramFreestyle.m_rpEqualizerBands, m_faEQBands.Length);
                    m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
                    m_cpConfigProxy.SyncConfig();
                }
            }
            UpdateUI();
        }

        private void CheckBox_RealtimeAdjust_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_RealtimeAdjust.Checked)
                return;
            if (m_paramBaseSystem.m_nEffectMode == 0U)
            {
                m_paramMusicMode.m_bEqualizerEnabled = !m_bEQEnabled ? 0 : 1;
                Array.Copy(m_faEQBands, m_paramMusicMode.m_rpEqualizerBands, m_faEQBands.Length);
                m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
                m_cpConfigProxy.SyncConfig();
            }
            if (m_paramBaseSystem.m_nEffectMode == 1U)
            {
                m_paramMovieMode.m_bEqualizerEnabled = !m_bEQEnabled ? 0 : 1;
                Array.Copy(m_faEQBands, m_paramMovieMode.m_rpEqualizerBands, m_faEQBands.Length);
                m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
                m_cpConfigProxy.SyncConfig();
            }
            if (m_paramBaseSystem.m_nEffectMode != 2U)
                return;
            m_paramFreestyle.m_bEqualizerEnabled = !m_bEQEnabled ? 0 : 1;
            Array.Copy(m_faEQBands, m_paramFreestyle.m_rpEqualizerBands, m_faEQBands.Length);
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }
    }
}
