using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSite.Models
{
  [NotMapped]
  public class Review
  {

    public int ReviewId { get; set; }
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    
    [StringLength(120)]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string user_name { get; set; }
  }
}

