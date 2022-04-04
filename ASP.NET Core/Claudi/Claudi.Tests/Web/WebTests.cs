using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Claudi.Tests.Web;

public class WebTests : WebApplicationFactory<Program>
{

    [Fact]
    public async Task IndexPageContainsH2()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Ние правим вашия дом свеж и модерен", html);
    }

    [Fact]
    public async Task CataloguesIndexPageContainsH1Prices()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Catalogues/Index");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("<h1>Цени</h1>", html);
    }

    [Fact]
    public async Task CalculatorsIndexPageContainsH1Prices()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Calculators/Index");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("<h1>Калкулатор</h1>", html);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task ColorsIndexPageContainsH1Samples()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Colors/Index");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("<h1>Мостри</h1>", html);
    }

    [Fact]
    public async Task ProductsIndexPageContainsH1Products()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Products/Index");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("<h1>Продукти</h1>", html);
    }

    [Fact]
    public async Task ContactsIndexPageContainsH1Conacts()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Home/Contact");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("<h1>Контакти</h1>", html);
    }

    [Fact]
    public async Task AdminDashboardIndexPageContainsHeader()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Administration/Dashboard/Index");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("<header class=", html);
    }

    [Fact]
    public async Task AdminAccountsIndexPageContainsHeader()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Administration/Accounts/Index");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("<header class=", html);
    }

    [Fact]
    public async Task CataloguesHorizontalPageContainsHeader()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Catalogues/Horizontal");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Хоризонтални Щори", html);
    }

    [Fact]
    public async Task CataloguesVerticalPageContainsHeader()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Catalogues/Vertical");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Вертикални Щори", html);
    }

    [Fact]
    public async Task CataloguesWoodenPageContainsHeader()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Catalogues/Wooden");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Дървени Щори", html);
    }

    [Fact]
    public async Task CataloguesRollerPageContainsHeader()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Catalogues/Roller");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Руло Щори", html);
    }

    [Fact]
    public async Task CataloguesPleatPageContainsHeader()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Catalogues/Pleat");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Плисе Щори", html);
    }

    [Fact]
    public async Task CataloguesRomanPageContainsHeader()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Catalogues/Roman");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Римски Щори", html);
    }

    [Fact]
    public async Task CataloguesBambooPageContainsHeader()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Catalogues/Bamboo");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Бамбукови Щори", html);
    }

    [Fact]
    public async Task ProductsHorizontalPageContainsH1Products()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Products/Horizontal");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Хоризонтални Щори", html);
    }

    [Fact]
    public async Task ProductsVerticalPageContainsH1Products()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Products/Vertical");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Вертикални Щори", html);
    }

    [Fact]
    public async Task ProductsWoodenPageContainsH1Products()
    {
        var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var response = await client.GetAsync("/Products/Wooden");

        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Дървени Щори", html);
    }
}
