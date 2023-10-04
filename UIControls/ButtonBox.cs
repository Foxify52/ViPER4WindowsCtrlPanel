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
        private readonly IContainer components;
        private readonly Dictionary<int, Item> m_dictItems = new Dictionary<int, Item>();
        private readonly Mutex m_dictMutex = new Mutex();
        private int m_nCurrentSelected = -1;

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
            Name = nameof(ButtonBox);
            Size = new Size(131, 45);
            MouseUp += new MouseEventHandler(ButtonBox_MouseUp);
            ResumeLayout(false);
        }

        private event ItemSelectDelegate ItemSelected;

        public event ItemSelectDelegate ItemSelectedNotify
        {
            add => ItemSelected += value;
            remove => ItemSelected -= value;
        }

        public ButtonBox()
        {
            InitializeComponent();
            m_nCurrentSelected = -1;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.StandardClick, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        public void AddItem(Item itButtonBoxItem)
        {
            if (itButtonBoxItem == null)
                return;
            m_dictMutex.WaitOne();
            m_dictItems.Add(m_dictItems.Count, itButtonBoxItem.Clone());
            m_dictMutex.ReleaseMutex();
            Invalidate();
        }

        public void AddItem(List<Item> lstItem)
        {
            if (lstItem == null)
                return;
            m_dictMutex.WaitOne();
            foreach (Item obj in lstItem)
            {
                if (obj != null)
                    m_dictItems.Add(m_dictItems.Count, obj.Clone());
            }
            m_dictMutex.ReleaseMutex();
            Invalidate();
        }

        public void AddItem(Item[] aryItem)
        {
            if (aryItem == null)
                return;
            m_dictMutex.WaitOne();
            foreach (Item obj in aryItem)
            {
                if (obj != null)
                    m_dictItems.Add(m_dictItems.Count, obj.Clone());
            }
            m_dictMutex.ReleaseMutex();
            Invalidate();
        }

        public void ClearItem()
        {
            Item itPrevItem = null;
            m_dictMutex.WaitOne();
            if (m_dictItems.ContainsKey(m_nCurrentSelected))
                itPrevItem = m_dictItems[m_nCurrentSelected].Clone();
            m_dictItems.Clear();
            m_dictMutex.ReleaseMutex();
            m_nCurrentSelected = -1;
            Invalidate();
            if (ItemSelected == null)
                return;
            ItemSelected(itPrevItem, null, this);
        }

        public Item GetItem(int nIndex)
        {
            Item obj = null;
            m_dictMutex.WaitOne();
            if (m_dictItems.ContainsKey(nIndex))
                obj = m_dictItems[nIndex].Clone();
            m_dictMutex.ReleaseMutex();
            return obj;
        }

        public void SelectItem(int nIndex)
        {
            Item itPrevItem = null;
            Item itCurrItem = null;
            m_dictMutex.WaitOne();
            if (m_dictItems.ContainsKey(m_nCurrentSelected))
                itPrevItem = m_dictItems[m_nCurrentSelected].Clone();
            if (m_dictItems.ContainsKey(nIndex))
            {
                itCurrItem = m_dictItems[nIndex].Clone();
                m_nCurrentSelected = nIndex;
            }
            else
                m_nCurrentSelected = -1;
            m_dictMutex.ReleaseMutex();
            Invalidate();
            if (ItemSelected == null)
                return;
            ItemSelected(itPrevItem, itCurrItem, this);
        }

        public void UpdateControl()
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(BackColor);
            if (m_dictItems.Count <= 0)
            {
                graphics.DrawRectangle(new Pen(Color.Gray, 4f), ClientRectangle);
            }
            else
            {
                m_dictMutex.WaitOne();
                int height = Height / m_dictItems.Count;
                for (int key = 0; key < m_dictItems.Count; ++key)
                {
                    if (m_nCurrentSelected != key)
                    {
                        graphics.DrawRectangle(new Pen(Color.Gray, 2f), 0.0f, height * key + 1f, Width, height);
                        Font font = Font;
                        graphics.DrawString(m_dictItems[key].Title, font, Brushes.Black, new RectangleF()
                        {
                            X = 20f,
                            Y = height * key + 5f,
                            Width = Width - 25f,
                            Height = height - 4f
                        }, new StringFormat()
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Center,
                            Trimming = StringTrimming.EllipsisCharacter,
                            FormatFlags = StringFormatFlags.NoWrap
                        });
                    }
                }
                if (m_dictItems.ContainsKey(m_nCurrentSelected))
                {
                    int nCurrentSelected = m_nCurrentSelected;
                    graphics.DrawRectangle(new Pen(Color.SteelBlue, 2f), 0.0f, height * nCurrentSelected + 1f, Width, height);
                    PointF pt1_1 = new PointF(6f, (float)(height * nCurrentSelected + height / 2.0 - 6.0));
                    PointF pt1_2 = new PointF(6f, (float)(height * nCurrentSelected + height / 2.0 + 6.0));
                    PointF pt2 = new PointF(15f, height * nCurrentSelected + height / 2f);
                    graphics.DrawLine(new Pen(Color.Black, 2f), pt1_1, pt2);
                    graphics.DrawLine(new Pen(Color.Black, 2f), pt1_2, pt2);
                    Font font = Font;
                    graphics.DrawString(m_dictItems[nCurrentSelected].Title, font, Brushes.Black, new RectangleF()
                    {
                        X = 20f,
                        Y = height * nCurrentSelected + 5f,
                        Width = Width - 25f,
                        Height = height - 4f
                    }, new StringFormat()
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center,
                        Trimming = StringTrimming.EllipsisCharacter,
                        FormatFlags = StringFormatFlags.NoWrap
                    });
                }
                m_dictMutex.ReleaseMutex();
            }
        }

        private void ButtonBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_dictItems.Count <= 0)
                return;
            Item itPrevItem = null;
            m_dictMutex.WaitOne();
            float num = Height / (float)m_dictItems.Count;
            if (m_dictItems.ContainsKey(m_nCurrentSelected))
                itPrevItem = m_dictItems[m_nCurrentSelected].Clone();
            m_dictMutex.ReleaseMutex();
            int key = (int)Math.Truncate(e.Y / (double)num);
            if (key < 0 || key >= m_dictItems.Count)
                return;
            m_dictMutex.WaitOne();
            if (m_dictItems.ContainsKey(key))
            {
                Item itCurrItem = m_dictItems[key].Clone();
                m_nCurrentSelected = key;
                Invalidate();
                m_dictMutex.ReleaseMutex();
                if (ItemSelected == null)
                    return;
                ItemSelected(itPrevItem, itCurrItem, this);
            }
            else
                m_dictMutex.ReleaseMutex();
        }

        public class Item
        {
            private object m_objUserData;
            private string m_szTitle = "";

            public object Tag
            {
                get => m_objUserData;
                set => m_objUserData = value;
            }

            public string Title
            {
                get => m_szTitle;
                set => m_szTitle = value;
            }

            public Item()
            {
            }

            public Item(string szText) => m_szTitle = szText;

            public Item(string szText, object objTag)
            {
                m_szTitle = szText;
                m_objUserData = objTag;
            }

            public bool IsEqual(Item itItem)
            {
                return itItem.Tag == m_objUserData && itItem.Title == m_szTitle;
            }

            public Item Clone()
            {
                return new Item(m_szTitle, m_objUserData);
            }
        }

        public delegate void ItemSelectDelegate(
          Item itPrevItem,
          Item itCurrItem,
          ButtonBox objSender);
    }
}
