namespace Claudi.Web.Data.Seeding
{
    using Claudi.Infrastructure.Data;
    using Claudi.Infrastructure.Data.Models.DataBaseModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public class Seeder
    {
        private static List<ProductCatalogue> catalogues = new();
        private static List<ProductColor> samples = new();
        private static List<GalleryPicture> galleryPictures = new();

        private static List<ProductModel> horizontalModels;
        private static List<ProductModel> verticalModels;
        private static List<ProductModel> woodenModels;
        private static List<ProductModel> rollerModels;
        private static List<ProductModel> romanModels;
        private static List<ProductModel> bambooModels;
        private static List<ProductModel> pleatsModels;
        private static List<ProductModel> externalRollersModels;
        private static List<ProductModel> externalVenetiansModels;
        private static List<ProductModel> tentsModels;
        private static List<ProductModel> netsModels;

        public static async Task Seed(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            
            //// ProductTypes
            var horizontalBlinds = new ProductType()
            {
                Name = "Хоризонтални Щори",
                NameShort = "Хоризонтални",
                EnglishName = "Horizontal Blinds",
                EnglishNameShort = "Horizontal",
                CreatedOn = DateTime.UtcNow,
            };
            var verticalBlinds = new ProductType()
            {
                Name = "Вертикални Щори",
                NameShort = "Вертикални",
                EnglishName = "Vertical Blinds",
                EnglishNameShort = "Vertical",
                CreatedOn = DateTime.UtcNow,
            };
            var woodenBlinds = new ProductType()
            {
                Name = "Дървени Щори",
                NameShort = "Дървени",
                EnglishName = "Wooden Blinds",
                EnglishNameShort = "Wooden",
                CreatedOn = DateTime.UtcNow,
            };
            var rollerBlinds = new ProductType()
            {
                Name = "Руло Щори",
                NameShort = "Руло",
                EnglishName = "Roller Blinds",
                EnglishNameShort = "Roller",
                CreatedOn = DateTime.UtcNow,
            };
            var romanBlinds = new ProductType()
            {
                Name = "Римски Щори",
                NameShort = "Римски",
                EnglishName = "Roman Blinds",
                EnglishNameShort = "Roman",
                CreatedOn = DateTime.UtcNow,
            };
            var bambooBlinds = new ProductType()
            {
                Name = "Бамбукови Щори",
                NameShort = "Бамбукови",
                EnglishName = "Bamboo Blinds",
                EnglishNameShort = "Bamboo",
                CreatedOn = DateTime.UtcNow,
            };
            var pleatsBlinds = new ProductType()
            {
                Name = "Плисе Щори",
                NameShort = "Плисе",
                EnglishName = "Pleat Blinds",
                EnglishNameShort = "Pleat",
                CreatedOn = DateTime.UtcNow,
            };
            var externalRollerBlinds = new ProductType()
            {
                Name = "Външни Ролетни Щори",
                NameShort = "Външни Ролетни",
                EnglishName = "External Roller Blinds",
                EnglishNameShort = "ExternalRoller",
                CreatedOn = DateTime.UtcNow,
            };
            var externalVenetianBlinds = new ProductType()
            {
                Name = "Външни Ламелни Щори",
                NameShort = "Външни Ламелни",
                EnglishName = "External Venetian Blinds",
                EnglishNameShort = "ExternalVenetian",
                CreatedOn = DateTime.UtcNow,
            };
            var tents = new ProductType()
            {
                Name = "Сенници",
                NameShort = "Сенници",
                EnglishName = "Tents",
                EnglishNameShort = "Tents",
                CreatedOn = DateTime.UtcNow,
            };
            var nets = new ProductType()
            {
                Name = "Мрежи Против Насекоми",
                NameShort = "Комарници",
                EnglishName = "Insect Nets",
                EnglishNameShort = "Nets",
                CreatedOn = DateTime.UtcNow,
            };

            //// ProductModels
            /// Horizontal
            var infrontGlasses = new ProductModel()
            {
                Name = "Пред Стъкло",
                EnglishName = "Infront of Glasses",
                Type = horizontalBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var infrontGlassesBO = new ProductModel()
            {
                Name = "Пред Стъкло BlackOut",
                EnglishName = "Infront of Glasses BlackOut",
                Type = horizontalBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var betweenGlasses = new ProductModel()
            {
                Name = "Между Стъкло",
                EnglishName = "Between Glasses",
                Type = horizontalBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var maxiStandart = new ProductModel()
            {
                Name = "Макси Стандарт",
                EnglishName = "Maxi Standart",
                Type = horizontalBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var maxiStandartBO = new ProductModel()
            {
                Name = "Макси Стандарт BlackOut",
                EnglishName = "Maxi Standart BlackOut",
                Type = horizontalBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var maxiLux = new ProductModel()
            {
                Name = "Макси Лукс",
                EnglishName = "Maxi Lux",
                Type = horizontalBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var ultimate = new ProductModel()
            {
                Name = "Ultimate",
                EnglishName = "Ultimate",
                Type = horizontalBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var megaview = new ProductModel()
            {
                Name = "Megaview",
                EnglishName = "Megaview",
                Type = horizontalBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var varioflex = new ProductModel()
            {
                Name = "Varioflex",
                EnglishName = "Varioflex",
                Type = horizontalBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };

            /// Vertical
            var mm89 = new ProductModel()
            {
                Name = "89 мм",
                EnglishName = "89 mm",
                OnCalculator = true,
                Type = verticalBlinds,
                CreatedOn = DateTime.UtcNow,
            };
            var mm127 = new ProductModel()
            {
                Name = "127 мм",
                EnglishName = "127 mm",
                OnCalculator = true,
                Type = verticalBlinds,
                CreatedOn = DateTime.UtcNow,
            };
            var al89 = new ProductModel()
            {
                Name = "89 мм Al",
                EnglishName = "89 mm Al",
                OnCalculator = true,
                Type = verticalBlinds,
                CreatedOn = DateTime.UtcNow,
            };

            ///Wooden
            var mm25 = new ProductModel()
            {
                Name = "25 мм",
                EnglishName = "25 mm",
                Type = woodenBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var mm50 = new ProductModel()
            {
                Name = "50 мм",
                EnglishName = "50 mm",
                Type = woodenBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };

            ///Roller
            var mini = new ProductModel()
            {
                Name = "Мини",
                EnglishName = "Mini",
                Type = rollerBlinds,
                CreatedOn = DateTime.UtcNow,
            };
            var standart = new ProductModel()
            {
                Name = "Стандарт",
                EnglishName = "Standart",
                Type = rollerBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var elegance = new ProductModel()
            {
                Name = "Елеганс",
                EnglishName = "Elegance",
                Type = rollerBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var perfectFit = new ProductModel()
            {
                Name = "PerfectFit",
                EnglishName = "PerfectFit",
                Type = rollerBlinds,
                CreatedOn = DateTime.UtcNow,
            };
            var comfort = new ProductModel()
            {
                Name = "Комфорт",
                EnglishName = "Comfort",
                Type = rollerBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var comfort40 = new ProductModel()
            {
                Name = "Комфорт 40+",
                EnglishName = "Comfort 40+",
                Type = rollerBlinds,
                CreatedOn = DateTime.UtcNow,
            };
            var duo = new ProductModel()
            {
                Name = "Дуо",
                EnglishName = "Duo",
                Type = rollerBlinds,
                CreatedOn = DateTime.UtcNow,
            };
            var dnStandart = new ProductModel()
            {
                Name = "Ден и Нощ Стандарт",
                EnglishName = "Day and Night Standart",
                Type = rollerBlinds,
                CreatedOn = DateTime.UtcNow,
            };
            var dnElegance = new ProductModel()
            {
                Name = "Ден и Нощ Стандарт",
                EnglishName = "Day and Night Standart",
                Type = rollerBlinds,
                CreatedOn = DateTime.UtcNow,
            };
            var dnComfort = new ProductModel()
            {
                Name = "Ден и Нощ Комфорт",
                EnglishName = "Day and Night Comfort",
                Type = rollerBlinds,
                CreatedOn = DateTime.UtcNow,
            };

            ///Roman
            var elegante = new ProductModel()
            {
                Name = "Елеганте",
                EnglishName = "Elegante",
                Type = romanBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var aura = new ProductModel()
            {
                Name = "Аура",
                EnglishName = "Aura",
                Type = romanBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };

            ///Bamboo
            var asha = new ProductModel()
            {
                Name = "Ейша",
                EnglishName = "Asha",
                Type = bambooBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var feba = new ProductModel()
            {
                Name = "Феба",
                EnglishName = "Feba",
                Type = bambooBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };

            ///Pleats
            var bb10 = new ProductModel()
            {
                Name = "BB 10",
                EnglishName = "BB 10",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var bb15 = new ProductModel()
            {
                Name = "BB 15",
                EnglishName = "BB 15",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var bb30 = new ProductModel()
            {
                Name = "BB 30",
                EnglishName = "BB 30",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var ao10 = new ProductModel()
            {
                Name = "AO 10",
                EnglishName = "AO 10",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var ao30 = new ProductModel()
            {
                Name = "AO 30",
                EnglishName = "AO 30",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var ao70 = new ProductModel()
            {
                Name = "AO 70",
                EnglishName = "AO 70",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var bf50 = new ProductModel()
            {
                Name = "BF 50",
                EnglishName = "BF 50",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var bf51 = new ProductModel()
            {
                Name = "BF 51",
                EnglishName = "BF 51",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var ao20 = new ProductModel()
            {
                Name = "AO 20",
                EnglishName = "AO 20",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var bo10 = new ProductModel()
            {
                Name = "BO 10",
                EnglishName = "BO 10",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var bb20 = new ProductModel()
            {
                Name = "BB 20",
                EnglishName = "BB 20",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var bb24 = new ProductModel()
            {
                Name = "BB 24",
                EnglishName = "BB 24",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var bb40 = new ProductModel()
            {
                Name = "BB 40",
                EnglishName = "BB 40",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var bo75 = new ProductModel()
            {
                Name = "BO 75",
                EnglishName = "BO 75",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var ao40 = new ProductModel()
            {
                Name = "AO 40",
                EnglishName = "AO 40",
                Type = pleatsBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };

            ///ExternalRoller
            var pvc = new ProductModel()
            {
                Name = "PVC",
                EnglishName = "PVC",
                Type = externalRollerBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var h39 = new ProductModel()
            {
                Name = "AL H-39",
                EnglishName = "AL H-39",
                Type = externalRollerBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var h39r = new ProductModel()
            {
                Name = "AL H-39R",
                EnglishName = "AL H-39R",
                Type = externalRollerBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var h40 = new ProductModel()
            {
                Name = "AL H-40EXT",
                EnglishName = "AL H-40EXT",
                Type = externalRollerBlinds,
                OnCalculator = false,
                CreatedOn = DateTime.UtcNow,
            };
            var h52 = new ProductModel()
            {
                Name = "AL H-52",
                EnglishName = "AL H-52",
                Type = externalRollerBlinds,
                OnCalculator = false,
                CreatedOn = DateTime.UtcNow,
            };

            ///ExternalVenetian
            var c50 = new ProductModel()
            {
                Name = "C 50",
                EnglishName = "C 50",
                Type = externalVenetianBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var c80 = new ProductModel()
            {
                Name = "C 80",
                EnglishName = "C 80",
                Type = externalVenetianBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var z90 = new ProductModel()
            {
                Name = "Z 90",
                EnglishName = "Z 90",
                Type = externalVenetianBlinds,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };

            ///Tents
            var tentStandart = new ProductModel()
            {
                Name = "Стандарт",
                EnglishName = "Standart",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var tentElegance = new ProductModel()
            {
                Name = "Елеганс",
                EnglishName = "Elgance",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var vera = new ProductModel()
            {
                Name = "Вера",
                EnglishName = "Vera",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var prestige = new ProductModel()
            {
                Name = "Престиж",
                EnglishName = "Prestige",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var classic = new ProductModel()
            {
                Name = "Класик",
                EnglishName = "Classic",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var smart = new ProductModel()
            {
                Name = "Смарт",
                EnglishName = "Smart",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var cabrio = new ProductModel()
            {
                Name = "Кабрио",
                EnglishName = "Cabrio",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var balkonski = new ProductModel()
            {
                Name = "Балконски",
                EnglishName = "Balkonski",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var crystal = new ProductModel()
            {
                Name = "Кристал",
                EnglishName = "Crystal",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var crystalRido = new ProductModel()
            {
                Name = "Кристал РИДО",
                EnglishName = "Crystal RIDO",
                Type = tents,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };

            ///Nets
            var hingedNet = new ProductModel()
            {
                Name = "Комарник на Панти",
                EnglishName = "Hinged Net",
                Type = nets,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var fixNet = new ProductModel()
            {
                Name = "Фиксиран Комарник",
                EnglishName = "Hinged Net",
                Type = nets,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var rollerNet = new ProductModel()
            {
                Name = "Ролетен Комарник в рамка",
                EnglishName = "Roller Net",
                Type = nets,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var rollerNetBuiltInDriver = new ProductModel()
            {
                Name = "Ролетен Комарник с вграден водач",
                EnglishName = "Roller Net with built in driver",
                Type = nets,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var rollerHorizontal = new ProductModel()
            {
                Name = "Ролетен Хоризонтален Комарник",
                EnglishName = "Roller Horizontal",
                Type = nets,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var doorNet = new ProductModel()
            {
                Name = "Врата Мрежа",
                EnglishName = "Door Net",
                Type = nets,
                OnCalculator = true,
                CreatedOn = DateTime.UtcNow,
            };
            var pleatLite = new ProductModel()
            {
                Name = "Плисе Мрежа LITE",
                EnglishName = "Pleat Net LITE",
                Type = nets,
                OnCalculator = false,
                CreatedOn = DateTime.UtcNow,
            };
            var pleatStarla = new ProductModel()
            {
                Name = "Плисе Мрежа Starla",
                EnglishName = "Pleat Net Starla",
                Type = nets,
                OnCalculator = false,
                CreatedOn = DateTime.UtcNow,
            };

            horizontalModels = new List<ProductModel>()
            {
                infrontGlasses,
                infrontGlassesBO,
                betweenGlasses,
                maxiStandart,
                maxiStandartBO,
                maxiLux,
                ultimate,
                megaview,
                varioflex,
            };
            verticalModels = new List<ProductModel>()
            {
                mm89,
                mm127,
                al89,
            };
            woodenModels = new List<ProductModel>()
            {
                 mm25,
                    mm50,
            };
            rollerModels = new List<ProductModel>()
            {
                mini,
                standart,
                elegance,
                perfectFit,
                comfort,
                comfort40,
                duo,
                dnStandart,
                dnElegance,
                dnComfort,
            };
            romanModels = new List<ProductModel>()
            {
                elegante,
                aura,
            };
            bambooModels = new List<ProductModel>()
            {
                asha,
                feba,
            };
            pleatsModels = new List<ProductModel>()
            {
                bb10,
                bb15,
                bb30,
                ao10,
                ao30,
                ao70,
                bf50,
                bf51,
                ao20,
                bo10,
                bb20,
                bb24,
                bb40,
                bo75,
                ao40,
            };
            externalRollersModels = new List<ProductModel>()
            {
                pvc,
                h39,
                h39r,
                h40,
                h52,
            };
            externalVenetiansModels = new List<ProductModel>()
            {
                c50,
                c80,
                z90,
            };
            tentsModels = new List<ProductModel>()
            {
                tentStandart,
                tentElegance,
                vera,
                prestige,
                classic,
                smart,
                cabrio,
                balkonski,
                crystal,
                crystalRido,
            };
            netsModels = new List<ProductModel>()
            {
                hingedNet,
                fixNet,
                rollerNet,
                rollerNetBuiltInDriver,
                rollerHorizontal,
                doorNet,
                pleatLite,
                pleatStarla,
            };

            if (!context.ProductTypes.Any())
            {
                var productTypes = new List<ProductType>() {
                    horizontalBlinds,
                    verticalBlinds,
                    woodenBlinds,
                    rollerBlinds,
                    romanBlinds,
                    bambooBlinds,
                    pleatsBlinds,
                    externalRollerBlinds,
                    externalVenetianBlinds,
                    tents,
                    nets,
                };

                await context.ProductTypes.AddRangeAsync(productTypes);

                await context.SaveChangesAsync();
            }

            if (!context.ProductModels.Any())
            {
                var productModels = new List<ProductModel>();
                productModels.AddRange(horizontalModels);
                productModels.AddRange(verticalModels);
                productModels.AddRange(woodenModels);
                productModels.AddRange(rollerModels);
                productModels.AddRange(romanModels);
                productModels.AddRange(bambooModels);
                productModels.AddRange(pleatsModels);
                productModels.AddRange(externalRollersModels);
                productModels.AddRange(externalVenetiansModels);
                productModels.AddRange(tentsModels);
                productModels.AddRange(netsModels);

                await context.ProductModels.AddRangeAsync(productModels);

                await context.SaveChangesAsync();
            }

            if (!context.ProductCatalogues.Any())
            {
                CatalogueCrowler("wwwroot/storage/catalogue");

                await context.ProductCatalogues.AddRangeAsync(catalogues);

                await context.SaveChangesAsync();
            }

            if (!context.ProductColors.Any())
            {
                SampleCrowler("wwwroot/storage/samples");

                await context.ProductColors.AddRangeAsync(samples);

                await context.SaveChangesAsync();
            }

            if (!context.GalleryPictures.Any())
            {
                GalleryCrowler("wwwroot/storage/gallery");

                await context.GalleryPictures.AddRangeAsync(galleryPictures);

                await context.SaveChangesAsync();
            }

            if (!context.ProductExtras.Any())
            {
                var extras = new List<ProductExtra>()
                {
                    new ProductExtra()
                    {
                        Name = "Странично Водене",
                        EnglishName = "Side Driving",
                        Group = 1,
                        OnClaculator = true,
                        Models = new List<ProductModel>()
                        {
                            infrontGlasses,
                            infrontGlassesBO,
                            betweenGlasses,
                            maxiStandart,
                            maxiStandartBO,
                            maxiLux,
                            ultimate,
                            megaview,
                            varioflex,
                            elegante,
                            aura,
                            mm25, 
                            mm50,
                            standart,
                            comfort,
                        }
                    },
                    new ProductExtra()
                    {
                        Name = "Фиксатор",
                        EnglishName = "Fixer",
                        Group = 1,
                        OnClaculator = false,
                        Models = new List<ProductModel>()
                        {
                            infrontGlasses,
                            infrontGlassesBO,
                            betweenGlasses,
                            maxiStandart,
                            maxiStandartBO,
                            maxiLux,
                            ultimate,
                            megaview,
                            varioflex,
                        }
                    },
                    new ProductExtra()
                    {
                        Name = "Планки Лукс",
                        EnglishName = "Lux",
                        Group = 2,
                        OnClaculator = true,
                        Models = new List<ProductModel>()
                        {
                            infrontGlasses,
                            infrontGlassesBO,
                            betweenGlasses,
                            ultimate,
                            megaview,
                            varioflex,
                        }
                    },
                    new ProductExtra()
                    {
                        Name = "Мотор с дистанционно",
                        EnglishName = "Remote Controll",
                        Group = 3,
                        OnClaculator = false,
                        Models = new List<ProductModel>()
                        {
                            pvc,
                            h39,
                            h39r,
                            h40,
                            h52,
                            c50,
                            c80,
                            z90,
                            tentStandart,
                            tentElegance,
                            vera,
                            prestige,
                            classic,
                            smart,

                        }
                    },
                    new ProductExtra()
                    {
                        Name = "Мотор с Бутон",
                        EnglishName = "Button Controll",
                        Group = 3,
                        OnClaculator = false,
                        Models = new List<ProductModel>()
                        {
                            pvc,
                            h39,
                            h39r,
                            h40,
                            h52,
                            c50,
                            c80,
                            z90,
                            tentStandart,
                            tentElegance,
                            vera,
                            prestige,
                            classic,
                            smart,
                        }
                    },
                    new ProductExtra()
                    {
                        Name = "Декортативен Капак",
                        EnglishName = "Decoration",
                        Group = 4,
                        OnClaculator = true,
                        Models = new List<ProductModel>()
                        {
                            c50,
                            c80,
                            z90,
                        }
                    },
                };

                await context.ProductExtras.AddRangeAsync(extras);

                await context.SaveChangesAsync();
            }
        }

        private static void CatalogueCrowler(string path)
        {
            var directories = Directory.GetDirectories(path);

            if (directories.Any())
            {
                foreach (var directory in directories)
                {
                    CatalogueCrowler(directory);
                }
            }
            else
            {
                var files = Directory.GetFiles(path);

                foreach (var file in files)
                {
                    var url = "/" + file.Replace("\\", "/");
                    var cssClass = string.Empty;
                    var group = string.Empty;

                    var parts = url.Split('/');
                    var number = int.Parse(parts.Last().Split(".")[0]);
                    var modelString = parts[parts.Length - 3];

                    var lastFolder = parts[parts.Length - 2];

                    if (lastFolder.Contains("_"))
                    {
                        var folderParts = lastFolder.Split('_');
                        cssClass = folderParts[0].Replace(" ", "");
                        group = folderParts[1];
                    }
                    else
                    {
                        cssClass = lastFolder.Replace(" ", "");
                        group = lastFolder;
                    }

                    var modelGroup = modelString switch
                    {
                        "HorizontalCatalogue" => horizontalModels,
                        "VerticalCatalogue" => verticalModels,
                        "WoodenCatalogue" => woodenModels,
                        "RollerCatalogue" => rollerModels,
                        "RomanCatalogue" => romanModels,
                        "PliseCatalogue" => pleatsModels,
                        "BambooCatalogue" => bambooModels,
                        "ExteriorRollersCatalogue" => externalRollersModels,
                        "ExteriorHorizontalCatalogue" => externalVenetiansModels,
                        "AwningCatalogue" => tentsModels,
                        "NetsCatalogue" => netsModels,
                        _ => throw new ArgumentNullException("Folder not found!")
                    };

                    url = url.Replace("/wwwroot", "");

                    catalogues.Add(new ProductCatalogue()
                    {
                        ImageUrl = url,
                        CssClass = cssClass,
                        Group = group,
                        Number = number,
                        Models = modelGroup,
                        Type = modelGroup[0].Type,
                    });
                }
            }
        }

        private static void SampleCrowler(string path)
        {
            var directories = Directory.GetDirectories(path);

            if (directories.Any())
            {
                foreach (var directory in directories)
                {
                    SampleCrowler(directory);
                }
            }
            else
            {
                var files = Directory.GetFiles(path);

                foreach (var file in files)
                {
                    var url = "/" + file.Replace("\\", "/");
                    var cssClass = string.Empty;
                    var group = string.Empty;

                    var parts = url.Split('/');
                    var number = parts.Last().Split(".")[0];
                    var modelString = parts[parts.Length - 3];

                    var lastFolder = parts[parts.Length - 2];

                    if (lastFolder.Contains("_"))
                    {
                        var folderParts = lastFolder.Split('_');
                        cssClass = folderParts[0].Replace(" ", "");
                        group = folderParts[1];
                    }
                    else
                    {
                        cssClass = lastFolder.Replace(" ", "");
                        group = lastFolder;
                    }

                    var modelGroup = modelString switch
                    {
                        "horizontal" => horizontalModels,
                        "89mm" => new List<ProductModel>() { verticalModels[0] },
                        "127mm" => new List<ProductModel>() { verticalModels[1] },
                        "al" => new List<ProductModel>() { verticalModels[2] },
                        "wooden" => woodenModels,
                        "roller" => rollerModels,
                        "roman" => romanModels,
                        "pleats" => pleatsModels,
                        "bamboo" => bambooModels,
                        "externalRoller" => externalRollersModels,
                        "external" => externalVenetiansModels,
                        "awning" => tentsModels,
                        "nets" => netsModels,
                        _ => throw new ArgumentNullException("Folder not found!")
                    };

                    url = url.Replace("/wwwroot", "");

                    samples.Add(new ProductColor()
                    {
                        Number = number,
                        Group = group,
                        Name = modelString,
                        CssClass = cssClass,
                        ImageUrl = url,
                        Models = modelGroup,
                    });
                }
            }
        }

        private static void GalleryCrowler(string path)
        {
            var directories = Directory.GetDirectories(path);

            if (directories.Any())
            {
                foreach (var directory in directories)
                {
                    GalleryCrowler(directory);
                }
            }
            else
            {
                var files = Directory.GetFiles(path);

                foreach (var file in files)
                {
                    var url = "/" + file.Replace("\\", "/");
                    var cssClass = string.Empty;
                    var group = string.Empty;

                    var parts = url.Split('/');
                    var modelString = parts[parts.Length - 3];

                    var lastFolder = parts[parts.Length - 2];

                    if (lastFolder.Contains("_"))
                    {
                        var folderParts = lastFolder.Split('_');
                        cssClass = folderParts[1].Replace(" ", "");
                        group = folderParts[0];
                    }
                    else
                    {
                        cssClass = lastFolder.Replace(" ", "");
                        group = lastFolder;
                    }

                    url = url.Replace("/wwwroot", "");

                    galleryPictures.Add(new GalleryPicture()
                    {
                        ImageUrl = url,
                        CssClass = cssClass,
                        Group = group,
                    });
                }
            }
        }
    }
}
