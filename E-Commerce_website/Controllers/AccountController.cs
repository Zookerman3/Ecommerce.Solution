using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EcommerceSite.Models;
using System.Threading.Tasks;
using EcommerceSite.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSite.Controllers
{
  public class AccountController : Controller
  {
    private readonly EcommerceSiteContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, EcommerceSiteContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    // public ActionResult Login()
    // {
    //     return View();
    // }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        ApplicationUser user = new ApplicationUser { UserName = model.Email };
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
        else
        {
          foreach (IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
          return View(model);
        }
      }
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
          return RedirectToAction("Index", "Home");
        }
        else
        {
          ModelState.AddModelError("", "There is something wrong with your email or username. Please try again.");
          return View(model);
        }
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Account");
    }



    // __________________________________________________________________

    [HttpPost]
    public ActionResult AddToCart(Product product, string userId, int productId)
    {
#nullable enable
      AppuserProduct? joinEntity = _db.AppuserProducts.FirstOrDefault(join => (join.UserID == userId && join.ProductId == product.ProductId));
#nullable disable
      if (joinEntity == null && userId != null)
      {
        _db.AppuserProducts.Add(new AppuserProduct() { UserID = userId, ProductId = product.ProductId });
        // thisBook.Copies = (thisBook.Copies -1);
        _db.SaveChanges();
      }
      return RedirectToAction("Cart", new { userId = userId });
    }



            [HttpPost]
        public ActionResult RemoveFromCart(int productId, string userId)
        {
            AppuserProduct joinEntity = _db.AppuserProducts.FirstOrDefault(join => (join.UserID == userId && join.ProductId == productId));
            if (joinEntity != null)
            {
                _db.AppuserProducts.Remove(joinEntity);
                _db.SaveChanges();
            }
            return RedirectToAction("Cart", new { userId = userId });
        }

            public ActionResult Cart(string userId, string page, bool showAll = true)
    {
      List<Product> products = Product.GetProducts(page, showAll);
      ApplicationUser thisUser = _db.Users
          .Include(User => User.JoinEntites)
          .FirstOrDefault(user => user.Id == userId);

      ViewBag.Products = products;
      return View(thisUser);
    }
  }
}