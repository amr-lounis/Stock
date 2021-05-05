using Stock.Controllers;
using Stock.Interfaces;
using Stock.Models;
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

namespace Stock.Views
{
    public partial class TableInvoices_UC : UserControl
    {
        public TableInvoices_UC()
        {
            InitializeComponent();
            vPageNumber.Text = "" + page;
            GridRefresh();
        }

        #region event
        //************************************************************************************* event
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
            ointerface.add(new Invoice_M());
        }
        private void event_edit(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                ointerface.edit(new Invoice_M());
            }
        }
        private void event_delete(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem as Invoice_M;
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
                var o = myDataGrid.SelectedItem;
                System.Reflection.PropertyInfo pi = o.GetType().GetProperty("ID");
                var v = (string)(pi.GetValue(o, null));
                Console.WriteLine(v);
            }
        }
        private void v_btn_OverlayGridCancel(object sender, EventArgs e)
        {
            GridRefresh();
        }
        private void GridRefresh()
        {
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = ointerface.getPage(ref page);
        }
        #endregion
        //************************************************************************************* Messanger
        #region Messanger
        void initMessanger() { OnSendMessage = Receiver; }
        public delegate void delegateSend(object _sender, dynamic _data);
        public static event delegateSend OnSendMessage;
        public static void Send(object _sender, dynamic _data)
        {
            if (OnSendMessage != null) OnSendMessage(_sender, _data);
        }
        public void Receiver(object _sender, dynamic _data)
        {
            Sender = (_sender as CashRegisters_UC);
            OnReturnMessage = Sender.ReturnInvoice;
            if (_data.mode != null)
            {
                if (_data.mode.Equals("Select"))
                {
                   
                }
            }
        }
        //dynamic data = new System.Dynamic.ExpandoObject();
        public delegate void delegateReturn(object _sender, dynamic _data);
        public static event delegateReturn OnReturnMessage;
        CashRegisters_UC Sender;
        #endregion
        //************************************************************************************* Variable
        #region Variable
        ITableInvoices ointerface = new CTableInvoices();
        public static int page = 0;
        #endregion
    }
}