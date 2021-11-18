using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUserDto, User>()
                .ForMember(d => d
                    .Age, o => o
                    .MapFrom(s => int.Parse(s.Age)));

            CreateMap<ImportProductDto, Product>()
                .ForMember(d => d.Price, o => o
                    .MapFrom(s => decimal.Parse(s.Price)))
                .ForMember(d => d.SellerId, o => o
                    .MapFrom(s => int.Parse(s.SellerId)));

            CreateMap<ImportCategoryDto, Category>();

            CreateMap<ImportCategoryProductDto, CategoryProduct>()
                .ForMember(d => d
                    .CategoryId, o => o
                    .MapFrom(s => int.Parse(s.CategoryId)))
                .ForMember(d => d
                    .ProductId, o => o
                    .MapFrom(s => int.Parse(s.ProductId)));
        }
    }
}
