using AutoMapper;
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

            //IMPORT Cars
            //CreateMap<ImportCarDto, Car>()
            //    .ForMember()
        }
    }
}
