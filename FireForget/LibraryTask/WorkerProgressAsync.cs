using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryTask
{
    public class WorkerProgressAsync
    {
        CancellationTokenSource Cts;

        IProgress<int> Progress;
        int Max;
        int Delay;

        Semaphore Sem;
        public WorkerProgressAsync(int max, int delay, CancellationTokenSource cts, IProgress<int> progress, Semaphore semaphore)
        {
            Max = max;
            Delay = delay;
            Cts = cts;
            Progress = progress;
            Sem = semaphore;
        }

        public async Task CountDown()
        {
            await Task.Factory.StartNew(Count);
        }

        private void Count()
        {
            Sem.WaitOne();

            for (int i = Max; i > 0; i--)
            {
                NotifyProgress(Progress, i);
                if (Cts.IsCancellationRequested)
                    break;

                Thread.Sleep(Delay);
            }

            Sem.Release();
        }

        private void NotifyProgress(IProgress<int> progress, int i)
        {
            progress.Report(i);
        }
    }
}
