using System.Threading;

namespace ViPER4WindowsBin.Utils.Win32GDI
{
  internal class GDIMutex
  {
    private Mutex MutexLock = new Mutex();

    public GDIMutex(bool Locking)
    {
      if (!Locking)
        return;
      this.MutexLock.WaitOne();
    }

    public void WaitLock() => this.MutexLock.WaitOne();

    public void Unlock() => this.MutexLock.ReleaseMutex();
  }
}
