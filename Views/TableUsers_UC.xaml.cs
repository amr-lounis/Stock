using Stock.Controllers;
using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Stock.Views
{
    public partial class TableUsers_UC : UserControl
    {
        ITableUsers ointerface = new CTableUsers();
        public static int page = 0;
        public TableUsers_UC()
        {
            InitializeComponent();
            vPageNumber.Text = "" + page;
            myDataGrid.ItemsSource = ointerface.getPage(ref page);
        }
        private void event_forward(object sender, RoutedEventArgs e)
        {
            page++;
            vPageNumber.Text = string.Format("{0}", page);
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = ointerface.getPage(ref page);
        }
        private void event_backward(object sender, RoutedEventArgs e)
        {
            page--;
            vPageNumber.Text = string.Format("{0}", page);
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = ointerface.getPage(ref page);
        }
       
        private void event_add(object sender, RoutedEventArgs e)
        {
            if (ointerface.add(new User()) >= 1)
            {
                myDataGrid.ItemsSource = null;
                myDataGrid.ItemsSource = ointerface.getPage(ref page);
            }
            else
            {
                MessageBox.Show("can\' add");
            }
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = ointerface.getPage(ref page);
        }
        private void event_edit(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                User o = myDataGrid.SelectedItem as User;
                if (ointerface.edit(o) >= 1)
                {
                    myDataGrid.ItemsSource = null;
                    myDataGrid.ItemsSource = ointerface.getPage(ref page);
                }
                else
                {
                    MessageBox.Show("can\' edit");
                }
            }
        }
        private void event_delete(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                User o = myDataGrid.SelectedItem as User;
                if (ointerface.delete(o) >= 1)
                {
                    myDataGrid.ItemsSource = null;
                    myDataGrid.ItemsSource = ointerface.getPage(ref page);
                }
                else
                {
                    MessageBox.Show("can\' detete");
                }
            }
        }
        private void event_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem;
                System.Reflection.PropertyInfo pi = o.GetType().GetProperty("ID");
                var v = (string)(pi.GetValue(o, null));
                MessageBox.Show(v + "");
            } 
        }

    }
}
