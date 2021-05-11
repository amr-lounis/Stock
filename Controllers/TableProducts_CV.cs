using Stock.Dataset.Model;
using Stock.Interfaces;
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
        //-------------------------------------------------------------------------------------
        public product get(long _id)
        {
            return TableProducts_CD.Get(_id);
        }
        //-------------------------------------------------------------------------------------
        public List<product> search(string _value, ref int _this_page, out string _data_out)
        {
            try
            {
                string s = "";
                var query = TableProducts_CD.search(_value, ref _this_page, out s);
                _data_out = s;
                return query.ToList();
            }
            catch (Exception) { _data_out = ""; return null; }
        }
        //-------------------------------------------------------------------------------------
        public int add(product _product)
        {
            TableProducts_CD.Add(_product);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int edit(product _product)
        {
            TableProducts_CD.Edit(_product);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public int delete(product _product)
        {
            TableProducts_CD.Delete(_product.ID);
            return 1;
        }
        //-------------------------------------------------------------------------------------
        public BitmapImage getImage(long _id)
        {
            return new BitmapImage();
        }
        //-------------------------------------------------------------------------------------
        public void setImage(BitmapImage _image, long _id)
        {

        }
        //-------------------------------------------------------------------------------------
    }
}

