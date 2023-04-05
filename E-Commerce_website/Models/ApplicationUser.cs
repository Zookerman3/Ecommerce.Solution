using Microsoft.AspNetCore.Identity;

namespace EcommerceSite.Models
{
  public class ApplicationUser : IdentityUser
  {
    public List<AppuserProduct> JoinEntites { get; }
  }
}