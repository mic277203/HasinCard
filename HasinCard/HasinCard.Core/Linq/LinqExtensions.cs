using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HasinCard.Core.Linq
{
    public static class LinqExtensions
    {
        public static List<T> ToDescPager<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> where,
            Expression<Func<T, dynamic>> orderBy, int start, int length) where T : class
        {
            if (where != null)
            {
                queryable = queryable.Where(where);
            }

            return queryable.OrderByDescending(orderBy).Skip(start).Take(length).ToList();
        }

        public static List<T> ToAscPager<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> where,
          Expression<Func<T, dynamic>> orderBy, int start, int length) where T : class
        {
            if (where != null)
            {
                queryable = queryable.Where(where);
            }

            return queryable.OrderBy(orderBy).Skip(start).Take(length).ToList();
        }
    }
}
