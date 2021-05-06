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
    public partial class InvoiceValidation : UserControl
    {
        public InvoiceValidation()
        {
            InitializeComponent();
            initReceiver();
        }
        private void v_btn_InvoiceValidate(object sender, RoutedEventArgs e)
        {
            ReturnMessage(this, null);
        }
        private void v_btn_InvoicePrint(object sender, RoutedEventArgs e)
        {

        }
        private void v_btn_InvoicePDF(object sender, RoutedEventArgs e)
        {

        }
        //************************************************************************************* Messanger //dynamic data = new System.Dynamic.ExpandoObject();
        #region Messanger
        void initReceiver() { OnSendMessage = ReceiveMessage; }
        public static void Send(object _sender, dynamic _data) { if (OnSendMessage != null) OnSendMessage(_sender, _data); }
        public void ReturnMessage(object _sender, dynamic _data) { if (OnReturnMessage != null) OnReturnMessage(_sender, _data); }
        public void ReceiveMessage(object _sender, dynamic _data)
        {
            OnReturnMessage = (_sender as CashRegisters_UC).ReturnInvoiceValidation; //change
            if (_data != null)
            {
                v_label_id.Content = _data;
            }
        }
        public delegate void delegateSend(object _sender, dynamic _data);
        public static event delegateSend OnSendMessage;

        public delegate void delegateReturn(object _sender, dynamic _data);
        public static event delegateReturn OnReturnMessage;
        #endregion
    }
}
