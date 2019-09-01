using System.Threading.Tasks;
using Vega.Core.Models;

namespace Vega.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleWithFeaturesAndModels(int id, bool includeRelated = true);
        Task<Vehicle> GetVehicleWithFeatures(int id);
        void AddVehicle(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);
    }
}