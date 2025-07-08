using Review_Auction.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review_Auction.Dtos
{
    public class ReviewResponseDto
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }

    }
}
