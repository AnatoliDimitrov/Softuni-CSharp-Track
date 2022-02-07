namespace SharedTrip.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Models.Users;
    using SharedTrip.Services;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext context;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(IValidator _validator, ApplicationDbContext _context, IPasswordHasher _passwordHasher)
        {
            this.validator = _validator;
            this.context = _context;
            this.passwordHasher = _passwordHasher;
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
            var hashedPassword = passwordHasher.Hash(user.Password);

            var userId = this.context
                .Users
                .Where(u => u.Username == user.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

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
            var errors = validator.ValidateRegistration(user);

            if (this.context.Users.Any(u => u.Username == user.Username))
            {
                errors.Add("Username is already taken.");
            }

            if (this.context.Users.Any(u => u.Email == user.Email))
            {
                errors.Add("Email already registered.");
            }

            if (errors.Any())
            {
                return this.Redirect("/Users/Register");
            }


            this.context
                .Users
                .Add(new User()
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = passwordHasher.Hash(user.Password),
                });

            context.SaveChanges();

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/Home/Index");
        }
    }
}
