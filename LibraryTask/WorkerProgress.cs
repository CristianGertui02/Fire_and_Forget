using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryTask
{
    public class WorkerProgress
    {
        CancellationTokenSource _cts;
        IProgress<int> _progress;
        int _max;
        int _ritardo;

        //costruttore
        public WorkerProgress(int max, int ritardo, CancellationTokenSource cts, IProgress<int> progress)
        {
            _max = max;
            _ritardo = ritardo;
            _cts = cts;
            _progress = progress;
        }

        public void start()
        {
            Task.Factory.StartNew(DoWork);
        }

        private void DoWork()
        {
            for (int i = 0; i < _max; i++)
            {
                NotifyProgress(_progress, i);
                Thread.Sleep(_ritardo);
                if (_cts.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        private void NotifyProgress(IProgress<int> progress, int i)
        {
            progress.Report(i);
        }
    }
}
