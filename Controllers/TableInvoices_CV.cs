using Stock.Dataset.Model;
using Stock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class TableInvoices_CV : ITableInvoices
    {
        //-------------------------------------------------------------------------------------
        public sold_invoice get(long _id)
        {
            return TableInvoices_CD.Get(_id);
        }
        //-------------------------------------------------------------------------------------
        public long GetID_NonValid()
        {
            return TableInvoices_CD.GetLastNonValid();
        }
        //-------------------------------------------------------------------------------------
        public List<sold_invoice> search(string _value, DateTime _begin, DateTime _end, ref int _this_page, out string _data_out)
        {
            try
            {
                var query = TableInvoices_CD.search(_value, ref _this_page, out _data_out);
                return query.ToList();
            }
            catch (Exception) { _data_out = "ERROR"; return new List<sold_invoice>(); }
        }
        //-------------------------------------------------------------------------------------
        public string add(sold_invoice _soldinvoice)
        {
            return TableInvoices_CD.Add(_soldinvoice) ? "ok add" : "Can not add";
        }
        //-------------------------------------------------------------------------------------
        public string edit(sold_invoice _Invoice)
        {
            return TableInvoices_CD.Edit(_Invoice) ? "ok edit" : "Can not edit";
        }
        public string edit(long _id, string _column, object _value)
        {
            return TableInvoices_CD.Edit(_id, _column, _value) ? "ok edit" : "Can not edit";
        }
        //-------------------------------------------------------------------------------------
        public string delete(long _id)
        {
            return TableInvoices_CD.Delete(_id) ? "ok delete" : "Can not delete";
        }
        //-------------------------------------------------------------------------------------
    }
}