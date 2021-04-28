﻿using Stock.Interfaces;
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
        //-------------------------------------------------------------------------------------
        public List<Product> page(ref int this_page)
        {
            Console.WriteLine("backward_page");
            List<Product> lo = new List<Product>();
            for (int i = 0; i < 10; i++) lo.Add(new Product()
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
            });
            int pageMax = 5;
            if (this_page < 0) this_page = 0;
            if (this_page > pageMax) this_page = pageMax;
            return lo;
        }
        //-------------------------------------------------------------------------------------
        public Product add(Product product)
        {
            Console.WriteLine("add");
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
            return o;
        }
        //-------------------------------------------------------------------------------------
        public Product edit(Product product)
        {
            Console.WriteLine("edit");
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
            return o;
        }
        //-------------------------------------------------------------------------------------
        public int delete(string ID)
        {
            Console.WriteLine("delete");
            return 1;
        }
        //-------------------------------------------------------------------------------------
    }
}