using System;
using System.Globalization;
using System.Linq;
using AutoMapper;

using CarDealer.DTO;
using CarDealer.Models;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputDto, Supplier>();

            CreateMap<PartInputDto, Part>();

            CreateMap<CarInputDto, Car>();

            CreateMap<CustomerInputDto, Customer>();

            CreateMap<SaleInputDto, Sale>();

            CreateMap<Customer, CustomerOutputDto>()
                .ForMember(dest => dest
                    .BirthDate, opt => opt
                    .MapFrom(src => src
                    .BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<Car, CarToyotaDto>();

            CreateMap<Supplier, SupplierOutputDto>()
                .ForMember(dest => dest
                    .PartsCount, opt => opt
                    .MapFrom(src => src
                        .Parts.Count));

            CreateMap<Car, CarOutputDto>()
                .ForMember(d => d
                    .Car, o => o
                    .MapFrom(s => s))
                .ForMember(d => d
                    .Parts, o => o
                    .MapFrom(s => s.PartCars.ToArray()));

            CreateMap<Customer, CustomerCarsOutputDto>()
                .ForMember(d => d
                    .FullName, o => o
                    .MapFrom(s => s
                        .Name))
                .ForMember(d => d
                    .BoughtCars, o => o
                    .MapFrom(s => s
                        .Sales.Count))
                .ForMember(d => d
                    .SpentMoney, o => o
                    .MapFrom(s => s.Sales.Sum(c => c.Car.PartCars.Sum(p => p.Part.Price))));
        }
    }
}
