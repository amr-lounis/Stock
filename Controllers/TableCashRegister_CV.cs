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
        //-------------------------------------------------------------------------------------
        public productsold get(long _id)
        {
            return TableCashRegister_CD.Get(_id);
        }
        //-------------------------------------------------------------------------------------
        public List<productsold> search(long _id_invoice, out double _sum) 
        { 
            try
            {
                var query = TableCashRegister_CD.search(_id_invoice, out _sum);
                return query.ToList();
            }
<<<<<<< HEAD
            catch (Exception) { _sum = 0 ; return new List<productsold>(); }
=======
            catch (Exception) { _sum = 0 ; return null; }
>>>>>>> 56794b865720454a67a5f629147411f52097afcc
        }
        //-------------------------------------------------------------------------------------
        public string add(productsold _productsold)
        {
            return TableCashRegister_CD.Add(_productsold) ? "ok add" : "Can not add";
        }
        //-------------------------------------------------------------------------------------
        public string edit(productsold _productsold)
        {
            return TableCashRegister_CD.Edit(_productsold) ? "ok edit" : "Can not edit";
        }
        //-------------------------------------------------------------------------------------
        public string delete(long _id)
        {
            return TableCashRegister_CD.Delete(_id) ? "ok delete" : "Can not delete";
        }
        //-------------------------------------------------------------------------------------
    }
}
