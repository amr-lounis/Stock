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
        static List<soldinvoice> list = new List<soldinvoice>();
        //-------------------------------------------------------------------------------------
        public soldinvoice get(long _id)
        {
            return list.Find(o => o.ID == _id);
        }
        //-------------------------------------------------------------------------------------
        public List<soldinvoice> search(string _value, DateTime _begin, DateTime _end, ref int _this_page, out string _data_out)
        {
            _data_out = "";
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int add(soldinvoice _Invoice)
        {
            if (_Invoice.ID.Equals(0)) _Invoice.ID = 1613132;
            list.Add(_Invoice);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(soldinvoice _Invoice)
        {
            var o = list.Find(x => x.ID == _Invoice.ID);
            o.DESCRIPTION = _Invoice.DESCRIPTION;
            o.DATE = _Invoice.DATE;
            o.VALIDATION = _Invoice.VALIDATION;
            o.MONEY_WITHOUT_ADDEDD = _Invoice.MONEY_WITHOUT_ADDEDD;
            o.MONEY_TAX = _Invoice.MONEY_TAX;
            o.MONEY_STAMP = _Invoice.MONEY_STAMP;
            o.MONEY_TOTAL = _Invoice.MONEY_TOTAL;
            o.MONEY_PAID = _Invoice.MONEY_PAID;
            o.MONEY_UNPAID = _Invoice.MONEY_UNPAID;
           
            list[list.FindIndex(x => x.ID == _Invoice.ID)] = o;
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int delete(soldinvoice _Invoice)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _Invoice.ID));
            return 1;
        }
        //-------------------------------------------------------------------------------------
    }
}

//var v = new soldinvoice
//{
//    ID = "",
//    ID_USERS = "",
//    ID_CUSTOMERS = "",
//    DESCRIPTION = "",
//    DATE = "",
//    VALIDATION = "",
//    MONEY_WITHOUT_ADDEDD = "",
//    MONEY_TAX = "",
//    MONEY_STAMP = "",
//    MONEY_TOTAL = "",
//    MONEY_PAID = "",
//    MONEY_UNPAID = ""
//};