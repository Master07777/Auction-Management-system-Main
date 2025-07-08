using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Review_Auction.Data;
using Review_Auction.Dtos;
using Review_Auction.Model;

namespace Review_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        // Read/Fetching Reviews
        [HttpGet("Product/{ProductId}")]
        public async Task<ActionResult<ReviewResponseDto>> GetReviewsForProduct(int ProductId)
        {
            var reviews = await _context.Reviews
                            .Where(u => u.ProductId == ProductId)
                            .Include(r => r.User)
                            .Select(r => new ReviewResponseDto
                            {
                                ReviewId = r.ReviewId,
                                Rating = r.Rating,
                                UserName = r.User.Name,
                                Comment = r.Comment
                            })
                            .ToListAsync();
            return Ok(reviews);
        }

        // Creating Reviews 
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
        {
            var review = new Review
            {
                Comment = dto.Comment,
                Rating = dto.Rating,
                UserId = dto.UserID,
                ProductId = dto.ProductId
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return Ok("Successfully Review Added");
        }

        // Delete Reviews
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null) return NotFound();

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }


        // Update Reviews
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateReview(int id, [FromBody] CreateReviewDto dto)
        {
            var review = await _context.Reviews.FindAsync(id);
            if(review == null) return NotFound();

            review.Comment = dto.Comment;
            review.Rating = dto.Rating;

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            return Ok("Updated Successfully");
        }

    }
}
