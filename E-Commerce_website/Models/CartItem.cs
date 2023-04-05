using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSite.Models
{
  [NotMapped]
  public class CartItem
  {
    [Key]
    public string ItemId { get; set; }
    public string CartId { get; set; } // The CartId property specifies the ID of the user that is associated with the item to purchase. You'll add code to create this user ID when the user accesses the shopping cart. This ID will also be stored as an ASP.NET Session variable.
    public int Quantity { get; set; }
    public System.DateTime DateCreated { get; set; }
    public int ProductId { get; set; }

  }
}
