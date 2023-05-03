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
    private IContainer components;
    private OpenFileDialog m_ofdDialog = new OpenFileDialog();
    private string m_szFilePathName = "";

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
      this.Name = nameof (OpenFileBox);
      this.Size = new Size(147, 36);
      this.Click += new EventHandler(this.OpenFileBox_Click);
      this.ResumeLayout(false);
    }

    private event OpenFileBox.FileChangeEventDelegate FileChanged;

    public event OpenFileBox.FileChangeEventDelegate FileChangeNotify
    {
      add => this.FileChanged += value;
      remove => this.FileChanged -= value;
    }

    public OpenFileBox()
    {
      this.InitializeComponent();
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.StandardClick, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.BackColor = Color.FromKnownColor(KnownColor.Control);
    }

    public string FilePathName
    {
      get => this.m_szFilePathName;
      set
      {
        this.m_szFilePathName = value;
        if (this.FileChanged != null)
          this.FileChanged(this.m_szFilePathName, this);
        this.Invalidate();
      }
    }

    public string DialogTitle
    {
      set => this.m_ofdDialog.Title = value;
    }

    public string OpenDirectory
    {
      set => this.m_ofdDialog.InitialDirectory = value;
    }

    public string FileFilter
    {
      set => this.m_ofdDialog.Filter = value;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
      graphics.Clear(this.BackColor);
      graphics.DrawRectangle(new Pen(Color.Gray, 1f), 0.0f, 0.0f, (float) this.Width, (float) this.Height);
      graphics.FillRectangle(Brushes.SteelBlue, (float) this.Width - 27f, 2f, 25f, (float) this.Height - 4f);
      float x = (float) this.Width - 14.5f;
      float num1 = (float) this.Height / 2f;
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
      if (this.m_szFilePathName.Length <= 0)
      {
        s = "";
      }
      else
      {
        int num2 = this.m_szFilePathName.LastIndexOf("\\");
        if (num2 > 0)
        {
          string str = this.m_szFilePathName.Substring(num2 + 1, this.m_szFilePathName.Length - num2 - 1);
          s = str.Length <= 0 ? "" : str;
        }
        else
          s = "";
      }
      Font font = this.Font;
      graphics.DrawString(s, font, Brushes.Black, new RectangleF()
      {
        X = 2f,
        Y = 2f,
        Width = (float) this.Width - 35f,
        Height = (float) this.Height - 4f
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
      if (this.m_ofdDialog.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_szFilePathName = this.m_ofdDialog.FileName;
      if (this.FileChanged != null)
        this.FileChanged(this.m_szFilePathName, this);
      this.Invalidate();
    }

    public delegate void FileChangeEventDelegate(string szFilePathName, OpenFileBox objSender);
  }
}
