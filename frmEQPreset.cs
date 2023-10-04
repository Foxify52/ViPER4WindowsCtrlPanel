using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
    public class FrmEQPreset : Form
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
        private readonly float[] m_faEQPreset = new float[18];
        private readonly IContainer components;
        private ButtonBox buttonBox_Preset;
        private SingleButton singleButton_Load;
        private SingleButton singleButton_Cancel;

        public FrmEQPreset()
        {
            InitializeComponent();
            Text = GlobalMessages.EQUALIZER_PRESET;
            singleButton_Load.ButtonText = GlobalMessages.LOAD_PRESET;
            singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_FLAT, "0"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_SUPERBASS, "1"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_SOFTBASS, "2"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_ROCK, "3"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_RANDB, "4"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_CLASSIC, "5"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_POP, "6"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_JAZZ, "7"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_BLUES, "8"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_ELECTRONIC, "9"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.EQUALIZER_PRESET_VOCAL, "10"));
            buttonBox_Preset.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(PresetSelected);
            for (int index = 0; index < m_faEQPreset.Length; ++index)
                m_faEQPreset[index] = 1f;
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
            if (!int.TryParse(tag, out int result))
                return;
            switch (result)
            {
                case 0:
                    Array.Copy(m_faEQPreset_Flat, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 1:
                    Array.Copy(m_faEQPreset_SuperBass, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 2:
                    Array.Copy(m_faEQPreset_SoftBass, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 3:
                    Array.Copy(m_faEQPreset_Rock, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 4:
                    Array.Copy(m_faEQPreset_RandB, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 5:
                    Array.Copy(m_faEQPreset_Classic, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 6:
                    Array.Copy(m_faEQPreset_Pop, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 7:
                    Array.Copy(m_faEQPreset_Jazz, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 8:
                    Array.Copy(m_faEQPreset_Blues, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 9:
                    Array.Copy(m_faEQPreset_Electronic, m_faEQPreset, m_faEQPreset.Length);
                    break;
                case 10:
                    Array.Copy(m_faEQPreset_Vocal, m_faEQPreset, m_faEQPreset.Length);
                    break;
            }
        }

        public void SetPreset(float[] faPreset)
        {
            if (faPreset == null || faPreset.Length != m_faEQPreset.Length)
                return;
            Array.Copy(faPreset, m_faEQPreset, m_faEQPreset.Length);
        }

        public float[] GetPreset()
        {
            return m_faEQPreset;
        }

        private void SingleButton_Load_ButtonClickNotify(SingleButton objSender)
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmEQPreset));
            buttonBox_Preset = new ButtonBox();
            singleButton_Load = new SingleButton();
            singleButton_Cancel = new SingleButton();
            SuspendLayout();
            buttonBox_Preset.BackColor = SystemColors.Control;
            buttonBox_Preset.Location = new Point(12, 12);
            buttonBox_Preset.Name = "buttonBox_Preset";
            buttonBox_Preset.Size = new Size(175, 331);
            buttonBox_Preset.TabIndex = 0;
            singleButton_Load.BackColor = SystemColors.Control;
            singleButton_Load.ButtonText = "$LOAD_PRESET";
            singleButton_Load.Location = new Point(193, 12);
            singleButton_Load.Name = "singleButton_Load";
            singleButton_Load.Size = new Size(112, 40);
            singleButton_Load.TabIndex = 1;
            singleButton_Load.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Load_ButtonClickNotify);
            singleButton_Cancel.BackColor = SystemColors.Control;
            singleButton_Cancel.ButtonText = "$CANCEL";
            singleButton_Cancel.Location = new Point(193, 303);
            singleButton_Cancel.Name = "singleButton_Cancel";
            singleButton_Cancel.Size = new Size(112, 40);
            singleButton_Cancel.TabIndex = 2;
            singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Cancel_ButtonClickNotify);
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 355);
            Controls.Add(singleButton_Cancel);
            Controls.Add(singleButton_Load);
            Controls.Add(buttonBox_Preset);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = nameof(FrmEQPreset);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$EQUALIZER_PRESET";
            ResumeLayout(false);
        }
    }
}
