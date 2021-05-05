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
    public partial class TableProducts_UC
    {
        public TableProducts_UC()
        {
            InitializeComponent();
            vPageNumber.Text = "" + page;
            GridRefresh();
        }
        //************************************************************************************* event
        #region event
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
            v_GridEdit.Visibility = Visibility.Visible;

            dynamic data = new System.Dynamic.ExpandoObject();
            data.mode = "Add";
            data.message = null;
            EditProducts_UC.Send(this, data);
        }
        private void event_edit(object sender, RoutedEventArgs e)
        {
            v_GridEdit.Visibility = Visibility.Visible;

            if (myDataGrid.SelectedItem != null)
            {
                dynamic data = new System.Dynamic.ExpandoObject();
                data.mode = "Edit";
                data.message = myDataGrid.SelectedItem as Product_M;
                EditProducts_UC.Send(this, data);
            }
        }
        private void event_delete(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem as Product_M;
                if (ointerface.delete(o) >= 1)
                {
                    GridRefresh();
                }
                else
                {
                    MessageBox.Show("can\'t detete");
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
                    Console.WriteLine(v);
                }
            }
        }
        private void v_btn_OverlayGridCancel(object sender, EventArgs e)
        {
            GridRefresh();
        }
        private void GridRefresh()
        {
            v_GridEdit.Visibility = Visibility.Collapsed;
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = ointerface.getPage(ref page);
        }
        #endregion
        //************************************************************************************* Messanger
        #region Messanger
        public void Return(object _sender, dynamic _data)
        {
            GridRefresh();
        }
        #endregion
        //************************************************************************************* Variable
        #region Variable
        ITableProducts ointerface = new CTableProducts();
        public static int page = 0;
        #endregion
    }
}

