using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review_Auction.Model
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Comment { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }


        // RELATION
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
