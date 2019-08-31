using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Persistence
{
    public class VehicleRepository
    {
        private readonly VegaDbContext _vegaDbContext;

        public VehicleRepository(VegaDbContext vegaDbContext)
        {
            _vegaDbContext = vegaDbContext;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await _vegaDbContext.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(m => m.Manufacturer)
                .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}