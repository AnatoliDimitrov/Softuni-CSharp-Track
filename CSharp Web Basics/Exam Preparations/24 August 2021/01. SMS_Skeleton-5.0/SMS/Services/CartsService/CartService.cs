namespace SMS.Services.CartsService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SMS.Common;
    using SMS.Data;
    using SMS.Models;
    using SMS.Repositories;
    using SMS.Services.ModelsValidatorService;

    public class CartService : ICartService
    {
        private readonly IRepository repository;

        public CartService(IModelValidatorService _validator, SMSDbContext _context)
        {
            this.repository = new Repository(_context);
        }

        public ICollection<string> AddProduct(string productId, string userId)
        {
            var errors = new List<string>();

            try
            {
                var product = repository.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

                var user = repository.All<User>()
                    .FirstOrDefault(p => p.Id == userId);

                product.CartId = user.CartId;

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }

        public (ICollection<string> errors, ICollection<Product>) CartDetails(string userId)
        {
            var errors = new List<string>();
            var products = new List<Product>();

            try
            {
                var user = this.repository.All<User>()
                .FirstOrDefault(p => p.Id == userId);

                products = this.repository.All<Product>()
                    .Where(p => p.CartId == user.CartId)
                    .ToList();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return (errors, products);
        }



        public ICollection<string> BuyProducts(string userId)
        {
            var errors = new List<string>();

            try
            {
                var user = this.repository.All<User>()
                .FirstOrDefault(p => p.Id == userId);

                this.repository.All<Product>()
                    .Where(p => p.CartId == user.CartId)
                    .ToList()
                    .ForEach(p => p.CartId = null);

                this.repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }
    }
}
