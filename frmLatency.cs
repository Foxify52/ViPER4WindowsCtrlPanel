using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
  public class frmLatency : Form
  {
    private IContainer components;
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
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmLatency));
      this.label_CurrentLatency = new Label();
      this.label_DesiredLatency = new Label();
      this.buttonBox_Latency = new ButtonBox();
      this.label_LowLatencyNote = new Label();
      this.singleButton_OK = new SingleButton();
      this.singleButton_Cancel = new SingleButton();
      this.SuspendLayout();
      this.label_CurrentLatency.AutoSize = true;
      this.label_CurrentLatency.Location = new Point(12, 9);
      this.label_CurrentLatency.Name = "label_CurrentLatency";
      this.label_CurrentLatency.Size = new Size(137, 12);
      this.label_CurrentLatency.TabIndex = 0;
      this.label_CurrentLatency.Text = "$CURRENT_LATENCY : 0ms";
      this.label_DesiredLatency.AutoSize = true;
      this.label_DesiredLatency.Location = new Point(12, 41);
      this.label_DesiredLatency.Name = "label_DesiredLatency";
      this.label_DesiredLatency.Size = new Size(101, 12);
      this.label_DesiredLatency.TabIndex = 1;
      this.label_DesiredLatency.Text = "$DESIRED_LATENCY";
      this.buttonBox_Latency.BackColor = SystemColors.Control;
      this.buttonBox_Latency.Location = new Point(12, 74);
      this.buttonBox_Latency.Name = "buttonBox_Latency";
      this.buttonBox_Latency.Size = new Size(137, 190);
      this.buttonBox_Latency.TabIndex = 2;
      this.buttonBox_Latency.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.buttonBox_Latency_ItemSelectedNotify);
      this.label_LowLatencyNote.AutoSize = true;
      this.label_LowLatencyNote.ForeColor = Color.Red;
      this.label_LowLatencyNote.Location = new Point(12, 59);
      this.label_LowLatencyNote.Name = "label_LowLatencyNote";
      this.label_LowLatencyNote.Size = new Size(107, 12);
      this.label_LowLatencyNote.TabIndex = 3;
      this.label_LowLatencyNote.Text = "$LOW_LATENCY_NOTE";
      this.singleButton_OK.BackColor = SystemColors.Control;
      this.singleButton_OK.ButtonText = "$OK";
      this.singleButton_OK.Location = new Point(155, 182);
      this.singleButton_OK.Name = "singleButton_OK";
      this.singleButton_OK.Size = new Size(88, 38);
      this.singleButton_OK.TabIndex = 4;
      this.singleButton_OK.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_OK_ButtonClickNotify);
      this.singleButton_Cancel.BackColor = SystemColors.Control;
      this.singleButton_Cancel.ButtonText = "$CANCEL";
      this.singleButton_Cancel.Location = new Point(155, 226);
      this.singleButton_Cancel.Name = "singleButton_Cancel";
      this.singleButton_Cancel.Size = new Size(88, 38);
      this.singleButton_Cancel.TabIndex = 5;
      this.singleButton_Cancel.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Cancel_ButtonClickNotify);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(254, 279);
      this.Controls.Add((Control) this.singleButton_Cancel);
      this.Controls.Add((Control) this.singleButton_OK);
      this.Controls.Add((Control) this.label_LowLatencyNote);
      this.Controls.Add((Control) this.buttonBox_Latency);
      this.Controls.Add((Control) this.label_DesiredLatency);
      this.Controls.Add((Control) this.label_CurrentLatency);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmLatency);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$LATENCY_SETTING";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public int ShortFilterLen
    {
      get => this.m_iShortLen;
      set
      {
        this.m_iShortLen = value;
        this.UpdateUI();
      }
    }

    public int MiddleFilterLen
    {
      get => this.m_iMiddleLen;
      set
      {
        this.m_iMiddleLen = value;
        this.UpdateUI();
      }
    }

    public int LongFilterLen
    {
      get => this.m_iLongLen;
      set
      {
        this.m_iLongLen = value;
        this.UpdateUI();
      }
    }

    public frmLatency()
    {
      this.InitializeComponent();
      this.Text = GlobalMessages.LATENCY_SETTING;
      this.label_CurrentLatency.Text = GlobalMessages.CURRENT_LATENCY + " : " + (this.GetLatency() * 1000f).ToString("F04") + " ms";
      this.label_DesiredLatency.Text = GlobalMessages.DESIRED_LATENCY;
      this.label_LowLatencyNote.Text = GlobalMessages.LOW_LATENCY_NOTE;
      this.singleButton_OK.ButtonText = GlobalMessages.OK;
      this.singleButton_Cancel.ButtonText = GlobalMessages.CANCEL;
      this.buttonBox_Latency.AddItem(new ButtonBox.Item((this.GetLatency(16384) * 1000f).ToString("F04") + " ms", (object) "16384"));
      this.buttonBox_Latency.AddItem(new ButtonBox.Item((this.GetLatency(8192) * 1000f).ToString("F04") + " ms", (object) "8192"));
      this.buttonBox_Latency.AddItem(new ButtonBox.Item((this.GetLatency(4096) * 1000f).ToString("F04") + " ms", (object) "4096"));
      this.buttonBox_Latency.AddItem(new ButtonBox.Item((this.GetLatency(2048) * 1000f).ToString("F04") + " ms", (object) "2048"));
      this.buttonBox_Latency.AddItem(new ButtonBox.Item((this.GetLatency(1024) * 1000f).ToString("F04") + " ms", (object) "1024"));
      this.buttonBox_Latency.AddItem(new ButtonBox.Item((this.GetLatency(512) * 1000f).ToString("F04") + " ms", (object) "512"));
      this.buttonBox_Latency.AddItem(new ButtonBox.Item((this.GetLatency(256) * 1000f).ToString("F04") + " ms", (object) "256"));
      this.buttonBox_Latency.AddItem(new ButtonBox.Item((this.GetLatency(128) * 1000f).ToString("F04") + " ms", (object) "128"));
      this.buttonBox_Latency.AddItem(new ButtonBox.Item((this.GetLatency(64) * 1000f).ToString("F04") + " ms", (object) "64"));
    }

    private float GetLatency() => (float) this.m_iShortLen / 44100f;

    private float GetLatency(int nLength) => (float) nLength / 44100f;

    private void UpdateUI() => this.label_CurrentLatency.Text = GlobalMessages.CURRENT_LATENCY + " : " + (this.GetLatency() * 1000f).ToString("F04") + " ms";

    private void buttonBox_Latency_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag) || tag == "")
        return;
      switch (tag)
      {
        case "64":
          this.m_iShortLen = 64;
          this.m_iMiddleLen = 2048;
          this.m_iLongLen = 16384;
          break;
        case "128":
          this.m_iShortLen = 128;
          this.m_iMiddleLen = 2048;
          this.m_iLongLen = 8192;
          break;
        case "256":
          this.m_iShortLen = 256;
          this.m_iMiddleLen = 8192;
          this.m_iLongLen = 0;
          break;
        case "512":
          this.m_iShortLen = 512;
          this.m_iMiddleLen = 4096;
          this.m_iLongLen = 0;
          break;
        case "1024":
          this.m_iShortLen = 1024;
          this.m_iMiddleLen = 2048;
          this.m_iLongLen = 0;
          break;
        case "2048":
          this.m_iShortLen = 2048;
          this.m_iMiddleLen = 0;
          this.m_iLongLen = 0;
          break;
        case "4096":
          this.m_iShortLen = 4096;
          this.m_iMiddleLen = 0;
          this.m_iLongLen = 0;
          break;
        case "8192":
          this.m_iShortLen = 8192;
          this.m_iMiddleLen = 0;
          this.m_iLongLen = 0;
          break;
        case "16384":
          this.m_iShortLen = 16384;
          this.m_iMiddleLen = 0;
          this.m_iLongLen = 0;
          break;
      }
    }

    private void singleButton_OK_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.OK;

    private void singleButton_Cancel_ButtonClickNotify(SingleButton objSender) => this.DialogResult = DialogResult.Cancel;
  }
}
