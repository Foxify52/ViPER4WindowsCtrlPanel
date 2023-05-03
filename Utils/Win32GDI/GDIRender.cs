using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ViPER4WindowsBin.Utils.Win32GDI
{
  internal class GDIRender
  {
    private const int SRCCOPY = 13369376;
    private Panel backgroundGraph;
    private Graphics backgroundGraphic;
    private Graphics backgroundRenderGraphic;
    private Graphics backgroundMemoryGraphic;
    private Graphics backgroundDrawGraphic;
    private Bitmap backgroundMemoryBitmap;
    private BufferedGraphics graphicsBuffer;
    private IntPtr memoryGraphicHdc;
    private IntPtr memoryBitmapHdc;
    private GDIMutex RenderLock;
    private DRAW_QUALITY DrawQuality;

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateCompatibleDC(IntPtr __pHDC);

    [DllImport("gdi32.dll")]
    private static extern IntPtr SelectObject(IntPtr __pHDC, IntPtr __pObject);

    [DllImport("gdi32.dll")]
    private static extern int BitBlt(
      IntPtr __pHdcDest,
      int __nXDest,
      int __nYDest,
      int __nWidth,
      int __nHeight,
      IntPtr __pHdcSrc,
      int __nXSrc,
      int __nYSrc,
      int __dwRop);

    [DllImport("gdi32.dll")]
    private static extern bool DeleteObject(IntPtr __pObject);

    public GDIRender()
    {
      this.backgroundGraphic = (Graphics) null;
      this.backgroundRenderGraphic = (Graphics) null;
      this.backgroundMemoryGraphic = (Graphics) null;
      this.backgroundDrawGraphic = (Graphics) null;
      this.backgroundMemoryBitmap = (Bitmap) null;
      this.graphicsBuffer = (BufferedGraphics) null;
      this.DrawQuality = DRAW_QUALITY.QUALITY_SUPER_HIGH;
      this.RenderLock = new GDIMutex(false);
    }

    ~GDIRender() => this.Dispose();

    public void Dispose()
    {
      if (this.backgroundGraphic != null)
        this.backgroundGraphic.Dispose();
      this.backgroundGraphic = (Graphics) null;
      if (this.graphicsBuffer != null)
        this.graphicsBuffer.Dispose();
      this.graphicsBuffer = (BufferedGraphics) null;
      if (this.backgroundRenderGraphic != null)
        this.backgroundRenderGraphic.Dispose();
      this.backgroundRenderGraphic = (Graphics) null;
      if (this.backgroundMemoryBitmap != null)
      {
        GDIRender.DeleteObject(this.memoryBitmapHdc);
        this.backgroundMemoryBitmap.Dispose();
      }
      this.backgroundMemoryBitmap = (Bitmap) null;
      if (this.backgroundMemoryGraphic != null)
      {
        GDIRender.DeleteObject(this.memoryGraphicHdc);
        this.backgroundMemoryGraphic.Dispose();
      }
      this.backgroundMemoryGraphic = (Graphics) null;
      if (this.backgroundDrawGraphic != null)
        this.backgroundDrawGraphic.Dispose();
      this.backgroundDrawGraphic = (Graphics) null;
    }

    public int ResetDraw(Panel GraphOle, Color BackColor)
    {
      if (GraphOle == null || GraphOle.GetType() != typeof (Panel) || GraphOle.ClientRectangle.Width < 1 || GraphOle.ClientRectangle.Height < 1)
        return -1;
      this.RenderLock.WaitLock();
      this.backgroundGraph = GraphOle;
      lock (this.backgroundGraph)
      {
        if (this.backgroundGraphic != null)
          this.backgroundGraphic.Dispose();
        if (this.graphicsBuffer != null)
          this.graphicsBuffer.Dispose();
        if (this.backgroundRenderGraphic != null)
          this.backgroundRenderGraphic.Dispose();
        if (this.backgroundMemoryBitmap != null)
        {
          GDIRender.DeleteObject(this.memoryBitmapHdc);
          this.backgroundMemoryBitmap.Dispose();
        }
        if (this.backgroundMemoryGraphic != null)
        {
          GDIRender.DeleteObject(this.memoryGraphicHdc);
          this.backgroundMemoryGraphic.Dispose();
        }
        if (this.backgroundDrawGraphic != null)
          this.backgroundDrawGraphic.Dispose();
        this.backgroundGraphic = this.backgroundGraph.CreateGraphics();
        this.graphicsBuffer = BufferedGraphicsManager.Current.Allocate(this.backgroundGraphic, this.backgroundGraph.ClientRectangle);
        this.backgroundRenderGraphic = this.graphicsBuffer.Graphics;
        this.backgroundRenderGraphic.Clear(BackColor);
        this.backgroundRenderGraphic.SetClip(this.backgroundGraph.ClientRectangle);
        this.backgroundMemoryBitmap = new Bitmap(this.backgroundGraph.ClientRectangle.Width, this.backgroundGraph.ClientRectangle.Height, this.backgroundRenderGraphic);
        this.backgroundMemoryGraphic = Graphics.FromImage((Image) this.backgroundMemoryBitmap);
        this.backgroundMemoryGraphic.Clear(BackColor);
        this.memoryGraphicHdc = GDIRender.CreateCompatibleDC(this.backgroundMemoryGraphic.GetHdc());
        this.memoryBitmapHdc = this.backgroundMemoryBitmap.GetHbitmap();
        GDIRender.SelectObject(this.memoryGraphicHdc, this.memoryBitmapHdc);
        this.backgroundDrawGraphic = Graphics.FromHdc(this.memoryGraphicHdc);
        switch (this.DrawQuality)
        {
          case DRAW_QUALITY.QUALITY_SUPER_HIGH:
            this.backgroundDrawGraphic.SmoothingMode = SmoothingMode.HighQuality;
            this.backgroundDrawGraphic.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            this.backgroundDrawGraphic.InterpolationMode = InterpolationMode.HighQualityBilinear;
            this.backgroundDrawGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            break;
          case DRAW_QUALITY.QUALITY_HIGH:
            this.backgroundDrawGraphic.SmoothingMode = SmoothingMode.AntiAlias;
            this.backgroundDrawGraphic.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            this.backgroundDrawGraphic.InterpolationMode = InterpolationMode.Bilinear;
            this.backgroundDrawGraphic.PixelOffsetMode = PixelOffsetMode.Half;
            break;
          case DRAW_QUALITY.QUALITY_MIDDLE:
            this.backgroundDrawGraphic.SmoothingMode = SmoothingMode.HighSpeed;
            this.backgroundDrawGraphic.TextRenderingHint = TextRenderingHint.AntiAlias;
            this.backgroundDrawGraphic.InterpolationMode = InterpolationMode.NearestNeighbor;
            this.backgroundDrawGraphic.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            break;
          case DRAW_QUALITY.QUALITY_LOW:
            this.backgroundDrawGraphic.SmoothingMode = SmoothingMode.None;
            this.backgroundDrawGraphic.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            this.backgroundDrawGraphic.InterpolationMode = InterpolationMode.Low;
            this.backgroundDrawGraphic.PixelOffsetMode = PixelOffsetMode.None;
            break;
        }
      }
      this.RenderLock.Unlock();
      return 0;
    }

    public void SetDrawQuality(DRAW_QUALITY NewQuality) => this.DrawQuality = NewQuality;

    public void BeginRender() => this.RenderLock.WaitLock();

    public void EndRender() => this.RenderLock.Unlock();

    public Graphics GetGraphicHandle() => this.backgroundDrawGraphic;

    public IntPtr BeginUnmanaged() => this.backgroundDrawGraphic.GetHdc();

    public void EndUnmanaged() => this.backgroundDrawGraphic.ReleaseHdc();

    public void BltToFront()
    {
      this.RenderLock.WaitLock();
      try
      {
        IntPtr hdc = this.backgroundDrawGraphic.GetHdc();
        GDIRender.BitBlt(this.backgroundRenderGraphic.GetHdc(), 0, 0, this.backgroundGraph.ClientRectangle.Width, this.backgroundGraph.ClientRectangle.Height, hdc, 0, 0, 13369376);
        this.backgroundDrawGraphic.ReleaseHdc();
        this.backgroundRenderGraphic.ReleaseHdc();
        this.graphicsBuffer.Render(this.backgroundGraphic);
      }
      finally
      {
        this.RenderLock.Unlock();
      }
    }

    public void BltToFront(int srcX, int srcY, int dstX, int dstY, int Width, int Height)
    {
      this.RenderLock.WaitLock();
      try
      {
        IntPtr hdc = this.backgroundDrawGraphic.GetHdc();
        GDIRender.BitBlt(this.backgroundRenderGraphic.GetHdc(), dstX, dstY, Width, Height, hdc, srcX, srcY, 13369376);
        this.backgroundDrawGraphic.ReleaseHdc();
        this.backgroundRenderGraphic.ReleaseHdc();
        this.graphicsBuffer.Render(this.backgroundGraphic);
      }
      finally
      {
        this.RenderLock.Unlock();
      }
    }
  }
}
