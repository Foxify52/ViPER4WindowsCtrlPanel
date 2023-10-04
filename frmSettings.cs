using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
    public class FrmSettings : Form
    {
        private readonly List<TrayMenuPreset> m_lstTrayMenuPreset = new List<TrayMenuPreset>();
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
        private SingleButton SingleButton_AddNewItem;
        private SingleButton SingleButton_OK;
        private SingleButton SingleButton_Cancel;
        private ContextMenuStrip contextMenuStrip_TrayItem;
        private ToolStripMenuItem ToolStripMenuItem_RemoveItem;
        private ToolStripSeparator ToolStripSeparator1;
        private ToolStripMenuItem ToolStripMenuItem_Name;
        private ToolStripTextBox ToolStripTextBox_Name;
        private ToolStripSeparator ToolStripSeparator2;
        private ToolStripMenuItem ToolStripMenuItem_Mode;
        private ToolStripComboBox ToolStripComboBox_Mode;
        private ToolStripSeparator ToolStripSeparator3;
        private ToolStripMenuItem ToolStripMenuItem_Preset;
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

        public void SetPresetPath(string szPath)
        {
            m_szPresetPath = szPath;
        }

        public void SetCloseToTray(bool bValue)
        {
            m_bCloseToTray = bValue;
            onOffSwitch_CloseToTray.SwitchedOn = m_bCloseToTray;
        }

        public bool GetCloseToTray()
        {
            return m_bCloseToTray;
        }

        public void SetTrayMenuPresetList(List<TrayMenuPreset> lstTrayMenuPreset)
        {
            m_lstTrayMenuPreset.Clear();
            listView_TrayMenuSetting.Items.Clear();
            if (lstTrayMenuPreset == null || lstTrayMenuPreset.Count <= 0)
                return;
            foreach (TrayMenuPreset trayMenuPreset1 in lstTrayMenuPreset)
            {
                if (trayMenuPreset1.Valid())
                {
                    if (string.IsNullOrEmpty(trayMenuPreset1.PresetName))
                        trayMenuPreset1.PresetName = GlobalMessages.UNNAMED;
                    TrayMenuPreset trayMenuPreset2 = trayMenuPreset1.Clone();
                    listView_TrayMenuSetting.Items.Add(new ListViewItem()
                    {
                        Text = trayMenuPreset2.PresetName,
                        SubItems = {
              EffectModeToString(trayMenuPreset2.PresetMode),
              trayMenuPreset2.PresetFileShort
            },
                        Tag = trayMenuPreset2
                    });
                    m_lstTrayMenuPreset.Add(trayMenuPreset2);
                }
            }
        }

        public List<TrayMenuPreset> GetTrayMenuPresetList()
        {
            return m_lstTrayMenuPreset;
        }

        public bool GetAPOCoexistEnabled()
        {
            return onOffSwitch_EnableCoexist.SwitchedOn;
        }

        public FrmSettings()
        {
            InitializeComponent();
            Text = GlobalMessages.SETTINGS;
            label_CloseToTray.Text = GlobalMessages.CLOSE_TO_TRAY;
            groupBox_TrayMenuSetting.Text = GlobalMessages.TRAY_MENU_SETTING;
            listView_TrayMenuSetting.Items.Clear();
            listView_TrayMenuSetting.Columns[0].Text = GlobalMessages.TRAY_MENU_PRESETNAME;
            listView_TrayMenuSetting.Columns[1].Text = GlobalMessages.TRAY_MENU_PRESETMODE;
            listView_TrayMenuSetting.Columns[2].Text = GlobalMessages.TRAY_MENU_PRESETFILE;
            SingleButton_AddNewItem.ButtonText = GlobalMessages.ADD_NEW_ITEM;
            SingleButton_OK.ButtonText = GlobalMessages.OK;
            SingleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
            ToolStripMenuItem_RemoveItem.Text = GlobalMessages.REMOVE_ITEM;
            ToolStripMenuItem_Name.Text = GlobalMessages.MENU_TIPS_NAME;
            ToolStripMenuItem_Mode.Text = GlobalMessages.MENU_TIPS_MODE;
            ToolStripMenuItem_Preset.Text = GlobalMessages.SELECT_PRESET_FILE;
            ToolStripComboBox_Mode.Items.Clear();
            ToolStripComboBox_Mode.Items.Add(new PresetModeItem(0));
            ToolStripComboBox_Mode.Items.Add(new PresetModeItem(1));
            ToolStripComboBox_Mode.Items.Add(new PresetModeItem(2));
            m_lstTrayMenuPreset.Clear();
            m_bCloseToTray = false;
            onOffSwitch_CloseToTray.SwitchedOn = false;
            label_EnableCoexist.Text = GlobalMessages.ENABLE_APO_COEXIST;
            if (RegHelper.QueryDWORD("LoadChildAPO", 0U) == 1U)
                onOffSwitch_EnableCoexist.SwitchedOn = true;
            else
                onOffSwitch_EnableCoexist.SwitchedOn = false;
        }

        private void RefreshList()
        {
            listView_TrayMenuSetting.Items.Clear();
            foreach (TrayMenuPreset trayMenuPreset in m_lstTrayMenuPreset)
            {
                if (trayMenuPreset.Valid())
                {
                    if (string.IsNullOrEmpty(trayMenuPreset.PresetName))
                        trayMenuPreset.PresetName = GlobalMessages.UNNAMED;
                    listView_TrayMenuSetting.Items.Add(new ListViewItem()
                    {
                        Text = trayMenuPreset.PresetName,
                        SubItems = {
              EffectModeToString(trayMenuPreset.PresetMode),
              trayMenuPreset.PresetFileShort
            },
                        Tag = trayMenuPreset
                    });
                }
            }
        }

        private void OnOffSwitch_CloseToTray_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_bCloseToTray = bSwitchedOn;
        }

        private void SingleButton_AddNewItem_ButtonClickNotify(SingleButton objSender)
        {
            m_lstTrayMenuPreset.Add(new TrayMenuPreset(GlobalMessages.UNNAMED, 0, ""));
            RefreshList();
        }

        private void ListView_TrayMenuSetting_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || listView_TrayMenuSetting.SelectedItems.Count != 1 || listView_TrayMenuSetting.SelectedItems[0].Tag == null || listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof(TrayMenuPreset))
                return;
            TrayMenuPreset tag = listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
            ToolStripTextBox_Name.Text = tag.PresetName;
            for (int index = 0; index < ToolStripComboBox_Mode.Items.Count; ++index)
            {
                if (ToolStripComboBox_Mode.Items[index] != null && ToolStripComboBox_Mode.Items[index].GetType() == typeof(PresetModeItem) && (ToolStripComboBox_Mode.Items[index] as PresetModeItem).PresetMode == tag.PresetMode)
                {
                    ToolStripComboBox_Mode.SelectedIndex = index;
                    break;
                }
            }
            contextMenuStrip_TrayItem.Show(listView_TrayMenuSetting, e.Location);
        }

        private void ToolStripMenuItem_RemoveItem_Click(object sender, EventArgs e)
        {
            if (listView_TrayMenuSetting.SelectedItems.Count != 1 || listView_TrayMenuSetting.SelectedItems[0].Tag == null || listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof(TrayMenuPreset) || MessageBox.Show(GlobalMessages.REMOVE_ITEM_QUESTION, GlobalMessages.REMOVE_ITEM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            TrayMenuPreset tag = listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
            if (m_lstTrayMenuPreset.Contains(tag))
                m_lstTrayMenuPreset.Remove(tag);
            RefreshList();
        }

        private void ToolStripTextBox_Name_KeyUp(object sender, KeyEventArgs e)
        {
            if (listView_TrayMenuSetting.SelectedItems.Count != 1 || listView_TrayMenuSetting.SelectedItems[0].Tag == null || listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof(TrayMenuPreset))
                return;
            TrayMenuPreset tag = listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
            tag.PresetName = ToolStripTextBox_Name.Text;
            if (string.IsNullOrEmpty(tag.PresetName))
                tag.PresetName = GlobalMessages.UNNAMED;
            listView_TrayMenuSetting.SelectedItems[0].Text = tag.PresetName;
        }

        private void ToolStripComboBox_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_TrayMenuSetting.SelectedItems.Count != 1 || listView_TrayMenuSetting.SelectedItems[0].Tag == null || listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof(TrayMenuPreset))
                return;
            TrayMenuPreset tag = listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
            if (ToolStripComboBox_Mode.SelectedItem == null || ToolStripComboBox_Mode.SelectedItem.GetType() != typeof(PresetModeItem))
                return;
            PresetModeItem selectedItem = ToolStripComboBox_Mode.SelectedItem as PresetModeItem;
            tag.PresetMode = selectedItem.PresetMode;
            listView_TrayMenuSetting.SelectedItems[0].SubItems[1].Text = EffectModeToString(tag.PresetMode);
        }

        private void ToolStripMenuItem_Preset_Click(object sender, EventArgs e)
        {
            if (listView_TrayMenuSetting.SelectedItems.Count != 1 || listView_TrayMenuSetting.SelectedItems[0].Tag == null || listView_TrayMenuSetting.SelectedItems[0].Tag.GetType() != typeof(TrayMenuPreset))
                return;
            TrayMenuPreset tag = listView_TrayMenuSetting.SelectedItems[0].Tag as TrayMenuPreset;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = GlobalMessages.LOAD_PRESET,
                Filter = "*.vpf|*.vpf",
                DefaultExt = "vpf",
                InitialDirectory = m_szPresetPath
            };
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            tag.PresetFile = openFileDialog.FileName;
            RefreshList();
        }

        private void SingleButton_OK_ButtonClickNotify(SingleButton objSender)
        {
            DialogResult = DialogResult.OK;
        }

        private void SingleButton_Cancel_ButtonClickNotify(SingleButton objSender)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmSettings));
            label_CloseToTray = new Label();
            onOffSwitch_CloseToTray = new OnOffSwitch();
            groupBox_TrayMenuSetting = new GroupBox();
            SingleButton_AddNewItem = new SingleButton();
            listView_TrayMenuSetting = new ListView();
            columnHeader_PresetName = new ColumnHeader();
            columnHeader_PresetMode = new ColumnHeader();
            columnHeader_PresetFile = new ColumnHeader();
            SingleButton_OK = new SingleButton();
            SingleButton_Cancel = new SingleButton();
            contextMenuStrip_TrayItem = new ContextMenuStrip(components);
            ToolStripMenuItem_RemoveItem = new ToolStripMenuItem();
            ToolStripSeparator1 = new ToolStripSeparator();
            ToolStripMenuItem_Name = new ToolStripMenuItem();
            ToolStripTextBox_Name = new ToolStripTextBox();
            ToolStripSeparator2 = new ToolStripSeparator();
            ToolStripMenuItem_Mode = new ToolStripMenuItem();
            ToolStripComboBox_Mode = new ToolStripComboBox();
            ToolStripSeparator3 = new ToolStripSeparator();
            ToolStripMenuItem_Preset = new ToolStripMenuItem();
            label_EnableCoexist = new Label();
            onOffSwitch_EnableCoexist = new OnOffSwitch();
            groupBox_TrayMenuSetting.SuspendLayout();
            contextMenuStrip_TrayItem.SuspendLayout();
            SuspendLayout();
            label_CloseToTray.AutoSize = true;
            label_CloseToTray.Location = new Point(12, 28);
            label_CloseToTray.Name = "label_CloseToTray";
            label_CloseToTray.Size = new Size(89, 12);
            label_CloseToTray.TabIndex = 0;
            label_CloseToTray.Text = "$CLOSE_TO_TRAY";
            onOffSwitch_CloseToTray.BackColor = Color.Transparent;
            onOffSwitch_CloseToTray.Location = new Point(277, 22);
            onOffSwitch_CloseToTray.Name = "onOffSwitch_CloseToTray";
            onOffSwitch_CloseToTray.Size = new Size(66, 23);
            onOffSwitch_CloseToTray.SwitchedOn = false;
            onOffSwitch_CloseToTray.TabIndex = 1;
            onOffSwitch_CloseToTray.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(OnOffSwitch_CloseToTray_SwitchChangeNotify);
            groupBox_TrayMenuSetting.Controls.Add(SingleButton_AddNewItem);
            groupBox_TrayMenuSetting.Controls.Add(listView_TrayMenuSetting);
            groupBox_TrayMenuSetting.Location = new Point(14, 59);
            groupBox_TrayMenuSetting.Name = "groupBox_TrayMenuSetting";
            groupBox_TrayMenuSetting.Size = new Size(329, 320);
            groupBox_TrayMenuSetting.TabIndex = 2;
            groupBox_TrayMenuSetting.TabStop = false;
            groupBox_TrayMenuSetting.Text = "$TRAY_MENU_SETTING";
            SingleButton_AddNewItem.BackColor = SystemColors.Control;
            SingleButton_AddNewItem.ButtonText = "$ADD_NEW_ITEM";
            SingleButton_AddNewItem.Location = new Point(6, 282);
            SingleButton_AddNewItem.Name = "SingleButton_AddNewItem";
            SingleButton_AddNewItem.Size = new Size(132, 29);
            SingleButton_AddNewItem.TabIndex = 1;
            SingleButton_AddNewItem.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_AddNewItem_ButtonClickNotify);
            listView_TrayMenuSetting.Columns.AddRange(new ColumnHeader[3]
            {
        columnHeader_PresetName,
        columnHeader_PresetMode,
        columnHeader_PresetFile
            });
            listView_TrayMenuSetting.FullRowSelect = true;
            listView_TrayMenuSetting.GridLines = true;
            listView_TrayMenuSetting.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView_TrayMenuSetting.HideSelection = false;
            listView_TrayMenuSetting.Location = new Point(6, 20);
            listView_TrayMenuSetting.MultiSelect = false;
            listView_TrayMenuSetting.Name = "listView_TrayMenuSetting";
            listView_TrayMenuSetting.Size = new Size(317, 256);
            listView_TrayMenuSetting.TabIndex = 0;
            listView_TrayMenuSetting.UseCompatibleStateImageBehavior = false;
            listView_TrayMenuSetting.View = View.Details;
            listView_TrayMenuSetting.MouseUp += new MouseEventHandler(ListView_TrayMenuSetting_MouseUp);
            columnHeader_PresetName.Text = "$TRAY_MENU_PRESETNAME";
            columnHeader_PresetName.Width = 89;
            columnHeader_PresetMode.Text = "$TRAY_MENU_PRESETMODE";
            columnHeader_PresetMode.Width = 81;
            columnHeader_PresetFile.Text = "$TRAY_MENU_PRESETFILE";
            columnHeader_PresetFile.Width = 136;
            SingleButton_OK.BackColor = SystemColors.Control;
            SingleButton_OK.ButtonText = "$OK";
            SingleButton_OK.Location = new Point(14, 447);
            SingleButton_OK.Name = "SingleButton_OK";
            SingleButton_OK.Size = new Size(112, 40);
            SingleButton_OK.TabIndex = 3;
            SingleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_OK_ButtonClickNotify);
            SingleButton_Cancel.BackColor = SystemColors.Control;
            SingleButton_Cancel.ButtonText = "$CANCEL";
            SingleButton_Cancel.Location = new Point(231, 447);
            SingleButton_Cancel.Name = "SingleButton_Cancel";
            SingleButton_Cancel.Size = new Size(112, 40);
            SingleButton_Cancel.TabIndex = 4;
            SingleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Cancel_ButtonClickNotify);
            contextMenuStrip_TrayItem.Items.AddRange(new ToolStripItem[9]
            {
         ToolStripMenuItem_RemoveItem,
         ToolStripSeparator1,
         ToolStripMenuItem_Name,
         ToolStripTextBox_Name,
         ToolStripSeparator2,
         ToolStripMenuItem_Mode,
         ToolStripComboBox_Mode,
         ToolStripSeparator3,
         ToolStripMenuItem_Preset
            });
            contextMenuStrip_TrayItem.Name = "contextMenuStrip_TrayItem";
            contextMenuStrip_TrayItem.Size = new Size(202, 164);
            ToolStripMenuItem_RemoveItem.Name = "ToolStripMenuItem_RemoveItem";
            ToolStripMenuItem_RemoveItem.Size = new Size(201, 22);
            ToolStripMenuItem_RemoveItem.Text = "$REMOVE_ITEM";
            ToolStripMenuItem_RemoveItem.Click += new EventHandler(ToolStripMenuItem_RemoveItem_Click);
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size(198, 6);
            ToolStripMenuItem_Name.Enabled = false;
            ToolStripMenuItem_Name.Name = "ToolStripMenuItem_Name";
            ToolStripMenuItem_Name.Size = new Size(201, 22);
            ToolStripMenuItem_Name.Text = "$MENU_TIPS_NAME";
            ToolStripTextBox_Name.Name = "ToolStripTextBox_Name";
            ToolStripTextBox_Name.Size = new Size(100, 23);
            ToolStripTextBox_Name.KeyUp += new KeyEventHandler(ToolStripTextBox_Name_KeyUp);
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripSeparator2.Size = new Size(198, 6);
            ToolStripMenuItem_Mode.Enabled = false;
            ToolStripMenuItem_Mode.Name = "ToolStripMenuItem_Mode";
            ToolStripMenuItem_Mode.Size = new Size(201, 22);
            ToolStripMenuItem_Mode.Text = "$MENU_TIPS_MODE";
            ToolStripComboBox_Mode.DropDownStyle = ComboBoxStyle.DropDownList;
            ToolStripComboBox_Mode.Name = "ToolStripComboBox_Mode";
            ToolStripComboBox_Mode.Size = new Size(121, 25);
            ToolStripComboBox_Mode.SelectedIndexChanged += new EventHandler(ToolStripComboBox_Mode_SelectedIndexChanged);
            ToolStripSeparator3.Name = "ToolStripSeparator3";
            ToolStripSeparator3.Size = new Size(198, 6);
            ToolStripMenuItem_Preset.Name = "ToolStripMenuItem_Preset";
            ToolStripMenuItem_Preset.Size = new Size(201, 22);
            ToolStripMenuItem_Preset.Text = "$SELECT_PRESET_FILE";
            ToolStripMenuItem_Preset.Click += new EventHandler(ToolStripMenuItem_Preset_Click);
            label_EnableCoexist.AutoSize = true;
            label_EnableCoexist.Location = new Point(12, 407);
            label_EnableCoexist.Name = "label_EnableCoexist";
            label_EnableCoexist.Size = new Size(119, 12);
            label_EnableCoexist.TabIndex = 5;
            label_EnableCoexist.Text = "$ENABLE_APO_COEXIST";
            onOffSwitch_EnableCoexist.BackColor = Color.Transparent;
            onOffSwitch_EnableCoexist.Location = new Point(277, 401);
            onOffSwitch_EnableCoexist.Name = "onOffSwitch_EnableCoexist";
            onOffSwitch_EnableCoexist.Size = new Size(66, 23);
            onOffSwitch_EnableCoexist.SwitchedOn = false;
            onOffSwitch_EnableCoexist.TabIndex = 6;
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 498);
            Controls.Add(onOffSwitch_EnableCoexist);
            Controls.Add(label_EnableCoexist);
            Controls.Add(SingleButton_Cancel);
            Controls.Add(SingleButton_OK);
            Controls.Add(groupBox_TrayMenuSetting);
            Controls.Add(label_CloseToTray);
            Controls.Add(onOffSwitch_CloseToTray);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = nameof(FrmSettings);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$SETTINGS";
            groupBox_TrayMenuSetting.ResumeLayout(false);
            contextMenuStrip_TrayItem.ResumeLayout(false);
            contextMenuStrip_TrayItem.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private class PresetModeItem
        {
            private int m_nPresetMode = -1;

            public int PresetMode
            {
                get => m_nPresetMode;
                set => m_nPresetMode = value;
            }

            public string PresetModeString
            {
                get
                {
                    if (m_nPresetMode == 0)
                        return GlobalMessages.MUSIC_MODE;
                    if (m_nPresetMode == 1)
                        return GlobalMessages.MOVIE_MODE;
                    return m_nPresetMode == 2 ? GlobalMessages.FREESTYLE_MODE : "";
                }
            }

            public PresetModeItem(int nMode) => m_nPresetMode = nMode;

            public override bool Equals(object obj)
            {
                return obj != null && obj.GetType() == typeof(PresetModeItem) && (obj as PresetModeItem).PresetMode == m_nPresetMode;
            }

            public override int GetHashCode()
            {
                return m_nPresetMode;
            }

            public override string ToString()
            {
                return PresetModeString;
            }
        }
    }
}
