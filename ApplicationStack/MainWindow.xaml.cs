using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
             try { InitializeComponent(); }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LinkProject.EventTunnel.Publish(new LinkProject.SomeUniqueEvent(true));
        }

        private void button1_MouseLeave(object sender, MouseEventArgs e)
        {
            LinkProject.EventTunnel.Publish(new LinkProject.SomeUniqueEvent(false));
        }
    }
}
