using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EcommerceSite.Models
{
    public class EcommerceSiteContext : IdentityDbContext<ApplicationUser>
    {

        public EcommerceSiteContext(DbContextOptions options) : base(options) { }
    }
}