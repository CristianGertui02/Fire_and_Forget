using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryTask
{
    public class WorkerAsync
    {
        CancellationTokenSource _cts;
        int _max;
        int _ritardo;

        //costruttore
        public WorkerAsync(int max, int ritardo, CancellationTokenSource cts)
        {
            _max = max;
            _ritardo = ritardo;
            _cts = cts;
        }

        public async Task start()
        {
            //Await significa che il flusso del metodo chiamante 
            //viene interrotto per attendere la disponibilità del risultato.

            //il processo non parte finchè ce n'è un altro in escuzione, cioè il 
            //processo 2 parte solo quando il processo 1 ha finito. 
           await Task.Factory.StartNew(DoWork);
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
