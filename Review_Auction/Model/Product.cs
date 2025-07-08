namespace Review_Auction.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public string Baseprice { get; set; }
        public string Expectedprice { get; set; }
    }
}
