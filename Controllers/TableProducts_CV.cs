using Stock.Dataset.Model;
using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Stock.Controllers
{
    public class TableProducts_CV : ITableProducts
    {
        static List<product> list = new List<product>();
        //-------------------------------------------------------------------------------------
        public product get(int _id)
        {
            return list.Find(o => o.ID == _id);
        }
        //-------------------------------------------------------------------------------------
        public List<product> getPage(ref int this_page)
        {
            int pageMax = 5;
            if (this_page < 0) this_page = 0;
            if (this_page > pageMax) this_page = pageMax;
            return list;
        }
        //-------------------------------------------------------------------------------------
        public int add(product _product)
        {
            list.Add(_product);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(product _product)
        {
            try
            {
                var o = list.Find(x => x.ID == _product.ID);
                o.NAME = _product.NAME;
                o.DESCRIPTION = _product.DESCRIPTION;
                o.ID_CATEGORY = _product.ID_CATEGORY;
                o.ID_UNITE = _product.ID_UNITE;
                o.CODE = _product.CODE;

                o.TAX_PERCE = _product.TAX_PERCE;
                o.MONEY_PURCHASE = _product.MONEY_PURCHASE;
                o.MONEY_SELLING = _product.MONEY_SELLING;
                o.MONEY_SELLING_MIN = _product.MONEY_SELLING_MIN;

                list[list.FindIndex(x => x.ID == _product.ID)] = o;
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }

        }
        //-------------------------------------------------------------------------------------
        public int delete(product _product)
        {
            list.RemoveAt(list.FindIndex(o => o.ID == _product.ID));
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public BitmapImage getImage(long _id)
        {
            throw new NotImplementedException();
        }
        //-------------------------------------------------------------------------------------
        public void setImage(BitmapImage _image, long _id)
        {
            throw new NotImplementedException();
        }
        //-------------------------------------------------------------------------------------
    }
}
