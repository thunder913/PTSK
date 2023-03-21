using Microsoft.AspNetCore.Mvc;
using Vulnarability_Showcase.ViewModels;

namespace Vulnarability_Showcase.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
