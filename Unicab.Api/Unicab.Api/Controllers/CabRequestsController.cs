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
    public class CabRequestsController : ControllerBase
    {
        private readonly UnicabContext _context;

        public CabRequestsController(UnicabContext context)
        {
            _context = context;
        }

        // GET: api/CabRequests
        [HttpGet]
        public IEnumerable<CabRequest> GetCabRequests()
        {
            return _context.CabRequests
                .Include(requests => requests.PickUpLocation)
                .Include(requests => requests.DropOffLocation)
                .Include(requests => requests.Passenger);
        }

        // GET: api/CabRequests/ByPassengerId/5
        [HttpGet("ByPassengerId/{id}")]
        public IEnumerable<CabRequest> GetCabRequests([FromRoute] int id)
        {
            return _context.CabRequests.Where(b => b.PassengerId == id)
                .Include(requests => requests.PickUpLocation)
                .Include(requests => requests.DropOffLocation)
                .Include(requests => requests.Passenger);
        }

        // GET: api/CabRequests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCabRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabRequest = await _context.CabRequests.FindAsync(id);

            if (cabRequest == null)
            {
                return NotFound();
            }

            return Ok(cabRequest);
        }

        // PUT: api/CabRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCabRequest([FromRoute] int id, [FromBody] CabRequest cabRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cabRequest.CabRequestId)
            {
                return BadRequest();
            }

            _context.Entry(cabRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabRequestExists(id))
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

        // POST: api/CabRequests
        [HttpPost]
        public async Task<IActionResult> PostCabRequest([FromBody] CabRequest cabRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CabRequests.Add(cabRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCabRequest", new { id = cabRequest.CabRequestId }, cabRequest);
        }

        // DELETE: api/CabRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCabRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cabRequest = await _context.CabRequests.FindAsync(id);
            if (cabRequest == null)
            {
                return NotFound();
            }

            _context.CabRequests.Remove(cabRequest);
            await _context.SaveChangesAsync();

            return Ok(cabRequest);
        }

        private bool CabRequestExists(int id)
        {
            return _context.CabRequests.Any(e => e.CabRequestId == id);
        }
    }
}