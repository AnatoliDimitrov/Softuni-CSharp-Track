namespace SMS.Services
{
    using SMS.Models.Products;
    using SMS.Models.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        public ICollection<string> ValidateRegistration(UserRegisterForm model);

        public ICollection<string> ValidateProduct(CreateProductForm model);
    }
}
