using System.Linq.Expressions;

namespace Akhil_API.Models
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> OrderByCustom<TEntity>(this IQueryable<TEntity> items, string sortBy, string sortOrder)
        {
            var type = typeof(TEntity); //{Name = "Product" FullName = "Akhil_API.Models.Product"}
            var expression = Expression.Parameter(type, "t"); //{t}
            var property = type.GetProperty(sortBy); //{System.Decimal Price}
            var expression_two = Expression.MakeMemberAccess(expression, property); //{t.Price}
            var lamda = Expression.Lambda(expression_two, expression); //{t => t.Price}
            var result = Expression.Call(
                typeof(Queryable),
                sortOrder == "desc" ? "OrderByDescending" : "OrderBy",
                new Type[] { type, property.PropertyType },
                items.Expression,
                Expression.Quote(lamda)
                );//{[Microsoft.EntityFrameworkCore.Query.QueryRootExpression].OrderBy(t => t.Price)}
            return items.Provider.CreateQuery<TEntity>(result);
        }
    }
}
