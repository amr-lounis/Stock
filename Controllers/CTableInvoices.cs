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
    public class CTableInvoices : ITableInvoices
    {
        static List<Invoice_M> list = new List<Invoice_M>();
        //-------------------------------------------------------------------------------------
        public Invoice_M get(string _ID)
        {
            return list.Find(o => o.ID == _ID);
        }
        //-------------------------------------------------------------------------------------
        public List<Invoice_M> getPage(ref int this_page)
        {
            int pageMax = 5;
            if (this_page < 0) this_page = 0;
            if (this_page > pageMax) this_page = pageMax;
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int add(Invoice_M _Invoice)
        {
            if (_Invoice.ID.Equals("0")) _Invoice.ID = Helper.random();
            list.Add(_Invoice);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(Invoice_M _Invoice)
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
        public int delete(Invoice_M _Invoice)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _Invoice.ID));
            return 1;
        }
        //-------------------------------------------------------------------------------------
    }
}

//var v = new Invoice_M
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