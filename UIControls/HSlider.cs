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
        private readonly IContainer components;

        private event PositionChangeEventDelegate PositionChanged;

        public event PositionChangeEventDelegate PositionChangeNotify
        {
            add => PositionChanged += value;
            remove => PositionChanged -= value;
        }

        public HSlider()
        {
            InitializeComponent();
            m_nPosition = 0U;
            m_nMoveDelta = 1U;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        public uint Position
        {
            get => m_nPosition;
            set
            {
                if (value < 0U)
                    value = 0U;
                if (value > 100U)
                    value = 100U;
                m_nPosition = value;
                PositionChanged?.Invoke(Position / 100f, this);
                Invalidate();
            }
        }

        public float PositionFloat
        {
            get => m_nPosition / 100f;
            set
            {
                uint num = (uint)((double)value * 100.0);
                if (num < 0U)
                    num = 0U;
                if (num > 100U)
                    num = 100U;
                m_nPosition = num;
                PositionChanged?.Invoke(Position / 100f, this);
                Invalidate();
            }
        }

        public uint MoveDelta
        {
            get => m_nMoveDelta;
            set => m_nMoveDelta = value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.Clear(BackColor);
            graphics.DrawLine(new Pen(Color.Gray, 2f), Height / 2f, Height / 2f, Width - Height / 2f, Height / 2f);
            float num = m_nPosition / 100f * (Width - Height) + Height / 2f;
            graphics.FillEllipse(Brushes.SteelBlue, num - Height / 4f, Height / 4f, Height / 2f, Height / 2f);
        }

        private void HSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            m_bMouseDown = true;
            float num = e.X;
            if ((double)num < Height / 2.0)
                num = Height / 2f;
            if ((double)num > Width - Height / 2.0)
                num = Width - Height / 2f;
            m_nPosition = (uint)Math.Round((double)((num - Height / 2f) / (Width - Height)) * 100.0);
            PositionChanged?.Invoke(Position / 100f, this);
            Invalidate();
        }

        private void HSlider_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            PositionChanged?.Invoke(Position / 100f, this);
            m_bMouseDown = false;
        }

        private void HSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_bMouseDown)
                return;
            float num = e.X;
            if ((double)num < Height / 2.0)
                num = Height / 2f;
            if ((double)num > Width - Height / 2.0)
                num = Width - Height / 2f;
            m_nPosition = (uint)Math.Round((double)((num - Height / 2f) / (Width - Height)) * 100.0);
            PositionChanged?.Invoke(Position / 100f, this);
            Invalidate();
        }

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
            Name = nameof(HSlider);
            Size = new Size(204, 47);
            MouseDown += new MouseEventHandler(HSlider_MouseDown);
            MouseMove += new MouseEventHandler(HSlider_MouseMove);
            MouseUp += new MouseEventHandler(HSlider_MouseUp);
            ResumeLayout(false);
        }

        public delegate void PositionChangeEventDelegate(float fPercent, HSlider objSender);
    }
}
