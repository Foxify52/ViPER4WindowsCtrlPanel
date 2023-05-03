using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;

namespace ViPER4WindowsBin.UIControls
{
  public class ButtonBox : UserControl
  {
    private IContainer components;
    private Dictionary<int, ButtonBox.Item> m_dictItems = new Dictionary<int, ButtonBox.Item>();
    private Mutex m_dictMutex = new Mutex();
    private int m_nCurrentSelected = -1;

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
      this.Name = nameof (ButtonBox);
      this.Size = new Size(131, 45);
      this.MouseUp += new MouseEventHandler(this.ButtonBox_MouseUp);
      this.ResumeLayout(false);
    }

    private event ButtonBox.ItemSelectDelegate ItemSelected;

    public event ButtonBox.ItemSelectDelegate ItemSelectedNotify
    {
      add => this.ItemSelected += value;
      remove => this.ItemSelected -= value;
    }

    public ButtonBox()
    {
      this.InitializeComponent();
      this.m_nCurrentSelected = -1;
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.StandardClick, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.BackColor = Color.FromKnownColor(KnownColor.Control);
    }

    public void AddItem(ButtonBox.Item itButtonBoxItem)
    {
      if (itButtonBoxItem == null)
        return;
      this.m_dictMutex.WaitOne();
      this.m_dictItems.Add(this.m_dictItems.Count, itButtonBoxItem.Clone());
      this.m_dictMutex.ReleaseMutex();
      this.Invalidate();
    }

    public void AddItem(List<ButtonBox.Item> lstItem)
    {
      if (lstItem == null)
        return;
      this.m_dictMutex.WaitOne();
      foreach (ButtonBox.Item obj in lstItem)
      {
        if (obj != null)
          this.m_dictItems.Add(this.m_dictItems.Count, obj.Clone());
      }
      this.m_dictMutex.ReleaseMutex();
      this.Invalidate();
    }

    public void AddItem(ButtonBox.Item[] aryItem)
    {
      if (aryItem == null)
        return;
      this.m_dictMutex.WaitOne();
      foreach (ButtonBox.Item obj in aryItem)
      {
        if (obj != null)
          this.m_dictItems.Add(this.m_dictItems.Count, obj.Clone());
      }
      this.m_dictMutex.ReleaseMutex();
      this.Invalidate();
    }

    public void ClearItem()
    {
      ButtonBox.Item itPrevItem = (ButtonBox.Item) null;
      this.m_dictMutex.WaitOne();
      if (this.m_dictItems.ContainsKey(this.m_nCurrentSelected))
        itPrevItem = this.m_dictItems[this.m_nCurrentSelected].Clone();
      this.m_dictItems.Clear();
      this.m_dictMutex.ReleaseMutex();
      this.m_nCurrentSelected = -1;
      this.Invalidate();
      if (this.ItemSelected == null)
        return;
      this.ItemSelected(itPrevItem, (ButtonBox.Item) null, this);
    }

    public ButtonBox.Item GetItem(int nIndex)
    {
      ButtonBox.Item obj = (ButtonBox.Item) null;
      this.m_dictMutex.WaitOne();
      if (this.m_dictItems.ContainsKey(nIndex))
        obj = this.m_dictItems[nIndex].Clone();
      this.m_dictMutex.ReleaseMutex();
      return obj;
    }

    public void SelectItem(int nIndex)
    {
      ButtonBox.Item itPrevItem = (ButtonBox.Item) null;
      ButtonBox.Item itCurrItem = (ButtonBox.Item) null;
      this.m_dictMutex.WaitOne();
      if (this.m_dictItems.ContainsKey(this.m_nCurrentSelected))
        itPrevItem = this.m_dictItems[this.m_nCurrentSelected].Clone();
      if (this.m_dictItems.ContainsKey(nIndex))
      {
        itCurrItem = this.m_dictItems[nIndex].Clone();
        this.m_nCurrentSelected = nIndex;
      }
      else
        this.m_nCurrentSelected = -1;
      this.m_dictMutex.ReleaseMutex();
      this.Invalidate();
      if (this.ItemSelected == null)
        return;
      this.ItemSelected(itPrevItem, itCurrItem, this);
    }

