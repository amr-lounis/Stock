using Stock.Classes;
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
    public partial class CashRegister_UC : UserControl
    {
        public CashRegister_UC()
        {
            InitializeComponent();
            v_text_NumericUpDown.Value = 5.5555;
            v_text_customer.Text = "customer";
            v_text_InvoiceALL.Text = "100";
            v_text_InvoiceID.Text = "19";
            v_image_customer.Source = new BitmapImage(new Uri("/assets/images/user.png", UriKind.Relative));

            var v = ointerface.add(new CashRegister_M());
            for (int i = 0; i < 5; i++) ointerface.add( new CashRegister_M() ) ;
            GridRefresh();
        }
        /**************************************************************/
        private void v_text_search_gotFocus(object sender, EventArgs e)
        {
            v_GridSearchProduct.Visibility = Visibility.Visible;
        }
        private void v_text_search_lostFocus(object sender, EventArgs e)
        {
            //v_GridSearchProduct.Visibility = Visibility.Collapsed;
        }
        private void v_btn_EditCustomer(object sender, EventArgs e)
        {
            v_GridSearchCustomer.Visibility = Visibility.Visible;
        }
        private void v_btn_EditInvoice(object sender, EventArgs e)
        {
            v_GridSearchInvoice.Visibility = Visibility.Visible;
        }
        private void v_btn_AddNewInvoice(object sender, EventArgs e)
        {
            MessageBox.Show("v_btn_AddNewInvoice");
        }
        private void v_btn_ValidateInvoice(object sender, EventArgs e)
        {
            MessageBox.Show("v_btn_ValidateInvoice");
        }
        /**************************************************************/
        private void v_btn_delete(object sender, EventArgs e)
        {
            if (v_GridCashRegister.SelectedItem != null)
            {
                var o = v_GridCashRegister.SelectedItem as CashRegister_M;
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
        /**************************************************************/
        private string EditWhat = "";
        private void EditInit(string column)
        {
            v_GridEdit.Visibility = Visibility.Visible;
            var o = v_GridCashRegister.SelectedItem;
            System.Reflection.PropertyInfo pi = o.GetType().GetProperty(EditWhat);
            var v = (string)(pi.GetValue(o, null));
            v_GridEditText.Text = v;
        }
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
            var o = v_GridCashRegister.SelectedItem as CashRegister_M;
            switch (EditWhat)
            {                
                case ("MONEY_ONE"):
                    {
                        o.MONEY_ONE = v_GridEditText.Text; 
                        ointerface.edit(o);
                    } break;
                case ("QUANTITY"):
                    {
                        o.QUANTITY = v_GridEditText.Text;
                        ointerface.edit(o);
                    }
                    break;
                case ("TAX_PERCE"):
                    {
                        o.TAX_PERCE = v_GridEditText.Text;
                        ointerface.edit(o);
                    }
                    break;
                case ("STAMP"):
                    {
                        o.STAMP = v_GridEditText.Text;
                        ointerface.edit(o);
                    }
                    break;
                default:break;
            }
            GridRefresh();
        }
        private void v_btn_editCancel(object sender, EventArgs e)
        {
            v_GridEdit.Visibility = Visibility.Collapsed;
            EditWhat = "";
            v_GridEditText.Text = "";
        }
        /**************************************************************/
        private void event_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (v_GridCashRegister.SelectedItem != null)
            {
                var o = v_GridCashRegister.SelectedItem;
                System.Reflection.PropertyInfo pi = o.GetType().GetProperty("ID");
                var v = (string)(pi.GetValue(o, null));
                MessageBox.Show(v + "");
            }
        }
        /**************************************************************/
        private void v_btn_OverlayGridCancel(object sender, EventArgs e)
        {
            v_GridSearchProduct.Visibility = Visibility.Collapsed;
            v_GridSearchCustomer.Visibility = Visibility.Collapsed;
            v_GridSearchInvoice.Visibility = Visibility.Collapsed;
            v_GridEdit.Visibility = Visibility.Collapsed;
        }
        /**************************************************************/
        private void GridRefresh()
        {
            v_GridCashRegister.ItemsSource = null;
            v_GridCashRegister.ItemsSource = ointerface.getAll();
        }
        /**************************************************************/
        ITableCashRegister ointerface = new CTableCashRegister();
        /**************************************************************/
    }
}
