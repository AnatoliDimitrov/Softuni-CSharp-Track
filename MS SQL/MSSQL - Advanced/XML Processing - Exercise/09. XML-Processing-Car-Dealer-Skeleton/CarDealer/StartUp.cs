using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dtos.Export;
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
            //ResetDatabase(context);

            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersXml));

            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, partsXml));

            //var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, carsXml));

            //var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersXml));

            //var salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, salesXml));

            //Console.WriteLine(GetCarsWithDistance(context));
            //Console.WriteLine(GetCarsFromMakeBmw(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
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

            var dtos = (ImportCarDto[])serializer.Deserialize(reader);

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

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            CreateMapper();

            using StringReader reader = new StringReader(inputXml);

            XmlRootAttribute root = new XmlRootAttribute("Customers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), root);

            var dtos = (ImportCustomerDto[]) serializer.Deserialize(reader);

            context.Customers
                .AddRange(mapper.Map<Customer[]>(dtos));

            context.SaveChanges();

            return $"Successfully imported {dtos.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            CreateMapper();

            using StringReader reader = new StringReader(inputXml);

            XmlRootAttribute root = new XmlRootAttribute("Sales");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto[]), root);

            var dtos = (ImportSaleDto[]) serializer.Deserialize(reader);

            ICollection<Sale> sales = new HashSet<Sale>();

            foreach (var dto in dtos)
            {
                var carId = int.Parse(dto.CarId);

                if (context.Cars.Any(c => c.Id == carId))
                {
                    var sale = mapper.Map<Sale>(dto);
                    sales.Add(sale);
                }
            }

            context.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CreateMapper();

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var dtos = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            serializer.Serialize(writer, dtos, ns);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            CreateMapper();

            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportBMWDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var dtos = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(b => b.Model)
                .ThenByDescending(b => b.TravelledDistance)
                .ProjectTo<ExportBMWDto>(mapper.ConfigurationProvider)
                .ToArray();
            serializer.Serialize(writer, dtos, ns);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            CreateMapper();

            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("suppliers");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportSupplierDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var dtos = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            serializer.Serialize(writer, dtos, ns);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarWithPartsDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var dtos = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance.ToString(),
                    Parts = c.PartCars
                        .OrderByDescending(p => p.Part.Price)
                        .Select(p => new ExportPartDto
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString()
                        })
                        .ToList()
                })
                .Take(5)
                .ToArray();

            serializer.Serialize(writer, dtos, ns);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("customers");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCustomerWithCarsDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var dtos = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(s => new ExportCustomerWithCarsDto
                {
                    FullName = s.Name,
                    Cars = s.Sales.Count,
                    MoneySpent = s.Sales.Select(sa => sa.Car)
                        .SelectMany(c => c.PartCars)
                        .Sum(p => p.Part.Price)
                })
                .OrderByDescending(c => c.MoneySpent)
                .ToArray();

            serializer.Serialize(writer, dtos,ns);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute root = new XmlRootAttribute("sales");
            XmlSerializer serializer = new XmlSerializer(typeof(ExportSaleDto[]), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var dtos = context.Sales
                .Select(s => new ExportSaleDto
                {
                    Car = new ExportCarWithAttributesDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance.ToString()
                    },

                    Discount = s.Discount.ToString("G29"),
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(p => p.Part.Price).ToString("G29"),
                    PriceWithDiscount = (s.Car.PartCars.Sum(p => p.Part.Price) * (1 - s.Discount * 0.01m)).ToString("G29")
                })
                .ToArray();

            serializer.Serialize(writer, dtos, ns);

            return sb.ToString().TrimEnd();
        }
    }
}