namespace SMS.Services.ProductsService
{
    using SMS.Models.Products;
    using System.Collections.Generic;
    public interface IProductService
    {
        ICollection<string> Validate(CreateProductForm model);

        ICollection<string> CreateProduct(CreateProductForm model);
    }
}