    public void UpdateControl() => this.Invalidate();

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
      graphics.Clear(this.BackColor);
      if (this.m_dictItems.Count <= 0)
      {
        graphics.DrawRectangle(new Pen(Color.Gray, 4f), this.ClientRectangle);
      }
      else
      {
        this.m_dictMutex.WaitOne();
        int height = this.Height / this.m_dictItems.Count;
        for (int key = 0; key < this.m_dictItems.Count; ++key)
        {
          if (this.m_nCurrentSelected != key)
          {
            graphics.DrawRectangle(new Pen(Color.Gray, 2f), 0.0f, (float) (height * key) + 1f, (float) this.Width, (float) height);
            Font font = this.Font;
            graphics.DrawString(this.m_dictItems[key].Title, font, Brushes.Black, new RectangleF()
            {
              X = 20f,
              Y = (float) (height * key) + 5f,
              Width = (float) this.Width - 25f,
              Height = (float) height - 4f
            }, new StringFormat()
            {
              Alignment = StringAlignment.Near,
              LineAlignment = StringAlignment.Center,
              Trimming = StringTrimming.EllipsisCharacter,
              FormatFlags = StringFormatFlags.NoWrap
            });
          }
        }
        if (this.m_dictItems.ContainsKey(this.m_nCurrentSelected))
        {
          int nCurrentSelected = this.m_nCurrentSelected;
          graphics.DrawRectangle(new Pen(Color.SteelBlue, 2f), 0.0f, (float) (height * nCurrentSelected) + 1f, (float) this.Width, (float) height);
          PointF pt1_1 = new PointF(6f, (float) ((double) (height * nCurrentSelected) + (double) height / 2.0 - 6.0));
          PointF pt1_2 = new PointF(6f, (float) ((double) (height * nCurrentSelected) + (double) height / 2.0 + 6.0));
          PointF pt2 = new PointF(15f, (float) (height * nCurrentSelected) + (float) height / 2f);
          graphics.DrawLine(new Pen(Color.Black, 2f), pt1_1, pt2);
          graphics.DrawLine(new Pen(Color.Black, 2f), pt1_2, pt2);
          Font font = this.Font;
          graphics.DrawString(this.m_dictItems[nCurrentSelected].Title, font, Brushes.Black, new RectangleF()
          {
            X = 20f,
            Y = (float) (height * nCurrentSelected) + 5f,
            Width = (float) this.Width - 25f,
            Height = (float) height - 4f
          }, new StringFormat()
          {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center,
            Trimming = StringTrimming.EllipsisCharacter,
            FormatFlags = StringFormatFlags.NoWrap
          });
        }
        this.m_dictMutex.ReleaseMutex();
      }
    }

    private void ButtonBox_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.m_dictItems.Count <= 0)
        return;
      ButtonBox.Item itPrevItem = (ButtonBox.Item) null;
      this.m_dictMutex.WaitOne();
      float num = (float) this.Height / (float) this.m_dictItems.Count;
      if (this.m_dictItems.ContainsKey(this.m_nCurrentSelected))
        itPrevItem = this.m_dictItems[this.m_nCurrentSelected].Clone();
      this.m_dictMutex.ReleaseMutex();
      int key = (int) Math.Truncate((double) e.Y / (double) num);
      if (key < 0 || key >= this.m_dictItems.Count)
        return;
      this.m_dictMutex.WaitOne();
      if (this.m_dictItems.ContainsKey(key))
      {
        ButtonBox.Item itCurrItem = this.m_dictItems[key].Clone();
        this.m_nCurrentSelected = key;
        this.Invalidate();
        this.m_dictMutex.ReleaseMutex();
        if (this.ItemSelected == null)
          return;
        this.ItemSelected(itPrevItem, itCurrItem, this);
      }
      else
        this.m_dictMutex.ReleaseMutex();
    }

    public class Item
    {
      private object m_objUserData;
      private string m_szTitle = "";

      public object Tag
      {
        get => this.m_objUserData;
        set => this.m_objUserData = value;
      }

      public string Title
      {
        get => this.m_szTitle;
        set => this.m_szTitle = value;
      }

      public Item()
      {
      }

      public Item(string szText) => this.m_szTitle = szText;

      public Item(string szText, object objTag)
      {
        this.m_szTitle = szText;
        this.m_objUserData = objTag;
      }

      public bool IsEqual(ButtonBox.Item itItem) => itItem.Tag == this.m_objUserData && itItem.Title == this.m_szTitle;

      public ButtonBox.Item Clone() => new ButtonBox.Item(this.m_szTitle, this.m_objUserData);
    }

    public delegate void ItemSelectDelegate(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender);
  }
}
