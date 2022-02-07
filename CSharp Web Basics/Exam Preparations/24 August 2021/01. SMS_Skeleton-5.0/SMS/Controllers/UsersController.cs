namespace SMS.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using SMS.Models.Users;
    using SMS.Services;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly SMSDbContext context;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(IValidator _validator, SMSDbContext _context, IPasswordHasher _passwordHasher)
        {
            this.validator = _validator;
            this.context = _context;
            this.passwordHasher = _passwordHasher;
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
            var hashedPassword = passwordHasher.Hash(user.Password);

            var userId = this.context
                .Users
                .Where(u => u.Username == user.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();
            if (userId == null)
            {
                return Error("Incorrect password and username");
            }

            this.SignIn(userId);

            return this.Redirect("/Home/Index");
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
                return Error(errors);
            }


            this.context
                .Users
                .Add(new User()
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = passwordHasher.Hash(user.Password),
                    Cart = new Cart(),
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
