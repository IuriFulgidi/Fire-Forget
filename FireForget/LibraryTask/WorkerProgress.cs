using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryTask
{
    //classe worker con Progress update
    public class WorkerProgress
    {
        CancellationTokenSource Cts;

        IProgress<int> Progress;

        int Max;
        int Delay;

        public WorkerProgress(int max, int delay, CancellationTokenSource cts, IProgress<int> progress)
        {
            Max = max;
            Delay = delay;
            Cts = cts;
            Progress = progress;
        }

        public void CountDown()
        {
            Task.Factory.StartNew(Count);
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
