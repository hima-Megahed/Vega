using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Core;
using Vega.Core.Models;

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