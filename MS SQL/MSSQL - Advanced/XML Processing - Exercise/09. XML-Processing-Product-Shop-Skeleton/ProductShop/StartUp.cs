using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using ProductShop.Data;
using ProductShop.Dtos.Export;
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

            //var importCategoriesProductsXML = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, importCategoriesProductsXML));

            Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            //Console.WriteLine(GetCategoriesByProductsCount(context));
            //Console.WriteLine(GetUsersWithProducts(context));
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

            StringReader reader = new StringReader(inputXml);

            using (reader)
            {
                ImportUserDto[] dtos = (ImportUserDto[])serializer.Deserialize(reader);

                context.Users
                    .AddRange(mapper.Map<IEnumerable<User>>(dtos));

                context.SaveChanges();

                return $"Successfully imported {dtos.Length}";
            }
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            CreateMapper();

            XmlRootAttribute root = new XmlRootAttribute("Products");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), root);

            StringReader reader = new StringReader(inputXml);

            using (reader)
            {
                var dtos = (ImportProductDto[])serializer.Deserialize(reader);

                context.Products
                    .AddRange(mapper.Map<IEnumerable<Product>>(dtos));

                context.SaveChanges();

                return $"Successfully imported {dtos.Length}";
            }
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            CreateMapper();

            XmlRootAttribute root = new XmlRootAttribute("Categories");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryDto[]), root);

            StringReader reader = new StringReader(inputXml);

            using (reader)
            {
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
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            CreateMapper();

            XmlRootAttribute root = new XmlRootAttribute("CategoryProducts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), root);

            StringReader reader = new StringReader(inputXml);

            var categoryProducts = new List<CategoryProduct>();


            using (reader)
            {
                var dtos = (ImportCategoryProductDto[])serializer.Deserialize(reader);
                
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
            }

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            CreateMapper();

            StringBuilder sb = new StringBuilder();
            TextWriter writer = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProductDto[]), "Products");
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);


            var productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            using (writer)
            {
                serializer.Serialize(writer, productDtos, ns);
            }
            return sb.ToString().TrimEnd();

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            CreateMapper();

            StringBuilder sb = new StringBuilder();

            StringWriter writer = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportUserWithSoldProducts>), "Users");
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (writer)
            {
                var dtos = context.Users
                    .Where(u => u.ProductsSold.Any())
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .ProjectTo<ExportUserWithSoldProducts>(mapper.ConfigurationProvider)
                    .Take(5)
                    .ToList();

                serializer.Serialize(writer, dtos);
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            CreateMapper();

            StringBuilder sb = new StringBuilder();

            StringWriter writer = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportCategoryProductsCountDto>), "Categories");
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (writer)
            {
                var dtos = context.Categories
                    .OrderByDescending(c => c.CategoryProducts.Count)
                    .ThenBy(c => c.CategoryProducts.Sum(p => p.Product.Price))
                    .ProjectTo<ExportCategoryProductsCountDto>(mapper.ConfigurationProvider)
                    .ToList();

                serializer.Serialize(writer, dtos);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            CreateMapper();

            StringBuilder sb = new StringBuilder();

            StringWriter sw = new StringWriter(sb);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportAllUsersDto), "Users");

            using (sw)
            {
                var dtos = context.Users
                    .Where(u => u.ProductsSold.Any())
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ProjectTo<ExportUserDto>(mapper.ConfigurationProvider)
                    .Take(10)
                    .ToList();

                var allUsers = new ExportAllUsersDto()
                {
                    Count = context.Users
                        .Count(u => u.ProductsSold.Any())
                        .ToString(),
                    Users = dtos
                };

                serializer.Serialize(sw, allUsers);

                return sb.ToString().TrimEnd();
            }
        }
    }
}