using System.Threading;

namespace ViPER4WindowsBin.Utils.Win32GDI
{
    internal class GDIMutex
    {
        private readonly Mutex MutexLock = new Mutex();

        public GDIMutex(bool Locking)
        {
            if (!Locking)
                return;
            MutexLock.WaitOne();
        }

        public void WaitLock()
        {
            MutexLock.WaitOne();
        }

        public void Unlock()
        {
            MutexLock.ReleaseMutex();
        }
    }
}
