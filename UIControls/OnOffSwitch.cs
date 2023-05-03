using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
  public class OnOffSwitch : UserControl
  {
    private IContainer components;
    private bool m_bSwitchStatus;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.DoubleBuffered = true;
      this.Name = nameof (OnOffSwitch);
      this.Size = new Size(107, 28);
      this.KeyUp += new KeyEventHandler(this.OnOffSwitch_KeyUp);
      this.MouseUp += new MouseEventHandler(this.OnOffSwitch_MouseUp);
      this.ResumeLayout(false);
    }

    private event OnOffSwitch.SwitchChangeEventDelegate SwitchChanged;

    public event OnOffSwitch.SwitchChangeEventDelegate SwitchChangeNotify
    {
      add => this.SwitchChanged += value;
      remove => this.SwitchChanged -= value;
    }

    public OnOffSwitch()
    {
      this.InitializeComponent();
      this.m_bSwitchStatus = false;
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.StandardClick, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.BackColor = Color.Transparent;
    }

    public bool SwitchedOn
    {
      get => this.m_bSwitchStatus;
      set
      {
        this.m_bSwitchStatus = value;
        if (this.SwitchChanged != null)
          this.SwitchChanged(this.m_bSwitchStatus, this);
        this.Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphics.Clear(Color.White);
      graphics.DrawRectangle(new Pen(Color.Gray, 1f), 0, 0, this.Width, this.Height);
      if (this.m_bSwitchStatus)
        graphics.FillRectangle(Brushes.SteelBlue, (float) ((double) this.Width / 2.0 + 6.0), 2f, (float) ((double) this.Width / 2.0 - 8.0), (float) this.Height - 4f);
      else
        graphics.FillRectangle(Brushes.Gray, 2f, 2f, (float) ((double) this.Width / 2.0 - 8.0), (float) this.Height - 4f);
    }

    private void OnOffSwitch_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Space && e.KeyCode != Keys.Return)
        return;
      this.m_bSwitchStatus = !this.m_bSwitchStatus;
      if (this.SwitchChanged != null)
        this.SwitchChanged(this.m_bSwitchStatus, this);
      this.Invalidate();
    }

    private void OnOffSwitch_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.m_bSwitchStatus = !this.m_bSwitchStatus;
      if (this.SwitchChanged != null)
        this.SwitchChanged(this.m_bSwitchStatus, this);
      this.Invalidate();
    }

    public delegate void SwitchChangeEventDelegate(bool bSwitchedOn, OnOffSwitch objSender);
  }
}
