namespace SMS.Services.CartsService
{

    using System.Collections.Generic;

    using SMS.Models;

    public interface ICartService
    {
        ICollection<string> AddProduct(string productId, string userId);

        (ICollection<string> errors, ICollection<Product>) CartDetails(string userId);

        ICollection<string> BuyProducts(string userId);
    }
}
