using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EcommerceSite.Models
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

        public static List<Product> GetProducts()
    {
      Task<string> apiCallTask = ApiHelper.GetAll();
      string result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(jsonResponse.ToString());

      return productList;
    }

    public static Product GetDetails(int id)
    {
      Task<string> apiCallTask = ApiHelper.Get(id);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Product product = JsonConvert.DeserializeObject<Product>(jsonResponse.ToString());

      return product;
    }

    public static void Post(Product product)
    {
      string jsonProduct = JsonConvert.SerializeObject(product);
      ApiHelper.Post(jsonProduct);
    }

    public static void Put(Product product)
    {
      string jsonProduct = JsonConvert.SerializeObject(product);
      ApiHelper.Put(product.ProductId, jsonProduct);
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  }
}