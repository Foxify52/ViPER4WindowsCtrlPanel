using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin.UIControls
{
  public class EQShape : UserControl
  {
    private IContainer components;
    private Color m_clBackColor = Color.White;
    private Color m_clForeColor = Color.Black;
    private float[] m_fEQBands = new float[18];
    private float[] m_fEQResponse = new float[256];

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
      this.Name = "EQShapre";
      this.Size = new Size(274, 129);
      this.ResumeLayout(false);
    }

    public EQShape()
    {
      this.InitializeComponent();
      for (int index = 0; index < this.m_fEQBands.Length; ++index)
        this.m_fEQBands[index] = 1f;
      this.ZeroArray();
      float[] fArray = RuntimeUtils.EqualizerUtils.EstimateEqualizerResponse(this.m_fEQBands);
      if (fArray != null)
        this.ScaleArray(fArray);
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

    public void SetEqualizerBands(float[] rEQBands)
    {
      if (rEQBands == null || rEQBands.Length != 18)
        return;
      Array.Copy((Array) rEQBands, (Array) this.m_fEQBands, this.m_fEQBands.Length);
      this.ZeroArray();
      float[] fArray = RuntimeUtils.EqualizerUtils.EstimateEqualizerResponse(this.m_fEQBands);
      if (fArray != null)
        this.ScaleArray(fArray);
      this.Invalidate();
    }

    private void ZeroArray()
    {
      for (int index = 0; index < this.m_fEQResponse.Length; ++index)
        this.m_fEQResponse[index] = 0.0f;
    }

    private void ScaleArray(float[] fArray)
    {
      int num = fArray.Length / (this.m_fEQResponse.Length + 1);
      int index1 = 0;
      for (int index2 = 0; index1 < fArray.Length && index2 < this.m_fEQResponse.Length; ++index2)
      {
        this.m_fEQResponse[index2] = fArray[index1];
        index1 += num;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphics.Clear(this.m_clBackColor);
      graphics.DrawRectangle(new Pen(Color.Gray, 1f), this.ClientRectangle);
      double num1 = ((double) this.Width - 2.0) / (double) (this.m_fEQResponse.Length + 1);
      float num2 = (float) ((double) this.m_fEQResponse[0] * (double) (this.Height - 2) + 1.0);
      if ((double) num2 < 2.0)
        num2 = 2f;
      if ((double) num2 > (double) this.Height - 2.0)
        num2 = (float) this.Height - 2f;
      PointF pt1 = new PointF(2f, (float) this.Height - num2);
      for (int index = 1; index < this.m_fEQResponse.Length; ++index)
      {
        float x = (float) index * (float) num1 + 2f;
        if ((double) x > (double) this.Width - 1.0)
          break;
        float num3 = (float) ((double) this.m_fEQResponse[index] * (double) (this.Height - 2) + 1.0);
        if ((double) num3 < 2.0)
          num3 = 2f;
        if ((double) num3 > (double) this.Height - 2.0)
          num3 = (float) this.Height - 2f;
        float y = (float) this.Height - num3;
        graphics.DrawLine(new Pen(this.m_clForeColor, 1f), pt1, new PointF(x, y));
        pt1.X = x;
        pt1.Y = y;
      }
    }
  }
}
