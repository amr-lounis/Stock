using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class Product
    {
        int a = 0, b = 999;
        static Random r = new Random();
        public Product()
        {
            ID = string.Format("{0}", r.Next(a, b));
            NAME = string.Format("{0}", r.Next(a, b));
            CATEGORY = string.Format("{0}", r.Next(a, b));
            UNITE = string.Format("{0}", r.Next(a, b));
            DESCRIPTION = string.Format("{0}", r.Next(a, b));
            CODE = string.Format("{0}", r.Next(a, b));
            IMPORTANCE = string.Format("{0}", r.Next(a, b));
            QUANTITY = string.Format("{0}", r.Next(a, b));
            QUANTITY_MIN = string.Format("{0}", r.Next(a, b));
            TAX_PERCE = string.Format("{0}", r.Next(a, b));
            MONEY_PURCHASE = string.Format("{0}", r.Next(a, b));
            MONEY_SELLING = string.Format("{0}", r.Next(a, b));
            MONEY_SELLING_MIN = string.Format("{0}", r.Next(a, b));
            DATE_PRODUCTION = string.Format("{0}", r.Next(a, b));
            DATE_PURCHASE = string.Format("{0}", r.Next(a, b));
            DATE_EXPIRATION = string.Format("{0}", r.Next(a, b));
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
