using MahApps.Metro.Controls;
using Stock.Controllers;
using Stock.Interfaces;
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

namespace Stock.Views
{ 
    public partial class Login : MetroWindow
    {
        ILogin o_ILogin = new CLogin();
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            NAME.Text = "admin";
            PASSWORD.Password = "admin";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(o_ILogin.Login(NAME.Text, PASSWORD.Password))
            {
                MainMenu wMainMenu = new MainMenu();
                wMainMenu.Owner = this;
                this.Hide(); // not required if using the child events below
                wMainMenu.ShowDialog();
                this.Show();
            }
            //System.Environment.Exit(1);
        }
    }
}
