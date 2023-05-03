using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
  public class VSlider : UserControl
  {
    private const uint m_nRangeMin = 0;
    private const uint m_nRangeMax = 100;
    private bool m_bMouseDown;
    private uint m_nPosition;
    private uint m_nMoveDelta = 1;
    private IContainer components;

    private event VSlider.PositionChangeEventDelegate PositionChanged;

    public event VSlider.PositionChangeEventDelegate PositionChangeNotify
    {
      add => this.PositionChanged += value;
      remove => this.PositionChanged -= value;
    }

    public VSlider()
    {
      this.InitializeComponent();
      this.m_nPosition = 0U;
      this.m_nMoveDelta = 1U;
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.StandardClick, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.BackColor = Color.FromKnownColor(KnownColor.Control);
    }

    public uint Position
    {
      get => 100U - this.m_nPosition;
      set
      {
        if (value < 0U)
          value = 0U;
        if (value > 100U)
          value = 100U;
        this.m_nPosition = 100U - value;
        if (this.PositionChanged != null)
          this.PositionChanged((float) this.Position / 100f, this);
        this.Invalidate();
      }
    }

    public uint MoveDelta
    {
      get => this.m_nMoveDelta;
      set => this.m_nMoveDelta = value;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphics.Clear(this.BackColor);
      graphics.DrawLine(new Pen(Color.Gray, 2f), (float) this.Width / 2f, (float) this.Width / 2f, (float) this.Width / 2f, (float) this.Height - (float) this.Width / 2f);
      float num = (float) this.m_nPosition / 100f * (float) (this.Height - this.Width) + (float) this.Width / 2f;
      graphics.FillEllipse(Brushes.SteelBlue, (float) this.Width / 4f, num - (float) this.Width / 4f, (float) this.Width / 2f, (float) this.Width / 2f);
    }

    private void VSlider_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.m_bMouseDown = true;
      float num = (float) e.Y;
      if ((double) num < (double) this.Width / 2.0)
        num = (float) this.Width / 2f;
      if ((double) num > (double) this.Height - (double) this.Width / 2.0)
        num = (float) this.Height - (float) this.Width / 2f;
      this.m_nPosition = (uint) Math.Round((double) ((num - (float) this.Width / 2f) / (float) (this.Height - this.Width)) * 100.0);
      if (this.PositionChanged != null)
        this.PositionChanged((float) this.Position / 100f, this);
      this.Invalidate();
    }

    private void VSlider_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      if (this.PositionChanged != null)
        this.PositionChanged((float) this.Position / 100f, this);
      this.m_bMouseDown = false;
    }

    private void VSlider_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.m_bMouseDown)
        return;
      float num = (float) e.Y;
      if ((double) num < (double) this.Width / 2.0)
        num = (float) this.Width / 2f;
      if ((double) num > (double) this.Height - (double) this.Width / 2.0)
        num = (float) this.Height - (float) this.Width / 2f;
      this.m_nPosition = (uint) Math.Round((double) ((num - (float) this.Width / 2f) / (float) (this.Height - this.Width)) * 100.0);
      if (this.PositionChanged != null)
        this.PositionChanged((float) this.Position / 100f, this);
      this.Invalidate();
    }

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
      this.BackColor = SystemColors.Control;
      this.DoubleBuffered = true;
      this.Name = nameof (VSlider);
      this.Size = new Size(47, 204);
      this.MouseDown += new MouseEventHandler(this.VSlider_MouseDown);
      this.MouseMove += new MouseEventHandler(this.VSlider_MouseMove);
      this.MouseUp += new MouseEventHandler(this.VSlider_MouseUp);
      this.ResumeLayout(false);
    }

    public delegate void PositionChangeEventDelegate(float fPercent, VSlider objSender);
  }
}
