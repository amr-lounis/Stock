using Stock.Dataset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Stock.Interfaces
{
    public interface ITableProducts
    {
        product get(long _id);
        List<product> search(string _value, ref int _this_page, out string _data_out);
        string add(product _product);
        string edit(product _product);
        string delete(long _id);
        BitmapImage getImage(long _id);
        void setImage(BitmapImage _image, long _id);
    }
}
