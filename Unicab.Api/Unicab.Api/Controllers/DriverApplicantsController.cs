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
    public class DriverApplicantsController : ControllerBase
    {
        private readonly UnicabContext _context;

        public DriverApplicantsController(UnicabContext context)
        {
            _context = context;
        }

        // GET: api/DriverApplicants
        [HttpGet]
        public IEnumerable<DriverApplicant> GetDriverApplicants()
        {
            return _context.DriverApplicants.Where(b => b.IsApproved != true);
        }

        // GET: api/DriverApplicants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverApplicant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driverApplicant = await _context.DriverApplicants.FindAsync(id);

            if (driverApplicant == null)
            {
                return NotFound();
            }

            return Ok(driverApplicant);
        }

        // PUT: api/DriverApplicants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverApplicant([FromRoute] int id, [FromBody] DriverApplicant driverApplicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driverApplicant.DriverApplicantId)
            {
                return BadRequest();
            }

            _context.Entry(driverApplicant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverApplicantExists(id))
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

        // POST: api/DriverApplicants
        [HttpPost]
        public async Task<IActionResult> PostDriverApplicant([FromBody] DriverApplicant driverApplicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DriverApplicants.Add(driverApplicant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriverApplicant", new { id = driverApplicant.DriverApplicantId }, driverApplicant);
        }

        // DELETE: api/DriverApplicants/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDriverApplicant([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var driverApplicant = await _context.DriverApplicants.FindAsync(id);
        //    if (driverApplicant == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DriverApplicants.Remove(driverApplicant);
        //    await _context.SaveChangesAsync();

        //    return Ok(driverApplicant);
        //}

        private bool DriverApplicantExists(int id)
        {
            return _context.DriverApplicants.Any(e => e.DriverApplicantId == id);
        }
    }
}