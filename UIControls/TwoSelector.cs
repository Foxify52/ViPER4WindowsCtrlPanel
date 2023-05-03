using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
  public class TwoSelector : UserControl
  {
    private object m_objLeftObj;
    private object m_objRightObj;
    private TwoSelector.SelectorPosition m_spCurrentPosition;
    private IContainer components;

    private event TwoSelector.SelectorChangeEventDelegate SelectorChanged;

    public event TwoSelector.SelectorChangeEventDelegate SelectorChangeNotify
    {
      add => this.SelectorChanged += value;
      remove => this.SelectorChanged -= value;
    }

    public TwoSelector()
    {
      this.InitializeComponent();
      this.m_objLeftObj = (object) null;
      this.m_objRightObj = (object) null;
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.StandardClick, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.BackColor = Color.Transparent;
    }

    public object LeftObject
    {
      get => this.m_objLeftObj;
      set => this.m_objLeftObj = value;
    }

    public object RightObject
    {
      get => this.m_objRightObj;
      set => this.m_objRightObj = value;
    }

    public object CurrentObject
    {
      get => this.m_spCurrentPosition == TwoSelector.SelectorPosition.SELECTOR_ON_LEFT ? this.m_objLeftObj : this.m_objRightObj;
      set
      {
        if (this.m_objLeftObj == this.m_objRightObj)
          return;
        if (value == this.m_objLeftObj)
        {
          this.m_spCurrentPosition = TwoSelector.SelectorPosition.SELECTOR_ON_LEFT;
          if (this.SelectorChanged != null)
            this.SelectorChanged(this.m_spCurrentPosition, this.m_objLeftObj, this);
          this.Invalidate();
        }
        else
        {
          if (value != this.m_objRightObj)
            return;
          this.m_spCurrentPosition = TwoSelector.SelectorPosition.SELECTOR_ON_RIGHT;
          if (this.SelectorChanged != null)
            this.SelectorChanged(this.m_spCurrentPosition, this.m_objRightObj, this);
          this.Invalidate();
        }
      }
    }

    public TwoSelector.SelectorPosition Selector
    {
      get => this.m_spCurrentPosition;
      set
      {
        this.m_spCurrentPosition = value;
        if (this.SelectorChanged != null)
        {
          if (this.m_spCurrentPosition == TwoSelector.SelectorPosition.SELECTOR_ON_LEFT)
            this.SelectorChanged(this.m_spCurrentPosition, this.m_objLeftObj, this);
          else
            this.SelectorChanged(this.m_spCurrentPosition, this.m_objRightObj, this);
        }
        this.Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphics.Clear(Color.White);
      graphics.DrawRectangle(new Pen(Color.Gray, 1f), 0, 0, this.Width, this.Height);
      if (this.m_spCurrentPosition == TwoSelector.SelectorPosition.SELECTOR_ON_LEFT)
        graphics.FillEllipse(Brushes.SteelBlue, new RectangleF()
        {
          X = 2f,
          Y = 2f,
          Width = (float) this.ClientRectangle.Height - 4f,
          Height = (float) this.ClientRectangle.Height - 4f
        });
      else
        graphics.FillEllipse(Brushes.SteelBlue, new RectangleF()
        {
          X = (float) ((double) this.ClientRectangle.Width - 2.0 - ((double) this.ClientRectangle.Height - 4.0)),
          Y = 2f,
          Width = (float) this.ClientRectangle.Height - 4f,
          Height = (float) this.ClientRectangle.Height - 4f
        });
    }

    private void TwoSelector_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      if (this.m_spCurrentPosition == TwoSelector.SelectorPosition.SELECTOR_ON_LEFT)
        this.Selector = TwoSelector.SelectorPosition.SELECTOR_ON_RIGHT;
      else
        this.Selector = TwoSelector.SelectorPosition.SELECTOR_ON_LEFT;
    }

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
      this.BackColor = Color.Transparent;
      this.DoubleBuffered = true;
      this.Name = nameof (TwoSelector);
      this.Size = new Size(107, 28);
      this.MouseUp += new MouseEventHandler(this.TwoSelector_MouseUp);
      this.ResumeLayout(false);
    }

    public enum SelectorPosition
    {
      SELECTOR_ON_LEFT,
      SELECTOR_ON_RIGHT,
    }

    public delegate void SelectorChangeEventDelegate(
      TwoSelector.SelectorPosition spCurrentPosition,
      object objSelected,
      TwoSelector objSender);
  }
}
