using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class CTableProducts : ITableProduct
    {
        int a = 0, b = 999;
        Random r = new Random();
        List<Product> list = new List<Product>();
        //-------------------------------------------------------------------------------------
        public int add(Product product)
        {
            Product o = new Product()
            {
                ID = string.Format("{0}", r.Next(a, b)),
                NAME = string.Format("{0}", r.Next(a, b)),
                CATEGORY = string.Format("{0}", r.Next(a, b)),
                UNITE = string.Format("{0}", r.Next(a, b)),
                DESCRIPTION = string.Format("{0}", r.Next(a, b)),
                CODE = string.Format("{0}", r.Next(a, b)),
                IMPORTANCE = string.Format("{0}", r.Next(a, b)),
                QUANTITY = string.Format("{0}", r.Next(a, b)),
                QUANTITY_MIN = string.Format("{0}", r.Next(a, b)),
                TAX_PERCE = string.Format("{0}", r.Next(a, b)),
                MONEY_PURCHASE = string.Format("{0}", r.Next(a, b)),
                MONEY_SELLING = string.Format("{0}", r.Next(a, b)),
                MONEY_SELLING_MIN = string.Format("{0}", r.Next(a, b)),
                DATE_PRODUCTION = string.Format("{0}", r.Next(a, b)),
                DATE_PURCHASE = string.Format("{0}", r.Next(a, b)),
                DATE_EXPIRATION = string.Format("{0}", r.Next(a, b)),
            };
            list.Add(o);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(Product product)
        {
            Product o = new Product()
            {
                ID = string.Format("{0}", r.Next(a, b)),
                NAME = string.Format("{0}", r.Next(a, b)),
                CATEGORY = string.Format("{0}", r.Next(a, b)),
                UNITE = string.Format("{0}", r.Next(a, b)),
                DESCRIPTION = string.Format("{0}", r.Next(a, b)),
                CODE = string.Format("{0}", r.Next(a, b)),
                IMPORTANCE = string.Format("{0}", r.Next(a, b)),
                QUANTITY = string.Format("{0}", r.Next(a, b)),
                QUANTITY_MIN = string.Format("{0}", r.Next(a, b)),
                TAX_PERCE = string.Format("{0}", r.Next(a, b)),
                MONEY_PURCHASE = string.Format("{0}", r.Next(a, b)),
                MONEY_SELLING = string.Format("{0}", r.Next(a, b)),
                MONEY_SELLING_MIN = string.Format("{0}", r.Next(a, b)),
                DATE_PRODUCTION = string.Format("{0}", r.Next(a, b)),
                DATE_PURCHASE = string.Format("{0}", r.Next(a, b)),
                DATE_EXPIRATION = string.Format("{0}", r.Next(a, b))

            };
            list[list.FindIndex(x => x.ID == product.ID)] = o;
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public List<Product> getPage(ref int this_page)
        {
            int pageMax = 5;
            if (this_page < 0) this_page = 0;
            if (this_page > pageMax) this_page = pageMax;
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int delete(Product _Product)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _Product.ID));
            return 1;
        }
        //-------------------------------------------------------------------------------------
    }
}
