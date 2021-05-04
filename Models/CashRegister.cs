using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class CashRegister
    {
        int a = 0, b = 999;
        static Random r = new Random();
        public CashRegister()
        {
            ID = string.Format("{0}", r.Next(a, b));
            ID_PRODUCTS = string.Format("{0}", r.Next(a, b));
            ID_INVOICES = string.Format("{0}", r.Next(a, b));
            NAME = string.Format("{0}", r.Next(a, b));
            CODE = string.Format("{0}", r.Next(a, b));
            MONEY_ONE = string.Format("{0}", r.Next(a, b));
            QUANTITY = string.Format("{0}", r.Next(a, b));
            TAX_PERCE = string.Format("{0}", r.Next(a, b));
            TAX_VALUE = string.Format("{0}", r.Next(a, b));
            STAMP = string.Format("{0}", r.Next(a, b));
            MONEY_PAID = string.Format("{0}", r.Next(a, b));
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
