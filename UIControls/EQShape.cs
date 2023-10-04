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
        private readonly IContainer components;
        private Color m_clBackColor = Color.White;
        private Color m_clForeColor = Color.Black;
        private readonly float[] m_fEQBands = new float[18];
        private readonly float[] m_fEQResponse = new float[256];

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            DoubleBuffered = true;
            Name = "EQShapre";
            Size = new Size(274, 129);
            ResumeLayout(false);
        }

        public EQShape()
        {
            InitializeComponent();
            for (int index = 0; index < m_fEQBands.Length; ++index)
                m_fEQBands[index] = 1f;
            ZeroArray();
            float[] fArray = RuntimeUtils.EqualizerUtils.EstimateEqualizerResponse(m_fEQBands);
            if (fArray != null)
                ScaleArray(fArray);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        public Color ShapeBackColor
        {
            get => m_clBackColor;
            set
            {
                m_clBackColor = value;
                Invalidate();
            }
        }

        public Color ShapeForeColor
        {
            get => m_clForeColor;
            set
            {
                m_clForeColor = value;
                Invalidate();
            }
        }

        public void SetEqualizerBands(float[] rEQBands)
        {
            if (rEQBands == null || rEQBands.Length != 18)
                return;
            Array.Copy(rEQBands, m_fEQBands, m_fEQBands.Length);
            ZeroArray();
            float[] fArray = RuntimeUtils.EqualizerUtils.EstimateEqualizerResponse(m_fEQBands);
            if (fArray != null)
                ScaleArray(fArray);
            Invalidate();
        }

        private void ZeroArray()
        {
            for (int index = 0; index < m_fEQResponse.Length; ++index)
                m_fEQResponse[index] = 0.0f;
        }

        private void ScaleArray(float[] fArray)
        {
            int num = fArray.Length / (m_fEQResponse.Length + 1);
            int index1 = 0;
            for (int index2 = 0; index1 < fArray.Length && index2 < m_fEQResponse.Length; ++index2)
            {
                m_fEQResponse[index2] = fArray[index1];
                index1 += num;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.Clear(m_clBackColor);
            graphics.DrawRectangle(new Pen(Color.Gray, 1f), ClientRectangle);
            double num1 = (Width - 2.0) / (m_fEQResponse.Length + 1);
            float num2 = (float)(m_fEQResponse[0] * (double)(Height - 2) + 1.0);
            if ((double)num2 < 2.0)
                num2 = 2f;
            if ((double)num2 > Height - 2.0)
                num2 = Height - 2f;
            PointF pt1 = new PointF(2f, Height - num2);
            for (int index = 1; index < m_fEQResponse.Length; ++index)
            {
                float x = index * (float)num1 + 2f;
                if ((double)x > Width - 1.0)
                    break;
                float num3 = (float)(m_fEQResponse[index] * (double)(Height - 2) + 1.0);
                if ((double)num3 < 2.0)
                    num3 = 2f;
                if ((double)num3 > Height - 2.0)
                    num3 = Height - 2f;
                float y = Height - num3;
                graphics.DrawLine(new Pen(m_clForeColor, 1f), pt1, new PointF(x, y));
                pt1.X = x;
                pt1.Y = y;
            }
        }
    }
}
