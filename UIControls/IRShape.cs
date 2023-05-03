using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
  public class IRShape : UserControl
  {
    private IContainer components;
    private Color m_clBackColor = Color.White;
    private Color m_clForeColor = Color.Black;
    private float[] m_fIRSamples = new float[256];

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
      this.Name = nameof (IRShape);
      this.Size = new Size(190, 63);
      this.ResumeLayout(false);
    }

    public IRShape()
    {
      this.InitializeComponent();
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
    }

    public Color ShapeBackColor
    {
      get => this.m_clBackColor;
      set
      {
        this.m_clBackColor = value;
        this.Invalidate();
      }
    }

    public Color ShapeForeColor
    {
      get => this.m_clForeColor;
      set
      {
        this.m_clForeColor = value;
        this.Invalidate();
      }
    }

    public void SetImpulseResponse(float[] fIRSamples, int nChannels)
    {
      this.ZeroArray();
      if (fIRSamples == null || nChannels <= 0)
      {
        this.Invalidate();
      }
      else
      {
        int length = fIRSamples.Length / nChannels;
        if (length <= 0)
        {
          this.Invalidate();
        }
        else
        {
          float[] fArray = new float[length];
          int num1 = 0;
          int index1 = 0;
          while (num1 < length * nChannels)
          {
            double num2 = 0.0;
            for (int index2 = 0; index2 < nChannels; ++index2)
              num2 += (double) fIRSamples[num1 + index2];
            double num3 = num2 / (double) nChannels;
            fArray[index1] = (float) num3;
            num1 += nChannels;
            ++index1;
          }
          this.ScaleArray(fArray);
          this.Invalidate();
        }
      }
    }

    private void ZeroArray()
    {
      for (int index = 0; index < this.m_fIRSamples.Length; ++index)
        this.m_fIRSamples[index] = 0.0f;
    }

    private void ScaleArray(float[] fArray)
    {
      int num1 = fArray.Length / (this.m_fIRSamples.Length + 1);
      float num2 = 0.0f;
      int index1 = 0;
      for (int index2 = 0; index1 < fArray.Length && index2 < this.m_fIRSamples.Length; ++index2)
      {
        this.m_fIRSamples[index2] = fArray[index1];
        if ((double) Math.Abs(this.m_fIRSamples[index2]) > (double) num2)
          num2 = Math.Abs(this.m_fIRSamples[index2]);
        index1 += num1;
      }
      if ((double) num2 <= 9.9999999747524271E-07)
        return;
      float num3 = (float) (1.0 / ((double) num2 + 9.9999999747524271E-07));
      for (int index3 = 0; index3 < this.m_fIRSamples.Length; ++index3)
        this.m_fIRSamples[index3] *= num3;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphics.Clear(this.m_clBackColor);
      graphics.DrawRectangle(new Pen(Color.Gray, 1f), this.ClientRectangle);
      double num1 = ((double) this.Width - 2.0) / (double) (this.m_fIRSamples.Length + 1);
      PointF pt1 = new PointF(2f, (float) this.Height / 2f);
      for (int index = 0; index < this.m_fIRSamples.Length; ++index)
      {
        float x = (float) index * (float) num1 + 2f;
        if ((double) x > (double) this.Width - 1.0)
          break;
        float num2 = (float) this.Height / 2f + this.m_fIRSamples[index] * ((float) (this.Height - 2) / 2f);
        if ((double) num2 < 2.0)
          num2 = 2f;
        if ((double) num2 > (double) this.Height - 2.0)
          num2 = (float) this.Height - 2f;
        float y = (float) this.Height - num2;
        graphics.DrawLine(new Pen(this.m_clForeColor, 1f), pt1, new PointF(x, y));
        pt1.X = x;
        pt1.Y = y;
      }
    }
  }
}
