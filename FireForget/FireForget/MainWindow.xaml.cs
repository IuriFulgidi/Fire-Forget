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

namespace FireForget
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        CancellationTokenSource cts;

        private async void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();

            //Fire&Forgtet
            //Worker wrkr = new Worker(10,1000,cts );
            //wrkr.CountDown();

            //ProgressUpdate
            //IProgress<int> p1 = new Progress<int>(UpdateUI);
            //WorkerProgress wrkrp = new WorkerProgress(10, 1000, cts, p1);
            //wrkrp.CountDown();

            //Async
            //WorkerAsync wrkra = new WorkerAsync(10, 1000, cts);
            //await wrkra.CountDown();

            //Async Progress
            IProgress<int> p2 = new Progress<int>(UpdateUI);
            Semaphore s = new Semaphore(1,1);
            WorkerProgressAsync wrkrpa = new WorkerProgressAsync(10, 1000, cts, p2, s);
            await wrkrpa.CountDown();

            MessageBox.Show("hey yo wassup, i wait the other thread");
        }

        private void UpdateUI(int num)
        {
            lbl_counter.Content = num.ToString();
        }

        private void Btn_stop_Click(object sender, RoutedEventArgs e)
        {
            if (cts != null)
                cts.Cancel();
        }
    }
}
