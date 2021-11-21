using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper; 

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            ResetDatabase(context);

            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            Console.WriteLine(ImportSuppliers(context, suppliersXml));

            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            Console.WriteLine(ImportParts(context, partsXml));

            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            Console.WriteLine(ImportCars(context, carsXml));
        }

        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("Reset Complete");
        }

        private static void CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {
                c.AddProfile(new CarDealerProfile());
            });

            mapper = new Mapper(config);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            CreateMapper();

            using StringReader reader = new StringReader(inputXml);

            XmlRootAttribute root = new XmlRootAttribute("Suppliers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), root);

            var dtos = (ImportSupplierDto[])serializer.Deserialize(reader);
            
            context.Suppliers
                .AddRange(mapper.Map<ICollection<Supplier>>(dtos));

            context.SaveChanges();
            
            return $"Successfully imported {dtos.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            CreateMapper();

            using StringReader reader = new StringReader(inputXml);

            XmlRootAttribute root = new XmlRootAttribute("Parts");
            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportPartDto>), root);

            var dtos = (List<ImportPartDto>)serializer.Deserialize(reader);

            ICollection<Part> parts = new HashSet<Part>();

            foreach (var dto in dtos)
            {
                int id = int.Parse(dto.SupplierId);

                if (context.Suppliers.Any(p => p.Id == id))
                {
                    Part part = mapper.Map<Part>(dto);
                    parts.Add(part);
                }
            }


            context.Parts
                .AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            CreateMapper();

            using StringReader reader = new StringReader(inputXml);

            XmlRootAttribute root = new XmlRootAttribute("Cars");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), root);

            var dtos = (ImportCarDto[]) serializer.Deserialize(reader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (var dto in dtos)
            {
                Car car = new Car()
                {
                    Model = dto.Model,
                    Make = dto.Make,
                    TravelledDistance = long.Parse(dto.TravelledDistance)
                };

                foreach (var partDto in dto.PartCars.Select(p => p.Id).Distinct())
                {
                    Part part = context.Parts.FirstOrDefault(p => p.Id == partDto);

                    if (part != null)
                    {
                        PartCar pc = new PartCar()
                        {
                            Car = car,
                            Part = part
                        };

                        car.PartCars.Add(pc);
                    }
                }

                cars.Add(car);
            }

            context.Cars
                .AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
    }
}