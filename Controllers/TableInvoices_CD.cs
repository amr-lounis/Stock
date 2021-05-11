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
    public static class TableInvoices_CD
    {
        public static IQueryable<soldinvoice> search(string _value, ref int _this_page, out string _data_out)
        {
            IQueryable<soldinvoice> query = null;
            try
            {
                var _db = Entities.GetInstance();
                query = _db.soldinvoices.Where(c =>  (c.DESCRIPTION.ToLower().Contains(_value))).OrderBy("NAME"); ;
                _data_out = SkipTake(ref _this_page, ref query);
                return query;
            }
            catch (Exception e) { _data_out = ""; return null; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static soldinvoice Get(long p_id)
        {
            try
            {
                var _db = Entities.GetInstance();
                return _db.soldinvoices.Single(c => c.ID == p_id);
            }
            catch (Exception) { return null; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static bool Add(soldinvoice _soldinvoice)
        {
            try
            {
                var _db = Entities.GetInstance();
                _db.soldinvoices.Add(_soldinvoice);
                _db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static bool Edit(soldinvoice _soldinvoice)
        {
            try
            {
                var _db = Entities.GetInstance();
                var o = Get(_soldinvoice.ID);
                o.ID_USERS = _soldinvoice.ID_USERS;
                o.ID_CUSTOMERS = _soldinvoice.ID_CUSTOMERS;
                o.DESCRIPTION = _soldinvoice.DESCRIPTION;
                o.DATE = _soldinvoice.DATE;
                o.VALIDATION = _soldinvoice.VALIDATION;
                o.MONEY_WITHOUT_ADDEDD = _soldinvoice.MONEY_WITHOUT_ADDEDD;
                o.MONEY_TAX = _soldinvoice.MONEY_TAX;
                o.MONEY_STAMP = _soldinvoice.MONEY_STAMP;
                o.MONEY_TOTAL = _soldinvoice.MONEY_TOTAL;
                o.MONEY_PAID = _soldinvoice.MONEY_PAID;
                o.MONEY_UNPAID = _soldinvoice.MONEY_UNPAID;

                _db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        //----------------------------------------------------------------------------------------------------------------
        public static bool Delete(long p_id)
        {
            try
            {
                var _db = Entities.GetInstance();
                _db.soldinvoices.Remove(_db.soldinvoices.Single(c => c.ID == p_id));
                _db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        //----------------------------------------------------------------------------------------------------------------
        private static int GetPageSize()
        {
            return Config_CD.load().software.pageSizeSearch;
        }
        //----------------------------------------------------------------------------------------------------------------
        private static string SkipTake<T>(ref int page_this, ref IQueryable<T> _query)
        {
            int page_max_size = GetPageSize();
            int _rows_all = _query.Count() - 1;
            int _page_count = (_rows_all / page_max_size);
            if (page_this < 0) page_this = 0;
            if (page_this > _page_count - 1) page_this = _page_count;
            _query = _query.Skip(page_this * page_max_size).Take(page_max_size);

            return string.Format("({0} / {1}) |{2}|", page_this + 1, _page_count + 1, _rows_all + 1);
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
