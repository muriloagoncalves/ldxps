
using System.Linq;
using System.Linq.Expressions;
using LDXPS.Domain.Paginations;

namespace LDXPS.Data.Extensions
{
    public static class QueryExtension
    {
        public static IOrderedQueryable<TSource> OrderByAscOrDesc<TSource>(this IQueryable<TSource> source, string propertyName, bool ascending)
        {
            var parameter = Expression.Parameter(typeof(TSource), "x");
            Expression property = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(property, parameter);


            var order = ascending ? "OrderBy" : "OrderByDescending";
            // REFLECTION: source.OrderBy(x => x.Property)
            var orderByMethod = typeof(Queryable).GetMethods().First(x => x.Name == order && x.GetParameters().Length == 2);
            var orderByGeneric = orderByMethod.MakeGenericMethod(typeof(TSource), property.Type);
            var result = orderByGeneric.Invoke(null, new object[] { source, lambda });

            return (IOrderedQueryable<TSource>)result;
        }

        public static IQueryable<TSource> Pagination<TSource, TEntity>(this IQueryable<TSource> source,
            Pagination<TEntity> pagination) where TEntity : class
        {
            return source
                .Skip((pagination.Page - 1) * pagination.PerPage)
                .Take(pagination.PerPage);
        }
    }
}
