namespace SMS.Services.ProductsService
{
    using System;
    using System.Collections.Generic;
    using SMS.Common;
    using SMS.Data;
    using SMS.Models;
    using SMS.Models.Products;
    using SMS.Repositories;
    using SMS.Services.ModelsValidatorService;

    public class ProductService : IProductService
    {
        private readonly IRepository repository;
        private readonly IModelValidatorService validator;

        public ProductService(IModelValidatorService _validator, SMSDbContext _context)
        {
            this.repository = new Repository(_context);
            validator = _validator;
        }


        public ICollection<string> Validate(CreateProductForm model)
        {
            var errors = validator.ValidateModel(model);
            var isDecimal = decimal.TryParse(model.Price, out decimal result);

            if (!isDecimal || result < 0.05m || result > 1000)
            {
                errors.Add("Price must be between 0.05 and 1000 inclusive");
            }

            return errors;
        }

        public ICollection<string> CreateProduct(CreateProductForm model)
        {
            var errors = this.Validate(model);

            if (errors.Count > 0)
            {
                return errors;
            }

            try
            {
                this.repository
                    .Add(new Product()
                    {
                        Name = model.Name,
                        Price = decimal.Parse(model.Price)
                    });

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }
    }
}
