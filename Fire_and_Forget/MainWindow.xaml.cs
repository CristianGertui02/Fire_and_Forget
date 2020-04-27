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

        CancellationTokenSource cts;
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();
            Work wrk = new Work( 10, 1000, cts);
            wrk.start();
            MessageBox.Show("posso farti leggere questo messaggio mentre sto anche contando");
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
