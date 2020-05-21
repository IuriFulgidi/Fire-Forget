using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryTask
{
    //classe worker asincrona
    public class WorkerAsync
    {
        CancellationTokenSource Cts;
        int Max;
        int Delay;

        public WorkerAsync(int max, int delay, CancellationTokenSource cts)
        {
            Max = max;
            Delay = delay;
            Cts = cts;
        }

        public async Task CountDown()
        {
            await Task.Factory.StartNew(Count);
        }

        private void Count()
        {
            for (int i = Max; i > 0; i--)
            {
                if (Cts.IsCancellationRequested)
                    break;

                Thread.Sleep(Delay);
            }
        }
    }
}
