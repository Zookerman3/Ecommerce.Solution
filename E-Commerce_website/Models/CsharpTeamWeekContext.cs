using Microsoft.EntityFrameworkCore;

namespace CsharpTeamWeek.Models
{
  public class CsharpTeamWeekContext : DbContext
  {
    // public ProductContext()
    //   : base("WingtipToys")
    // {
    // }
    
    // public DbSet<Product> Products { get; set; } needed?
    public DbSet<CartItem> ShoppingCartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
  }
}