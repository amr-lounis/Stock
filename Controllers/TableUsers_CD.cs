using Stock.Dataset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public static class TableUsers_CD
    {
        public static IQueryable<user> search(string p_srting, ref int PageThis)
        {
            var _db = Entities.GetInstance();
            IQueryable<user> query;
            try
            {
                query = null;
                query = _db.users.Where(c => c.NAME.ToLower().Contains(p_srting) || c.DESCRIPTION.ToLower().Contains(p_srting)).Take(GetPageSize());
                return query;
            }
            catch (Exception e) { return null; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static user Get(long p_id)
        {
            try
            {
                var _db = Entities.GetInstance();
                return _db.users.Single(c => c.ID == p_id);
            }
            catch (Exception) { return null; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static bool Add(user _user)
        {
            try
            {
                var _db = Entities.GetInstance();
                _db.users.Add(_user);
                _db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static bool Edit(user _user)
        {
            try
            {
                var _db = Entities.GetInstance();
                var o = Get(_user.ID);
                o.ID_ROLE = _user.ID_ROLE;
                o.NAME = _user.NAME;
                o.PASSWORD = _user.PASSWORD;
                o.GENDER = _user.GENDER;
                o.ACTIVITY = _user.ACTIVITY;
                o.NRC = _user.NRC;
                o.NIF = _user.NIF;
                o.ADDRESS = _user.ADDRESS;
                o.CITY = _user.CITY;
                o.COUNTRY = _user.COUNTRY;
                o.PHONE = _user.PHONE;
                o.FAX = _user.FAX;
                o.WEBSITE = _user.WEBSITE;
                o.EMAIL = _user.EMAIL;
                _db.SaveChanges();
                return true;
            }
            catch (Exception){ return false; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static bool Delete(long p_id)
        {
            try
            {
                var _db = Entities.GetInstance();
                _db.users.Remove(_db.users.Single(c => c.ID == p_id));
                _db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        //----------------------------------------------------------------------------------------------------------------
        private static bool IsExistName(string p_string)
        {
            try
            {
                var _db = Entities.GetInstance();
                return _db.users.Any(o => o.NAME == p_string);
            }
            catch (Exception) { return false; }
        }
        //----------------------------------------------------------------------------------------------------------------
        private static int GetPageSize()
        {
            return Config_CD.load().software.pageSizeSearch;
        }
        private static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });
            var enumarableType = typeof(System.Linq.Queryable);
            var method = enumarableType.GetMethods().Where(m => m.Name == "OrderBy" && m.IsGenericMethodDefinition).Where(m =>
            {
                var parameters = m.GetParameters().ToList();
                return parameters.Count == 2;
            }).Single();
            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);
            var newQuery = (IOrderedQueryable<TSource>)genericMethod.Invoke(genericMethod, new object[] { query, selector });
            return newQuery;
        }
        private static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });
            var enumarableType = typeof(System.Linq.Queryable);
            var method = enumarableType.GetMethods().Where(m => m.Name == "OrderByDescending" && m.IsGenericMethodDefinition).Where(m =>
            {
                var parameters = m.GetParameters().ToList();
                return parameters.Count == 2;
            }).Single();
            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);
            var newQuery = (IOrderedQueryable<TSource>)genericMethod.Invoke(genericMethod, new object[] { query, selector });
            return newQuery;
        }
        //----------------------------------------------------------------------------------------------------------------
    }
}
