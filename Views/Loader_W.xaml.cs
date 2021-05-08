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
        public Loader_W()
        {
            InitializeComponent();
            SplashScreen splashScreen = new SplashScreen("/assets/images/customer.png");
            splashScreen.Show(false);
            nextWindow();
            splashScreen.Close(TimeSpan.FromSeconds(5));



            //Config_CD o = Config_CD.load();
            //MessageBox.Show(o.software.language);
            //o.software.language = "AR";
            //Config_CD.save(o);

            //Config_CD x = Config_CD.load();
            //MessageBox.Show(x.software.language);
        }
        private void nextWindow()
        {
            Login_W wLogin = new Login_W();
            this.Hide();
            wLogin.Show();
            wLogin.Owner = this.Owner;
            this.Close();
        }
    }
}
