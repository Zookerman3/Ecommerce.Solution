using Microsoft.AspNetCore.Mvc;
using EcommerceSite.Models;

namespace TravelAPIClient.Controllers;

public class ProductsController : Controller
{
  public IActionResult Index()
  {
    List<Product> products = Product.GetProducts();
    return View(products);
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
    return RedirectToAction("Details", new { id = product.ProductId});
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
