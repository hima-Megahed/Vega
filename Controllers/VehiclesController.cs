using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resource;
using Vega.Core;
using Vega.Core.Models;

namespace Vega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource saveVehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            _vehicleRepository.AddVehicle(vehicle);
            await _unitOfWork.SaveChangesAsync();

            vehicle = await _vehicleRepository.GetVehicleWithFeaturesAndModels(vehicle.Id);

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource saveVehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await _vehicleRepository.GetVehicleWithFeatures(id);

            if (vehicle == null)
                return NotFound();

            _mapper.Map(saveVehicleResource, vehicle);

            vehicle.LastUpdate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            vehicle = await _vehicleRepository.GetVehicleWithFeaturesAndModels(id);


            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleWithFeaturesAndModels(id, false);

            if (vehicle == null)
                return NotFound();

            _vehicleRepository.RemoveVehicle(vehicle);
            await _unitOfWork.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleWithFeaturesAndModels(id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

        [HttpGet]
        public async Task<QueryResultResource<VehicleResource>> GetVehicles([FromQuery]VehicleQueryResource vehicleQueryResource)
        {
            var filter = _mapper.Map<VehicleQueryResource, VehicleQuery>(vehicleQueryResource);

            var queryResult = await _vehicleRepository.GetVehicles(filter);

            return _mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>(queryResult);
        }
    }
}