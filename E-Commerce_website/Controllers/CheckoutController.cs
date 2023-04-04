using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EcommerceSite.Models;

namespace EcommerceSite.Controllers;

public class CheckoutController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public CheckoutController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }
}
