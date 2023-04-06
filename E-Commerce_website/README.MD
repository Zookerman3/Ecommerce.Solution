@{
    decimal totalPrice = 0; // initialize the total price variable
}

<div class="cart-items">
    @foreach (Product product in ViewBag.Products)
    {
        @foreach (AppuserProduct join in Model.JoinEntites)
        {
            if (join.ProductId == product.ProductId)
            {
                <div class="cart-item">
                    <img style="max-height: 150px; min-height: 150px; max-width: 200px; object-fit: contain;" src="@product.ImageLink"
                        alt="@product.Name">
                    <br>
                    <br>
                    $@product.Price <br><strong>@product.Name</strong> <br>
                    <a href="/Products/Details/@(product.ProductId)">View Details</a>
                     @using (Html.BeginForm("RemoveFromCart", "Account", new { productId = product.ProductId, userId = join.UserID }, FormMethod.Post))
{
    <input type="submit" value="Remove from Cart" />
}
                </div>

                totalPrice += product.Price; // add the current product's price to the total price
            }
        }
    }
    <p> Cart total: $@totalPrice </p> <!-- display the total price -->
</div>
  <div class="checkout-container">
    <div id="smart-button-container">
      @* <div style="text-align: center"><label for="description">Total cost: </label><input type="text"
      name="descriptionInput" id="description" maxlength="127" value=""></div> *@
      @* <p id="descriptionError" style="visibility: hidden; color:red; text-align: center;">Please enter a
      description</p>
      *@
      <div style="text-align: center"><label for="amount">Total: </label>
      <input name="amountInput" type="number" id="amount" value=@totalPrice><span> USD</span></div>