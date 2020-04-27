using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryTask
{
    public class Work
    {
        CancellationTokenSource _cts;
        int _max;
        int _ritardo;

        //costruttore
        public Work (int max, int ritardo, CancellationTokenSource cts)
        {
            _max = max;
            _ritardo = ritardo;
            _cts = cts;
        }

        public void start()
        {
            Task.Factory.StartNew(DoWork);
        }

        private void DoWork()
        {
            for (int i = 0; i < _max; i++)
            {
                Thread.Sleep(_ritardo);
                if (_cts.IsCancellationRequested)
                {
                    break;
                }
            }
        }
    }
}
