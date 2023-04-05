using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EcommerceSite.Models
{
  [NotMapped]
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

    public List<AppuserProduct> JoinEntites { get; }

    public static List<Product> GetProducts(string page, bool showAll)
    {
      Task<string> apiCallTask = ApiHelper.GetAll(page, showAll);
      string result = apiCallTask.Result;

      ApiResponse<Product> apiResponse = JsonConvert.DeserializeObject<ApiResponse<Product>>(result);

      if (apiResponse == null)
      {
        throw new Exception("Failed to deserialize API response.");
      }

      if (apiResponse.Data == null)
      {
        throw new Exception("API response did not contain any data.");
      }

      List<Product> productList = apiResponse.Data;

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