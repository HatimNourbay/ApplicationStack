using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace ApplicationStack
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i;
        public MainWindow()
        {
             try { InitializeComponent(); }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
             i = 0;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int messages;

            i++;

            Stopwatch stoop = new Stopwatch();
            stoop.Start();
            messages = i;
            try
            {
                PipeLink.Sender.SendMessage(messages);
                stoop.Stop();
                Console.WriteLine(stoop.ElapsedMilliseconds + " ms");

            }
            catch (Exception u)
            {
                Console.WriteLine(u);
            }
        }
    }
}
