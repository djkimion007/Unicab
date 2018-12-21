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
    public class DriversController : ControllerBase
    {
        private readonly UnicabContext _context;

        public DriversController(UnicabContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [HttpGet]
        public IEnumerable<Driver> GetDrivers()
        {
            return _context.Drivers;
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        // GET: api/{emailAddress}/{password}
        [HttpGet("{emailAddress}/{password}")]
        public async Task<IActionResult> GetDriver([FromRoute] string emailAddress, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driver = await _context.Drivers.SingleOrDefaultAsync(b => b.EmailAddress == emailAddress);

            if (driver == null)
            {
                return NotFound();
            }

            if (driver.Password == password)
                return Ok(driver);
            else
                return Unauthorized();
        }

        // PUT: api/Drivers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver([FromRoute] int id, [FromBody] Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driver.DriverId)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // POST: api/Drivers
        [HttpPost]
        public async Task<IActionResult> PostDriver([FromBody] Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriver", new { id = driver.DriverId }, driver);
        }

        // DELETE: api/Drivers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDriver([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var driver = await _context.Drivers.FindAsync(id);
        //    if (driver == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Drivers.Remove(driver);
        //    await _context.SaveChangesAsync();

        //    return Ok(driver);
        //}

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.DriverId == id);
        }
    }
}