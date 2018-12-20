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
    public class DriverBlacklistsController : ControllerBase
    {
        private readonly UnicabContext _context;

        public DriverBlacklistsController(UnicabContext context)
        {
            _context = context;
        }

        // GET: api/DriverBlacklists
        [HttpGet]
        public IEnumerable<DriverBlacklist> GetDriverBlacklists()
        {
            return _context.DriverBlacklists;
        }

        // GET: api/DriverBlacklists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverBlacklist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driverBlacklist = await _context.DriverBlacklists.FindAsync(id);

            if (driverBlacklist == null)
            {
                return NotFound();
            }

            return Ok(driverBlacklist);
        }

        // PUT: api/DriverBlacklists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverBlacklist([FromRoute] int id, [FromBody] DriverBlacklist driverBlacklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driverBlacklist.DriverBlacklistId)
            {
                return BadRequest();
            }

            _context.Entry(driverBlacklist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverBlacklistExists(id))
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

        // POST: api/DriverBlacklists
        [HttpPost]
        public async Task<IActionResult> PostDriverBlacklist([FromBody] DriverBlacklist driverBlacklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DriverBlacklists.Add(driverBlacklist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriverBlacklist", new { id = driverBlacklist.DriverBlacklistId }, driverBlacklist);
        }

        // DELETE: api/DriverBlacklists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverBlacklist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driverBlacklist = await _context.DriverBlacklists.FindAsync(id);
            if (driverBlacklist == null)
            {
                return NotFound();
            }

            _context.DriverBlacklists.Remove(driverBlacklist);
            await _context.SaveChangesAsync();

            return Ok(driverBlacklist);
        }

        private bool DriverBlacklistExists(int id)
        {
            return _context.DriverBlacklists.Any(e => e.DriverBlacklistId == id);
        }
    }
}