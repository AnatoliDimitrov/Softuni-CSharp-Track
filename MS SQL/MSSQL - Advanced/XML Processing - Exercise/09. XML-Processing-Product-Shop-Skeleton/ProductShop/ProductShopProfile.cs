using System.Linq;
using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUserDto, User>()
                .ForMember(d => d.Age, o => o
                    .MapFrom(s => int.Parse(s.Age)));

            CreateMap<ImportProductDto, Product>()
                .ForMember(d => d.Price, o => o
                    .MapFrom(s => decimal.Parse(s.Price)))
                .ForMember(d => d.SellerId, o => o
                    .MapFrom(s => int.Parse(s.SellerId)));

            CreateMap<ImportCategoryDto, Category>();

            CreateMap<ImportCategoryProductDto, CategoryProduct>()
                .ForMember(d => d.CategoryId, o => o
                    .MapFrom(s => int.Parse(s.CategoryId)))
                .ForMember(d => d.ProductId, o => o
                    .MapFrom(s => int.Parse(s.ProductId)));

            CreateMap<Product, ExportProductDto>()
                .ForMember(d => d.Price, o => o
                    .MapFrom(s => s.Price.ToString()))
                .ForMember(d => d.BuyerName, o => o
                    .MapFrom(s => s.Buyer == null ? null : $"{s.Buyer.FirstName} {s.Buyer.LastName}"));

            CreateMap<User, ExportUserWithSoldProducts>()
                .ForMember(d => d
                    .ProductsSold, o => o
                    .MapFrom(s => s.ProductsSold));

            CreateMap<Product, ExportSoldProductDto>()
                .ForMember(d => d.Price, o => o
                    .MapFrom(s => s.Price.ToString("G29")));

            CreateMap<Category, ExportCategoryProductsCountDto>()
                .ForMember(d => d.Count, o => o
                    .MapFrom(s => s.CategoryProducts.Count.ToString()))
                .ForMember(d => d.AveragePrice, o => o
                    .MapFrom(s => s.CategoryProducts.Average(p => p.Product.Price).ToString("G29")))
                .ForMember(d => d.TotalRevenue, o => o
                    .MapFrom(s => s.CategoryProducts.Sum(p => p.Product.Price).ToString("G29")));

            CreateMap<User, ExportUserDto>()
                .ForMember(d => d.ProductsSold, o => o
                    .MapFrom(s => new ExportSoldProductsDto()
                    {
                        Products = s.ProductsSold
                            .OrderByDescending(p => p.Price)
                            .Select(p => new ExportSoldProductDto()
                            {
                                Name = p.Name,
                                Price = p.Price.ToString("G29")
                            })
                            .ToList(),
                        Count = s.ProductsSold.Count.ToString()
                    }));
        }
    }
}
