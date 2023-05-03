using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
  public class frmVirtualization : Form
  {
    private IContainer components;
    private Label label_AudioSystemConfig;
    private ButtonBox buttonBox_AudioSystemConfig;
    private GroupBox groupBox_VirtApplied;
    private CheckBox checkBox_MusicMode;
    private CheckBox checkBox_Freestyle;
    private CheckBox checkBox_MovieMode;
    private ListView listView_Speaker;
    private ColumnHeader columnHeader_Speaker;
    private ColumnHeader columnHeader_Angle;
    private SingleButton singleButton_ResetConfig;
    private GroupBox groupBox_VirtEnv;
    private OnOffSwitch onOffSwitch_EnvRealize;
    private ComboBox comboBox_EnvRealizePreset;
    private HSlider hSlider_EnvRealizeDrySignal;
    private SingleButton singleButton_OK;
    private Label label_PrePostProcess;
    private ContextMenuStrip contextMenuStrip_SpeakerAngle;
    private ToolStripMenuItem toolStripMenuItem_SpeakerAngle;
    private ToolStripSeparator toolStripSeparator_Angle;
    private ToolStripComboBox toolStripComboBox_SpeakerAngle;
    private SingleButton singleButton_Cancel;
    private TwoSelector twoSelector_PrePostProcess;
    private RuntimeUtils.ConfigProxy._ParamOfBaseSystem m_paramSystem = new RuntimeUtils.ConfigProxy._ParamOfBaseSystem();
    private int m_nCurrentAudioSystem = -1;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmVirtualization));
      this.label_AudioSystemConfig = new Label();
      this.groupBox_VirtApplied = new GroupBox();
      this.checkBox_Freestyle = new CheckBox();
      this.checkBox_MovieMode = new CheckBox();
      this.checkBox_MusicMode = new CheckBox();
      this.listView_Speaker = new ListView();
      this.columnHeader_Speaker = new ColumnHeader();
      this.columnHeader_Angle = new ColumnHeader();
      this.groupBox_VirtEnv = new GroupBox();
      this.label_PrePostProcess = new Label();
      this.comboBox_EnvRealizePreset = new ComboBox();
      this.contextMenuStrip_SpeakerAngle = new ContextMenuStrip(this.components);
      this.toolStripMenuItem_SpeakerAngle = new ToolStripMenuItem();
      this.toolStripSeparator_Angle = new ToolStripSeparator();
      this.toolStripComboBox_SpeakerAngle = new ToolStripComboBox();
      this.singleButton_Cancel = new SingleButton();
      this.twoSelector_PrePostProcess = new TwoSelector();
      this.hSlider_EnvRealizeDrySignal = new HSlider();
      this.onOffSwitch_EnvRealize = new OnOffSwitch();
      this.singleButton_ResetConfig = new SingleButton();
      this.singleButton_OK = new SingleButton();
      this.buttonBox_AudioSystemConfig = new ButtonBox();
      this.groupBox_VirtApplied.SuspendLayout();
      this.groupBox_VirtEnv.SuspendLayout();
      this.contextMenuStrip_SpeakerAngle.SuspendLayout();
      this.SuspendLayout();
      this.label_AudioSystemConfig.AutoSize = true;
      this.label_AudioSystemConfig.Location = new Point(12, 17);
      this.label_AudioSystemConfig.Name = "label_AudioSystemConfig";
      this.label_AudioSystemConfig.Size = new Size(125, 12);
      this.label_AudioSystemConfig.TabIndex = 0;
      this.label_AudioSystemConfig.Text = "$AUDIO_SYSTEM_CONFIG";
      this.groupBox_VirtApplied.Controls.Add((Control) this.checkBox_Freestyle);
      this.groupBox_VirtApplied.Controls.Add((Control) this.checkBox_MovieMode);
      this.groupBox_VirtApplied.Controls.Add((Control) this.checkBox_MusicMode);
      this.groupBox_VirtApplied.Location = new Point(151, 292);
      this.groupBox_VirtApplied.Name = "groupBox_VirtApplied";
      this.groupBox_VirtApplied.Size = new Size(167, 88);
      this.groupBox_VirtApplied.TabIndex = 2;
      this.groupBox_VirtApplied.TabStop = false;
      this.groupBox_VirtApplied.Text = "$VIRT_APPLIED";
      this.checkBox_Freestyle.AutoSize = true;
      this.checkBox_Freestyle.Location = new Point(16, 64);
      this.checkBox_Freestyle.Name = "checkBox_Freestyle";
      this.checkBox_Freestyle.Size = new Size(114, 16);
      this.checkBox_Freestyle.TabIndex = 5;
      this.checkBox_Freestyle.Text = "$FREESTYLE_MODE";
      this.checkBox_Freestyle.UseVisualStyleBackColor = true;
      this.checkBox_MovieMode.AutoSize = true;
      this.checkBox_MovieMode.Location = new Point(16, 42);
      this.checkBox_MovieMode.Name = "checkBox_MovieMode";
      this.checkBox_MovieMode.Size = new Size(90, 16);
      this.checkBox_MovieMode.TabIndex = 4;
      this.checkBox_MovieMode.Text = "$MOVIE_MODE";
      this.checkBox_MovieMode.UseVisualStyleBackColor = true;
      this.checkBox_MusicMode.AutoSize = true;
      this.checkBox_MusicMode.Location = new Point(16, 20);
      this.checkBox_MusicMode.Name = "checkBox_MusicMode";
      this.checkBox_MusicMode.Size = new Size(90, 16);
      this.checkBox_MusicMode.TabIndex = 3;
      this.checkBox_MusicMode.Text = "$MUSIC_MODE";
      this.checkBox_MusicMode.UseVisualStyleBackColor = true;
      this.listView_Speaker.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader_Speaker,
        this.columnHeader_Angle
      });
      this.listView_Speaker.FullRowSelect = true;
      this.listView_Speaker.GridLines = true;
      this.listView_Speaker.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listView_Speaker.HideSelection = false;
      this.listView_Speaker.Location = new Point(151, 71);
      this.listView_Speaker.MultiSelect = false;
      this.listView_Speaker.Name = "listView_Speaker";
      this.listView_Speaker.Size = new Size(167, 215);
      this.listView_Speaker.TabIndex = 3;
      this.listView_Speaker.UseCompatibleStateImageBehavior = false;
      this.listView_Speaker.View = View.Details;
      this.listView_Speaker.MouseUp += new MouseEventHandler(this.listView_Speaker_MouseUp);
      this.columnHeader_Speaker.Text = "$VIRT_SPEAKER";
      this.columnHeader_Speaker.Width = 95;
      this.columnHeader_Angle.Text = "$VIRT_SPEAKER_ANGLE";
      this.groupBox_VirtEnv.Controls.Add((Control) this.twoSelector_PrePostProcess);
      this.groupBox_VirtEnv.Controls.Add((Control) this.label_PrePostProcess);
      this.groupBox_VirtEnv.Controls.Add((Control) this.hSlider_EnvRealizeDrySignal);
      this.groupBox_VirtEnv.Controls.Add((Control) this.comboBox_EnvRealizePreset);
      this.groupBox_VirtEnv.Controls.Add((Control) this.onOffSwitch_EnvRealize);
      this.groupBox_VirtEnv.Location = new Point(324, 36);
      this.groupBox_VirtEnv.Name = "groupBox_VirtEnv";
      this.groupBox_VirtEnv.Size = new Size(222, 106);
      this.groupBox_VirtEnv.TabIndex = 5;
      this.groupBox_VirtEnv.TabStop = false;
      this.groupBox_VirtEnv.Text = "$VIRTUAL_ENVIRONMENT";
      this.label_PrePostProcess.AutoSize = true;
      this.label_PrePostProcess.Location = new Point(6, 79);
      this.label_PrePostProcess.Name = "label_PrePostProcess";
      this.label_PrePostProcess.Size = new Size(107, 12);
      this.label_PrePostProcess.TabIndex = 3;
      this.label_PrePostProcess.Text = "$PRE_POST_PROCESS";
      this.comboBox_EnvRealizePreset.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_EnvRealizePreset.FormattingEnabled = true;
      this.comboBox_EnvRealizePreset.Location = new Point(6, 20);
      this.comboBox_EnvRealizePreset.Name = "comboBox_EnvRealizePreset";
      this.comboBox_EnvRealizePreset.Size = new Size(210, 20);
      this.comboBox_EnvRealizePreset.TabIndex = 1;
      this.contextMenuStrip_SpeakerAngle.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.toolStripMenuItem_SpeakerAngle,
        (ToolStripItem) this.toolStripSeparator_Angle,
        (ToolStripItem) this.toolStripComboBox_SpeakerAngle
      });
      this.contextMenuStrip_SpeakerAngle.Name = "contextMenuStrip_SpeakerAngle";
      this.contextMenuStrip_SpeakerAngle.Size = new Size(182, 61);
      this.contextMenuStrip_SpeakerAngle.Closed += new ToolStripDropDownClosedEventHandler(this.contextMenuStrip_SpeakerAngle_Closed);
      this.toolStripMenuItem_SpeakerAngle.Enabled = false;
      this.toolStripMenuItem_SpeakerAngle.Name = "toolStripMenuItem_SpeakerAngle";
      this.toolStripMenuItem_SpeakerAngle.Size = new Size(181, 22);
      this.toolStripMenuItem_SpeakerAngle.Text = "$SPEAKER_ANGLE";
      this.toolStripSeparator_Angle.Name = "toolStripSeparator_Angle";
      this.toolStripSeparator_Angle.Size = new Size(178, 6);
      this.toolStripComboBox_SpeakerAngle.DropDownStyle = ComboBoxStyle.DropDownList;
      this.toolStripComboBox_SpeakerAngle.Name = "toolStripComboBox_SpeakerAngle";
      this.toolStripComboBox_SpeakerAngle.Size = new Size(121, 25);
      this.toolStripComboBox_SpeakerAngle.SelectedIndexChanged += new EventHandler(this.toolStripComboBox_SpeakerAngle_SelectedIndexChanged);
      this.singleButton_Cancel.BackColor = SystemColors.Control;
      this.singleButton_Cancel.ButtonText = "$CANCEL";
      this.singleButton_Cancel.Location = new Point(446, 347);
      this.singleButton_Cancel.Name = "singleButton_Cancel";
      this.singleButton_Cancel.Size = new Size(100, 33);
      this.singleButton_Cancel.TabIndex = 8;
      this.singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Cancel_ButtonClickNotify);
      this.twoSelector_PrePostProcess.BackColor = Color.Transparent;
      this.twoSelector_PrePostProcess.CurrentObject = (object) null;
      this.twoSelector_PrePostProcess.LeftObject = (object) null;
      this.twoSelector_PrePostProcess.Location = new Point(146, 74);
      this.twoSelector_PrePostProcess.Name = "twoSelector_PrePostProcess";
      this.twoSelector_PrePostProcess.RightObject = (object) null;
      this.twoSelector_PrePostProcess.Selector = TwoSelector.SelectorPosition.SELECTOR_ON_LEFT;
      this.twoSelector_PrePostProcess.Size = new Size(70, 22);
      this.twoSelector_PrePostProcess.TabIndex = 9;
      this.hSlider_EnvRealizeDrySignal.BackColor = SystemColors.Control;
      this.hSlider_EnvRealizeDrySignal.Location = new Point(68, 48);
      this.hSlider_EnvRealizeDrySignal.MoveDelta = 1U;
      this.hSlider_EnvRealizeDrySignal.Name = "hSlider_EnvRealizeDrySignal";
      this.hSlider_EnvRealizeDrySignal.Position = 0U;
      this.hSlider_EnvRealizeDrySignal.PositionFloat = 0.0f;
      this.hSlider_EnvRealizeDrySignal.Size = new Size(148, 20);
      this.hSlider_EnvRealizeDrySignal.TabIndex = 2;
      this.onOffSwitch_EnvRealize.BackColor = Color.Transparent;
      this.onOffSwitch_EnvRealize.Location = new Point(6, 46);
      this.onOffSwitch_EnvRealize.Name = "onOffSwitch_EnvRealize";
      this.onOffSwitch_EnvRealize.Size = new Size(53, 22);
      this.onOffSwitch_EnvRealize.SwitchedOn = false;
      this.onOffSwitch_EnvRealize.TabIndex = 0;
      this.singleButton_ResetConfig.BackColor = SystemColors.Control;
      this.singleButton_ResetConfig.ButtonText = "$VIRT_RESET";
      this.singleButton_ResetConfig.Location = new Point(151, 36);
      this.singleButton_ResetConfig.Name = "singleButton_ResetConfig";
      this.singleButton_ResetConfig.Size = new Size(167, 26);
      this.singleButton_ResetConfig.TabIndex = 4;
      this.singleButton_ResetConfig.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_ResetConfig_ButtonClickNotify);
      this.singleButton_OK.BackColor = SystemColors.Control;
      this.singleButton_OK.ButtonText = "$OK";
      this.singleButton_OK.Location = new Point(324, 347);
      this.singleButton_OK.Name = "singleButton_OK";
      this.singleButton_OK.Size = new Size(100, 33);
      this.singleButton_OK.TabIndex = 6;
      this.singleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_OK_ButtonClickNotify);
      this.buttonBox_AudioSystemConfig.BackColor = SystemColors.Control;
      this.buttonBox_AudioSystemConfig.Location = new Point(14, 36);
      this.buttonBox_AudioSystemConfig.Name = "buttonBox_AudioSystemConfig";
      this.buttonBox_AudioSystemConfig.Size = new Size(131, 344);
      this.buttonBox_AudioSystemConfig.TabIndex = 1;
      this.buttonBox_AudioSystemConfig.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.buttonBox_AudioSystemConfig_ItemSelectedNotify);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(562, 394);
      this.Controls.Add((Control) this.singleButton_Cancel);
      this.Controls.Add((Control) this.groupBox_VirtEnv);
      this.Controls.Add((Control) this.singleButton_ResetConfig);
      this.Controls.Add((Control) this.singleButton_OK);
      this.Controls.Add((Control) this.listView_Speaker);
      this.Controls.Add((Control) this.groupBox_VirtApplied);
      this.Controls.Add((Control) this.buttonBox_AudioSystemConfig);
      this.Controls.Add((Control) this.label_AudioSystemConfig);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (frmVirtualization);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$VIRTUALIZATION";
      this.groupBox_VirtApplied.ResumeLayout(false);
      this.groupBox_VirtApplied.PerformLayout();
      this.groupBox_VirtEnv.ResumeLayout(false);
      this.groupBox_VirtEnv.PerformLayout();
      this.contextMenuStrip_SpeakerAngle.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void SetBaseSystemParam(
      RuntimeUtils.ConfigProxy._ParamOfBaseSystem paramSystem)
    {
      this.m_paramSystem = paramSystem;
      int num1 = this.m_paramSystem.m_bVirtApplied & 1;
      int num2 = this.m_paramSystem.m_bVirtApplied >> 1 & 1;
      int num3 = this.m_paramSystem.m_bVirtApplied >> 2 & 1;
      if (num1 == 1)
        this.checkBox_MusicMode.Checked = true;
      if (num2 == 1)
        this.checkBox_MovieMode.Checked = true;
      if (num3 == 1)
        this.checkBox_Freestyle.Checked = true;
      this.onOffSwitch_EnvRealize.SwitchedOn = this.m_paramSystem.m_bEnvRealizeEnabled == 1;
      this.hSlider_EnvRealizeDrySignal.PositionFloat = this.m_paramSystem.m_rEnvRealizeDrySignal;
      this.twoSelector_PrePostProcess.Selector = this.m_paramSystem.m_bEnvRealizePreprocess != 1 ? TwoSelector.SelectorPosition.SELECTOR_ON_RIGHT : TwoSelector.SelectorPosition.SELECTOR_ON_LEFT;
      for (int index = 0; index < this.comboBox_EnvRealizePreset.Items.Count; ++index)
      {
        if ((this.comboBox_EnvRealizePreset.Items[index] as frmVirtualization.EnvRealizePreset).PresetID == this.m_paramSystem.m_nEnvRealizePreset)
        {
          this.comboBox_EnvRealizePreset.SelectedIndex = index;
          break;
        }
      }
    }

    public RuntimeUtils.ConfigProxy._ParamOfBaseSystem GetBaseSystemParam()
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (this.checkBox_MusicMode.Checked)
        num1 = 1;
      if (this.checkBox_MovieMode.Checked)
        num2 = 1;
      if (this.checkBox_Freestyle.Checked)
        num3 = 1;
      this.m_paramSystem.m_bVirtApplied = num1 | num2 << 1 | num3 << 2;
      this.m_paramSystem.m_bEnvRealizeEnabled = !this.onOffSwitch_EnvRealize.SwitchedOn ? 0 : 1;
      this.m_paramSystem.m_bEnvRealizePreprocess = this.twoSelector_PrePostProcess.Selector != TwoSelector.SelectorPosition.SELECTOR_ON_LEFT ? 0 : 1;
      this.m_paramSystem.m_rEnvRealizeDrySignal = this.hSlider_EnvRealizeDrySignal.PositionFloat;
      if (this.comboBox_EnvRealizePreset.SelectedItem == null)
        this.m_paramSystem.m_bEnvRealizeEnabled = 0;
      else if (this.comboBox_EnvRealizePreset.SelectedItem.GetType() != typeof (frmVirtualization.EnvRealizePreset))
        this.m_paramSystem.m_bEnvRealizeEnabled = 0;
      else
        this.m_paramSystem.m_nEnvRealizePreset = (this.comboBox_EnvRealizePreset.SelectedItem as frmVirtualization.EnvRealizePreset).PresetID;
      return this.m_paramSystem;
    }

    public frmVirtualization()
    {
      Parameters.LoadDefaultParameter(ref this.m_paramSystem);
      this.m_nCurrentAudioSystem = -1;
      this.InitializeComponent();
      this.Text = GlobalMessages.VIRTUALIZATION;
      this.label_AudioSystemConfig.Text = GlobalMessages.AUDIO_SYSTEM_CONFIG;
      this.singleButton_ResetConfig.ButtonText = GlobalMessages.VIRT_RESET;
      this.groupBox_VirtApplied.Text = GlobalMessages.VIRT_APPLIED;
      this.checkBox_MusicMode.Text = GlobalMessages.MUSIC_MODE;
      this.checkBox_MovieMode.Text = GlobalMessages.MOVIE_MODE;
      this.checkBox_Freestyle.Text = GlobalMessages.FREESTYLE_MODE;
      this.groupBox_VirtEnv.Text = GlobalMessages.VIRT_ENVIRONMENT;
      this.label_PrePostProcess.Text = GlobalMessages.VIRT_PREPOST_PROCESS;
      this.singleButton_OK.ButtonText = GlobalMessages.OK;
      this.singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
      this.buttonBox_AudioSystemConfig.ClearItem();
      this.buttonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_MONO, (object) "0"));
      this.buttonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_STEREO, (object) "1"));
      this.buttonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_HEADSET, (object) "2"));
      this.buttonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_REARSTEREO, (object) "3"));
      this.buttonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_QUAD, (object) "4"));
      this.buttonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_X5P1, (object) "5"));
      this.buttonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_X6P1, (object) "6"));
      this.buttonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_X7P1, (object) "7"));
      this.buttonBox_AudioSystemConfig.AddItem(new ButtonBox.Item(GlobalMessages.AUDIO_SYSTEM_X8P1, (object) "8"));
      this.listView_Speaker.Columns[0].Text = GlobalMessages.VIRT_SPEAKER;
      this.listView_Speaker.Columns[1].Text = GlobalMessages.VIRT_SPEAKER_ANGLE;
      this.listView_Speaker.Items.Clear();
      this.checkBox_MusicMode.Checked = false;
      this.checkBox_MovieMode.Checked = false;
      this.checkBox_Freestyle.Checked = false;
      this.onOffSwitch_EnvRealize.SwitchedOn = false;
      this.hSlider_EnvRealizeDrySignal.PositionFloat = 0.7f;
      this.twoSelector_PrePostProcess.Selector = TwoSelector.SelectorPosition.SELECTOR_ON_LEFT;
      this.comboBox_EnvRealizePreset.Items.Clear();
      this.comboBox_EnvRealizePreset.Items.Add((object) new frmVirtualization.EnvRealizePreset(GlobalMessages.VIRT_ENVIR_SMALLROOM, 2));
      this.comboBox_EnvRealizePreset.Items.Add((object) new frmVirtualization.EnvRealizePreset(GlobalMessages.VIRT_ENVIR_BATHROOM, 3));
      this.comboBox_EnvRealizePreset.Items.Add((object) new frmVirtualization.EnvRealizePreset(GlobalMessages.VIRT_ENVIR_LIVINGROOM, 4));
      this.comboBox_EnvRealizePreset.Items.Add((object) new frmVirtualization.EnvRealizePreset(GlobalMessages.VIRT_ENVIR_STONEROOM, 5));
      this.comboBox_EnvRealizePreset.Items.Add((object) new frmVirtualization.EnvRealizePreset(GlobalMessages.VIRT_ENVIR_AUDITORIUM, 6));
      this.comboBox_EnvRealizePreset.Items.Add((object) new frmVirtualization.EnvRealizePreset(GlobalMessages.VIRT_ENVIR_CONCERTHALL, 7));
      this.comboBox_EnvRealizePreset.Items.Add((object) new frmVirtualization.EnvRealizePreset(GlobalMessages.VIRT_ENVIR_HALLWAY, 12));
      this.toolStripMenuItem_SpeakerAngle.Text = GlobalMessages.VIRT_SPEAKER_ANGLE;
      this.toolStripComboBox_SpeakerAngle.Items.Clear();
      for (int fAngle = -180; fAngle <= 180; fAngle += 10)
        this.toolStripComboBox_SpeakerAngle.Items.Add((object) new frmVirtualization.SpeakerAngle((float) fAngle));
    }

    private string FormatAngleString(float fAngle) => (double) fAngle >= 0.0 ? "+" + fAngle.ToString("F01") : fAngle.ToString("F01");

    private void RefreshSpeakerList()
    {
      this.listView_Speaker.Items.Clear();
      switch (this.m_nCurrentAudioSystem)
      {
        case 0:
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_00[0])
          }));
          break;
        case 1:
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_01[0])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_01[1])
          }));
          break;
        case 2:
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_02[0])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_02[1])
          }));
          break;
        case 3:
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_03[0])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_03[1])
          }));
          break;
        case 4:
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_04[0])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_04[1])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_04[2])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_04[3])
          }));
          break;
        case 5:
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_05[0])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_05[1])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_05[2])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_LFE,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_05[3])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_05[4])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_05[5])
          }));
          break;
        case 6:
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_06[0])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_06[1])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_06[2])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_LFE,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_06[3])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKCENTER,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_06[4])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_SIDELEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_06[5])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_SIDERIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_06[6])
          }));
          break;
        case 7:
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_07[0])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_07[1])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_07[2])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_LFE,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_07[3])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_07[4])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_07[5])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_SIDELEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_07[7])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_SIDERIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_07[7])
          }));
          break;
        case 8:
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_08[0])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_08[1])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_FRONTCENTER,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_08[2])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_LFE,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_08[3])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKLEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_08[4])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKRIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_08[5])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_BACKCENTER,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_08[6])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_SIDELEFT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_08[7])
          }));
          this.listView_Speaker.Items.Add(new ListViewItem(new string[2]
          {
            GlobalMessages.VIRT_SPEAKER_SIDERIGHT,
            this.FormatAngleString(this.m_paramSystem.m_rpChannelAngle_08[8])
          }));
          break;
      }
    }

    private void buttonBox_AudioSystemConfig_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || itCurrItem.Tag.GetType() != typeof (string))
        return;
      string tag = itCurrItem.Tag as string;
      if (string.IsNullOrEmpty(tag))
        return;
      int result = -1;
      if (!int.TryParse(tag, out result) || result < 0 || result > 8)
        return;
      this.m_nCurrentAudioSystem = result;
      this.RefreshSpeakerList();
    }

    private void singleButton_ResetConfig_ButtonClickNotify(SingleButton objSender)
    {
      this.m_paramSystem.m_rpChannelAngle_00 = new float[9];
      this.m_paramSystem.m_rpChannelAngle_01 = new float[9];
      this.m_paramSystem.m_rpChannelAngle_02 = new float[9];
      this.m_paramSystem.m_rpChannelAngle_03 = new float[9];
      this.m_paramSystem.m_rpChannelAngle_04 = new float[9];
      this.m_paramSystem.m_rpChannelAngle_05 = new float[9];
      this.m_paramSystem.m_rpChannelAngle_06 = new float[9];
      this.m_paramSystem.m_rpChannelAngle_07 = new float[9];
      this.m_paramSystem.m_rpChannelAngle_08 = new float[9];
      this.m_paramSystem.m_rpChannelAngle_00[0] = 0.0f;
      this.m_paramSystem.m_rpChannelAngle_01[0] = -30f;
      this.m_paramSystem.m_rpChannelAngle_01[1] = 30f;
      this.m_paramSystem.m_rpChannelAngle_02[0] = -90f;
      this.m_paramSystem.m_rpChannelAngle_02[1] = 90f;
      this.m_paramSystem.m_rpChannelAngle_03[0] = -150f;
      this.m_paramSystem.m_rpChannelAngle_03[1] = 150f;
      this.m_paramSystem.m_rpChannelAngle_04[0] = -45f;
      this.m_paramSystem.m_rpChannelAngle_04[1] = 45f;
      this.m_paramSystem.m_rpChannelAngle_04[2] = -135f;
      this.m_paramSystem.m_rpChannelAngle_04[3] = 135f;
      this.m_paramSystem.m_rpChannelAngle_05[0] = -30f;
      this.m_paramSystem.m_rpChannelAngle_05[1] = 30f;
      this.m_paramSystem.m_rpChannelAngle_05[2] = 0.0f;
      this.m_paramSystem.m_rpChannelAngle_05[3] = 0.0f;
      this.m_paramSystem.m_rpChannelAngle_05[4] = -110f;
      this.m_paramSystem.m_rpChannelAngle_05[5] = 110f;
      this.m_paramSystem.m_rpChannelAngle_06[0] = -30f;
      this.m_paramSystem.m_rpChannelAngle_06[1] = 30f;
      this.m_paramSystem.m_rpChannelAngle_06[2] = 0.0f;
      this.m_paramSystem.m_rpChannelAngle_06[3] = 0.0f;
      this.m_paramSystem.m_rpChannelAngle_06[4] = 180f;
      this.m_paramSystem.m_rpChannelAngle_06[5] = -90f;
      this.m_paramSystem.m_rpChannelAngle_06[6] = 90f;
      this.m_paramSystem.m_rpChannelAngle_07[0] = -30f;
      this.m_paramSystem.m_rpChannelAngle_07[1] = 30f;
      this.m_paramSystem.m_rpChannelAngle_07[2] = 0.0f;
      this.m_paramSystem.m_rpChannelAngle_07[3] = 0.0f;
      this.m_paramSystem.m_rpChannelAngle_07[4] = -150f;
      this.m_paramSystem.m_rpChannelAngle_07[5] = 150f;
      this.m_paramSystem.m_rpChannelAngle_07[6] = -90f;
      this.m_paramSystem.m_rpChannelAngle_07[7] = 90f;
      this.m_paramSystem.m_rpChannelAngle_08[0] = -30f;
      this.m_paramSystem.m_rpChannelAngle_08[1] = 30f;
      this.m_paramSystem.m_rpChannelAngle_08[2] = 0.0f;
      this.m_paramSystem.m_rpChannelAngle_08[3] = 0.0f;
      this.m_paramSystem.m_rpChannelAngle_08[4] = -150f;
      this.m_paramSystem.m_rpChannelAngle_08[5] = 150f;
      this.m_paramSystem.m_rpChannelAngle_08[6] = 180f;
      this.m_paramSystem.m_rpChannelAngle_08[7] = -90f;
      this.m_paramSystem.m_rpChannelAngle_08[8] = 90f;
      this.RefreshSpeakerList();
    }

    private void listView_Speaker_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right || this.m_nCurrentAudioSystem < 0 || this.listView_Speaker.SelectedItems.Count != 1)
        return;
      float[] numArray = (float[]) null;
      int num1 = -1;
      switch (this.m_nCurrentAudioSystem)
      {
        case 0:
          numArray = this.m_paramSystem.m_rpChannelAngle_00;
          num1 = 1;
          break;
        case 1:
          numArray = this.m_paramSystem.m_rpChannelAngle_01;
          num1 = 2;
          break;
        case 2:
          numArray = this.m_paramSystem.m_rpChannelAngle_02;
          num1 = 2;
          break;
        case 3:
          numArray = this.m_paramSystem.m_rpChannelAngle_03;
          num1 = 2;
          break;
        case 4:
          numArray = this.m_paramSystem.m_rpChannelAngle_04;
          num1 = 4;
          break;
        case 5:
          numArray = this.m_paramSystem.m_rpChannelAngle_05;
          num1 = 6;
          break;
        case 6:
          numArray = this.m_paramSystem.m_rpChannelAngle_06;
          num1 = 7;
          break;
        case 7:
          numArray = this.m_paramSystem.m_rpChannelAngle_07;
          num1 = 8;
          break;
        case 8:
          numArray = this.m_paramSystem.m_rpChannelAngle_08;
          num1 = 9;
          break;
      }
      if (numArray == null)
        return;
      int index1 = this.listView_Speaker.SelectedItems[0].Index;
      if (index1 >= num1)
        return;
      float num2 = numArray[index1];
      int num3 = -1;
      for (int index2 = 0; index2 < this.toolStripComboBox_SpeakerAngle.Items.Count; ++index2)
      {
        frmVirtualization.SpeakerAngle speakerAngle = this.toolStripComboBox_SpeakerAngle.Items[index2] as frmVirtualization.SpeakerAngle;
        if ((double) speakerAngle.AngleFloat == (double) num2)
        {
          num3 = index2;
          break;
        }
        if ((double) speakerAngle.AngleFloat == 0.0)
          num3 = index2;
      }
      if (num3 == -1)
        return;
      this.contextMenuStrip_SpeakerAngle.Tag = (object) null;
      this.toolStripComboBox_SpeakerAngle.SelectedIndex = num3;
      this.contextMenuStrip_SpeakerAngle.Tag = (object) index1.ToString();
      this.contextMenuStrip_SpeakerAngle.Show((Control) this.listView_Speaker, e.Location);
    }

    private void toolStripComboBox_SpeakerAngle_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_nCurrentAudioSystem < 0 || this.contextMenuStrip_SpeakerAngle.Tag == null || this.contextMenuStrip_SpeakerAngle.Tag.GetType() != typeof (string))
        return;
      string tag = this.contextMenuStrip_SpeakerAngle.Tag as string;
      if (string.IsNullOrEmpty(tag))
        return;
      int result = -1;
      if (!int.TryParse(tag, out result))
        return;
      float[] numArray = (float[]) null;
      int num = -1;
      switch (this.m_nCurrentAudioSystem)
      {
        case 0:
          numArray = this.m_paramSystem.m_rpChannelAngle_00;
          num = 1;
          break;
        case 1:
          numArray = this.m_paramSystem.m_rpChannelAngle_01;
          num = 2;
          break;
        case 2:
          numArray = this.m_paramSystem.m_rpChannelAngle_02;
          num = 2;
          break;
        case 3:
          numArray = this.m_paramSystem.m_rpChannelAngle_03;
          num = 2;
          break;
        case 4:
          numArray = this.m_paramSystem.m_rpChannelAngle_04;
          num = 4;
          break;
        case 5:
          numArray = this.m_paramSystem.m_rpChannelAngle_05;
          num = 6;
          break;
        case 6:
          numArray = this.m_paramSystem.m_rpChannelAngle_06;
          num = 7;
          break;
        case 7:
          numArray = this.m_paramSystem.m_rpChannelAngle_07;
          num = 8;
          break;
        case 8:
          numArray = this.m_paramSystem.m_rpChannelAngle_08;
          num = 9;
          break;
      }
      if (numArray == null || result >= num || this.toolStripComboBox_SpeakerAngle.SelectedItem == null || this.toolStripComboBox_SpeakerAngle.SelectedItem.GetType() != typeof (frmVirtualization.SpeakerAngle))
        return;
      frmVirtualization.SpeakerAngle selectedItem = this.toolStripComboBox_SpeakerAngle.SelectedItem as frmVirtualization.SpeakerAngle;
      numArray[result] = selectedItem.AngleFloat;
    }

    private void contextMenuStrip_SpeakerAngle_Closed(
      object sender,
      ToolStripDropDownClosedEventArgs e)
    {
      this.contextMenuStrip_SpeakerAngle.Tag = (object) null;
      this.RefreshSpeakerList();
    }

    private void singleButton_OK_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.OK;

    private void singleButton_Cancel_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.Cancel;

    private class EnvRealizePreset
    {
      private string m_szPresetName = "";
      private int m_nPresetID = -1;

      public string PresetName => this.m_szPresetName;

      public string Text
      {
        get => this.m_szPresetName;
        set => this.m_szPresetName = value;
      }

      public int PresetID => this.m_nPresetID;

      public EnvRealizePreset(string szPresetName, int nPresetID)
      {
        this.m_szPresetName = szPresetName;
        this.m_nPresetID = nPresetID;
      }

      public override bool Equals(object obj)
      {
        if (obj == null || obj.GetType() != typeof (frmVirtualization.EnvRealizePreset))
          return false;
        frmVirtualization.EnvRealizePreset envRealizePreset = obj as frmVirtualization.EnvRealizePreset;
        return envRealizePreset.PresetName == this.m_szPresetName && envRealizePreset.PresetID == this.m_nPresetID;
      }

      public override int GetHashCode() => this.m_nPresetID;

      public override string ToString() => this.m_szPresetName;
    }

    private class SpeakerAngle
    {
      private float m_fAngle;

      public string AngleString => (double) this.m_fAngle >= 0.0 ? "+" + this.m_fAngle.ToString("F01") : this.m_fAngle.ToString("F01");

      public float AngleFloat
      {
        get => this.m_fAngle;
        set => this.m_fAngle = value;
      }

      public SpeakerAngle(float fAngle) => this.m_fAngle = fAngle;

      public override bool Equals(object obj) => obj != null && obj.GetType() == typeof (frmVirtualization.SpeakerAngle) && (double) (obj as frmVirtualization.SpeakerAngle).AngleFloat == (double) this.m_fAngle;

      public override int GetHashCode() => (int) Math.Round((double) this.m_fAngle);

      public override string ToString() => this.AngleString;
    }
  }
}
