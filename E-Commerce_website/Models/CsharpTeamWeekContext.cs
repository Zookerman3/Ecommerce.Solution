using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSite.Models
{
  [NotMapped]
  public class EcommerceSiteContext : IdentityDbContext<ApplicationUser>
  {

    // public ProductContext()
    //   : base("WingtipToys")
    // {
    // }

    // public DbSet<Product> Products { get; set; } needed?
    public DbSet<Order> Orders { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<AppuserProduct> AppuserProducts { get; set; }

    public EcommerceSiteContext(DbContextOptions<EcommerceSiteContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      // Configure your model here
    }
  }
}
