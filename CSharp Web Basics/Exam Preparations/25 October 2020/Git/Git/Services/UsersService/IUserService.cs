using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services.UsersService
{
    public interface IUserService
    {
        ICollection<string> Register(UserRegisterForm model);

        (string id, ICollection<string> errors) Login(LoginUserForm model);

        string Hash(string password);
    }
}
