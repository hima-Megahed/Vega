using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resource;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public ManufacturersController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufacturerResource>>> GetManufacturers()
        {
            var manufacturers = await _context.Manufacturers.Include(m => m.Models).ToListAsync();

            return _mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ManufacturerResource>>(manufacturers).ToList();
        }

        //// GET: api/Manufacturers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Manufacturer>> GetManufacturer(int id)
        //{
        //    var manufacturer = await _context.Manufacturers.FindAsync(id);

        //    if (manufacturer == null)
        //    {
        //        return NotFound();
        //    }

        //    return manufacturer;
        //}

        //// PUT: api/Manufacturers/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutManufacturer(int id, Manufacturer manufacturer)
        //{
        //    if (id != manufacturer.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(manufacturer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ManufacturerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Manufacturers
        //[HttpPost]
        //public async Task<ActionResult<Manufacturer>> PostManufacturer(Manufacturer manufacturer)
        //{
        //    _context.Manufacturers.Add(manufacturer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetManufacturer", new { id = manufacturer.Id }, manufacturer);
        //}

        //// DELETE: api/Manufacturers/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Manufacturer>> DeleteManufacturer(int id)
        //{
        //    var manufacturer = await _context.Manufacturers.FindAsync(id);
        //    if (manufacturer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Manufacturers.Remove(manufacturer);
        //    await _context.SaveChangesAsync();

        //    return manufacturer;
        //}

        //private bool ManufacturerExists(int id)
        //{
        //    return _context.Manufacturers.Any(e => e.Id == id);
        //}
    }
}
