using Microsoft.EntityFrameworkCore;
using Review_Auction.Model;

namespace Review_Auction.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
