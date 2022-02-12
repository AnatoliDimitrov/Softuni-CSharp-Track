namespace SharedTrip.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SharedTrip.Models.Users;
    using SharedTrip.Services.UsersService;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService _service)
        {
            this.userService = _service;
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserForm user)
        {
            var userId = userService.Login(user);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Home/Index");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterForm user)
        {
            var errors = userService.Register(user);

            if (errors.Any())
            {
                //return this.Error(errors);
                return this.Redirect("/Users/Register");
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
