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
        public sold_product get(long _id)
        {
            return TableCashRegister_CD.Get(_id);
        }
        //-------------------------------------------------------------------------------------
        public List<sold_product> searchByInvoice(long _id_invoice) 
        { 
            try
            {
                return TableCashRegister_CD.search(_id_invoice).ToList();
            }
            catch (Exception) { return new List<sold_product>(); }
        }
        //-------------------------------------------------------------------------------------
        public string add(sold_product _productsold)
        {
            return TableCashRegister_CD.Add(_productsold) ? "ok add" : "Can not add";
        }
        //-------------------------------------------------------------------------------------
        public string edit(sold_product _productsold)
        {
            return TableCashRegister_CD.Edit(_productsold) ? "ok edit" : "Can not edit";
        }
        public string edit(long _id, string _column, object _value)
        {
            return TableCashRegister_CD.Edit(_id, _column, _value) ? "ok edit" : "Can not edit";
        }
        //-------------------------------------------------------------------------------------
        public string delete(long _id)
        {
            return TableCashRegister_CD.Delete(_id) ? "ok delete" : "Can not delete";
        }
        //-------------------------------------------------------------------------------------
    }
}
