using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unicab.Api.Contexts;
using Unicab.Api.Models;

namespace Unicab.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabRequestFulfillmentsController : ControllerBase
    {
        private readonly UnicabContext _context;

        public CabRequestFulfillmentsController(UnicabContext context)
        {
            _context = context;
        }

        // GET: api/CabRequestFulfillments
        [HttpGet]
        public IEnumerable<CabRequestFulfillment> GetCabRequestFulfillments()
        {
            return _context.CabRequestFulfillments;
        }

        // GET: api/CabRequestFulfillments
        [HttpGet("FulfillmentByDriverId/{id}")]
        public IEnumerable<CabRequestFulfillment> GetCabRequestFulfillments([FromRoute] int id)
        {
            return _context.CabRequestFulfillments.Where(b => b.DriverId == id && b.DriverHasCompleted != true)
                .Include(p => p.CabRequest)
                    .ThenInclude(q => q.DropOffLocation)
                .Include(p => p.CabRequest)
                    .ThenInclude(q => q.PickUpLocation)
                .Include(p => p.CabRequest)
                    .ThenInclude(q => q.Passenger);
        }

        // GET: api/CabRequestFulfillments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCabRequestFulfillment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabRequestFulfillment = await _context.CabRequestFulfillments.FindAsync(id);

            if (cabRequestFulfillment == null)
            {
                return NotFound();
            }

            return Ok(cabRequestFulfillment);
        }

        // PUT: api/CabRequestFulfillments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCabRequestFulfillment([FromRoute] int id, [FromBody] CabRequestFulfillment cabRequestFulfillment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cabRequestFulfillment.CabRequestFulfillmentId)
            {
                return BadRequest();
            }

            _context.Entry(cabRequestFulfillment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabRequestFulfillmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CabRequestFulfillments
        [HttpPost]
        public async Task<IActionResult> PostCabRequestFulfillment([FromBody] CabRequestFulfillment cabRequestFulfillment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CabRequestFulfillments.Add(cabRequestFulfillment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCabRequestFulfillment", new { id = cabRequestFulfillment.CabRequestFulfillmentId }, cabRequestFulfillment);
        }

        // DELETE: api/CabRequestFulfillments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCabRequestFulfillment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabRequestFulfillment = await _context.CabRequestFulfillments.FindAsync(id);
            if (cabRequestFulfillment == null)
            {
                return NotFound();
            }

            _context.CabRequestFulfillments.Remove(cabRequestFulfillment);
            await _context.SaveChangesAsync();

            return Ok(cabRequestFulfillment);
        }

        private bool CabRequestFulfillmentExists(int id)
        {
            return _context.CabRequestFulfillments.Any(e => e.CabRequestFulfillmentId == id);
        }
    }
}