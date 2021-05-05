using Stock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class Invoice_M
    {
        public Invoice_M()
        {
            ID = "0"; 
            ID_USERS = "0";
            ID_CUSTOMERS = "0";
            DESCRIPTION = Helper.random();
            DATE = Helper.random();
            VALIDATION = Helper.random();
            MONEY_WITHOUT_ADDEDD = Helper.random();
            MONEY_TAX = Helper.random();
            MONEY_STAMP = Helper.random();
            MONEY_TOTAL = Helper.random();
            MONEY_PAID = Helper.random();
            MONEY_UNPAID = Helper.random();
        }
        public string ID { get; set; }
        public string ID_USERS { get; set; }
        public string ID_CUSTOMERS { get; set; }
        public string DESCRIPTION { get; set; }
        public string DATE { get; set; }
        public string VALIDATION { get; set; }
        public string MONEY_WITHOUT_ADDEDD { get; set; }
        public string MONEY_TAX { get; set; }
        public string MONEY_STAMP { get; set; }
        public string MONEY_TOTAL { get; set; }
        public string MONEY_PAID { get; set; }
        public string MONEY_UNPAID { get; set; }
    }
}
