using Microsoft.AspNetCore.Mvc;
using Vulnarability_Showcase.Services.Interfaces;
using Vulnarability_Showcase.ViewModels;

namespace Vulnarability_Showcase.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (!HttpContext.Request.Cookies.Any(x => x.Key == "username"))
            {
                return this.Redirect("/Login");
            }

            try
            {
                var username = HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == "username");

                var user = _userService.GetHomePageData(username.Value);

                return this.View(user);
            }
            catch (Exception)
            {
                return this.View(new HomeViewModel() { IsLoggedIn = false });
            }
        }
    }
}
