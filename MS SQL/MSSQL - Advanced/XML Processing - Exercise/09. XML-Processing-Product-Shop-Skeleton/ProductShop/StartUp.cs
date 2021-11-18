using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //ResetDatabase(context);

            //var importUsersXML = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context, importUsersXML));

            //var importProductsXML = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, importProductsXML));

            //var importCategoriesXML = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, importCategoriesXML));

            var importCategoriesProductsXML = File.ReadAllText("../../../Datasets/categories-products.xml");
            Console.WriteLine(ImportCategoryProducts(context, importCategoriesProductsXML));
        }

        private static void ResetDatabase(ProductShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            Console.WriteLine("Reset Database Successful");
        }

        private static void CreateMapper()
        {
            MapperConfiguration configuration = new MapperConfiguration(c =>
            {
                c.AddProfile(new ProductShopProfile());
            });

            mapper = new Mapper(configuration);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            CreateMapper();

            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]) ,root);

            using StringReader reader = new StringReader(inputXml);

            ImportUserDto[] dtos = (ImportUserDto[])serializer.Deserialize(reader);

            context.Users
                .AddRange(mapper.Map<IEnumerable<User>>(dtos));

            context.SaveChanges();

            return $"Successfully imported {dtos.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            CreateMapper();

            XmlRootAttribute root = new XmlRootAttribute("Products");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            var dtos = (ImportProductDto[])serializer.Deserialize(reader);

            context.Products
                .AddRange(mapper.Map<IEnumerable<Product>>(dtos));

            context.SaveChanges();

            return $"Successfully imported {dtos.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            CreateMapper();

            XmlRootAttribute root = new XmlRootAttribute("Categories");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            var dtos = (ImportCategoryDto[])serializer.Deserialize(reader);

            var categories = new List<Category>();

            foreach (ImportCategoryDto dto in dtos)
            {
                if (dto.Name == "null" || dto.Name == null || dto.Name == "")
                {
                    continue;
                }

                categories.Add(mapper.Map<Category>(dto));
            }

            context.Categories
                .AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {dtos.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            CreateMapper();

            XmlRootAttribute root = new XmlRootAttribute("CategoryProducts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            var dtos = (ImportCategoryProductDto[])serializer.Deserialize(reader);

            var categoryProducts = new List<CategoryProduct>();

            foreach (ImportCategoryProductDto dto in dtos)
            {
                var categoryId = int.Parse(dto.CategoryId);
                var productId = int.Parse(dto.ProductId);

                var hasCategory = context.Categories
                    .ToList()
                    .Any(c => c.Id == categoryId);

                var hasProduct = context.Products
                    .ToList()
                    .Any(p => p.Id == productId);

                if (hasProduct && hasCategory)
                {
                    categoryProducts.Add(mapper.Map<CategoryProduct>(dto));
                }
            }

            context.CategoryProducts
                .AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
    }
}