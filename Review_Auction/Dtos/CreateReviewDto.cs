namespace Review_Auction.Dtos
{
    public class CreateReviewDto
    {
        public string Comment { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
    }
}
