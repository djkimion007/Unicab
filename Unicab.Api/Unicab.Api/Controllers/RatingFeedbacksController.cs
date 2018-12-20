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
    public class RatingFeedbacksController : ControllerBase
    {
        private readonly UnicabContext _context;

        public RatingFeedbacksController(UnicabContext context)
        {
            _context = context;
        }

        // GET: api/RatingFeedbacks
        [HttpGet]
        public IEnumerable<RatingFeedback> GetRatingFeedbacks()
        {
            return _context.RatingFeedbacks;
        }

        // GET: api/RatingFeedbacks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRatingFeedback([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ratingFeedback = await _context.RatingFeedbacks.FindAsync(id);

            if (ratingFeedback == null)
            {
                return NotFound();
            }

            return Ok(ratingFeedback);
        }

        // PUT: api/RatingFeedbacks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatingFeedback([FromRoute] int id, [FromBody] RatingFeedback ratingFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ratingFeedback.RatingFeedbackId)
            {
                return BadRequest();
            }

            _context.Entry(ratingFeedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingFeedbackExists(id))
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

        // POST: api/RatingFeedbacks
        [HttpPost]
        public async Task<IActionResult> PostRatingFeedback([FromBody] RatingFeedback ratingFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RatingFeedbacks.Add(ratingFeedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatingFeedback", new { id = ratingFeedback.RatingFeedbackId }, ratingFeedback);
        }

        // DELETE: api/RatingFeedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRatingFeedback([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ratingFeedback = await _context.RatingFeedbacks.FindAsync(id);
            if (ratingFeedback == null)
            {
                return NotFound();
            }

            _context.RatingFeedbacks.Remove(ratingFeedback);
            await _context.SaveChangesAsync();

            return Ok(ratingFeedback);
        }

        private bool RatingFeedbackExists(int id)
        {
            return _context.RatingFeedbacks.Any(e => e.RatingFeedbackId == id);
        }
    }
}