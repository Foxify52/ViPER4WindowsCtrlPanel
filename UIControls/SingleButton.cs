using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
    public class SingleButton : UserControl
    {
        private readonly IContainer components;
        private bool m_bMouseDown;
        private string m_szButtonText = "";

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
            Name = nameof(SingleButton);
            Size = new Size(112, 40);
            KeyUp += new KeyEventHandler(SingleButton_KeyUp);
            MouseDown += new MouseEventHandler(SingleButton_MouseDown);
            MouseUp += new MouseEventHandler(SingleButton_MouseUp);
            ResumeLayout(false);
        }

        private event ButtonClickEventDelegate ButtonClick;

        public event ButtonClickEventDelegate ButtonClickNotify
        {
            add => ButtonClick += value;
            remove => ButtonClick -= value;
        }

        public SingleButton()
        {
            InitializeComponent();
            m_bMouseDown = false;
            m_szButtonText = "";
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        public string ButtonText
        {
            get => m_szButtonText;
            set
            {
                m_szButtonText = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(BackColor);
            graphics.DrawRectangle(new Pen(Color.Gray, 2f), ClientRectangle);
            Brush brush = Brushes.Black;
            if (m_bMouseDown)
                brush = Brushes.SteelBlue;
            Font font = Font;
            graphics.DrawString(m_szButtonText, font, brush, new RectangleF()
            {
                X = 3f,
                Y = 5f,
                Width = Width - 6f,
                Height = Height - 6f
            }, new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            });
        }

        private void SingleButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            m_bMouseDown = true;
            Invalidate();
        }

        private void SingleButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            m_bMouseDown = false;
            Invalidate();
            if (ButtonClick == null)
                return;
            ButtonClick(this);
        }

        private void SingleButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Space || ButtonClick == null)
                return;
            ButtonClick(this);
        }

        public delegate void ButtonClickEventDelegate(SingleButton objSender);
    }
}
