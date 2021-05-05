using Stock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class Product_M
    {
        public Product_M()
        {
            ID = "0";
            NAME = Helper.random();
            CATEGORY = Helper.random();
            UNITE = Helper.random();
            DESCRIPTION = Helper.random();
            CODE = Helper.random();
            IMPORTANCE = Helper.random();
            QUANTITY = Helper.random();
            QUANTITY_MIN = Helper.random();
            TAX_PERCE = Helper.random();
            MONEY_PURCHASE = Helper.random();
            MONEY_SELLING = Helper.random();
            MONEY_SELLING_MIN = Helper.random();
            DATE_PRODUCTION = Helper.random();
            DATE_PURCHASE = Helper.random();
            DATE_EXPIRATION = Helper.random();
        }
        public string ID { get; set; }
        public string NAME { get; set; }
        public string CATEGORY { get; set; }
        public string UNITE { get; set; }
        public string DESCRIPTION { get; set; }
        public string CODE { get; set; }
        public string IMPORTANCE { get; set; }
        public string QUANTITY { get; set; }
        public string QUANTITY_MIN { get; set; }
        public string TAX_PERCE { get; set; }
        public string MONEY_PURCHASE { get; set; }
        public string MONEY_SELLING { get; set; }
        public string MONEY_SELLING_MIN { get; set; }
        public string DATE_PRODUCTION { get; set; }
        public string DATE_PURCHASE { get; set; }
        public string DATE_EXPIRATION { get; set; }
    }
}
