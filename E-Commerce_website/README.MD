    <a href="@Url.Action("Index", "Products", new { type = "CPU", showAll = true })">View CPU Products</a>
    <a href="@Url.Action("Index", "Products", new { type = "GPU", showAll = true })">View GPU Products</a>
    <a href="@Url.Action("Index", "Products", new { type = "RAM", showAll = true })">View RAM Products</a>
    <a href="@Url.Action("Index", "Products", new { type = "Motherboard", showAll = true })">View Motherboard Products</a>
    <a href="@Url.Action("Index", "Products", new { type = "PSU", showAll = true })">View PSU Products</a>
    <a href="@Url.Action("Index", "Products", new { type = "FAN", showAll = true })">View Fan Products</a>
    <a href="@Url.Action("Index", "Products", new { type = "CASE", showAll = true })">View Case Products</a>
    <a href="@Url.Action("Index", "Products", new { type = "SSD", showAll = true })">View SSD Products</a>




  public async Task<IActionResult> Index(string query, bool showAll, string type = null)
  {
    // if (string.IsNullOrEmpty(query))
    // {
    //   List<Product> products = Product.GetProducts(query, showAll);
    //   return View("Index", products);
    // }

    if (string.IsNullOrEmpty(query))
    {
      List<Product> products = Product.GetProducts(query, showAll);

      if (!string.IsNullOrEmpty(type))
      {
        products = products.Where(p => p.Type == type).ToList();
      }

      return View("Index", products);
    }

    HttpClient client = new HttpClient();
    string url = "https://api.example.com/products";

    if (!string.IsNullOrEmpty(query))
    {
      List<Product> products = Product.GetProducts(query, showAll);
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
