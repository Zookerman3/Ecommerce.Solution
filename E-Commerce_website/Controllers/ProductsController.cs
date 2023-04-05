using Microsoft.AspNetCore.Mvc;
using EcommerceSite.Models;


namespace EcommerceSite.Controllers;

public class ProductsController : Controller
{

  public async Task<IActionResult> Index(string query)
  {
    if (string.IsNullOrEmpty(query))
    {
      List<Product> products = Product.GetProducts(query);
      return View("Index", products);
    }

    HttpClient client = new HttpClient();
    string url = "https://api.example.com/products";

    if (!string.IsNullOrEmpty(query))
    {
      List<Product> products = Product.GetProducts(query);
      return View("Index", products);
    }

    HttpResponseMessage response = await client.GetAsync(url);

    if (response.IsSuccessStatusCode)
    {
      List<Product> products = await response.Content.ReadFromJsonAsync<List<Product>>();
      return View(products);
    }
    else
    {
      // handle the error response
      return View("Error");
    }
  }

  public IActionResult Details(int id)
  {
    Product product = Product.GetDetails(id);
    return View(product);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Product product)
  {
    Product.Post(product);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Product product = Product.GetDetails(id);
    return View(product);
  }

  [HttpPost]
  public ActionResult Edit(Product product)
  {
    Product.Put(product);
    return RedirectToAction("Details", new { id = product.ProductId });
  }

  public ActionResult Delete(int id)
  {
    Product product = Product.GetDetails(id);
    return View(product);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Product.Delete(id);
    return RedirectToAction("Index");
  }
}
