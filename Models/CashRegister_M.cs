using Stock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class CashRegister_M
    {
        public CashRegister_M()
        {
            ID = "0";
            ID_PRODUCTS = "0";
            ID_INVOICES = "0";
            NAME = "";
            CODE = "";
            MONEY_ONE = "0";
            QUANTITY = "0";
            TAX_PERCE = "0";
            TAX_VALUE = "0";
            STAMP = "0";
            MONEY_PAID = "0";
        }
        public string ID { get; set; }
        public string ID_PRODUCTS { get; set; }
        public string ID_INVOICES { get; set; }
        public string NAME { get; set; }
        public string UNIT { get; set; }
        public string CODE { get; set; }
        public string MONEY_ONE { get; set; }
        public string QUANTITY { get; set; }
        public string TAX_PERCE { get; set; }
        public string TAX_VALUE { get; set; }
        public string STAMP { get; set; }
        public string MONEY_PAID { get; set; }
    }
}
