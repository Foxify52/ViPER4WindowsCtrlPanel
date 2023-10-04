using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
    public class FrmVirtualization : Form
    {
        private IContainer components;
        private Label label_AudioSystemConfig;
        private ButtonBox ButtonBox_AudioSystemConfig;
        private GroupBox groupBox_VirtApplied;
        private CheckBox checkBox_MusicMode;
        private CheckBox checkBox_Freestyle;
        private CheckBox checkBox_MovieMode;
        private ListView ListView_Speaker;
        private ColumnHeader columnHeader_Speaker;
        private ColumnHeader columnHeader_Angle;
        private SingleButton SingleButton_ResetConfig;
        private GroupBox groupBox_VirtEnv;
        private OnOffSwitch onOffSwitch_EnvRealize;
        private ComboBox comboBox_EnvRealizePreset;
        private HSlider hSlider_EnvRealizeDrySignal;
        private SingleButton SingleButton_OK;
        private Label label_PrePostProcess;
        private ContextMenuStrip ContextMenuStrip_SpeakerAngle;
        private ToolStripMenuItem ToolStripMenuItem_SpeakerAngle;
        private ToolStripSeparator ToolStripSeparator_Angle;
        private ToolStripComboBox ToolStripComboBox_SpeakerAngle;
        private SingleButton SingleButton_Cancel;
        private TwoSelector twoSelector_PrePostProcess;
        private RuntimeUtils.ConfigProxy.ParamOfBaseSystem m_paramSystem = new RuntimeUtils.ConfigProxy.ParamOfBaseSystem();
        private int m_nCurrentAudioSystem = -1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmVirtualization));
            label_AudioSystemConfig = new Label();
            groupBox_VirtApplied = new GroupBox();
            checkBox_Freestyle = new CheckBox();
            checkBox_MovieMode = new CheckBox();
            checkBox_MusicMode = new CheckBox();
            ListView_Speaker = new ListView();
            columnHeader_Speaker = new ColumnHeader();
            columnHeader_Angle = new ColumnHeader();
            groupBox_VirtEnv = new GroupBox();
            label_PrePostProcess = new Label();
            comboBox_EnvRealizePreset = new ComboBox();
            ContextMenuStrip_SpeakerAngle = new ContextMenuStrip(components);
            ToolStripMenuItem_SpeakerAngle = new ToolStripMenuItem();
            ToolStripSeparator_Angle = new ToolStripSeparator();
            ToolStripComboBox_SpeakerAngle = new ToolStripComboBox();
            SingleButton_Cancel = new SingleButton();
            twoSelector_PrePostProcess = new TwoSelector();
            hSlider_EnvRealizeDrySignal = new HSlider();
            onOffSwitch_EnvRealize = new OnOffSwitch();
            SingleButton_ResetConfig = new SingleButton();
            SingleButton_OK = new SingleButton();
            ButtonBox_AudioSystemConfig = new ButtonBox();
            groupBox_VirtApplied.SuspendLayout();
            groupBox_VirtEnv.SuspendLayout();
            ContextMenuStrip_SpeakerAngle.SuspendLayout();
            SuspendLayout();
            label_AudioSystemConfig.AutoSize = true;
            label_AudioSystemConfig.Location = new Point(12, 17);
            label_AudioSystemConfig.Name = "label_AudioSystemConfig";
            label_AudioSystemConfig.Size = new Size(125, 12);
            label_AudioSystemConfig.TabIndex = 0;
            label_AudioSystemConfig.Text = "$AUDIO_SYSTEM_CONFIG";
            groupBox_VirtApplied.Controls.Add(checkBox_Freestyle);
            groupBox_VirtApplied.Controls.Add(checkBox_MovieMode);
            groupBox_VirtApplied.Controls.Add(checkBox_MusicMode);
            groupBox_VirtApplied.Location = new Point(151, 292);
            groupBox_VirtApplied.Name = "groupBox_VirtApplied";
            groupBox_VirtApplied.Size = new Size(167, 88);
            groupBox_VirtApplied.TabIndex = 2;
            groupBox_VirtApplied.TabStop = false;
            groupBox_VirtApplied.Text = "$VIRT_APPLIED";
            checkBox_Freestyle.AutoSize = true;
            checkBox_Freestyle.Location = new Point(16, 64);
            checkBox_Freestyle.Name = "checkBox_Freestyle";
            checkBox_Freestyle.Size = new Size(114, 16);
            checkBox_Freestyle.TabIndex = 5;
            checkBox_Freestyle.Text = "$FREESTYLE_MODE";
            checkBox_Freestyle.UseVisualStyleBackColor = true;
            checkBox_MovieMode.AutoSize = true;
            checkBox_MovieMode.Location = new Point(16, 42);
            checkBox_MovieMode.Name = "checkBox_MovieMode";
            checkBox_MovieMode.Size = new Size(90, 16);
            checkBox_MovieMode.TabIndex = 4;
            checkBox_MovieMode.Text = "$MOVIE_MODE";
            checkBox_MovieMode.UseVisualStyleBackColor = true;
            checkBox_MusicMode.AutoSize = true;
            checkBox_MusicMode.Location = new Point(16, 20);
            checkBox_MusicMode.Name = "checkBox_MusicMode";
            checkBox_MusicMode.Size = new Size(90, 16);
            checkBox_MusicMode.TabIndex = 3;
            checkBox_MusicMode.Text = "$MUSIC_MODE";
            checkBox_MusicMode.UseVisualStyleBackColor = true;
            ListView_Speaker.Columns.AddRange(new ColumnHeader[2]
            {
        columnHeader_Speaker,
        columnHeader_Angle
            });
            ListView_Speaker.FullRowSelect = true;
            ListView_Speaker.GridLines = true;
            ListView_Speaker.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            ListView_Speaker.HideSelection = false;
            ListView_Speaker.Location = new Point(151, 71);
            ListView_Speaker.MultiSelect = false;
            ListView_Speaker.Name = "ListView_Speaker";
            ListView_Speaker.Size = new Size(167, 215);
            ListView_Speaker.TabIndex = 3;
            ListView_Speaker.UseCompatibleStateImageBehavior = false;
            ListView_Speaker.View = View.Details;
            ListView_Speaker.MouseUp += new MouseEventHandler(ListView_Speaker_MouseUp);
            columnHeader_Speaker.Text = "$VIRT_SPEAKER";
            columnHeader_Speaker.Width = 95;
            columnHeader_Angle.Text = "$VIRT_SPEAKER_ANGLE";
            groupBox_VirtEnv.Controls.Add(twoSelector_PrePostProcess);
            groupBox_VirtEnv.Controls.Add(label_PrePostProcess);
            groupBox_VirtEnv.Controls.Add(hSlider_EnvRealizeDrySignal);
            groupBox_VirtEnv.Controls.Add(comboBox_EnvRealizePreset);
            groupBox_VirtEnv.Controls.Add(onOffSwitch_EnvRealize);
            groupBox_VirtEnv.Location = new Point(324, 36);
            groupBox_VirtEnv.Name = "groupBox_VirtEnv";
            groupBox_VirtEnv.Size = new Size(222, 106);
            groupBox_VirtEnv.TabIndex = 5;
            groupBox_VirtEnv.TabStop = false;
            groupBox_VirtEnv.Text = "$VIRTUAL_ENVIRONMENT";
            label_PrePostProcess.AutoSize = true;
            label_PrePostProcess.Location = new Point(6, 79);
            label_PrePostProcess.Name = "label_PrePostProcess";
            label_PrePostProcess.Size = new Size(107, 12);
            label_PrePostProcess.TabIndex = 3;
            label_PrePostProcess.Text = "$PRE_POST_PROCESS";
            comboBox_EnvRealizePreset.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_EnvRealizePreset.FormattingEnabled = true;
            comboBox_EnvRealizePreset.Location = new Point(6, 20);
            comboBox_EnvRealizePreset.Name = "comboBox_EnvRealizePreset";
            comboBox_EnvRealizePreset.Size = new Size(210, 20);
            comboBox_EnvRealizePreset.TabIndex = 1;
            ContextMenuStrip_SpeakerAngle.Items.AddRange(new ToolStripItem[3]
            {
         ToolStripMenuItem_SpeakerAngle,
         ToolStripSeparator_Angle,
         ToolStripComboBox_SpeakerAngle
            });
            ContextMenuStrip_SpeakerAngle.Name = "ContextMenuStrip_SpeakerAngle";
            ContextMenuStrip_SpeakerAngle.Size = new Size(182, 61);
            ContextMenuStrip_SpeakerAngle.Closed += new ToolStripDropDownClosedEventHandler(ContextMenuStrip_SpeakerAngle_Closed);
            ToolStripMenuItem_SpeakerAngle.Enabled = false;
            ToolStripMenuItem_SpeakerAngle.Name = "ToolStripMenuItem_SpeakerAngle";
            ToolStripMenuItem_SpeakerAngle.Size = new Size(181, 22);
            ToolStripMenuItem_SpeakerAngle.Text = "$SPEAKER_ANGLE";
            ToolStripSeparator_Angle.Name = "ToolStripSeparator_Angle";
            ToolStripSeparator_Angle.Size = new Size(178, 6);
            ToolStripComboBox_SpeakerAngle.DropDownStyle = ComboBoxStyle.DropDownList;
            ToolStripComboBox_SpeakerAngle.Name = "ToolStripComboBox_SpeakerAngle";
            ToolStripComboBox_SpeakerAngle.Size = new Size(121, 25);
            ToolStripComboBox_SpeakerAngle.SelectedIndexChanged += new EventHandler(ToolStripComboBox_SpeakerAngle_SelectedIndexChanged);
            SingleButton_Cancel.BackColor = SystemColors.Control;
            SingleButton_Cancel.ButtonText = "$CANCEL";
            SingleButton_Cancel.Location = new Point(446, 347);
            SingleButton_Cancel.Name = "SingleButton_Cancel";
            SingleButton_Cancel.Size = new Size(100, 33);
            SingleButton_Cancel.TabIndex = 8;
            SingleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Cancel_ButtonClickNotify);
            twoSelector_PrePostProcess.BackColor = Color.Transparent;
            twoSelector_PrePostProcess.CurrentObject = null;
            twoSelector_PrePostProcess.LeftObject = null;
            twoSelector_PrePostProcess.Location = new Point(146, 74);
            twoSelector_PrePostProcess.Name = "twoSelector_PrePostProcess";
            twoSelector_PrePostProcess.RightObject = null;
            twoSelector_PrePostProcess.Selector = TwoSelector.SelectorPosition.SELECTOR_ON_LEFT;
            twoSelector_PrePostProcess.Size = new Size(70, 22);
            twoSelector_PrePostProcess.TabIndex = 9;
            hSlider_EnvRealizeDrySignal.BackColor = SystemColors.Control;
            hSlider_EnvRealizeDrySignal.Location = new Point(68, 48);
            hSlider_EnvRealizeDrySignal.MoveDelta = 1U;
            hSlider_EnvRealizeDrySignal.Name = "hSlider_EnvRealizeDrySignal";
            hSlider_EnvRealizeDrySignal.Position = 0U;
            hSlider_EnvRealizeDrySignal.PositionFloat = 0.0f;
            hSlider_EnvRealizeDrySignal.Size = new Size(148, 20);
            hSlider_EnvRealizeDrySignal.TabIndex = 2;
            onOffSwitch_EnvRealize.BackColor = Color.Transparent;
            onOffSwitch_EnvRealize.Location = new Point(6, 46);
            onOffSwitch_EnvRealize.Name = "onOffSwitch_EnvRealize";
            onOffSwitch_EnvRealize.Size = new Size(53, 22);
            onOffSwitch_EnvRealize.SwitchedOn = false;
            onOffSwitch_EnvRealize.TabIndex = 0;
            SingleButton_ResetConfig.BackColor = SystemColors.Control;
            SingleButton_ResetConfig.ButtonText = "$VIRT_RESET";
            SingleButton_ResetConfig.Location = new Point(151, 36);
            SingleButton_ResetConfig.Name = "SingleButton_ResetConfig";
            SingleButton_ResetConfig.Size = new Size(167, 26);
            SingleButton_ResetConfig.TabIndex = 4;
            SingleButton_ResetConfig.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_ResetConfig_ButtonClickNotify);
            SingleButton_OK.BackColor = SystemColors.Control;
            SingleButton_OK.ButtonText = "$OK";
            SingleButton_OK.Location = new Point(324, 347);
            SingleButton_OK.Name = "SingleButton_OK";
            SingleButton_OK.Size = new Size(100, 33);
            SingleButton_OK.TabIndex = 6;
            SingleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_OK_ButtonClickNotify);
            ButtonBox_AudioSystemConfig.BackColor = SystemColors.Control;
            ButtonBox_AudioSystemConfig.Location = new Point(14, 36);
            ButtonBox_AudioSystemConfig.Name = "ButtonBox_AudioSystemConfig";
            ButtonBox_AudioSystemConfig.Size = new Size(131, 344);
            ButtonBox_AudioSystemConfig.TabIndex = 1;
            ButtonBox_AudioSystemConfig.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(ButtonBox_AudioSystemConfig_ItemSelectedNotify);
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 394);
            Controls.Add(SingleButton_Cancel);
            Controls.Add(groupBox_VirtEnv);
            Controls.Add(SingleButton_ResetConfig);
            Controls.Add(SingleButton_OK);
            Controls.Add(ListView_Speaker);
            Controls.Add(groupBox_VirtApplied);
            Controls.Add(ButtonBox_AudioSystemConfig);
            Controls.Add(label_AudioSystemConfig);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = nameof(FrmVirtualization);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$VIRTUALIZATION";
            groupBox_VirtApplied.ResumeLayout(false);
            groupBox_VirtApplied.PerformLayout();
            groupBox_VirtEnv.ResumeLayout(false);
            groupBox_VirtEnv.PerformLayout();
            ContextMenuStrip_SpeakerAngle.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        public void SetBaseSystemParam(
          RuntimeUtils.ConfigProxy.ParamOfBaseSystem paramSystem)
        {
            m_paramSystem = paramSystem;
            int num1 = m_paramSystem.m_bVirtApplied & 1;
            int num2 = m_paramSystem.m_bVirtApplied >> 1 & 1;
            int num3 = m_paramSystem.m_bVirtApplied >> 2 & 1;
            if (num1 == 1)
                checkBox_MusicMode.Checked = true;
            if (num2 == 1)
                checkBox_MovieMode.Checked = true;
            if (num3 == 1)
                checkBox_Freestyle.Checked = true;
            onOffSwitch_EnvRealize.SwitchedOn = m_paramSystem.m_bEnvRealizeEnabled == 1;
            hSlider_EnvRealizeDrySignal.PositionFloat = m_paramSystem.m_rEnvRealizeDrySignal;
            twoSelector_PrePostProcess.Selector = m_paramSystem.m_bEnvRealizePreprocess != 1 ? TwoSelector.SelectorPosition.SELECTOR_ON_RIGHT : TwoSelector.SelectorPosition.SELECTOR_ON_LEFT;
            for (int index = 0; index < comboBox_EnvRealizePreset.Items.Count; ++index)
            {
                if ((comboBox_EnvRealizePreset.Items[index] as EnvRealizePreset).PresetID == m_paramSystem.m_nEnvRealizePreset)
                {
                    comboBox_EnvRealizePreset.SelectedIndex = index;
                    break;
                }
            }
        }

        public RuntimeUtils.ConfigProxy.ParamOfBaseSystem GetBaseSystemParam()
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            if (checkBox_MusicMode.Checked)
                num1 = 1;
            if (checkBox_MovieMode.Checked)
                num2 = 1;
            if (checkBox_Freestyle.Checked)
                num3 = 1;
            m_paramSystem.m_bVirtApplied = num1 | num2 << 1 | num3 << 2;
            m_paramSystem.m_bEnvRealizeEnabled = !onOffSwitch_EnvRealize.SwitchedOn ? 0 : 1;
            m_paramSystem.m_bEnvRealizePreprocess = twoSelector_PrePostProcess.Selector != TwoSelector.SelectorPosition.SELECTOR_ON_LEFT ? 0 : 1;
            m_paramSystem.m_rEnvRealizeDrySignal = hSlider_EnvRealizeDrySignal.PositionFloat;
            if (comboBox_EnvRealizePreset.SelectedItem == null)
                m_paramSystem.m_bEnvRealizeEnabled = 0;
            else if (comboBox_EnvRealizePreset.SelectedItem.GetType() != typeof(EnvRealizePreset))
                m_paramSystem.m_bEnvRealizeEnabled = 0;
            else
                m_paramSystem.m_nEnvRealizePreset = (comboBox_EnvRealizePreset.SelectedItem as EnvRealizePreset).PresetID;
            return m_paramSystem;
        }

        public FrmVirtualization()
        {
            Parameters.LoadDefaultParameter(ref m_paramSystem);
            m_nCurrentAudioSystem = -1;
            InitializeComponent();
            Text = GlobalMessages.VIRTUALIZATION;
            label_AudioSystemConfig.Text = GlobalMessages.AUDIO_SYSTEM_CONFIG;
            SingleButton_ResetConfig.ButtonText = GlobalMessages.VIRT_RESET;
            groupBox_VirtApplied.Text = GlobalMessages.VIRT_APPLIED;
            checkBox_MusicMode.Text = GlobalMessages.MUSIC_MODE;
            checkBox_MovieMode.Text = GlobalMessages.MOVIE_MODE;
            checkBox_Freestyle.Text = GlobalMessages.FREESTYLE_MODE;
            groupBox_VirtEnv.Text = GlobalMessages.VIRT_ENVIRONMENT;
            label_PrePostProcess.Text = GlobalMessages.VIRT_PREPOST_PROCESS;
            SingleButton_OK.ButtonText = GlobalMessages.OK;
            SingleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
            ButtonBox_AudioSystemConfig.ClearItem();
            ButtonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_MONO, "0"));
            ButtonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_STEREO, "1"));
            ButtonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_HEADSET, "2"));
            ButtonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_REARSTEREO, "3"));
            ButtonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_QUAD, "4"));
            ButtonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_X5P1, "5"));
            ButtonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_X6P1, "6"));
            ButtonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_X7P1, "7"));
            ButtonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_X8P1, "8"));
            ListView_Speaker.Columns[0].Text = GlobalMessages.VIRT_SPEAKER;
            ListView_Speaker.Columns[1].Text = GlobalMessages.VIRT_SPEAKER_ANGLE;
            ListView_Speaker.Items.Clear();
            checkBox_MusicMode.Checked = false;
            checkBox_MovieMode.Checked = false;
            checkBox_Freestyle.Checked = false;
            onOffSwitch_EnvRealize.SwitchedOn = false;
            hSlider_EnvRealizeDrySignal.PositionFloat = 0.7f;
            twoSelector_PrePostProcess.Selector = TwoSelector.SelectorPosition.SELECTOR_ON_LEFT;
            comboBox_EnvRealizePreset.Items.Clear();
            comboBox_EnvRealizePreset.Items.Add(new EnvRealizePreset(GlobalMessages.VIRT_ENVIR_SMALLROOM, 2));
            comboBox_EnvRealizePreset.Items.Add(new EnvRealizePreset(GlobalMessages.VIRT_ENVIR_BATHROOM, 3));
            comboBox_EnvRealizePreset.Items.Add(new EnvRealizePreset(GlobalMessages.VIRT_ENVIR_LIVINGROOM, 4));
            comboBox_EnvRealizePreset.Items.Add(new EnvRealizePreset(GlobalMessages.VIRT_ENVIR_STONEROOM, 5));
            comboBox_EnvRealizePreset.Items.Add(new EnvRealizePreset(GlobalMessages.VIRT_ENVIR_AUDITORIUM, 6));
            comboBox_EnvRealizePreset.Items.Add(new EnvRealizePreset(GlobalMessages.VIRT_ENVIR_CONCERTHALL, 7));
            comboBox_EnvRealizePreset.Items.Add(new EnvRealizePreset(GlobalMessages.VIRT_ENVIR_HALLWAY, 12));
            ToolStripMenuItem_SpeakerAngle.Text = GlobalMessages.VIRT_SPEAKER_ANGLE;
            ToolStripComboBox_SpeakerAngle.Items.Clear();
            for (int fAngle = -180; fAngle <= 180; fAngle += 10)
                ToolStripComboBox_SpeakerAngle.Items.Add(new SpeakerAngle(fAngle));
        }

        private string FormatAngleString(float fAngle)
        {
            return (double)fAngle >= 0.0 ? "+" + fAngle.ToString("F01") : fAngle.ToString("F01");
        }

        private void RefreshSpeakerList()
        {
            ListView_Speaker.Items.Clear();
            switch (m_nCurrentAudioSystem)
            {
                case 0:
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_00[0])
                    }));
                    break;
                case 1:
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_01[0])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_01[1])
                    }));
                    break;
                case 2:
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_02[0])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_02[1])
                    }));
                    break;
                case 3:
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_03[0])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_03[1])
                    }));
                    break;
                case 4:
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_04[0])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_04[1])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_04[2])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_04[3])
                    }));
                    break;
                case 5:
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_05[0])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_05[1])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_05[2])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_LFE,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_05[3])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_05[4])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_05[5])
                    }));
                    break;
                case 6:
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_06[0])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_06[1])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_06[2])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_LFE,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_06[3])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKCENTER,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_06[4])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_SIDELEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_06[5])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_SIDERIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_06[6])
                    }));
                    break;
                case 7:
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_07[0])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_07[1])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_07[2])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_LFE,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_07[3])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_07[4])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_07[5])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_SIDELEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_07[7])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_SIDERIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_07[7])
                    }));
                    break;
                case 8:
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_08[0])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_08[1])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_08[2])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_LFE,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_08[3])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_08[4])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_08[5])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_BACKCENTER,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_08[6])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_SIDELEFT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_08[7])
                    }));
                    ListView_Speaker.Items.Add(new ListViewItem(new string[2]
                    {
            GlobalMessages.VIRT_SPEAKER_SIDERIGHT,
            FormatAngleString(m_paramSystem.m_rpChannelAngle_08[8])
                    }));
                    break;
            }
        }

        private void ButtonBox_AudioSystemConfig_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || itCurrItem.Tag.GetType() != typeof(string))
                return;
            string tag = itCurrItem.Tag as string;
            if (string.IsNullOrEmpty(tag))
                return;
            if (!int.TryParse(tag, out int result) || result < 0 || result > 8)
                return;
            m_nCurrentAudioSystem = result;
            RefreshSpeakerList();
        }

        private void SingleButton_ResetConfig_ButtonClickNotify(SingleButton objSender)
        {
            m_paramSystem.m_rpChannelAngle_00 = new float[9];
            m_paramSystem.m_rpChannelAngle_01 = new float[9];
            m_paramSystem.m_rpChannelAngle_02 = new float[9];
            m_paramSystem.m_rpChannelAngle_03 = new float[9];
            m_paramSystem.m_rpChannelAngle_04 = new float[9];
            m_paramSystem.m_rpChannelAngle_05 = new float[9];
            m_paramSystem.m_rpChannelAngle_06 = new float[9];
            m_paramSystem.m_rpChannelAngle_07 = new float[9];
            m_paramSystem.m_rpChannelAngle_08 = new float[9];
            m_paramSystem.m_rpChannelAngle_00[0] = 0.0f;
            m_paramSystem.m_rpChannelAngle_01[0] = -30f;
            m_paramSystem.m_rpChannelAngle_01[1] = 30f;
            m_paramSystem.m_rpChannelAngle_02[0] = -90f;
            m_paramSystem.m_rpChannelAngle_02[1] = 90f;
            m_paramSystem.m_rpChannelAngle_03[0] = -150f;
            m_paramSystem.m_rpChannelAngle_03[1] = 150f;
            m_paramSystem.m_rpChannelAngle_04[0] = -45f;
            m_paramSystem.m_rpChannelAngle_04[1] = 45f;
            m_paramSystem.m_rpChannelAngle_04[2] = -135f;
            m_paramSystem.m_rpChannelAngle_04[3] = 135f;
            m_paramSystem.m_rpChannelAngle_05[0] = -30f;
            m_paramSystem.m_rpChannelAngle_05[1] = 30f;
            m_paramSystem.m_rpChannelAngle_05[2] = 0.0f;
            m_paramSystem.m_rpChannelAngle_05[3] = 0.0f;
            m_paramSystem.m_rpChannelAngle_05[4] = -110f;
            m_paramSystem.m_rpChannelAngle_05[5] = 110f;
            m_paramSystem.m_rpChannelAngle_06[0] = -30f;
            m_paramSystem.m_rpChannelAngle_06[1] = 30f;
            m_paramSystem.m_rpChannelAngle_06[2] = 0.0f;
            m_paramSystem.m_rpChannelAngle_06[3] = 0.0f;
            m_paramSystem.m_rpChannelAngle_06[4] = 180f;
            m_paramSystem.m_rpChannelAngle_06[5] = -90f;
            m_paramSystem.m_rpChannelAngle_06[6] = 90f;
            m_paramSystem.m_rpChannelAngle_07[0] = -30f;
            m_paramSystem.m_rpChannelAngle_07[1] = 30f;
            m_paramSystem.m_rpChannelAngle_07[2] = 0.0f;
            m_paramSystem.m_rpChannelAngle_07[3] = 0.0f;
            m_paramSystem.m_rpChannelAngle_07[4] = -150f;
            m_paramSystem.m_rpChannelAngle_07[5] = 150f;
            m_paramSystem.m_rpChannelAngle_07[6] = -90f;
            m_paramSystem.m_rpChannelAngle_07[7] = 90f;
            m_paramSystem.m_rpChannelAngle_08[0] = -30f;
            m_paramSystem.m_rpChannelAngle_08[1] = 30f;
            m_paramSystem.m_rpChannelAngle_08[2] = 0.0f;
            m_paramSystem.m_rpChannelAngle_08[3] = 0.0f;
            m_paramSystem.m_rpChannelAngle_08[4] = -150f;
            m_paramSystem.m_rpChannelAngle_08[5] = 150f;
            m_paramSystem.m_rpChannelAngle_08[6] = 180f;
            m_paramSystem.m_rpChannelAngle_08[7] = -90f;
            m_paramSystem.m_rpChannelAngle_08[8] = 90f;
            RefreshSpeakerList();
        }

        private void ListView_Speaker_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || m_nCurrentAudioSystem < 0 || ListView_Speaker.SelectedItems.Count != 1)
                return;
            float[] numArray = null;
            int num1 = -1;
            switch (m_nCurrentAudioSystem)
            {
                case 0:
                    numArray = m_paramSystem.m_rpChannelAngle_00;
                    num1 = 1;
                    break;
                case 1:
                    numArray = m_paramSystem.m_rpChannelAngle_01;
                    num1 = 2;
                    break;
                case 2:
                    numArray = m_paramSystem.m_rpChannelAngle_02;
                    num1 = 2;
                    break;
                case 3:
                    numArray = m_paramSystem.m_rpChannelAngle_03;
                    num1 = 2;
                    break;
                case 4:
                    numArray = m_paramSystem.m_rpChannelAngle_04;
                    num1 = 4;
                    break;
                case 5:
                    numArray = m_paramSystem.m_rpChannelAngle_05;
                    num1 = 6;
                    break;
                case 6:
                    numArray = m_paramSystem.m_rpChannelAngle_06;
                    num1 = 7;
                    break;
                case 7:
                    numArray = m_paramSystem.m_rpChannelAngle_07;
                    num1 = 8;
                    break;
                case 8:
                    numArray = m_paramSystem.m_rpChannelAngle_08;
                    num1 = 9;
                    break;
            }
            if (numArray == null)
                return;
            int index1 = ListView_Speaker.SelectedItems[0].Index;
            if (index1 >= num1)
                return;
            float num2 = numArray[index1];
            int num3 = -1;
            for (int index2 = 0; index2 < ToolStripComboBox_SpeakerAngle.Items.Count; ++index2)
            {
                SpeakerAngle speakerAngle = ToolStripComboBox_SpeakerAngle.Items[index2] as SpeakerAngle;
                if ((double)speakerAngle.AngleFloat == (double)num2)
                {
                    num3 = index2;
                    break;
                }
                if ((double)speakerAngle.AngleFloat == 0.0)
                    num3 = index2;
            }
            if (num3 == -1)
                return;
            ContextMenuStrip_SpeakerAngle.Tag = null;
            ToolStripComboBox_SpeakerAngle.SelectedIndex = num3;
            ContextMenuStrip_SpeakerAngle.Tag = index1.ToString();
            ContextMenuStrip_SpeakerAngle.Show(ListView_Speaker, e.Location);
        }

        private void ToolStripComboBox_SpeakerAngle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_nCurrentAudioSystem < 0 || ContextMenuStrip_SpeakerAngle.Tag == null || ContextMenuStrip_SpeakerAngle.Tag.GetType() != typeof(string))
                return;
            string tag = ContextMenuStrip_SpeakerAngle.Tag as string;
            if (string.IsNullOrEmpty(tag))
                return;
            if (!int.TryParse(tag, out int result))
                return;
            float[] numArray = null;
            int num = -1;
            switch (m_nCurrentAudioSystem)
            {
                case 0:
                    numArray = m_paramSystem.m_rpChannelAngle_00;
                    num = 1;
                    break;
                case 1:
                    numArray = m_paramSystem.m_rpChannelAngle_01;
                    num = 2;
                    break;
                case 2:
                    numArray = m_paramSystem.m_rpChannelAngle_02;
                    num = 2;
                    break;
                case 3:
                    numArray = m_paramSystem.m_rpChannelAngle_03;
                    num = 2;
                    break;
                case 4:
                    numArray = m_paramSystem.m_rpChannelAngle_04;
                    num = 4;
                    break;
                case 5:
                    numArray = m_paramSystem.m_rpChannelAngle_05;
                    num = 6;
                    break;
                case 6:
                    numArray = m_paramSystem.m_rpChannelAngle_06;
                    num = 7;
                    break;
                case 7:
                    numArray = m_paramSystem.m_rpChannelAngle_07;
                    num = 8;
                    break;
                case 8:
                    numArray = m_paramSystem.m_rpChannelAngle_08;
                    num = 9;
                    break;
            }
            if (numArray == null || result >= num || ToolStripComboBox_SpeakerAngle.SelectedItem == null || ToolStripComboBox_SpeakerAngle.SelectedItem.GetType() != typeof(SpeakerAngle))
                return;
            SpeakerAngle selectedItem = ToolStripComboBox_SpeakerAngle.SelectedItem as SpeakerAngle;
            numArray[result] = selectedItem.AngleFloat;
        }

        private void ContextMenuStrip_SpeakerAngle_Closed(
          object sender,
          ToolStripDropDownClosedEventArgs e)
        {
            ContextMenuStrip_SpeakerAngle.Tag = null;
            RefreshSpeakerList();
        }

        private void SingleButton_OK_ButtonClickNotify(SingleButton objSender)
        {
            DialogResult = DialogResult.OK;
        }

        private void SingleButton_Cancel_ButtonClickNotify(SingleButton objSender)
        {
            DialogResult = DialogResult.Cancel;
        }

        private class EnvRealizePreset
        {
            private string m_szPresetName = "";
            private readonly int m_nPresetID = -1;

            public string PresetName => m_szPresetName;

            public string Text
            {
                get => m_szPresetName;
                set => m_szPresetName = value;
            }

            public int PresetID => m_nPresetID;

            public EnvRealizePreset(string szPresetName, int nPresetID)
            {
                m_szPresetName = szPresetName;
                m_nPresetID = nPresetID;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || obj.GetType() != typeof(EnvRealizePreset))
                    return false;
                EnvRealizePreset envRealizePreset = obj as EnvRealizePreset;
                return envRealizePreset.PresetName == m_szPresetName && envRealizePreset.PresetID == m_nPresetID;
            }

            public override int GetHashCode()
            {
                return m_nPresetID;
            }

            public override string ToString()
            {
                return m_szPresetName;
            }
        }

        private class SpeakerAngle
        {
            private float m_fAngle;

            public string AngleString => m_fAngle >= 0.0 ? "+" + m_fAngle.ToString("F01") : m_fAngle.ToString("F01");

            public float AngleFloat
            {
                get => m_fAngle;
                set => m_fAngle = value;
            }

            public SpeakerAngle(float fAngle) => m_fAngle = fAngle;

            public override bool Equals(object obj)
            {
                return obj != null && obj.GetType() == typeof(SpeakerAngle) && (double)(obj as SpeakerAngle).AngleFloat == m_fAngle;
            }

            public override int GetHashCode()
            {
                return (int)Math.Round(m_fAngle);
            }

            public override string ToString()
            {
                return AngleString;
            }
        }
    }
}
