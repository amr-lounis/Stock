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
    /// <summary>
    /// Interaction logic for CashRegister_UC.xaml
    /// </summary>
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

        }

        private void v_text_search_gotFocus(object sender, EventArgs e)
        {
            MessageBox.Show("v_text_search_gotFocus");
        }
        private void v_text_search_lostFocus(object sender, EventArgs e)
        {
            MessageBox.Show("v_text_search_lostFocus");
        }
        private void v_btn_EditCustomer(object sender, EventArgs e)
        {
            MessageBox.Show("v_btn_EditCustomer");
        }
        private void v_btn_EditInvoice(object sender, EventArgs e)
        {
            MessageBox.Show("v_btn_EditInvoice");
        }
        private void v_btn_AddNewInvoice(object sender, EventArgs e)
        {
            MessageBox.Show("v_btn_AddNewInvoice");
        }
        private void v_btn_ValidateInvoice(object sender, EventArgs e)
        {
            MessageBox.Show("v_btn_ValidateInvoice");
        }
    }
}
