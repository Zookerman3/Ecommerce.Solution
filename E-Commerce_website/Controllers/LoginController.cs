using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EcommerceSite.Models;

namespace EcommerceSite.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public LoginController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}