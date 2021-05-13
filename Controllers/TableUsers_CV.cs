using Stock.Dataset.Model;
using Stock.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Stock.Controllers
{
    public class TableUsers_CV : ITableUsers
    {
        //-------------------------------------------------------------------------------------
        public user get(long _id)
        {
            return TableUsers_CD.Get(_id) ?? new user {ID = 0,NAME = "default",DESCRIPTION="" };
        }
        //-------------------------------------------------------------------------------------
        public List<user> search(string _value, ref int _this_page, out string _data_out)
        {
            try
            {
                var query = TableUsers_CD.search(_value, ref _this_page, out _data_out);
                return query.ToList();
            }
            catch (Exception){ _data_out = ""; return new List<user>(); }
        }
        //-------------------------------------------------------------------------------------
        public string add(user _user)
        {
             return TableUsers_CD.Add(_user) ? "ok add" : "Can not add";
        }
        //-------------------------------------------------------------------------------------
        public string edit(user _user)
        {
            return TableUsers_CD.Edit(_user) ? "ok edit" : "Can not edit";
        }
        //-------------------------------------------------------------------------------------
        public string delete(long _id)
        {
            return TableUsers_CD.Delete(_id) ? "ok delete" : "Can not delete";
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
