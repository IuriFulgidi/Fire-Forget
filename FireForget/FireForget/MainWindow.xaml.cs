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

        private void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();

            Worker wrkr = new Worker(10,1000,cts );

            wrkr.CountDown();

            MessageBox.Show("hey yo wassup, i don't give a shit about the other guy");
        }

        private void Btn_stop_Click(object sender, RoutedEventArgs e)
        {
            if (cts != null)
                cts.Cancel();
        }
    }
}
