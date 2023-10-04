using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
    public class OpenFileBox : UserControl
    {
        private readonly IContainer components;
        private readonly OpenFileDialog m_ofdDialog = new OpenFileDialog();
        private string m_szFilePathName = "";

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
            Name = nameof(OpenFileBox);
            Size = new Size(147, 36);
            Click += new EventHandler(OpenFileBox_Click);
            ResumeLayout(false);
        }

        private event FileChangeEventDelegate FileChanged;

        public event FileChangeEventDelegate FileChangeNotify
        {
            add => FileChanged += value;
            remove => FileChanged -= value;
        }

        public OpenFileBox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        public string FilePathName
        {
            get => m_szFilePathName;
            set
            {
                m_szFilePathName = value;
                FileChanged?.Invoke(m_szFilePathName, this);
                Invalidate();
            }
        }

        public string DialogTitle
        {
            set => m_ofdDialog.Title = value;
        }

        public string OpenDirectory
        {
            set => m_ofdDialog.InitialDirectory = value;
        }

        public string FileFilter
        {
            set => m_ofdDialog.Filter = value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(BackColor);
            graphics.DrawRectangle(new Pen(Color.Gray, 1f), 0.0f, 0.0f, Width, Height);
            graphics.FillRectangle(Brushes.SteelBlue, Width - 27f, 2f, 25f, Height - 4f);
            float x = Width - 14.5f;
            float num1 = Height / 2f;
            PointF pointF1 = new PointF(x - 4f, num1 - 4f);
            PointF pointF2 = new PointF(x + 4f, num1 - 4f);
            PointF pointF3 = new PointF(x, num1 + 4f);
            graphics.FillPolygon(Brushes.Black, new PointF[3]
            {
        pointF1,
        pointF2,
        pointF3
            });
            string s;
            if (m_szFilePathName.Length <= 0)
            {
                s = "";
            }
            else
            {
                int num2 = m_szFilePathName.LastIndexOf("\\");
                if (num2 > 0)
                {
                    string str = m_szFilePathName.Substring(num2 + 1, m_szFilePathName.Length - num2 - 1);
                    s = str.Length <= 0 ? "" : str;
                }
                else
                    s = "";
            }
            Font font = Font;
            graphics.DrawString(s, font, Brushes.Black, new RectangleF()
            {
                X = 2f,
                Y = 2f,
                Width = Width - 35f,
                Height = Height - 4f
            }, new StringFormat()
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            });
        }

        private void OpenFileBox_Click(object sender, EventArgs e)
        {
            if (m_ofdDialog.ShowDialog() == DialogResult.Cancel)
                return;
            m_szFilePathName = m_ofdDialog.FileName;
            FileChanged?.Invoke(m_szFilePathName, this);
            Invalidate();
        }

        public delegate void FileChangeEventDelegate(string szFilePathName, OpenFileBox objSender);
    }
}
