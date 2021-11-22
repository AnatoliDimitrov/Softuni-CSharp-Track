using System.Linq;
using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {

            //IMPORT Suppliers
            CreateMap<ImportSupplierDto, Supplier>()
                .ForMember(d => d.IsImporter, o => o
                    .MapFrom(s => bool.Parse(s.IsImporter)));

            //IMPORT Parts
            CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.Price, o => o
                    .MapFrom(s => decimal.Parse(s.Price)))
                .ForMember(d => d.Quantity, o => o
                    .MapFrom(s => int.Parse(s.Quantity)))
                .ForMember(d => d.SupplierId, o => o
                    .MapFrom(s => int.Parse(s.SupplierId)));

            //IMPORT Customers
            CreateMap<ImportCustomerDto, Customer>()
                .ForMember(d => d.IsYoungDriver, o => o
                    .MapFrom(s => bool.Parse(s.IsYoungDriver)));

            //IMPORT Sales
            CreateMap<ImportSaleDto, Sale>();

            //EXPORT Cars
            CreateMap<Car, ExportCarDto>();

            //EXPORT BMW
            CreateMap<Car, ExportBMWDto>();

            //EXPORT Suppliers
            CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(d => d.Parts, o => o
                    .MapFrom(s => s.Parts.Count.ToString()));

            //EXPORT Customers with cars
            CreateMap<Customer, ExportCustomerWithCarsDto>()
                .ForMember(d => d.Cars, o => o
                    .MapFrom(s => s.Sales.Count.ToString()))
                .ForMember(d => d.MoneySpent, o => o
                    .MapFrom(s => s.Sales.Count));

            CreateMap<Car, ExportCarWithAttributesDto>();

        }
    }
}
