using Stock.Dataset.Model;
using Stock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class TableCashRegister_CV : ITableCashRegisters
    {
        List<productsold> list = new List<productsold>();
        //-------------------------------------------------------------------------------------
        public productsold get(int _id)
        {
            return list.Find(o => o.ID == _id);
        }
        //-------------------------------------------------------------------------------------
        public List<productsold> getAll()
        {
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int add(productsold _productsold)
        {
            if(_productsold.ID.Equals("0")) _productsold.ID = 23132;
            list.Add(_productsold);
            calcule(ref _productsold);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(productsold _productsold)
        {
            var o = list.Find(x => x.ID == _productsold.ID);
            o.MONEY_ONE = _productsold.MONEY_ONE;
            o.QUANTITY = _productsold.QUANTITY;
            o.TAX_PERCE = _productsold.TAX_PERCE;
            o.STAMP = _productsold.STAMP;

            calcule(ref _productsold);

            list[list.FindIndex(x => x.ID == _productsold.ID)] = o;
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int delete(productsold _productsold)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _productsold.ID));
            return 1;
        }
        //-------------------------------------------------------------------------------------
        void calcule(ref productsold _productsold)
        {
            var MONEY_ONE = _productsold.MONEY_ONE;
            var QUANTITY = _productsold.QUANTITY;
            var TAX_PERCE = _productsold.TAX_PERCE;
            var STAMP = _productsold.STAMP;
            var TAX_VALUE = string.Format("{0}", MONEY_ONE / 100 * TAX_PERCE);
            var MONEY_PAID = string.Format("{0}", (MONEY_ONE + STAMP + (MONEY_ONE / 100 * TAX_PERCE)) * QUANTITY);
        }
    }
}
