using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSite.Models
{

  [NotMapped]
  public class ApiHelper
  {
    public static async Task<string> GetAll(string page = "", bool showAll = false)
    {
      RestClient client = new RestClient("http://localhost:5114/");
    string queryString = $"{page}{(showAll ?  "&showAll=true" : "")}"; // creates a new variable named queryString which takes an optional parameter of page and an optional parameter of showAll. showAll remains false unless explicitly passed in as true.
      RestRequest request = new RestRequest($"api/products?{queryString}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5114/");
      RestRequest request = new RestRequest($"api/products/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newProduct)
    {
      RestClient client = new RestClient("http://localhost:5114/");
      RestRequest request = new RestRequest($"api/products", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newProduct);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newProduct)
    {
      RestClient client = new RestClient("http://localhost:5114/");
      RestRequest request = new RestRequest($"api/products/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newProduct);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5114/");
      RestRequest request = new RestRequest($"api/products/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }

    [HttpPost(Name = "Post")]
    public static async void PostNewUser(string newApplicationUser, string jsonApplicationUser)
    {
      RestClient client = new RestClient("http://localhost:5114/");
      RestRequest request = new RestRequest($"api/products", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newApplicationUser);
      await client.PostAsync(request);
    }
  }
}