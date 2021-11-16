using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;

using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersJsonToString = File.ReadAllText("./../../../Datasets/suppliers.json");
            //var partsJsonToString = File.ReadAllText("./../../../Datasets/parts.json");
            //var carsJsonToString = File.ReadAllText("./../../../Datasets/cars.json");
            //var customersJsonToString = File.ReadAllText("./../../../Datasets/customers.json");
            //var salesJsonToString = File.ReadAllText("./../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliersJsonToString));
            //Console.WriteLine(ImportParts(context, partsJsonToString));
            //Console.WriteLine(ImportCars(context, carsJsonToString));
            //Console.WriteLine(ImportCustomers(context, customersJsonToString));
            //Console.WriteLine(ImportSales(context, salesJsonToString));
            //Console.WriteLine(GetOrderedCustomers(context));
            //Console.WriteLine(GetCarsFromMakeToyota(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static void CreateMapper()
        {
            var mapperConfigoration = new MapperConfiguration(c =>
            {
                c.AddProfile(new CarDealerProfile());
            });

            mapper = new Mapper(mapperConfigoration);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            CreateMapper();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<SupplierInputDto>>(inputJson).ToList();

            context.Suppliers
                .AddRange(mapper.Map<IEnumerable<Supplier>>(dtos));

            context.SaveChanges();

            return $"Successfully imported {dtos.Count}."; ;
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            CreateMapper();

            var suppliersCount = context.Suppliers.Count();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<PartInputDto>>(inputJson).ToList();

            dtos = dtos.Where(d => d.SupplierId <= suppliersCount).ToList();

            context.Parts
                .AddRange(mapper.Map<IEnumerable<Part>>(dtos));

            context.SaveChanges();

            return $"Successfully imported {dtos.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            CreateMapper();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<CarInputDto>>(inputJson).ToList();

            var cars = new List<Car>();

            foreach (var dto in dtos)
            {
                var car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TravelledDistance
                };

                foreach (var part in dto.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar(){PartId = part});
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {dtos.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            CreateMapper();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<CustomerInputDto>>(inputJson);

            context.Customers
                .AddRange(mapper.Map<IEnumerable<Customer>>(dtos));

            context.SaveChanges();

            return $"Successfully imported {dtos.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            CreateMapper();

            var dtos = JsonConvert.DeserializeObject<IEnumerable<SaleInputDto>>(inputJson);

            context.Sales
                .AddRange(mapper.Map<IEnumerable<Sale>>(dtos));

            context.SaveChanges();

            return $"Successfully imported {dtos.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            CreateMapper();

            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<CustomerOutputDto>(mapper.ConfigurationProvider)
                .ToList();

            return JsonConvert.SerializeObject(customers).TrimEnd();
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            CreateMapper();

            var toyotas = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(t => t.Model)
                .ThenByDescending(t => t.TravelledDistance)
                .ProjectTo<CarToyotaDto>(mapper.ConfigurationProvider)
                .ToList();

            return JsonConvert.SerializeObject(toyotas).TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            CreateMapper();

            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<SupplierOutputDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(suppliers).TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            CreateMapper();

            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars
                        .Select(p => new
                        {
                            p.Part.Name,
                            Price = p.Part.Price.ToString("f2")
                        })
                        .ToArray()
                });

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            CreateMapper();

            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .ProjectTo<CustomerCarsOutputDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            DefaultContractResolver resolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = resolver
            };

            return JsonConvert.SerializeObject(customers, settings).TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            CreateMapper();

            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(p => p.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(p => p.Part.Price) * (1 - s.Discount * 0.01m):f2}"
                })
                .ToList()
                .Take(10);

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}