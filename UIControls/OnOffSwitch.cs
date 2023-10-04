using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
    public class OnOffSwitch : UserControl
    {
        private readonly IContainer components;
        private bool m_bSwitchStatus;

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
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Name = nameof(OnOffSwitch);
            Size = new Size(107, 28);
            KeyUp += new KeyEventHandler(OnOffSwitch_KeyUp);
            MouseUp += new MouseEventHandler(OnOffSwitch_MouseUp);
            ResumeLayout(false);
        }

        private event SwitchChangeEventDelegate SwitchChanged;

        public event SwitchChangeEventDelegate SwitchChangeNotify
        {
            add => SwitchChanged += value;
            remove => SwitchChanged -= value;
        }

        public OnOffSwitch()
        {
            InitializeComponent();
            m_bSwitchStatus = false;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
        }

        public bool SwitchedOn
        {
            get => m_bSwitchStatus;
            set
            {
                m_bSwitchStatus = value;
                SwitchChanged?.Invoke(m_bSwitchStatus, this);
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.Clear(Color.White);
            graphics.DrawRectangle(new Pen(Color.Gray, 1f), 0, 0, Width, Height);
            if (m_bSwitchStatus)
                graphics.FillRectangle(Brushes.SteelBlue, (float)(Width / 2.0 + 6.0), 2f, (float)(Width / 2.0 - 8.0), Height - 4f);
            else
                graphics.FillRectangle(Brushes.Gray, 2f, 2f, (float)(Width / 2.0 - 8.0), Height - 4f);
        }

        private void OnOffSwitch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space && e.KeyCode != Keys.Return)
                return;
            m_bSwitchStatus = !m_bSwitchStatus;
            SwitchChanged?.Invoke(m_bSwitchStatus, this);
            Invalidate();
        }

        private void OnOffSwitch_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            m_bSwitchStatus = !m_bSwitchStatus;
            SwitchChanged?.Invoke(m_bSwitchStatus, this);
            Invalidate();
        }

        public delegate void SwitchChangeEventDelegate(bool bSwitchedOn, OnOffSwitch objSender);
    }
}
