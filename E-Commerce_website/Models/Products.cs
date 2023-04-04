using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CsharpTeamWeek.Models
{
  public class Product
  {

    public int ProductId { get; set; }
    public string Brand { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public string ImageLink { get; set; }
    public virtual List<Review> Reviews { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? ReviewCount { get; set; }
    public void UpdateReviewCount()
    {
        ReviewCount = Reviews?.Count ?? 0;
    }
  }
}