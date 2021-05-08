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
    public class TableCashRegister_CV : ITableCashRegisters
    {
        List<CashRegister_M> list = new List<CashRegister_M>();
        //-------------------------------------------------------------------------------------
        public CashRegister_M get(string _ID)
        {
            return list.Find(o => o.ID == _ID);
        }
        //-------------------------------------------------------------------------------------
        public List<CashRegister_M> getAll()
        {
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int add(CashRegister_M _CashRegister)
        {
            if(_CashRegister.ID.Equals("0")) _CashRegister.ID = Helper.random();
            list.Add(_CashRegister);
            calcule(ref _CashRegister);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(CashRegister_M _CashRegister)
        {
            var o = list.Find(x => x.ID == _CashRegister.ID);
            o.NAME = _CashRegister.NAME;
            o.CODE = _CashRegister.CODE;
            o.MONEY_ONE = _CashRegister.MONEY_ONE;
            o.QUANTITY = _CashRegister.QUANTITY;
            o.TAX_PERCE = _CashRegister.TAX_PERCE;
            o.STAMP = _CashRegister.STAMP;

            calcule(ref _CashRegister);

            list[list.FindIndex(x => x.ID == _CashRegister.ID)] = o;
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int delete(CashRegister_M _CashRegister)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _CashRegister.ID));
            return 1;
        }
        //-------------------------------------------------------------------------------------
        void calcule(ref CashRegister_M _CashRegister)
        {
            var MONEY_ONE = Helper.DoubleFromString(_CashRegister.MONEY_ONE);
            var QUANTITY = Helper.DoubleFromString(_CashRegister.QUANTITY);
            var TAX_PERCE = Helper.DoubleFromString(_CashRegister.TAX_PERCE);
            var STAMP = Helper.DoubleFromString(_CashRegister.STAMP);
            _CashRegister.TAX_VALUE = string.Format("{0}", MONEY_ONE / 100 * TAX_PERCE);
            _CashRegister.MONEY_PAID = string.Format("{0}", (MONEY_ONE + STAMP + (MONEY_ONE / 100 * TAX_PERCE)) * QUANTITY);
        }
    }
}
