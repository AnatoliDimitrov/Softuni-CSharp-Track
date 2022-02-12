namespace SharedTrip.Services.UsersService
{
    using System.Collections.Generic;

    using SharedTrip.Models.Users;

    public interface IUserService
    {
        ICollection<string> ValidateRegistration(UserRegisterForm model);

        ICollection<string> Register(UserRegisterForm model);

        string Login(LoginUserForm model);

        string Hash(string password);
    }
}
