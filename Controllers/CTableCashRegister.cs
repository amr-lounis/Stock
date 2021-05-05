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
    public class CTableCashRegister : ITableCashRegister
    {
        List<CashRegister_M> list = new List<CashRegister_M>();
        //-------------------------------------------------------------------------------------
        public int add(CashRegister_M _CashRegister)
        {
            if(_CashRegister.ID.Equals("0")) _CashRegister.ID = Helper.random();
            list.Add(_CashRegister);
            return 1;
        }
        public int edit(CashRegister_M _CashRegister)
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
        public List<CashRegister_M> getAll()
        {
            return list;
        }
        public int delete(CashRegister_M _CashRegister)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _CashRegister.ID));
            return 1;
        }
    }
}
