using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vega.Core.Models;

namespace Vega.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObject, Dictionary<string, Expression<Func<T, object>>> columnsMapping)
        {
            if (string.IsNullOrEmpty(queryObject.SortBy) || !columnsMapping.ContainsKey(queryObject.SortBy))
                return query;

            return queryObject.IsSortAscending ? 
                query.OrderBy(columnsMapping[queryObject.SortBy]) : query.OrderByDescending(columnsMapping[queryObject.SortBy]);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObject)
        {
            if (queryObject.Page <= 0)
                queryObject.Page = 1;

            if (queryObject.PageSize <= 0)
                queryObject.PageSize = 10;

            return query.Skip((queryObject.Page - 1) * queryObject.PageSize).Take(queryObject.PageSize);
        }

        public static IQueryable<Vehicle> ApplyFiltering(this IQueryable<Vehicle> query, VehicleQuery vehicleQuery)
        {
            if (vehicleQuery.ManufacturerId.HasValue)
                query = query.Where(v => v.Model.ManufacturerId == vehicleQuery.ManufacturerId.Value);

            if (vehicleQuery.ModelId.HasValue)
                query = query.Where(v => v.Model.Id == vehicleQuery.ModelId.Value);

            return query;
        }
    }
}
