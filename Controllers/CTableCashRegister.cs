using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class CTableCashRegister : ITableCashRegister
    {
        int a = 0, b = 999;
        Random r = new Random();
        List<CashRegister> list = new List<CashRegister>();
        //-------------------------------------------------------------------------------------
        public int add(CashRegister _CashRegister)
        {
            CashRegister o = new CashRegister()
            {
                ID = string.Format("{0}", r.Next(a, b)),
                ID_PRODUCTS = string.Format("{0}", r.Next(a, b)),
                ID_INVOICES = string.Format("{0}", r.Next(a, b)),
                NAME = string.Format("{0}", r.Next(a, b)),
                CODE = string.Format("{0}", r.Next(a, b)),
                MONEY_UNIT = string.Format("{0}", r.Next(a, b)),
                QUANTITY = string.Format("{0}", r.Next(a, b)),
                TAX_PERCE = string.Format("{0}", r.Next(a, b)),
                TAX_VALUE = string.Format("{0}", r.Next(a, b)),
                STAMP = string.Format("{0}", r.Next(a, b)),
                MONEY_PAID = string.Format("{0}", r.Next(a, b)),
            };
            list.Add(o);
            return 1;
        }
        public int edit(CashRegister _CashRegister)
        {
            CashRegister o = new CashRegister
            {
                ID = string.Format("{0}", r.Next(a, b)),
                ID_PRODUCTS = string.Format("{0}", r.Next(a, b)),
                ID_INVOICES = string.Format("{0}", r.Next(a, b)),
                NAME = string.Format("{0}", r.Next(a, b)),
                CODE = string.Format("{0}", r.Next(a, b)),
                MONEY_UNIT = string.Format("{0}", r.Next(a, b)),
                QUANTITY = string.Format("{0}", r.Next(a, b)),
                TAX_PERCE = string.Format("{0}", r.Next(a, b)),
                TAX_VALUE = string.Format("{0}", r.Next(a, b)),
                STAMP = string.Format("{0}", r.Next(a, b)),
                MONEY_PAID = string.Format("{0}", r.Next(a, b)),
            };
            list[list.FindIndex(x => x.ID == _CashRegister.ID)] = o;
            return 1;
        }
        public List<CashRegister> getAll()
        {
            return list;
        }
        public int delete(CashRegister _CashRegister)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _CashRegister.ID));
            return 1;
        }
    }
}
