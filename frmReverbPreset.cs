using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
    public class FrmReverbPreset : Form
    {
        private float m_rReverbSize;
        private float m_rReverbPredelay;
        private float m_rReverbDamping;
        private float m_rReverbDensity;
        private float m_rReverbBandwidth = 1f;
        private float m_rReverbDecay;
        private float m_rReverbEarlyMix;
        private float m_rReverbMix;
        private readonly IContainer components;
        private SingleButton singleButton_Cancel;
        private SingleButton singleButton_Load;
        private ButtonBox buttonBox_Preset;

        public float ReverbSize
        {
            get => m_rReverbSize;
            set => m_rReverbSize = value;
        }

        public float ReverbPredelay
        {
            get => m_rReverbPredelay;
            set => m_rReverbPredelay = value;
        }

        public float ReverbDamping
        {
            get => m_rReverbDamping;
            set => m_rReverbDamping = value;
        }

        public float ReverbDensity
        {
            get => m_rReverbDensity;
            set => m_rReverbDensity = value;
        }

        public float ReverbBandwidth
        {
            get => m_rReverbBandwidth;
            set => m_rReverbBandwidth = value;
        }

        public float ReverbDecay
        {
            get => m_rReverbDecay;
            set => m_rReverbDecay = value;
        }

        public float ReverbEarlyMix
        {
            get => m_rReverbEarlyMix;
            set => m_rReverbEarlyMix = value;
        }

        public float ReverbMix
        {
            get => m_rReverbMix;
            set => m_rReverbMix = value;
        }

        public FrmReverbPreset()
        {
            InitializeComponent();
            Text = GlobalMessages.REVERB_PRESET;
            singleButton_Load.ButtonText = GlobalMessages.LOAD_PRESET;
            singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_LIVINGROOM, "0"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_BATHROOM, "1"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_BATHROOM_BATHING, "2"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_BEDROOM, "3"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_THEATER, "4"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_AUDITORIUM, "5"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_UNDERGROUND_PLAZA, "6"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_UNDERGROUND_PARKING, "7"));
            buttonBox_Preset.AddItem(new ButtonBox.Item(GlobalMessages.REVERB_PRESET_SCENE_SHOW, "8"));
            buttonBox_Preset.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(PresetSelected);
        }

        private void Apply01Preset()
        {
            m_rReverbDamping = 0.3f;
            m_rReverbDensity = 0.3f;
            m_rReverbBandwidth = 0.96f;
            m_rReverbPredelay = 0.2f;
            m_rReverbSize = 0.15f;
            m_rReverbDecay = 0.41f;
            m_rReverbMix = 0.36f;
            m_rReverbEarlyMix = 0.51f;
        }

        private void Apply02Preset()
        {
            m_rReverbDamping = 0.65f;
            m_rReverbDensity = 0.8f;
            m_rReverbBandwidth = 1f;
            m_rReverbPredelay = 0.0f;
            m_rReverbSize = 0.05f;
            m_rReverbDecay = 0.26f;
            m_rReverbMix = 0.51f;
            m_rReverbEarlyMix = 0.59f;
        }

        private void Apply03Preset()
        {
            m_rReverbDamping = 0.65f;
            m_rReverbDensity = 0.8f;
            m_rReverbBandwidth = 0.11f;
            m_rReverbPredelay = 0.0f;
            m_rReverbSize = 0.05f;
            m_rReverbDecay = 0.26f;
            m_rReverbMix = 0.51f;
            m_rReverbEarlyMix = 0.59f;
        }

        private void Apply04Preset()
        {
            m_rReverbDamping = 0.3f;
            m_rReverbDensity = 0.3f;
            m_rReverbBandwidth = 0.8f;
            m_rReverbPredelay = 0.14f;
            m_rReverbSize = 0.08f;
            m_rReverbDecay = 0.41f;
            m_rReverbMix = 0.29f;
            m_rReverbEarlyMix = 0.41f;
        }

        private void Apply05Preset()
        {
            m_rReverbDamping = 0.65f;
            m_rReverbDensity = 0.3f;
            m_rReverbBandwidth = 0.25f;
            m_rReverbPredelay = 0.0f;
            m_rReverbSize = 0.51f;
            m_rReverbDecay = 0.06f;
            m_rReverbMix = 0.39f;
            m_rReverbEarlyMix = 0.5f;
        }

        private void Apply06Preset()
        {
            m_rReverbDamping = 0.65f;
            m_rReverbDensity = 0.16f;
            m_rReverbBandwidth = 1f;
            m_rReverbPredelay = 0.37f;
            m_rReverbSize = 0.6f;
            m_rReverbDecay = 0.26f;
            m_rReverbMix = 0.51f;
            m_rReverbEarlyMix = 0.59f;
        }

        private void Apply07Preset()
        {
            m_rReverbDamping = 0.65f;
            m_rReverbDensity = 0.3f;
            m_rReverbBandwidth = 0.0f;
            m_rReverbPredelay = 0.0f;
            m_rReverbSize = 1f;
            m_rReverbDecay = 0.0f;
            m_rReverbMix = 0.39f;
            m_rReverbEarlyMix = 0.5f;
        }

        private void Apply08Preset()
        {
            m_rReverbDamping = 0.65f;
            m_rReverbDensity = 0.16f;
            m_rReverbBandwidth = 0.91f;
            m_rReverbPredelay = 0.18f;
            m_rReverbSize = 1f;
            m_rReverbDecay = 0.0f;
            m_rReverbMix = 0.59f;
            m_rReverbEarlyMix = 0.33f;
        }

        private void Apply09Preset()
        {
            m_rReverbDamping = 0.65f;
            m_rReverbDensity = 0.33f;
            m_rReverbBandwidth = 0.15f;
            m_rReverbPredelay = 0.0f;
            m_rReverbSize = 0.81f;
            m_rReverbDecay = 0.0f;
            m_rReverbMix = 0.4f;
            m_rReverbEarlyMix = 0.25f;
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
                    Apply01Preset();
                    break;
                case 1:
                    Apply02Preset();
                    break;
                case 2:
                    Apply03Preset();
                    break;
                case 3:
                    Apply04Preset();
                    break;
                case 4:
                    Apply05Preset();
                    break;
                case 5:
                    Apply06Preset();
                    break;
                case 6:
                    Apply07Preset();
                    break;
                case 7:
                    Apply08Preset();
                    break;
                case 8:
                    Apply09Preset();
                    break;
            }
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmReverbPreset));
            singleButton_Cancel = new SingleButton();
            singleButton_Load = new SingleButton();
            buttonBox_Preset = new ButtonBox();
            SuspendLayout();
            singleButton_Cancel.BackColor = SystemColors.Control;
            singleButton_Cancel.ButtonText = "$CANCEL";
            singleButton_Cancel.Location = new Point(193, 303);
            singleButton_Cancel.Name = "singleButton_Cancel";
            singleButton_Cancel.Size = new Size(112, 40);
            singleButton_Cancel.TabIndex = 5;
            singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Cancel_ButtonClickNotify);
            singleButton_Load.BackColor = SystemColors.Control;
            singleButton_Load.ButtonText = "$LOAD_PRESET";
            singleButton_Load.Location = new Point(193, 12);
            singleButton_Load.Name = "singleButton_Load";
            singleButton_Load.Size = new Size(112, 40);
            singleButton_Load.TabIndex = 4;
            singleButton_Load.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Load_ButtonClickNotify);
            buttonBox_Preset.BackColor = SystemColors.Control;
            buttonBox_Preset.Location = new Point(12, 12);
            buttonBox_Preset.Name = "buttonBox_Preset";
            buttonBox_Preset.Size = new Size(175, 331);
            buttonBox_Preset.TabIndex = 3;
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
            Name = nameof(FrmReverbPreset);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$REVERB_PRESET";
            ResumeLayout(false);
        }
    }
}
