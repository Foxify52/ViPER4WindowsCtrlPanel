using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
  public class frmSettings : Form
  {
    private List<TrayMenuPreset> m_lstTrayMenuPreset = new List<TrayMenuPreset>();
    private bool m_bCloseToTray;
    private string m_szPresetPath = "";
    private IContainer components;
    private Label label_CloseToTray;
    private OnOffSwitch onOffSwitch_CloseToTray;
    private GroupBox groupBox_TrayMenuSetting;
    private ListView listView_TrayMenuSetting;
    private ColumnHeader columnHeader_PresetName;
    private ColumnHeader columnHeader_PresetMode;
    private ColumnHeader columnHeader_PresetFile;
    private SingleButton singleButton_AddNewItem;
    private SingleButton singleButton_OK;
    private SingleButton singleButton_Cancel;
    private ContextMenuStrip contextMenuStrip_TrayItem;
    private ToolStripMenuItem toolStripMenuItem_RemoveItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem toolStripMenuItem_Name;
    private ToolStripTextBox toolStripTextBox_Name;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem toolStripMenuItem_Mode;
    private ToolStripComboBox toolStripComboBox_Mode;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem toolStripMenuItem_Preset;
    private Label label_EnableCoexist;
    private OnOffSwitch onOffSwitch_EnableCoexist;

    private string EffectModeToString(int nMode)
    {
      switch (nMode)
      {
        case 0:
          return GlobalMessages.MUSIC_MODE;
        case 1:
          return GlobalMessages.MOVIE_MODE;
        case 2:
          return GlobalMessages.FREESTYLE_MODE;
        default:
          return "";
      }
    }

    public void SetPresetPath(string szPath) => this.m_szPresetPath = szPath;

    public void SetCloseToTray(bool bValue)
    {
      this.m_bCloseToTray = bValue;
      this.onOffSwitch_CloseToTray.SwitchedOn = this.m_bCloseToTray;
    }

    public bool GetCloseToTray() => this.m_bCloseToTray;

    public void SetTrayMenuPresetList(List<TrayMenuPreset> lstTrayMenuPreset)
    {
      this.m_lstTrayMenuPreset.Clear();
      this.listView_TrayMenuSetting.Items.Clear();
      if (lstTrayMenuPreset == null || lstTrayMenuPreset.Count <= 0)
        return;
      foreach (TrayMenuPreset trayMenuPreset1 in lstTrayMenuPreset)
      {
        if (trayMenuPreset1.Valid())
        {
          if (string.IsNullOrEmpty(trayMenuPreset1.PresetName))
            trayMenuPreset1.PresetName = GlobalMessages.UNNAMED;
          TrayMenuPreset trayMenuPreset2 = trayMenuPreset1.Clone();
          this.listView_TrayMenuSetting.Items.Add(new ListViewItem()
          {
            Text = trayMenuPreset2.PresetName,
            SubItems = {
              this.EffectModeToString(trayMenuPreset2.PresetMode),
              trayMenuPreset2.PresetFileShort
            },
            Tag = (object) trayMenuPreset2
          });
          this.m_lstTrayMenuPreset.Add(trayMenuPreset2);
        }
      }
    }

    public List<TrayMenuPreset> GetTrayMenuPresetList() => this.m_lstTrayMenuPreset;

    public bool GetAPOCoexistEnabled() => this.onOffSwitch_EnableCoexist.SwitchedOn;

    public frmSettings()
    {
      this.InitializeComponent();
      this.Text = GlobalMessages.SETTINGS;
      this.label_CloseToTray.Text = GlobalMessages.CLOSE_TO_TRAY;
      this.groupBox_TrayMenuSetting.Text = GlobalMessages.TRAY_MENU_SETTING;
      this.listView_TrayMenuSetting.Items.Clear();
      this.listView_TrayMenuSetting.Columns[0].Text = GlobalMessages.TRAY_MENU_PRESETNAME;
      this.listView_TrayMenuSetting.Columns[1].Text = GlobalMessages.TRAY_MENU_PRESETMODE;
      this.listView_TrayMenuSetting.Columns[2].Text = GlobalMessages.TRAY_MENU_PRESETFILE;
      this.singleButton_AddNewItem.ButtonText = GlobalMessages.ADD_NEW_ITEM;
      this.singleButton_OK.ButtonText = GlobalMessages.OK;
      this.singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
      this.toolStripMenuItem_RemoveItem.Text = GlobalMessages.REMOVE_ITEM;
      this.toolStripMenuItem_Name.Text = GlobalMessages.MENU_TIPS_NAME;
      this.toolStripMenuItem_Mode.Text = GlobalMessages.MENU_TIPS_MODE;
      this.toolStripMenuItem_Preset.Text = GlobalMessages.SELECT_PRESET_FILE;
      this.toolStripComboBox_Mode.Items.Clear();
      this.toolStripComboBox_Mode.Items.Add((object) new frmSettings.PresetModeItem(0));
      this.toolStripComboBox_Mode.Items.Add((object) new frmSettings.PresetModeItem(1));
      this.toolStripComboBox_Mode.Items.Add((object) new frmSettings.PresetModeItem(2));
      this.m_lstTrayMenuPreset.Clear();
      this.m_bCloseToTray = false;
      this.onOffSwitch_CloseToTray.SwitchedOn = false;
      this.label_EnableCoexist.Text = GlobalMessages.ENABLE_APO_COEXIST;
      if (RegHelper.QueryDWORD("LoadChildAPO", 0U) == 1U)
        this.onOffSwitch_EnableCoexist.SwitchedOn = true;
      else
        this.onOffSwitch_EnableCoexist.SwitchedOn = false;
    }

    private void RefreshList()
    {
      this.listView_TrayMenuSetting.Items.Clear();
      foreach (TrayMenuPreset trayMenuPreset in this.m_lstTrayMenuPreset)
      {
        if (trayMenuPreset.Valid())
        {
          if (string.IsNullOrEmpty(trayMenuPreset.PresetName))
            trayMenuPreset.PresetName = GlobalMessages.UNNAMED;
          this.listView_TrayMenuSetting.Items.Add(new ListViewItem()
          {
            Text = trayMenuPreset.PresetName,
            SubItems = {
              this.EffectModeToString(trayMenuPreset.PresetMode),
              trayMenuPreset.PresetFileShort
            },
            Tag = (object) trayMenuPreset
          });
        }
      }
    }

    private void onOffSwitch_CloseToTray_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender) => this.m_bCloseToTray = bSwitchedOn;

    private void singleButton_AddNewItem_ButtonClickNotify(SingleButton objSender)
    {
      this.m_lstTrayMenuPreset.Add(new TrayMenuPreset(GlobalMessages.UNNAMED, 0, ""));
      this.RefreshList();
    }

    private void listView_TrayMenuSetting_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right || this.listView_TrayMenuSetting.SelectedItems.Count != 1 || this.listView_TrayMenuSetting.SelectedItems[0].Tag == null || this.listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof (TrayMenuPreset))
        return;
      TrayMenuPreset tag = this.listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
      this.toolStripTextBox_Name.Text = tag.PresetName;
      for (int index = 0; index < this.toolStripComboBox_Mode.Items.Count; ++index)
      {
        if (this.toolStripComboBox_Mode.Items[index] != null && this.toolStripComboBox_Mode.Items[index].GetType() == typeof (frmSettings.PresetModeItem) && (this.toolStripComboBox_Mode.Items[index] as frmSettings.PresetModeItem).PresetMode == tag.PresetMode)
        {
          this.toolStripComboBox_Mode.SelectedIndex = index;
          break;
        }
      }
      this.contextMenuStrip_TrayItem.Show((Control) this.listView_TrayMenuSetting, e.Location);
    }

    private void toolStripMenuItem_RemoveItem_Click(object sender, EventArgs e)
    {
      if (this.listView_TrayMenuSetting.SelectedItems.Count != 1 || this.listView_TrayMenuSetting.SelectedItems[0].Tag == null || this.listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof (TrayMenuPreset) || MessageBox.Show(GlobalMessages.REMOVE_ITEM_QUESTION, GlobalMessages.REMOVE_ITEM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      TrayMenuPreset tag = this.listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
      if (this.m_lstTrayMenuPreset.Contains(tag))
        this.m_lstTrayMenuPreset.Remove(tag);
      this.RefreshList();
    }

    private void toolStripTextBox_Name_KeyUp(object sender, KeyEventArgs e)
    {
      if (this.listView_TrayMenuSetting.SelectedItems.Count != 1 || this.listView_TrayMenuSetting.SelectedItems[0].Tag == null || this.listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof (TrayMenuPreset))
        return;
      TrayMenuPreset tag = this.listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
      tag.PresetName = this.toolStripTextBox_Name.Text;
      if (string.IsNullOrEmpty(tag.PresetName))
        tag.PresetName = GlobalMessages.UNNAMED;
      this.listView_TrayMenuSetting.SelectedItems[0].Text = tag.PresetName;
    }

    private void toolStripComboBox_Mode_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listView_TrayMenuSetting.SelectedItems.Count != 1 || this.listView_TrayMenuSetting.SelectedItems[0].Tag == null || this.listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof (TrayMenuPreset))
        return;
      TrayMenuPreset tag = this.listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
      if (this.toolStripComboBox_Mode.SelectedItem == null || this.toolStripComboBox_Mode.SelectedItem.GetType() != typeof (frmSettings.PresetModeItem))
        return;
      frmSettings.PresetModeItem selectedItem = this.toolStripComboBox_Mode.SelectedItem as frmSettings.PresetModeItem;
      tag.PresetMode = selectedItem.PresetMode;
      this.listView_TrayMenuSetting.SelectedItems[0].SubItems[1].Text = this.EffectModeToString(tag.PresetMode);
    }

    private void toolStripMenuItem_Preset_Click(object sender, EventArgs e)
    {
      if (this.listView_TrayMenuSetting.SelectedItems.Count != 1 || this.listView_TrayMenuSetting.SelectedItems[0].Tag == null || this.listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof (TrayMenuPreset))
        return;
      TrayMenuPreset tag = this.listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = GlobalMessages.LOAD_PRESET;
      openFileDialog.Filter = "*.vpf|*.vpf";
      openFileDialog.DefaultExt = "vpf";
      openFileDialog.InitialDirectory = this.m_szPresetPath;
      if (openFileDialog.ShowDialog() == DialogResult.Cancel)
        return;
      tag.PresetFile = openFileDialog.FileName;
      this.RefreshList();
    }

    private void singleButton_OK_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.OK;

    private void singleButton_Cancel_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.Cancel;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSettings));
      this.label_CloseToTray = new Label();
      this.onOffSwitch_CloseToTray = new OnOffSwitch();
      this.groupBox_TrayMenuSetting = new GroupBox();
      this.singleButton_AddNewItem = new SingleButton();
      this.listView_TrayMenuSetting = new ListView();
      this.columnHeader_PresetName = new ColumnHeader();
      this.columnHeader_PresetMode = new ColumnHeader();
      this.columnHeader_PresetFile = new ColumnHeader();
      this.singleButton_OK = new SingleButton();
      this.singleButton_Cancel = new SingleButton();
      this.contextMenuStrip_TrayItem = new ContextMenuStrip(this.components);
      this.toolStripMenuItem_RemoveItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripMenuItem_Name = new ToolStripMenuItem();
      this.toolStripTextBox_Name = new ToolStripTextBox();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripMenuItem_Mode = new ToolStripMenuItem();
      this.toolStripComboBox_Mode = new ToolStripComboBox();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripMenuItem_Preset = new ToolStripMenuItem();
      this.label_EnableCoexist = new Label();
      this.onOffSwitch_EnableCoexist = new OnOffSwitch();
      this.groupBox_TrayMenuSetting.SuspendLayout();
      this.contextMenuStrip_TrayItem.SuspendLayout();
      this.SuspendLayout();
      this.label_CloseToTray.AutoSize = true;
      this.label_CloseToTray.Location = new Point(12, 28);
      this.label_CloseToTray.Name = "label_CloseToTray";
      this.label_CloseToTray.Size = new Size(89, 12);
      this.label_CloseToTray.TabIndex = 0;
      this.label_CloseToTray.Text = "$CLOSE_TO_TRAY";
      this.onOffSwitch_CloseToTray.BackColor = Color.Transparent;
      this.onOffSwitch_CloseToTray.Location = new Point(277, 22);
      this.onOffSwitch_CloseToTray.Name = "onOffSwitch_CloseToTray";
      this.onOffSwitch_CloseToTray.Size = new Size(66, 23);
      this.onOffSwitch_CloseToTray.SwitchedOn = false;
      this.onOffSwitch_CloseToTray.TabIndex = 1;
      this.onOffSwitch_CloseToTray.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.onOffSwitch_CloseToTray_SwitchChangeNotify);
      this.groupBox_TrayMenuSetting.Controls.Add((Control) this.singleButton_AddNewItem);
      this.groupBox_TrayMenuSetting.Controls.Add((Control) this.listView_TrayMenuSetting);
      this.groupBox_TrayMenuSetting.Location = new Point(14, 59);
      this.groupBox_TrayMenuSetting.Name = "groupBox_TrayMenuSetting";
      this.groupBox_TrayMenuSetting.Size = new Size(329, 320);
      this.groupBox_TrayMenuSetting.TabIndex = 2;
      this.groupBox_TrayMenuSetting.TabStop = false;
      this.groupBox_TrayMenuSetting.Text = "$TRAY_MENU_SETTING";
      this.singleButton_AddNewItem.BackColor = SystemColors.Control;
      this.singleButton_AddNewItem.ButtonText = "$ADD_NEW_ITEM";
      this.singleButton_AddNewItem.Location = new Point(6, 282);
      this.singleButton_AddNewItem.Name = "singleButton_AddNewItem";
      this.singleButton_AddNewItem.Size = new Size(132, 29);
      this.singleButton_AddNewItem.TabIndex = 1;
      this.singleButton_AddNewItem.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_AddNewItem_ButtonClickNotify);
      this.listView_TrayMenuSetting.Columns.AddRange(new ColumnHeader[3]
      {
        this.columnHeader_PresetName,
        this.columnHeader_PresetMode,
        this.columnHeader_PresetFile
      });
      this.listView_TrayMenuSetting.FullRowSelect = true;
      this.listView_TrayMenuSetting.GridLines = true;
      this.listView_TrayMenuSetting.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listView_TrayMenuSetting.HideSelection = false;
      this.listView_TrayMenuSetting.Location = new Point(6, 20);
      this.listView_TrayMenuSetting.MultiSelect = false;
      this.listView_TrayMenuSetting.Name = "listView_TrayMenuSetting";
      this.listView_TrayMenuSetting.Size = new Size(317, 256);
      this.listView_TrayMenuSetting.TabIndex = 0;
      this.listView_TrayMenuSetting.UseCompatibleStateImageBehavior = false;
      this.listView_TrayMenuSetting.View = View.Details;
      this.listView_TrayMenuSetting.MouseUp += new MouseEventHandler(this.listView_TrayMenuSetting_MouseUp);
      this.columnHeader_PresetName.Text = "$TRAY_MENU_PRESETNAME";
      this.columnHeader_PresetName.Width = 89;
      this.columnHeader_PresetMode.Text = "$TRAY_MENU_PRESETMODE";
      this.columnHeader_PresetMode.Width = 81;
      this.columnHeader_PresetFile.Text = "$TRAY_MENU_PRESETFILE";
      this.columnHeader_PresetFile.Width = 136;
      this.singleButton_OK.BackColor = SystemColors.Control;
      this.singleButton_OK.ButtonText = "$OK";
      this.singleButton_OK.Location = new Point(14, 447);
      this.singleButton_OK.Name = "singleButton_OK";
      this.singleButton_OK.Size = new Size(112, 40);
      this.singleButton_OK.TabIndex = 3;
      this.singleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_OK_ButtonClickNotify);
      this.singleButton_Cancel.BackColor = SystemColors.Control;
      this.singleButton_Cancel.ButtonText = "$CANCEL";
      this.singleButton_Cancel.Location = new Point(231, 447);
      this.singleButton_Cancel.Name = "singleButton_Cancel";
      this.singleButton_Cancel.Size = new Size(112, 40);
      this.singleButton_Cancel.TabIndex = 4;
      this.singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Cancel_ButtonClickNotify);
      this.contextMenuStrip_TrayItem.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.toolStripMenuItem_RemoveItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripMenuItem_Name,
        (ToolStripItem) this.toolStripTextBox_Name,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripMenuItem_Mode,
        (ToolStripItem) this.toolStripComboBox_Mode,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripMenuItem_Preset
      });
      this.contextMenuStrip_TrayItem.Name = "contextMenuStrip_TrayItem";
      this.contextMenuStrip_TrayItem.Size = new Size(202, 164);
      this.toolStripMenuItem_RemoveItem.Name = "toolStripMenuItem_RemoveItem";
      this.toolStripMenuItem_RemoveItem.Size = new Size(201, 22);
      this.toolStripMenuItem_RemoveItem.Text = "$REMOVE_ITEM";
      this.toolStripMenuItem_RemoveItem.Click += new EventHandler(this.toolStripMenuItem_RemoveItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(198, 6);
      this.toolStripMenuItem_Name.Enabled = false;
      this.toolStripMenuItem_Name.Name = "toolStripMenuItem_Name";
      this.toolStripMenuItem_Name.Size = new Size(201, 22);
      this.toolStripMenuItem_Name.Text = "$MENU_TIPS_NAME";
      this.toolStripTextBox_Name.Name = "toolStripTextBox_Name";
      this.toolStripTextBox_Name.Size = new Size(100, 23);
      this.toolStripTextBox_Name.KeyUp += new KeyEventHandler(this.toolStripTextBox_Name_KeyUp);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(198, 6);
      this.toolStripMenuItem_Mode.Enabled = false;
      this.toolStripMenuItem_Mode.Name = "toolStripMenuItem_Mode";
      this.toolStripMenuItem_Mode.Size = new Size(201, 22);
      this.toolStripMenuItem_Mode.Text = "$MENU_TIPS_MODE";
      this.toolStripComboBox_Mode.DropDownStyle = ComboBoxStyle.DropDownList;
      this.toolStripComboBox_Mode.Name = "toolStripComboBox_Mode";
      this.toolStripComboBox_Mode.Size = new Size(121, 25);
      this.toolStripComboBox_Mode.SelectedIndexChanged += new EventHandler(this.toolStripComboBox_Mode_SelectedIndexChanged);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(198, 6);
      this.toolStripMenuItem_Preset.Name = "toolStripMenuItem_Preset";
      this.toolStripMenuItem_Preset.Size = new Size(201, 22);
      this.toolStripMenuItem_Preset.Text = "$SELECT_PRESET_FILE";
      this.toolStripMenuItem_Preset.Click += new EventHandler(this.toolStripMenuItem_Preset_Click);
      this.label_EnableCoexist.AutoSize = true;
      this.label_EnableCoexist.Location = new Point(12, 407);
      this.label_EnableCoexist.Name = "label_EnableCoexist";
      this.label_EnableCoexist.Size = new Size(119, 12);
      this.label_EnableCoexist.TabIndex = 5;
      this.label_EnableCoexist.Text = "$ENABLE_APO_COEXIST";
      this.onOffSwitch_EnableCoexist.BackColor = Color.Transparent;
      this.onOffSwitch_EnableCoexist.Location = new Point(277, 401);
      this.onOffSwitch_EnableCoexist.Name = "onOffSwitch_EnableCoexist";
      this.onOffSwitch_EnableCoexist.Size = new Size(66, 23);
      this.onOffSwitch_EnableCoexist.SwitchedOn = false;
      this.onOffSwitch_EnableCoexist.TabIndex = 6;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(356, 498);
      this.Controls.Add((Control) this.onOffSwitch_EnableCoexist);
      this.Controls.Add((Control) this.label_EnableCoexist);
      this.Controls.Add((Control) this.singleButton_Cancel);
      this.Controls.Add((Control) this.singleButton_OK);
      this.Controls.Add((Control) this.groupBox_TrayMenuSetting);
      this.Controls.Add((Control) this.label_CloseToTray);
      this.Controls.Add((Control) this.onOffSwitch_CloseToTray);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmSettings);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$SETTINGS";
      this.groupBox_TrayMenuSetting.ResumeLayout(false);
      this.contextMenuStrip_TrayItem.ResumeLayout(false);
      this.contextMenuStrip_TrayItem.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private class PresetModeItem
    {
      private int m_nPresetMode = -1;

      public int PresetMode
      {
        get => this.m_nPresetMode;
        set => this.m_nPresetMode = value;
      }

      public string PresetModeString
      {
        get
        {
          if (this.m_nPresetMode == 0)
            return GlobalMessages.MUSIC_MODE;
          if (this.m_nPresetMode == 1)
            return GlobalMessages.MOVIE_MODE;
          return this.m_nPresetMode == 2 ? GlobalMessages.FREESTYLE_MODE : "";
        }
      }

      public PresetModeItem(int nMode) => this.m_nPresetMode = nMode;

      public override bool Equals(object obj) => obj != null && obj.GetType() == typeof (frmSettings.PresetModeItem) && (obj as frmSettings.PresetModeItem).PresetMode == this.m_nPresetMode;

      public override int GetHashCode() => this.m_nPresetMode;

      public override string ToString() => this.PresetModeString;
    }
  }
}
