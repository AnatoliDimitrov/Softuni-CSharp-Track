namespace FootballManager.Services.UsersService
{
    using System.Collections.Generic;

    using FootballManager.ViewModels.Users;

    public interface IUserService
    {
        ICollection<string> Register(UserRegisterForm model);

        (string id, ICollection<string> errors) Login(LoginUserForm model);

        string Hash(string password);
    }
}
