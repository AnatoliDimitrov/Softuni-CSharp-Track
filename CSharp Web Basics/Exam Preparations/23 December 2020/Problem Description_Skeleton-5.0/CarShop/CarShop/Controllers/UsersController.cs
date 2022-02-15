namespace CarShop.Controllers
{
    using System.Linq;

    using CarShop.Services.UsersService;
    using CarShop.ViewModels;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(UserService _service)
        {
            this.userService = _service;
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Home/Index");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserForm user)
        {
            var (userId, errors) = userService.Login(user);

            if (userId == null)
            {
                errors.Add("Incorrect username or password.");
                return this.Error(errors);
                //return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/Cars/All");
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Cars/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterForm user)
        {
            var errors = userService.Register(user);

            if (errors.Any())
            {
                return this.Error(errors);
                //return this.Redirect("/Users/Register");
            }

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/Home/Index");
        }
    }
}
