using Stock.Dataset.Model;
using Stock.Models;
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
        product get(int _id);
        List<product> getPage(ref int this_page);
        int add(product _product);
        int edit(product _product);
        int delete(product _product);
        BitmapImage getImage(long _id);
        void setImage(BitmapImage _image, long _id);
    }
}
