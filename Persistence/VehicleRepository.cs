using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resource;
using Vega.Core;
using Vega.Core.Models;
using Vega.Extensions;

namespace Vega.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext _vegaDbContext;

        public VehicleRepository(VegaDbContext vegaDbContext)
        {
            _vegaDbContext = vegaDbContext;
        }

        public async Task<Vehicle> GetVehicleWithFeaturesAndModels(int id, bool includeRelated = true)
        {
            if (includeRelated == false)
                return await _vegaDbContext.Vehicles.FindAsync(id);
            
            return await _vegaDbContext.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(m => m.Manufacturer)
                .SingleOrDefaultAsync(v => v.Id == id);
        }
        public async Task<Vehicle> GetVehicleWithFeatures(int id)
        {
            return await _vegaDbContext.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery vehicleQuery)
        {
            var result = new QueryResult<Vehicle>();

            var query = _vegaDbContext.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(m => m.Manufacturer).AsQueryable();

            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>
            {
                ["manufacturer"] = v => v.Model.Manufacturer.Name,
                ["model"] = v => v.Model.Name,
                ["contactName"] = v => v.ContactName
            };

            query = query.ApplyFiltering(vehicleQuery);

            query = query.ApplyOrdering(vehicleQuery, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(vehicleQuery);

            result.Items = await query.ToListAsync();

            return result;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vegaDbContext.Vehicles.Add(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            _vegaDbContext.Remove(vehicle);
        }
    }
}