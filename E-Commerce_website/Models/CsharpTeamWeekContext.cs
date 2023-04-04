using Microsoft.EntityFrameworkCore;

namespace CsharpTeamWeek.Models
{
  public class CsharpTeamWeekContext : DbContext
  {
    public CsharpTeamWeekContext(DbContextOptions<CsharpTeamWeekContext> options)
        : base(options)
    {
    }
    // public ProductContext()
    //   : base("WingtipToys")
    // {
    // }

    // public DbSet<Product> Products { get; set; } needed?
    public DbSet<CartItem> ShoppingCartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      // Configure your model here
    }
  }
}