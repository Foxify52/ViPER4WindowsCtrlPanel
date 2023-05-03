using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
  public class frmChannelPan : Form
  {
    private float m_rChannelPan;
    private IContainer components;
    private Label label_Left;
    private Label label_Right;
    private HSlider hSlider_Pan;
    private SingleButton singleButton_Center;
    private Label label_Value;

    public float ChannelPan
    {
      get => this.m_rChannelPan;
      set
      {
        this.m_rChannelPan = value;
        this.hSlider_Pan.PositionFloat = (float) ((double) this.m_rChannelPan * 0.5 + 0.5);
      }
    }

    public frmChannelPan()
    {
      this.InitializeComponent();
      this.Text = GlobalMessages.CHANNEL_PAN;
      this.label_Left.Text = GlobalMessages.LEFT;
      this.label_Right.Text = GlobalMessages.RIGHT;
      this.singleButton_Center.ButtonText = GlobalMessages.BALANCE;
    }

    private void hSlider_Pan_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_rChannelPan = (float) (((double) fPercent - 0.5) * 2.0);
      this.label_Value.Text = this.m_rChannelPan.ToString("F01");
    }

    private void singleButton_Center_ButtonClickNotify(SingleButton objSender)
    {
      this.m_rChannelPan = 0.0f;
      this.hSlider_Pan.Position = 50U;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmChannelPan));
      this.label_Left = new Label();
      this.label_Right = new Label();
      this.hSlider_Pan = new HSlider();
      this.singleButton_Center = new SingleButton();
      this.label_Value = new Label();
      this.SuspendLayout();
      this.label_Left.AutoSize = true;
      this.label_Left.Location = new Point(48, 9);
      this.label_Left.Name = "label_Left";
      this.label_Left.Size = new Size(35, 12);
      this.label_Left.TabIndex = 0;
      this.label_Left.Text = "$LEFT";
      this.label_Right.AutoSize = true;
      this.label_Right.Location = new Point(386, 9);
      this.label_Right.Name = "label_Right";
      this.label_Right.Size = new Size(41, 12);
      this.label_Right.TabIndex = 1;
      this.label_Right.Text = "$RIGHT";
      this.hSlider_Pan.BackColor = SystemColors.Control;
      this.hSlider_Pan.Location = new Point(24, 29);
      this.hSlider_Pan.MoveDelta = 1U;
      this.hSlider_Pan.Name = "hSlider_Pan";
      this.hSlider_Pan.Position = 50U;
      this.hSlider_Pan.PositionFloat = 0.5f;
      this.hSlider_Pan.Size = new Size(403, 47);
      this.hSlider_Pan.TabIndex = 2;
      this.hSlider_Pan.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.hSlider_Pan_PositionChangeNotify);
      this.singleButton_Center.BackColor = SystemColors.Control;
      this.singleButton_Center.ButtonText = "$BALANCE";
      this.singleButton_Center.Location = new Point(172, 84);
      this.singleButton_Center.Name = "singleButton_Center";
      this.singleButton_Center.Size = new Size(112, 40);
      this.singleButton_Center.TabIndex = 3;
      this.singleButton_Center.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_Center_ButtonClickNotify);
      this.label_Value.Location = new Point(170, 9);
      this.label_Value.Name = "label_Value";
      this.label_Value.Size = new Size(114, 17);
      this.label_Value.TabIndex = 4;
      this.label_Value.Text = "0.0";
      this.label_Value.TextAlign = ContentAlignment.TopCenter;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(456, 140);
      this.Controls.Add((Control) this.label_Value);
      this.Controls.Add((Control) this.singleButton_Center);
      this.Controls.Add((Control) this.hSlider_Pan);
      this.Controls.Add((Control) this.label_Right);
      this.Controls.Add((Control) this.label_Left);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmChannelPan);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "$CHANNEL_PAN";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
