using Stock.Classes;
using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class CTableProducts : ITableProducts
    {
        static List<Product_M> list = new List<Product_M>();
        //-------------------------------------------------------------------------------------
        public Product_M get(string _ID)
        {
            return list.Find(o => o.ID == _ID);
        }
        //-------------------------------------------------------------------------------------
        public List<Product_M> getPage(ref int this_page)
        {
            int pageMax = 5;
            if (this_page < 0) this_page = 0;
            if (this_page > pageMax) this_page = pageMax;
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int add(Product_M _Product)
        {
            if (_Product.ID.Equals("0")) _Product.ID =Helper.random();
            list.Add(_Product);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(Product_M _Product)
        {
            try
            {
                var o = list.Find(x => x.ID == _Product.ID);
                o.NAME = _Product.NAME;
                o.CATEGORY = _Product.CATEGORY;
                o.UNITE = _Product.UNITE;
                o.DESCRIPTION = _Product.DESCRIPTION;
                o.CODE = _Product.CODE;
                o.IMPORTANCE = _Product.IMPORTANCE;
                o.QUANTITY = _Product.QUANTITY;
                o.QUANTITY_MIN = _Product.QUANTITY_MIN;
                o.TAX_PERCE = _Product.TAX_PERCE;
                o.MONEY_PURCHASE = _Product.MONEY_PURCHASE;
                o.MONEY_SELLING = _Product.MONEY_SELLING;
                o.MONEY_SELLING_MIN = _Product.MONEY_SELLING_MIN;
                o.DATE_PRODUCTION = _Product.DATE_PRODUCTION;
                o.DATE_PURCHASE = _Product.DATE_PURCHASE;
                o.DATE_EXPIRATION = _Product.DATE_EXPIRATION;

                list[list.FindIndex(x => x.ID == _Product.ID)] = o;
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }

        }
        //-------------------------------------------------------------------------------------
        public int delete(Product_M _Product)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _Product.ID));
            return 1;
        }
        //-------------------------------------------------------------------------------------
    }
}
