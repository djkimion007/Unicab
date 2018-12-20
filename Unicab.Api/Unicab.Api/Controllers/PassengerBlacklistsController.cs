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
    public class PassengerBlacklistsController : ControllerBase
    {
        private readonly UnicabContext _context;

        public PassengerBlacklistsController(UnicabContext context)
        {
            _context = context;
        }

        // GET: api/PassengerBlacklists
        [HttpGet]
        public IEnumerable<PassengerBlacklist> GetPassengerBlacklists()
        {
            return _context.PassengerBlacklists;
        }

        // GET: api/PassengerBlacklists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassengerBlacklist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var passengerBlacklist = await _context.PassengerBlacklists.FindAsync(id);

            if (passengerBlacklist == null)
            {
                return NotFound();
            }

            return Ok(passengerBlacklist);
        }

        // PUT: api/PassengerBlacklists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassengerBlacklist([FromRoute] int id, [FromBody] PassengerBlacklist passengerBlacklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != passengerBlacklist.PassengerBlacklistId)
            {
                return BadRequest();
            }

            _context.Entry(passengerBlacklist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerBlacklistExists(id))
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

        // POST: api/PassengerBlacklists
        [HttpPost]
        public async Task<IActionResult> PostPassengerBlacklist([FromBody] PassengerBlacklist passengerBlacklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PassengerBlacklists.Add(passengerBlacklist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassengerBlacklist", new { id = passengerBlacklist.PassengerBlacklistId }, passengerBlacklist);
        }

        // DELETE: api/PassengerBlacklists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassengerBlacklist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var passengerBlacklist = await _context.PassengerBlacklists.FindAsync(id);
            if (passengerBlacklist == null)
            {
                return NotFound();
            }

            _context.PassengerBlacklists.Remove(passengerBlacklist);
            await _context.SaveChangesAsync();

            return Ok(passengerBlacklist);
        }

        private bool PassengerBlacklistExists(int id)
        {
            return _context.PassengerBlacklists.Any(e => e.PassengerBlacklistId == id);
        }
    }
}