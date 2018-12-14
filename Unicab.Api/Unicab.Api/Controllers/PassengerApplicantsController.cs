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
    public class PassengerApplicantsController : ControllerBase
    {
        private readonly UsersContext _context;

        public PassengerApplicantsController(UsersContext context)
        {
            _context = context;
        }

        // GET: api/PassengerApplicants
        [HttpGet]
        public IEnumerable<PassengerApplicant> GetPassengerApplicants()
        {
            return _context.PassengerApplicants.Where(b => b.IsApproved != true);
        }

        // GET: api/PassengerApplicants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassengerApplicant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var passengerApplicant = await _context.PassengerApplicants.FindAsync(id);

            if (passengerApplicant == null)
            {
                return NotFound();
            }

            return Ok(passengerApplicant);
        }

        // PUT: api/PassengerApplicants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassengerApplicant([FromRoute] int id, [FromBody] PassengerApplicant passengerApplicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != passengerApplicant.PassengerApplicantId)
            {
                return BadRequest();
            }

            _context.Entry(passengerApplicant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerApplicantExists(id))
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

        // POST: api/PassengerApplicants
        [HttpPost]
        public async Task<IActionResult> PostPassengerApplicant([FromBody] PassengerApplicant passengerApplicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PassengerApplicants.Add(passengerApplicant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassengerApplicant", new { id = passengerApplicant.PassengerApplicantId }, passengerApplicant);
        }

        // DELETE: api/PassengerApplicants/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePassengerApplicant([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var passengerApplicant = await _context.PassengerApplicants.FindAsync(id);
        //    if (passengerApplicant == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PassengerApplicants.Remove(passengerApplicant);
        //    await _context.SaveChangesAsync();

        //    return Ok(passengerApplicant);
        //}

        private bool PassengerApplicantExists(int id)
        {
            return _context.PassengerApplicants.Any(e => e.PassengerApplicantId == id);
        }
    }
}