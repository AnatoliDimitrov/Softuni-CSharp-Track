using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersJson = File.ReadAllText("./../../../Datasets/users.json");
            //var productsJson = File.ReadAllText("./../../../Datasets/products.json");
            //var categoriesJson = File.ReadAllText("./../../../Datasets/categories.json");
            //var categoriesJson = File.ReadAllText("./../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context, usersJson));
            //Console.WriteLine(ImportProducts(context, productsJson));
            //Console.WriteLine(ImportCategories(context, categoriesJson));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesJson));
            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            //Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson){

            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName +  " " + p.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToArray();

            var result = JsonConvert.SerializeObject(products);

            return result.Trim();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(u => u.ProductsSold.Count(b => b.Buyer != null) > 0)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(b => b.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToArray();

            return JsonConvert.SerializeObject(sellers).TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2"),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")
                })
                .ToArray();

            return JsonConvert.SerializeObject(categories).TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(u => u.ProductsSold.Count(b => b.BuyerId != null) > 0)
                .OrderByDescending(u => u.ProductsSold.Count(b => b.BuyerId != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                        {
                            count = u.ProductsSold.Count,
                            products = u.ProductsBought
                                .Where(ps => ps != null)
                                .Select(ps => new
                                {
                                    name = ps.Name,
                                    price = ps.Price
                                })
                    }})
                .ToArray();

            var result = new
            {
                usersCount = sellers.Length,
                users = sellers
            };

            return JsonConvert.SerializeObject(result).TrimEnd();
        }
    }
}