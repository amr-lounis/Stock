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
                var query = TableProducts_CD.search(_value, ref _this_page, out _data_out);
                return query.ToList();
            }
            catch (Exception) { _data_out = ""; return null; }
        }
        //-------------------------------------------------------------------------------------
        public string add(product _product)
        {
            _product.ID = 0;

            return TableProducts_CD.Add(_product) ? "ok add" : "Can not add";
        }
        //-------------------------------------------------------------------------------------
        public string edit(product _product)
        {
            return TableProducts_CD.Edit(_product) ? "ok edit" : "Can not edit";
        }
        //-------------------------------------------------------------------------------------
        public string delete(long _id)
        {
            return TableProducts_CD.Delete(_id) ? "ok delete" : "Can not delete";
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

