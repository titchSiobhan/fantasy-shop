using Microsoft.EntityFrameworkCore;
using fantasy_shop.Models;

namespace fantasy_shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users {  get; set; }
        public DbSet<Order> Orderss { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
