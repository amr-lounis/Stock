using Stock.Dataset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public static class TableCashRegister_CD
    {
        public static IQueryable<productsold> search(long _id_invoice, out double _sum)
        {
            IQueryable<productsold> query = null;
            try
            {
                var _db = Entities.GetInstance();
                query = _db.productsolds.Where(c => c.ID_INVOICE == _id_invoice ) ;
                _sum = _db.productsolds.Where(c => c.ID_INVOICE == _id_invoice ).Sum(i => i.MONEY_PAID).Value;
                return query;
            }
            catch (Exception e) { log(e.Message); _sum = 0 ; return null; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static productsold Get(long p_id)
        {
            try
            {
                var _db = Entities.GetInstance();
                return _db.productsolds.Single(c => c.ID == p_id);
            }

            catch (Exception e) { log(e.Message); return null; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static bool Add(productsold _productsold)
        {
            try
            {
                var _db = Entities.GetInstance();
                calcule(ref _productsold);
                _db.productsolds.Add(_productsold);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e) { log(e.Message); return false; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static bool Edit(productsold _productsold)
        {
            try
            {
                var _db = Entities.GetInstance();
                var o = Get(_productsold.ID);
                o.ID_INVOICE = _productsold.ID_INVOICE;
                o.ID_PRODUCT = _productsold.ID_PRODUCT;
                o.MONEY_ONE = _productsold.MONEY_ONE;
                o.QUANTITY = _productsold.QUANTITY;
                o.TAX_PERCE = _productsold.TAX_PERCE;
                o.STAMP = _productsold.STAMP;
                calcule(ref _productsold);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e) { log(e.Message); return false; }
        }
        public static bool Edit(long _id, string _column, object _value)
        {
            try
            {
                var _db = Entities.GetInstance();
                var o = Get(_id);
                if (_column.Equals("ID_INVOICE")) o.ID_INVOICE = (long)_value;
                if (_column.Equals("ID_INVOICE")) o.ID_INVOICE = (long)_value;
                if (_column.Equals("NAME")) o.NAME = (string) _value;
                if (_column.Equals("DESCRIPTION")) o.DESCRIPTION = (string)_value;
                if (_column.Equals("MONEY_ONE")) o.MONEY_ONE = rnd(_value);
                if (_column.Equals("QUANTITY")) o.QUANTITY = rnd(_value);
                if (_column.Equals("TAX_PERCE")) o.TAX_PERCE = rnd(_value);
                if (_column.Equals("STAMP")) o.STAMP = rnd(_value);
                calcule(ref o);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e) { log(e.Message); return false; }
        }
      
        //----------------------------------------------------------------------------------------------------------------
        public static bool Delete(long p_id)
        {
            try
            {
                var _db = Entities.GetInstance();
                _db.productsolds.Remove(_db.productsolds.Single(c => c.ID == p_id));
                _db.SaveChanges();
                return true;
            }
            catch (Exception e) { log(e.Message); return false; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static void calcule(ref productsold _productsold)
        {
            try
            {
                var v = ((_productsold.MONEY_ONE) * _productsold.QUANTITY + (_productsold.MONEY_ONE * _productsold.TAX_PERCE / 100) + _productsold.STAMP);
                _productsold.MONEY_PAID = rnd(v);
            }
            catch (Exception e) { log(e.Message);}
        }
        public static double rnd(object _value)
        {
            return Math.Round((double)_value, 2);
        }
        //----------------------------------------------------------------------------------------------------------------
        static void log(string _data, string _type = "error")
        {
            Console.WriteLine("\n----------------------------------\n" + _type + ":" + _data + "\n----------------------------------\n");
        }
        //----------------------------------------------------------------------------------------------------------------
    }
}
