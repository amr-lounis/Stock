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
        public TableUsers_UC()
        {
            InitializeComponent();
            initMessanger();
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
            EditUsers_UC.Send("Add", null);
        }
        private void event_edit(object sender, RoutedEventArgs e)
        {
            v_GridEdit.Visibility = Visibility.Visible;
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem as User_M;
                EditUsers_UC.Send("Edit", o);
            }
        }
        private void event_delete(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem as User_M;
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
        #endregion
        //************************************************************************************* Messanger
        #region Messanger
        void initMessanger() { OnSendMessage += Receiver; }
        public delegate void delegateSend(string _string, object _message);
        public static event delegateSend OnSendMessage;
        public static void Send(string _string, object _message)
        {
            if (OnSendMessage != null) OnSendMessage(_string, _message);
        }
        public void Receiver(string _string, object _message)
        {
            GridRefresh();
        }
        #endregion
        //*************************************************************************************
        private void GridRefresh()
        {
            v_GridEdit.Visibility = Visibility.Collapsed;
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = ointerface.getPage(ref page);
        }
        //*************************************************************************************
        ITableUsers ointerface = new CTableUsers();
        public static int page = 0;
        //*************************************************************************************
    }
}
