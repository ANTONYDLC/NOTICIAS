using FeedbackAPI.Data;
using FeedbackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace FeedbackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbacksController : ControllerBase
    {
        private readonly FeedbackContext _context;

        public FeedbacksController(FeedbackContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Feedback>> Get()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = feedback.Id }, feedback);
        }

        public class LikeRequest
        {
            public int FeedbackId { get; set; }
            public bool IsPositive { get; set; }
        }

        [HttpPost("like")]
        public async Task<IActionResult> Like([FromBody] LikeRequest request)
        {
            var feedback = await _context.Feedbacks.FindAsync(request.FeedbackId);
            if (feedback == null)
                return NotFound();

            if (request.IsPositive)
                feedback.LikesCount++;
            else
                feedback.DislikesCount++;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Voto registrado" });
        }
    }
}
