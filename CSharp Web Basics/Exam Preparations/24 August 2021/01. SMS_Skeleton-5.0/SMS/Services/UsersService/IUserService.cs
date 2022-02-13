namespace SMS.Services.UsersService
{
    using SMS.Models.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        ICollection<string> Register(UserRegisterForm model);

        (string id, ICollection<string> errors) Login(LoginUserForm model);

        string Hash(string password);
    }
}
