using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSite.Models;

public class AppuserProduct
{
    public int AppuserProductId { get; set; }
    public string UserID { get; set; }
    [ForeignKey("UserID")]
    public virtual ApplicationUser ApplicationUser { get; set; }
    public int ProductId { get; set; } 
    public Product Product { get; set; }
    public DateTime CheckoutDate { get; set; }

}
