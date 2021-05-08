using MahApps.Metro.Controls;
using Stock.Controllers;
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
using System.Windows.Shapes;

namespace Stock.Views
{
    public partial class Loader_W : MetroWindow
    {
        public delegate void delegateSend(object _sender, dynamic _data);
        public event delegateSend runEvent;
        public Loader_W()
        {
            InitializeComponent();
            //SplashScreen splashScreen = new SplashScreen("/assets/images/customer.png");
            //splashScreen.Show(false);

            //splashScreen.Close(TimeSpan.FromSeconds(5));

            //runEvent = runLoader;
            //Task t = new Task(delegate ()
            //{
            //    Thread.Sleep(2000);
            //    if (runEvent != null) runEvent(this, null);
            //});
            //t.Start();
            //TimeSpan.FromSeconds(5);


            Config_CD o = Config_CD.load();
            MessageBox.Show(o.software.language);
            o.software.language = "AR";
            Config_CD.save(o);

            Config_CD x = Config_CD.load();
            MessageBox.Show(x.software.language);
        }
        private void runLoader(object _sender, dynamic _data)
        {
            MainMenu_W wMainMenu = new MainMenu_W();
            //wMainMenu.Owner = (Loader_W)_sender;
            this.Hide(); // not required if using the child events below
            wMainMenu.Show();
            this.Close();
        }
    }
}
