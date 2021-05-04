using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class CashRegister
    {
        public string ID { get; set; }
        public string ID_PRODUCTS { get; set; }
        public string ID_INVOICES { get; set; }
        public string NAME { get; set; }
        public string CODE { get; set; }
        public string MONEY_UNIT { get; set; }
        public string QUANTITY { get; set; }
        public string TAX_PERCE { get; set; }
        public string TAX_VALUE { get; set; }
        public string STAMP { get; set; }
        public string MONEY_PAID { get; set; }
    }
}
