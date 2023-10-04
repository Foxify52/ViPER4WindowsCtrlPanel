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
        private readonly IContainer components;

        private event PositionChangeEventDelegate PositionChanged;

        public event PositionChangeEventDelegate PositionChangeNotify
        {
            add => PositionChanged += value;
            remove => PositionChanged -= value;
        }

        public VSlider()
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
            get => 100U - m_nPosition;
            set
            {
                if (value < 0U)
                    value = 0U;
                if (value > 100U)
                    value = 100U;
                m_nPosition = 100U - value;
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
            graphics.DrawLine(new Pen(Color.Gray, 2f), Width / 2f, Width / 2f, Width / 2f, Height - Width / 2f);
            float num = m_nPosition / 100f * (Height - Width) + Width / 2f;
            graphics.FillEllipse(Brushes.SteelBlue, Width / 4f, num - Width / 4f, Width / 2f, Width / 2f);
        }

        private void VSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            m_bMouseDown = true;
            float num = e.Y;
            if ((double)num < Width / 2.0)
                num = Width / 2f;
            if ((double)num > Height - Width / 2.0)
                num = Height - Width / 2f;
            m_nPosition = (uint)Math.Round((double)((num - Width / 2f) / (Height - Width)) * 100.0);
            PositionChanged?.Invoke(Position / 100f, this);
            Invalidate();
        }

        private void VSlider_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            PositionChanged?.Invoke(Position / 100f, this);
            m_bMouseDown = false;
        }

        private void VSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_bMouseDown)
                return;
            float num = e.Y;
            if ((double)num < Width / 2.0)
                num = Width / 2f;
            if ((double)num > Height - Width / 2.0)
                num = Height - Width / 2f;
            m_nPosition = (uint)Math.Round((double)((num - Width / 2f) / (Height - Width)) * 100.0);
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
            BackColor = SystemColors.Control;
            DoubleBuffered = true;
            Name = nameof(VSlider);
            Size = new Size(47, 204);
            MouseDown += new MouseEventHandler(VSlider_MouseDown);
            MouseMove += new MouseEventHandler(VSlider_MouseMove);
            MouseUp += new MouseEventHandler(VSlider_MouseUp);
            ResumeLayout(false);
        }

        public delegate void PositionChangeEventDelegate(float fPercent, VSlider objSender);
    }
}
