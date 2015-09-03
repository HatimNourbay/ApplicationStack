using LinkProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ProjectUser
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged, IEventReceiver
    {
        public MainWindow()
        {
            InitializeComponent();

            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen; //start the window at the centre of the screen
            DataContext = this;
            EventTunnel.Subscribe(this);
        }

        public bool CompareClick { get; set; }


        public bool ClickCheck
        {
            get { return CompareClick; }
            set
            {
                if (value != CompareClick)
                {
                    CompareClick = value;
                    OnPropertyChanged("ClickCheck");
                }
            }
        }

        public void Receive<T>(T arg) where T : EventArgs
        {
            var casted = arg as SomeUniqueEvent;
            if (casted != null)
            {
                ClickCheck = casted.Clicked;
            }
        }

        #region INotifyPropertyChanged implementation

        //Implementation of the INotifyPropertyChanged. Used to communicate with the main window thanks to the MVVM model. 

        // SEE MSDN DOC

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {


            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null)
            {
                h(this, e);
            }
            else
            {
                Console.WriteLine("fail");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged implementation
    }


}
