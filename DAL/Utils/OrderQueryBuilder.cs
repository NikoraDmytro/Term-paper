using System.Linq.Expressions;

namespace DAL.Utils
{
    public static class OrderQueryBuilder
    {
        public static IOrderedQueryable<T>?
            CreateOrderQuery<T>(IQueryable<T> query, string orderBy)
        {
            string? property = orderBy.Split(" ").FirstOrDefault();

            if (string.IsNullOrEmpty(property))
            {
                return null;
            }

            var propertyInfo = typeof(T).GetProperty(property);
            bool isDescending = orderBy.EndsWith("desc");

            if (propertyInfo == null)
            {
                return null;
            }
            
            if (isDescending)
            {
                return query.OrderByDescending(
                    x => propertyInfo.GetValue(x));
            }
            
            return query.OrderBy(x => propertyInfo.GetValue(x));
        }
    }
}