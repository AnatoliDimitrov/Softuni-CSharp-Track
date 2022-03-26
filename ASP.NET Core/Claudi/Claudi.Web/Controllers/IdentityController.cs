using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Claudi.Web.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task<IActionResult> CreateUsers()
        {
            var anatoli = new IdentityUser
            {
                Email = "apdimitrov@yahoo.com",
                UserName = "apdimitrov@yahoo.com",
                EmailConfirmed = true,
                PhoneNumber = "+359898344409",
                NormalizedEmail = "APDIMITROV@YAHOO.COM"
            };

            this._userManager.CreateAsync(anatoli, "Anatoli84");
            return this.Ok();
        }
    }
}
