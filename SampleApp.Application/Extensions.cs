using SampleApp.Application.Common.Exceptions;
using System.Linq.Expressions;

namespace SampleApp.Application;

internal static class Extensions
{
    public static IQueryable<T> OrderDescendingDynamic<T>(this IQueryable<T> Data, string propToOrder)
    {
        if (typeof(T).GetProperty(propToOrder) == null)
            throw new SortException(propToOrder, typeof(T));
        var param = Expression.Parameter(typeof(T));
        var memberAccess = Expression.Property(param, propToOrder);
        var convertedMemberAccess = Expression.Convert(memberAccess, typeof(object));
        var orderPredicate = Expression.Lambda<Func<T, object>>(convertedMemberAccess, param);

        return Data.OrderByDescending(orderPredicate);
    }
}

