using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDomainLab
{
    class Startup
    {
        [STAThread()]
        static void Main()
        {
            AppDomain domain = AppDomain.CreateDomain("another domain");

            CrossAppDomainDelegate action = () =>
            {
                App app = new App();
                app.MainWindow = new MainWindow();
                app.MainWindow.Show();
                app.Run();
            };

            domain.DoCallBack(action);
            
        }
    }
}
