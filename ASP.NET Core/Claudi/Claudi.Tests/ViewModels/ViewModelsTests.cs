using System.Collections.Generic;
using System.Linq;
using Claudi.Core.ViewModels.AdministrationViewModels.AccountsViewModels;
using Claudi.Core.ViewModels.CalculatorViewModels;
using Claudi.Core.ViewModels.CataloguesViewModels;
using Claudi.Core.ViewModels.ColorsViewModels;
using Claudi.Core.ViewModels.ContactsViewModel;
using Claudi.Core.ViewModels.GalleriesViewModels;
using Claudi.Core.ViewModels.MyProductsViewModels;
using FluentAssertions;

namespace Claudi.Tests.ViewModels
{
    using Xunit;

    public class ViewModelsTests
    {
        [Fact]

        public void IndexUsersViewModelWorksProperly()
        {
            var usersViewModels = new List<UsersViewModel>();

            for (int i = 0; i < 10; i++)
            {
                usersViewModels.Add(new UsersViewModel()
                {
                    Id = i.ToString(),
                    Email = i.ToString(),
                    IsAdmin = false,
                    IsEmailConfirmed = true
                });
            }

            var indexVm = new IndexUsersViewModel()
            {
                Message = "test",
                Users = usersViewModels
            };

            Assert.IsType(typeof(IndexUsersViewModel), indexVm);
            usersViewModels.Should().BeEquivalentTo(indexVm.Users);
            "test".Should().BeEquivalentTo(indexVm.Message);

            usersViewModels[0].Should().BeEquivalentTo(indexVm.Users[0]);
        }

        [Fact]

        public void IndexViewModelWorksProperly()
        {
            var usersViewModels = new List<TypeViewModel>();

            for (int i = 0; i < 10; i++)
            {
                usersViewModels.Add(new TypeViewModel()
                {
                    Id = i,
                    Name = i.ToString(),
                    ShortName = i.ToString(),
                });
            }

            var indexVm = new IndexViewModel()
            {
                Saved = "test",
                Products = usersViewModels
            };

            Assert.IsType(typeof(IndexViewModel), indexVm);
            usersViewModels.Should().BeEquivalentTo(indexVm.Products);
            "test".Should().BeEquivalentTo(indexVm.Saved);

            usersViewModels[0].Should().BeEquivalentTo(indexVm.Products[0]);
        }

        [Fact]

        public void CataloguesViewModelWorksProperly()
        {
            var groupsViewModels = new List<CataloguesGroupsViewModel>();
            var catalogueViewModels = new List<CatalogueViewModel>();

            for (int i = 0; i < 10; i++)
            {
                groupsViewModels.Add(new CataloguesGroupsViewModel()
                {
                    Group = i.ToString(),
                    CssClass = i.ToString(),
                });
                catalogueViewModels.Add(new CatalogueViewModel()
                {
                    Group = i.ToString(),
                    CssClass = i.ToString(),
                    Number = i,
                    ImageUrl = i.ToString(),
                    TypeId = i
                });
            }

            var indexVm = new CataloguesViewModel()
            {
                Type = "test",
                Catalogues = catalogueViewModels,
                Groups = groupsViewModels,
            };

            Assert.IsType(typeof(CataloguesViewModel), indexVm);
            groupsViewModels.Should().BeEquivalentTo(indexVm.Groups);
            catalogueViewModels.Should().BeEquivalentTo(indexVm.Catalogues);
            "test".Should().BeEquivalentTo(indexVm.Type);

            groupsViewModels[0].Should().BeEquivalentTo(indexVm.Groups.ToList()[0]);
            catalogueViewModels[0].Should().BeEquivalentTo(indexVm.Catalogues.ToList()[0]);
        }

        [Fact]
        public void ColorsViewModelWorksProperly()
        {
            var groupsViewModels = new List<ColorsGroupsViewModel>();
            var catalogueViewModels = new List<Core.ViewModels.ColorsViewModels.ColorViewModel>();

            for (int i = 0; i < 10; i++)
            {
                groupsViewModels.Add(new ColorsGroupsViewModel()
                {
                    Group = i.ToString(),
                    CssClass = i.ToString(),
                });
                catalogueViewModels.Add(new Core.ViewModels.ColorsViewModels.ColorViewModel()
                {
                    Number = i.ToString(),
                    Name = i.ToString(),
                    Real = i.ToString(),
                    Group = i.ToString(),
                    CssClass = i.ToString(),
                    ImageUrl = i.ToString(),
                });
            }

            var indexVm = new ColorsViewModel()
            {
                Type = "test",
                Colors = catalogueViewModels,
                Groups = groupsViewModels,
            };

            Assert.IsType(typeof(ColorsViewModel), indexVm);
            groupsViewModels.Should().BeEquivalentTo(indexVm.Groups);
            catalogueViewModels.Should().BeEquivalentTo(indexVm.Colors);
            "test".Should().BeEquivalentTo(indexVm.Type);

            groupsViewModels[0].Should().BeEquivalentTo(indexVm.Groups.ToList()[0]);
            catalogueViewModels[0].Should().BeEquivalentTo(indexVm.Colors.ToList()[0]);
        }

        [Fact]
        public void GalleriesViewModelWorksProperly()
        {
            var groupsViewModels = new List<GalleresGroupsViewModel>();
            var catalogueViewModels = new List<GalleryPictureViewModel>();

            for (int i = 0; i < 10; i++)
            {
                groupsViewModels.Add(new GalleresGroupsViewModel()
                {
                    Group = i.ToString(),
                    CssClass = i.ToString(),
                });
                catalogueViewModels.Add(new GalleryPictureViewModel()
                {
                    Group = i.ToString(),
                    CssClass = i.ToString(),
                    ImageUrl = i.ToString(),
                });
            }

            var indexVm = new GalleriesViewModel()
            {
                Type = "test",
                Pictures = catalogueViewModels,
                Groups = groupsViewModels,
            };

            Assert.IsType(typeof(GalleriesViewModel), indexVm);
            groupsViewModels.Should().BeEquivalentTo(indexVm.Groups);
            catalogueViewModels.Should().BeEquivalentTo(indexVm.Pictures);
            "test".Should().BeEquivalentTo(indexVm.Type);

            groupsViewModels[0].Should().BeEquivalentTo(indexVm.Groups.ToList()[0]);
            catalogueViewModels[0].Should().BeEquivalentTo(indexVm.Pictures.ToList()[0]);
        }

        [Fact]
        public void EmailContactViewModelWorksProperly()
        {

            var indexVm = new EmailContactViewModel()
            {
                From = "apdimitrov@yahoo.com",
                Subject = "test",
                Message = "anotherTest"
            };

            Assert.IsType(typeof(EmailContactViewModel), indexVm);
            "test".Should().BeEquivalentTo(indexVm.Subject);
            "anotherTest".Should().BeEquivalentTo(indexVm.Message);
            "apdimitrov@yahoo.com".Should().BeEquivalentTo(indexVm.From);
        }

        [Fact]
        public void DeleteViewModelWorksProperly()
        {

            var indexVm = new DeleteViewModel()
            {
                Id = "test"
            };

            Assert.IsType(typeof(DeleteViewModel), indexVm);
            "test".Should().BeEquivalentTo(indexVm.Id);
        }
    }
}
