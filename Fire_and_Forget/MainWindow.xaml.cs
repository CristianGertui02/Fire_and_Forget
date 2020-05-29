using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryTask;

namespace Fire_and_Forget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Semaphore sem = new Semaphore(1, 2);
        CancellationTokenSource cts;
        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();
            //WorkerAsync wrk = new WorkerAsync(10, 1000, cts);
            IProgress<int> progress = new Progress<int>(UpdateUI);
            WorkerProgressAsync wrk = new WorkerProgressAsync(sem, 11, 1000, cts, progress);
            await wrk.start();

            
            //WorkerProgress wrk = new WorkerProgress(10,1000,cts,progress);
            //wrk.start();
            MessageBox.Show("posso farti leggere questo messaggio mentre sto anche contando");
        }

        private void UpdateUI(int i)
        {
            Lbl_ris.Content = i.ToString();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (cts!=null)
            {

                cts.Cancel();

            }
        }
    }
}
