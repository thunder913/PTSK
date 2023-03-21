using Vulnarability_Showcase.Models;
using Vulnarability_Showcase.ViewModels;

namespace Vulnarability_Showcase.Services.Interfaces
{
    public interface IUserService
    {
        User Login(LoginViewModel loginViewModel);
        User Register(RegisterViewModel registerViewModel);
        HomeViewModel GetHomePageData(string username);
    }
}
