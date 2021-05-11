using Stock.Dataset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Stock.Interfaces
{
    interface ITableUsers
    {
        user get(long _id);
        List<user> search(string _value, ref int _this_page, out string _data_out);
        int add(user _user);
        int edit(user _user);
        int delete(user _user);
        BitmapImage getImage(long _id);
        void setImage(BitmapImage _image, long _id);
    }
}
