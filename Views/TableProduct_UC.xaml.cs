using Stock.Controllers;
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
using Stock.Models;
using Stock.Interfaces;

namespace Stock.Views
{
    public partial class TableProduct_UC
    {
        public TableProduct_UC()
        {
            InitializeComponent();
            vPageNumber.Text = "" + page;
            GridRefresh();
        }
        private void event_forward(object sender, RoutedEventArgs e)
        {
            page++;
            vPageNumber.Text = string.Format("{0}", page);
            GridRefresh();
        }
        private void event_backward(object sender, RoutedEventArgs e)
        {
            page--;
            vPageNumber.Text = string.Format("{0}", page);
            GridRefresh();
        }
        
        private void event_add(object sender, RoutedEventArgs e)
        {
            if (ointerface.add(new Product()) >= 1)
            {
                GridRefresh();
            }
            else
            {
                MessageBox.Show("can\' add");
            }
        }
        private void event_edit(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem as Product;
                o.NAME = "XXX";
                if (ointerface.edit(o) >= 1)
                {
                    GridRefresh();
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
                var o = myDataGrid.SelectedItem as Product;
                if (ointerface.delete(o) >= 1)
                {
                    GridRefresh();
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
                if (myDataGrid.SelectedItem != null)
                {
                    var o = myDataGrid.SelectedItem;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty("ID");
                    var v = (string)(pi.GetValue(o, null));
                    MessageBox.Show(v + "");
                }
            }
        }
        /**************************************************************/
        private void v_btn_OverlayGridCancel(object sender, EventArgs e)
        {

        }
        /**************************************************************/
        private void GridRefresh()
        {
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = ointerface.getPage(ref page);
        }
        /**************************************************************/
        ITableProduct ointerface = new CTableProducts();
        public static int page = 0;
        /**************************************************************/

    }
}
