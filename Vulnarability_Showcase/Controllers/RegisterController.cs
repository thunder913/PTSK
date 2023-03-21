using Microsoft.AspNetCore.Mvc;

namespace Vulnarability_Showcase.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
