using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
    public class FrmLatency : Form
    {
        private readonly IContainer components;
        private Label label_CurrentLatency;
        private Label label_DesiredLatency;
        private ButtonBox buttonBox_Latency;
        private Label label_LowLatencyNote;
        private SingleButton singleButton_OK;
        private SingleButton singleButton_Cancel;
        private int m_iShortLen = 4096;
        private int m_iMiddleLen;
        private int m_iLongLen;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmLatency));
            label_CurrentLatency = new Label();
            label_DesiredLatency = new Label();
            buttonBox_Latency = new ButtonBox();
            label_LowLatencyNote = new Label();
            singleButton_OK = new SingleButton();
            singleButton_Cancel = new SingleButton();
            SuspendLayout();
            label_CurrentLatency.AutoSize = true;
            label_CurrentLatency.Location = new Point(12, 9);
            label_CurrentLatency.Name = "label_CurrentLatency";
            label_CurrentLatency.Size = new Size(137, 12);
            label_CurrentLatency.TabIndex = 0;
            label_CurrentLatency.Text = "$CURRENT_LATENCY : 0ms";
            label_DesiredLatency.AutoSize = true;
            label_DesiredLatency.Location = new Point(12, 41);
            label_DesiredLatency.Name = "label_DesiredLatency";
            label_DesiredLatency.Size = new Size(101, 12);
            label_DesiredLatency.TabIndex = 1;
            label_DesiredLatency.Text = "$DESIRED_LATENCY";
            buttonBox_Latency.BackColor = SystemColors.Control;
            buttonBox_Latency.Location = new Point(12, 74);
            buttonBox_Latency.Name = "buttonBox_Latency";
            buttonBox_Latency.Size = new Size(137, 190);
            buttonBox_Latency.TabIndex = 2;
            buttonBox_Latency.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(ButtonBox_Latency_ItemSelectedNotify);
            label_LowLatencyNote.AutoSize = true;
            label_LowLatencyNote.ForeColor = Color.Red;
            label_LowLatencyNote.Location = new Point(12, 59);
            label_LowLatencyNote.Name = "label_LowLatencyNote";
            label_LowLatencyNote.Size = new Size(107, 12);
            label_LowLatencyNote.TabIndex = 3;
            label_LowLatencyNote.Text = "$LOW_LATENCY_NOTE";
            singleButton_OK.BackColor = SystemColors.Control;
            singleButton_OK.ButtonText = "$OK";
            singleButton_OK.Location = new Point(155, 182);
            singleButton_OK.Name = "singleButton_OK";
            singleButton_OK.Size = new Size(88, 38);
            singleButton_OK.TabIndex = 4;
            singleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_OK_ButtonClickNotify);
            singleButton_Cancel.BackColor = SystemColors.Control;
            singleButton_Cancel.ButtonText = "$CANCEL";
            singleButton_Cancel.Location = new Point(155, 226);
            singleButton_Cancel.Name = "singleButton_Cancel";
            singleButton_Cancel.Size = new Size(88, 38);
            singleButton_Cancel.TabIndex = 5;
            singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Cancel_ButtonClickNotify);
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 279);
            Controls.Add(singleButton_Cancel);
            Controls.Add(singleButton_OK);
            Controls.Add(label_LowLatencyNote);
            Controls.Add(buttonBox_Latency);
            Controls.Add(label_DesiredLatency);
            Controls.Add(label_CurrentLatency);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = nameof(FrmLatency);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$LATENCY_SETTING";
            ResumeLayout(false);
            PerformLayout();
        }

        public int ShortFilterLen
        {
            get => m_iShortLen;
            set
            {
                m_iShortLen = value;
                UpdateUI();
            }
        }

        public int MiddleFilterLen
        {
            get => m_iMiddleLen;
            set
            {
                m_iMiddleLen = value;
                UpdateUI();
            }
        }

        public int LongFilterLen
        {
            get => m_iLongLen;
            set
            {
                m_iLongLen = value;
                UpdateUI();
            }
        }

        public FrmLatency()
        {
            InitializeComponent();
            Text = GlobalMessages.LATENCY_SETTING;
            label_CurrentLatency.Text = GlobalMessages.CURRENT_LATENCY + " : " + (GetLatency() * 1000f).ToString("F04") + " ms";
            label_DesiredLatency.Text = GlobalMessages.DESIRED_LATENCY;
            label_LowLatencyNote.Text = GlobalMessages.LOW_LATENCY_NOTE;
            singleButton_OK.ButtonText = GlobalMessages.OK;
            singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
            buttonBox_Latency.AddItem(new ButtonBox.Item((GetLatency(16384) * 1000f).ToString("F04") + " ms", "16384"));
            buttonBox_Latency.AddItem(new ButtonBox.Item((GetLatency(8192) * 1000f).ToString("F04") + " ms", "8192"));
            buttonBox_Latency.AddItem(new ButtonBox.Item((GetLatency(4096) * 1000f).ToString("F04") + " ms", "4096"));
            buttonBox_Latency.AddItem(new ButtonBox.Item((GetLatency(2048) * 1000f).ToString("F04") + " ms", "2048"));
            buttonBox_Latency.AddItem(new ButtonBox.Item((GetLatency(1024) * 1000f).ToString("F04") + " ms", "1024"));
            buttonBox_Latency.AddItem(new ButtonBox.Item((GetLatency(512) * 1000f).ToString("F04") + " ms", "512"));
            buttonBox_Latency.AddItem(new ButtonBox.Item((GetLatency(256) * 1000f).ToString("F04") + " ms", "256"));
            buttonBox_Latency.AddItem(new ButtonBox.Item((GetLatency(128) * 1000f).ToString("F04") + " ms", "128"));
            buttonBox_Latency.AddItem(new ButtonBox.Item((GetLatency(64) * 1000f).ToString("F04") + " ms", "64"));
        }

        private float GetLatency()
        {
            return m_iShortLen / 44100f;
        }

        private float GetLatency(int nLength)
        {
            return nLength / 44100f;
        }

        private void UpdateUI()
        {
            label_CurrentLatency.Text = GlobalMessages.CURRENT_LATENCY + " : " + (GetLatency() * 1000f).ToString("F04") + " ms";
        }

        private void ButtonBox_Latency_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag) || tag == "")
                return;
            switch (tag)
            {
                case "64":
                    m_iShortLen = 64;
                    m_iMiddleLen = 2048;
                    m_iLongLen = 16384;
                    break;
                case "128":
                    m_iShortLen = 128;
                    m_iMiddleLen = 2048;
                    m_iLongLen = 8192;
                    break;
                case "256":
                    m_iShortLen = 256;
                    m_iMiddleLen = 8192;
                    m_iLongLen = 0;
                    break;
                case "512":
                    m_iShortLen = 512;
                    m_iMiddleLen = 4096;
                    m_iLongLen = 0;
                    break;
                case "1024":
                    m_iShortLen = 1024;
                    m_iMiddleLen = 2048;
                    m_iLongLen = 0;
                    break;
                case "2048":
                    m_iShortLen = 2048;
                    m_iMiddleLen = 0;
                    m_iLongLen = 0;
                    break;
                case "4096":
                    m_iShortLen = 4096;
                    m_iMiddleLen = 0;
                    m_iLongLen = 0;
                    break;
                case "8192":
                    m_iShortLen = 8192;
                    m_iMiddleLen = 0;
                    m_iLongLen = 0;
                    break;
                case "16384":
                    m_iShortLen = 16384;
                    m_iMiddleLen = 0;
                    m_iLongLen = 0;
                    break;
            }
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
