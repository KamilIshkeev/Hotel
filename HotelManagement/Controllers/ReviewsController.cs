using HotelManagement.Interfaces;
using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            var createdReview = await _reviewService.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetReview), new { id = createdReview.Id }, createdReview);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            var existingReview = await _reviewService.GetReviewByIdAsync(id);
            if (existingReview == null)
            {
                return NotFound();
            }

            await _reviewService.UpdateReviewAsync(review);

            return NoContent();
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
