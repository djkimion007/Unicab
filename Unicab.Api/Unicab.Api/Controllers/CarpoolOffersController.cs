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
    public class CarpoolOffersController : ControllerBase
    {
        private readonly UnicabContext _context;

        public CarpoolOffersController(UnicabContext context)
        {
            _context = context;
        }

        // GET: api/CarpoolOffers
        [HttpGet]
        public IEnumerable<CarpoolOffer> GetCarpoolOffers()
        {
            return _context.CarpoolOffers;
        }

        //// GET: api/CarpoolOffers/ByDriverId/5
        //[HttpGet("ByDriverId/{id}")]
        //public IEnumerable<CarpoolOffer> GetCarpoolOffers([FromRoute] int id)
        //{
        //    return _context.CarpoolOffers.Where(b => b.OfferDriver.DriverId == id);
        //}

        // GET: api/CarpoolOffers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarpoolOffer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carpoolOffer = await _context.CarpoolOffers.FindAsync(id);

            if (carpoolOffer == null)
            {
                return NotFound();
            }

            return Ok(carpoolOffer);
        }

        // PUT: api/CarpoolOffers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarpoolOffer([FromRoute] int id, [FromBody] CarpoolOffer carpoolOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carpoolOffer.CarpoolOfferId)
            {
                return BadRequest();
            }

            _context.Entry(carpoolOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarpoolOfferExists(id))
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

        // POST: api/CarpoolOffers
        [HttpPost]
        public async Task<IActionResult> PostCarpoolOffer([FromBody] CarpoolOffer carpoolOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CarpoolOffers.Add(carpoolOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarpoolOffer", new { id = carpoolOffer.CarpoolOfferId }, carpoolOffer);
        }

        // DELETE: api/CarpoolOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarpoolOffer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carpoolOffer = await _context.CarpoolOffers.FindAsync(id);
            if (carpoolOffer == null)
            {
                return NotFound();
            }

            _context.CarpoolOffers.Remove(carpoolOffer);
            await _context.SaveChangesAsync();

            return Ok(carpoolOffer);
        }

        private bool CarpoolOfferExists(int id)
        {
            return _context.CarpoolOffers.Any(e => e.CarpoolOfferId == id);
        }
    }
}