using Stock.Classes;
using Stock.Dataset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class CD_TableUsers
    {
        static Entities _db = Entities.GetInstance();
        static int PageCount = 0, PageSize = 0, LineCount = 0;
        static string LableSearch;
        //public static IQueryable<user> search(string p_srting, ref int PageThis, string p_orderBy)
        //{
        //    IQueryable<user> _Query;
        //    try
        //    {
        //            _Query = null;
        //            _Query = _db.users.Where(c => c.NAME.ToLower().Contains(p_srting) || c.DESCRIPTION.ToLower().Contains(p_srting));
        //            LableSearch = SkipTake(ref PageThis, ref _Query);
        //            return _Query;
        //    }
        //    catch (Exception e) { F_File.LogError(e); return null; }
        //}
        //public static string SkipTake(ref int PageThis, ref IQueryable<user> p_Query)
        //{
        //    GetPageSize();
        //    if (PageSize <= 0) PageSize = 1;
        //    if (PageThis <= 0) PageThis = 0;
        //    if (PageThis > PageCount) PageThis = PageCount;
        //    LineCount = p_Query.Count();
        //    p_Query = p_Query.Skip(PageThis * PageSize).Take(PageSize);
        //    PageCount = (LineCount / PageSize);
        //    return string.Format("({0} / {1}) |{2}|", PageThis + 1, PageCount + 1, LineCount);
        //}
        //public static void GetPageSize()
        //{
        //    PageSize = C_Variables.Software_.pageSizeSearch;
        //}
        //public static string GetLableSearch()
        //{
        //    return LableSearch;
        //}

        //public static long NewId()
        //{
        //    return (_db.users.Count() > 0) ? _db.users.Max(u => u.ID) + 1 : 1;
        //}
        //public static user Get(long p_id)
        //{
        //    return _db.users.Single(c => c.ID == p_id);
        //}

        //public static void Delete(long p_id)
        //{
        //    _db.users.Remove(_db.users.Single(c => c.ID == p_id));
        //    _db.SaveChanges();
        //}
        ////************************************************************************
        //public static void Commit()
        //{
        //    _db.SaveChanges();
        //}
        //public static void EditFromObject(user p)
        //{
        //    if (p.NAME.Length == 0) { DialogError.Error(); return; }
        //    if (p.ID <= 0) if (IsExistName(p.NAME)) { DialogError.Error(); return; }
        //    if (p.ID > 0) if (!IsCanEditName(p.ID, p.NAME)) { DialogError.Error(); return; }

        //    if (p.ID > 0) // edit
        //    {
        //        try
        //        {
        //            var r = Get(p.ID);
        //            r.NAME = p.NAME;
        //            r.DESCRIPTION = p.DESCRIPTION;
        //            r.CODE = p.CODE;
        //            r.FIRSTNAME = p.FIRSTNAME;
        //            r.LASTNAME = p.LASTNAME;
        //            r.GENDER = p.GENDER;
        //            r.BIRTHDAY = p.BIRTHDAY;
        //            r.ADDRESS = p.ADDRESS;
        //            r.CITY = p.CITY;
        //            r.COUNTRY = p.COUNTRY;
        //            r.PHONE = p.PHONE;
        //            r.FAX = p.FAX;
        //            r.WEBSITE = p.WEBSITE;
        //            r.EMAIL = p.EMAIL;
        //            r.MONEY_ACCOUNT = p.MONEY_ACCOUNT;
        //            r.PICTURE = p.PICTURE;
        //            r.TYPE = p.TYPE;
        //            _db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            F_File.LogError(e);
        //        }
        //    }
        //    else         // add
        //    {
        //        try
        //        {
        //            p.ID = NewId();
        //            _db.users.Add(p);
        //            _db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            F_File.LogError(e);
        //        }
        //    }
        //}
        //private static bool IsExistName(string p_string)
        //{
        //    return _db.users.Any(o => o.NAME == p_string);
        //}
        //private static bool IsCanEditName(long id, string p_string)
        //{
        //    return !_db.users.Any(o => o.NAME == p_string && o.ID != id);
        //}
        ////*****************************************
    }
}
