using Stock.Controllers;
using Stock.Dataset.Model;
using Stock.Interfaces;
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
    public partial class CashRegisters_UC : UserControl
    {
        invoicesold thisInvoicesold;
        public CashRegisters_UC()
        {
            InitializeComponent();
            v_text_NumericUpDown.Value = 0;
            v_text_customer.Text = "customer";

            v_image_customer.Source = new BitmapImage(new Uri("/assets/images/customer.png", UriKind.Relative));
            thisInvoicesold = new invoicesold 
            {
                ID = oi_Invoice.GetID_NonValid(),
            };
            v_text_InvoiceID.Text = thisInvoicesold.ID +"";
            GridRefresh();
        }

        //*************************************************************************************  event
        #region event
        //========================================
        private void v_text_search_gotFocus(object sender, EventArgs e)
        {
            v_GridSearchProduct.Visibility = Visibility.Visible;
            TableProducts_UC.Send(this, null);
        }
        private void v_text_search_lostFocus(object sender, EventArgs e)
        {
            //v_GridSearchProduct.Visibility = Visibility.Collapsed;
        }
        private void v_btn_EditCustomer(object sender, EventArgs e)
        {
            v_GridSearchCustomer.Visibility = Visibility.Visible;
            TableUsers_UC.Send(this, null);
        }
        private void v_btn_EditInvoice(object sender, EventArgs e)
        {
            v_GridSearchInvoice.Visibility = Visibility.Visible;
            TableInvoices_UC.Send(this, null);
        }
        private void v_btn_AddNewInvoice(object sender, EventArgs e)
        {
            oi_Invoice.GetID_NonValid();
        }
        private void v_btn_ValidateInvoice(object sender, EventArgs e)
        {
            v_GridInvoiceValidation.Visibility = Visibility.Visible;
            InvoiceValidation_UC.Send(this,v_text_InvoiceID.Text);
        }
        private void v_btn_delete(object sender, EventArgs e)
        {
            if (v_GridCashRegister.SelectedItem != null)
            {
                var o = v_GridCashRegister.SelectedItem as productsold;
                MessageBox.Show(oi_CashRegisters.delete(o.ID));
                GridRefresh();
            }
        }
        //========================================
        private void v_btn_EditMoneyOFOne(object sender, EventArgs e)
        {
            EditWhat = "MONEY_ONE";
            EditInit(EditWhat);
        }
        private void v_btn_EditQuantity(object sender, EventArgs e)
        {
            EditWhat = "QUANTITY";
            EditInit(EditWhat);
        }
        private void v_btn_EditTaxPerce(object sender, EventArgs e)
        {
            EditWhat = "TAX_PERCE";
            EditInit(EditWhat);
        }
        private void v_btn_EditStamp(object sender, EventArgs e)
        {
            EditWhat = "STAMP";
            EditInit(EditWhat);
        }
        private void v_btn_editOk(object sender, EventArgs e)
        {
            v_GridEdit.Visibility = Visibility.Collapsed;
            var o = v_GridCashRegister.SelectedItem as productsold;
            switch (EditWhat)
            {
                case ("MONEY_ONE"):
                    {
                        o.MONEY_ONE = v_GridEdit_value.Value ?? 0;
                        oi_CashRegisters.edit(o);
                    }
                    break;
                case ("QUANTITY"):
                    {
                        o.QUANTITY = v_GridEdit_value.Value ?? 0;
                        oi_CashRegisters.edit(o);
                    }
                    break;
                case ("TAX_PERCE"):
                    {
                        o.TAX_PERCE = v_GridEdit_value.Value ?? 0;
                        oi_CashRegisters.edit(o);
                    }
                    break;
                case ("STAMP"):
                    {
                        o.STAMP = v_GridEdit_value.Value ?? 0;
                        oi_CashRegisters.edit(o);
                    }
                    break;
                default: break;
            }
            GridRefresh();
        }
        private void v_btn_editCancel(object sender, EventArgs e)
        {
            v_GridEdit.Visibility = Visibility.Collapsed;
            EditWhat = "";
            v_GridEdit_value.Value = 0;
        }
        private string EditWhat = "";
        private void EditInit(string column)
        {
            if (v_GridCashRegister.SelectedItem != null)
            {
                v_GridEdit.Visibility = Visibility.Visible;
                var o = v_GridCashRegister.SelectedItem;
                System.Reflection.PropertyInfo pi = o.GetType().GetProperty(EditWhat);
                var v = (double)(pi.GetValue(o, null));
                v_GridEdit_value.Value = v;
            }
        }
        //========================================
        private void event_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (v_GridCashRegister.SelectedItem != null)
            {

            }
        }
        private void v_btn_OverlayGridCancel(object sender, EventArgs e)
        {
            GridRefresh();
        }
        #endregion
        //************************************************************************************* Messanger
        #region Messanger
        public void ReturnInvoice(object _sender, dynamic _data)
        {
            v_text_InvoiceID.Text = string.Format("{0}", _data.ID);
            thisInvoicesold.ID = _data.ID;
            GridRefresh();
        }
        public void ReturnCustome(object _sender, dynamic _data)
        {
            v_text_customer.Text = string.Format(" {0}:{1}", _data.ID, _data.NAME);
            thisInvoicesold.ID_CUSTOMERS = _data.ID;
            GridRefresh();
        }
        public void ReturnProduct(object _sender, dynamic _data)
        {
            var o = new productsold();
            o.ID_PRODUCT = _data.ID;
            o.ID_INVOICE = thisInvoicesold.ID;
            o.MONEY_ONE = _data.MONEY_SELLING;
            o.QUANTITY = 1;
            o.TAX_PERCE = _data.TAX_PERCE;
            o.STAMP = 0;

            oi_CashRegisters.add(o);
            GridRefresh();
        }
        public void ReturnInvoiceValidation(object _sender, dynamic _data)
        {
            MessageBox.Show("ReturnInvoiceValidation");
            GridRefresh();
        }        
        #endregion
        /**************************************************************/
        private void GridRefresh()
        {
            v_GridSearchProduct.Visibility = Visibility.Collapsed;
            v_GridSearchCustomer.Visibility = Visibility.Collapsed;
            v_GridSearchInvoice.Visibility = Visibility.Collapsed;
            v_GridInvoiceValidation.Visibility = Visibility.Collapsed;
            v_GridEdit.Visibility = Visibility.Collapsed;

            v_GridCashRegister.ItemsSource = null;
            double _sum;
            v_GridCashRegister.ItemsSource = oi_CashRegisters.search(thisInvoicesold.ID,out _sum);
            v_text_NumericUpDown.Value = _sum;
        }
        /**************************************************************/
        ITableCashRegisters oi_CashRegisters = new TableCashRegister_CV();
        ITableInvoices oi_Invoice = new TableInvoices_CV();
        /**************************************************************/
    }
}
