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
    public class CarpoolOfferFulfillmentsController : ControllerBase
    {
        private readonly UnicabContext _context;

        public CarpoolOfferFulfillmentsController(UnicabContext context)
        {
            _context = context;
        }

        // GET: api/CarpoolOfferFulfillments
        [HttpGet]
        public IEnumerable<CarpoolOfferFulfillment> GetCarpoolOfferFulfillments()
        {
            return _context.CarpoolOfferFulfillments;
        }

        // GET: api/CarpoolOfferFulfillments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarpoolOfferFulfillment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carpoolOfferFulfillment = await _context.CarpoolOfferFulfillments.FindAsync(id);

            if (carpoolOfferFulfillment == null)
            {
                return NotFound();
            }

            return Ok(carpoolOfferFulfillment);
        }

        // PUT: api/CarpoolOfferFulfillments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarpoolOfferFulfillment([FromRoute] int id, [FromBody] CarpoolOfferFulfillment carpoolOfferFulfillment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carpoolOfferFulfillment.CarpoolOfferFulfillmentId)
            {
                return BadRequest();
            }

            _context.Entry(carpoolOfferFulfillment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarpoolOfferFulfillmentExists(id))
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

        // POST: api/CarpoolOfferFulfillments
        [HttpPost]
        public async Task<IActionResult> PostCarpoolOfferFulfillment([FromBody] CarpoolOfferFulfillment carpoolOfferFulfillment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CarpoolOfferFulfillments.Add(carpoolOfferFulfillment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarpoolOfferFulfillment", new { id = carpoolOfferFulfillment.CarpoolOfferFulfillmentId }, carpoolOfferFulfillment);
        }

        // DELETE: api/CarpoolOfferFulfillments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarpoolOfferFulfillment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carpoolOfferFulfillment = await _context.CarpoolOfferFulfillments.FindAsync(id);
            if (carpoolOfferFulfillment == null)
            {
                return NotFound();
            }

            _context.CarpoolOfferFulfillments.Remove(carpoolOfferFulfillment);
            await _context.SaveChangesAsync();

            return Ok(carpoolOfferFulfillment);
        }

        private bool CarpoolOfferFulfillmentExists(int id)
        {
            return _context.CarpoolOfferFulfillments.Any(e => e.CarpoolOfferFulfillmentId == id);
        }
    }
}