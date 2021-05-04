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
        List<CashRegister> list = new List<CashRegister>();
        //-------------------------------------------------------------------------------------
        public int add(CashRegister _CashRegister)
        {
            list.Add(_CashRegister);
            return 1;
        }
        public int edit(CashRegister _CashRegister)
        {
            var o = list.Find(x => x.ID == _CashRegister.ID);
            o.NAME = _CashRegister.NAME;
            o.CODE = _CashRegister.CODE;
            o.MONEY_ONE = _CashRegister.MONEY_ONE;
            o.QUANTITY = _CashRegister.QUANTITY;
            o.TAX_PERCE = _CashRegister.TAX_PERCE;
            o.TAX_VALUE = _CashRegister.TAX_VALUE;
            o.STAMP = _CashRegister.STAMP;
            o.MONEY_PAID = _CashRegister.MONEY_PAID;

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
