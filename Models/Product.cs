using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class Product
    {
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
