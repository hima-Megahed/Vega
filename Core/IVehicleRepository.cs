using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Core.Models;

namespace Vega.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleWithFeaturesAndModels(int id, bool includeRelated = true);
        Task<Vehicle> GetVehicleWithFeatures(int id);
        Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery vehicleQuery);
        void AddVehicle(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);
    }
}