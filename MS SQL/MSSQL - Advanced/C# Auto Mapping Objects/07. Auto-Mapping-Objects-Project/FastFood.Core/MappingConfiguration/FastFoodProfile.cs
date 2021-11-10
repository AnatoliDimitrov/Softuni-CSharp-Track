using AutoMapper;

using FastFood.Models;
using FastFood.Core.ViewModels.Positions;
using FastFood.Core.ViewModels.Categories;
using FastFood.Core.ViewModels.Employees;
using FastFood.Core.ViewModels.Items;
using FastFood.Core.ViewModels.Orders;

namespace FastFood.Core.MappingConfiguration
{

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Employees

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id));

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));

            //Categories

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            //Items
            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id));

            //Orders
            this.CreateMap<CreateOrderInputModel, Order>();

            this.CreateMap<CreateOrderInputModel, OrderItem>();

            this.CreateMap<Order, OrderAllViewModel>();
        }
    }
}
