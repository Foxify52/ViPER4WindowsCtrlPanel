using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
  public class SingleButton : UserControl
  {
    private IContainer components;
    private bool m_bMouseDown;
    private string m_szButtonText = "";

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
      this.Name = nameof (SingleButton);
      this.Size = new Size(112, 40);
      this.KeyUp += new KeyEventHandler(this.SingleButton_KeyUp);
      this.MouseDown += new MouseEventHandler(this.SingleButton_MouseDown);
      this.MouseUp += new MouseEventHandler(this.SingleButton_MouseUp);
      this.ResumeLayout(false);
    }

    private event SingleButton.ButtonClickEventDelegate ButtonClick;

    public event SingleButton.ButtonClickEventDelegate ButtonClickNotify
    {
      add => this.ButtonClick += value;
      remove => this.ButtonClick -= value;
    }

    public SingleButton()
    {
      this.InitializeComponent();
      this.m_bMouseDown = false;
      this.m_szButtonText = "";
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.StandardClick, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.BackColor = Color.FromKnownColor(KnownColor.Control);
    }

    public string ButtonText
    {
      get => this.m_szButtonText;
      set
      {
        this.m_szButtonText = value;
        this.Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
      graphics.Clear(this.BackColor);
      graphics.DrawRectangle(new Pen(Color.Gray, 2f), this.ClientRectangle);
      Brush brush = Brushes.Black;
      if (this.m_bMouseDown)
        brush = Brushes.SteelBlue;
      Font font = this.Font;
      graphics.DrawString(this.m_szButtonText, font, brush, new RectangleF()
      {
        X = 3f,
        Y = 5f,
        Width = (float) this.Width - 6f,
        Height = (float) this.Height - 6f
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
      this.m_bMouseDown = true;
      this.Invalidate();
    }

    private void SingleButton_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.m_bMouseDown = false;
      this.Invalidate();
      if (this.ButtonClick == null)
        return;
      this.ButtonClick(this);
    }

    private void SingleButton_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Space || this.ButtonClick == null)
        return;
      this.ButtonClick(this);
    }

    public delegate void ButtonClickEventDelegate(SingleButton objSender);
  }
}
