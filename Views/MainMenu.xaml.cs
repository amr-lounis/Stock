using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Stock.Views
{
    public partial class MainMenu : RibbonWindow
    {
        TableProduct_UC v_TableProducrs = new TableProduct_UC();
        TableUsers_UC v_TableUsers = new TableUsers_UC();

        public MainMenu()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            UIPanel.Children.Add(v_TableUsers);
        }

        private void RibbonWin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (RibbonWin.SelectedIndex == 0)
            //{

            //}
            //else if (RibbonWin.SelectedIndex == 1)
            //{
            //    UIPanel.Children.Clear();
            //    UIPanel.Children.Add(v_TableUsers);
            //}
            //else if (RibbonWin.SelectedIndex == 2)
            //{
            //    UIPanel.Children.Clear();
            //    UIPanel.Children.Add(v_TableProducrs);
            //}
            //else
            //{
            //    Console.WriteLine(RibbonWin.SelectedIndex);
            //    Console.Beep();
            //}
        }
    }
}
