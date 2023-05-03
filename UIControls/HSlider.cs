using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
  public class HSlider : UserControl
  {
    private const uint m_nRangeMin = 0;
    private const uint m_nRangeMax = 100;
    private bool m_bMouseDown;
    private uint m_nPosition;
    private uint m_nMoveDelta = 1;
    private IContainer components;

    private event HSlider.PositionChangeEventDelegate PositionChanged;

    public event HSlider.PositionChangeEventDelegate PositionChangeNotify
    {
      add => this.PositionChanged += value;
      remove => this.PositionChanged -= value;
    }

    public HSlider()
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
      get => this.m_nPosition;
      set
      {
        if (value < 0U)
          value = 0U;
        if (value > 100U)
          value = 100U;
        this.m_nPosition = value;
        if (this.PositionChanged != null)
          this.PositionChanged((float) this.Position / 100f, this);
        this.Invalidate();
      }
    }

    public float PositionFloat
    {
      get => (float) this.m_nPosition / 100f;
      set
      {
        uint num = (uint) ((double) value * 100.0);
        if (num < 0U)
          num = 0U;
        if (num > 100U)
          num = 100U;
        this.m_nPosition = num;
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
      graphics.DrawLine(new Pen(Color.Gray, 2f), (float) this.Height / 2f, (float) this.Height / 2f, (float) this.Width - (float) this.Height / 2f, (float) this.Height / 2f);
      float num = (float) this.m_nPosition / 100f * (float) (this.Width - this.Height) + (float) this.Height / 2f;
      graphics.FillEllipse(Brushes.SteelBlue, num - (float) this.Height / 4f, (float) this.Height / 4f, (float) this.Height / 2f, (float) this.Height / 2f);
    }

    private void HSlider_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.m_bMouseDown = true;
      float num = (float) e.X;
      if ((double) num < (double) this.Height / 2.0)
        num = (float) this.Height / 2f;
      if ((double) num > (double) this.Width - (double) this.Height / 2.0)
        num = (float) this.Width - (float) this.Height / 2f;
      this.m_nPosition = (uint) Math.Round((double) ((num - (float) this.Height / 2f) / (float) (this.Width - this.Height)) * 100.0);
      if (this.PositionChanged != null)
        this.PositionChanged((float) this.Position / 100f, this);
      this.Invalidate();
    }

    private void HSlider_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      if (this.PositionChanged != null)
        this.PositionChanged((float) this.Position / 100f, this);
      this.m_bMouseDown = false;
    }

    private void HSlider_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.m_bMouseDown)
        return;
      float num = (float) e.X;
      if ((double) num < (double) this.Height / 2.0)
        num = (float) this.Height / 2f;
      if ((double) num > (double) this.Width - (double) this.Height / 2.0)
        num = (float) this.Width - (float) this.Height / 2f;
      this.m_nPosition = (uint) Math.Round((double) ((num - (float) this.Height / 2f) / (float) (this.Width - this.Height)) * 100.0);
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
      this.DoubleBuffered = true;
      this.Name = nameof (HSlider);
      this.Size = new Size(204, 47);
      this.MouseDown += new MouseEventHandler(this.HSlider_MouseDown);
      this.MouseMove += new MouseEventHandler(this.HSlider_MouseMove);
      this.MouseUp += new MouseEventHandler(this.HSlider_MouseUp);
      this.ResumeLayout(false);
    }

    public delegate void PositionChangeEventDelegate(float fPercent, HSlider objSender);
  }
}
