using System.Collections.Generic;

namespace SMS.Models.Users
{
    public class ProductsViewModel
    {
        public string Username { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
