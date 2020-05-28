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

        public WorkerProgressAsync(int max, int delay, CancellationTokenSource cts, IProgress<int> progress)
        {
            Max = max;
            Delay = delay;
            Cts = cts;
            Progress = progress;
        }

        public async Task CountDown()
        {
            await Task.Factory.StartNew(Count);
        }

        private void Count()
        {
            for (int i = Max; i > 0; i--)
            {
                NotifyProgress(Progress, i);
                if (Cts.IsCancellationRequested)
                    break;

                Thread.Sleep(Delay);
            }
        }

        private void NotifyProgress(IProgress<int> progress, int i)
        {
            progress.Report(i);
        }
    }
}
