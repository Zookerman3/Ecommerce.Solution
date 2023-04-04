
namespace EcommerceSite.Models;

public class ShoppingCart
{
    public int ShoppingCartId { get; set; }

    public virtual List<CartItem> CartItems { get; set; }
}
