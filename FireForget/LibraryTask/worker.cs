using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryTask
{
    public class Worker
    {
        CancellationTokenSource Cts;
        int Max;
        int Delay;

        public Worker(int max,int delay,CancellationTokenSource cts)
        {
            Max = max;
            Delay = delay;
            Cts = cts;
        }

        public void CountDown()
        {
            Task.Factory.StartNew(Count);
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
