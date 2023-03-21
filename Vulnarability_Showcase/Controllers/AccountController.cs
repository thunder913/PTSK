using Microsoft.AspNetCore.Mvc;
using Vulnarability_Showcase.Services.Interfaces;
using Vulnarability_Showcase.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using Aspose.Words;

namespace Vulnarability_Showcase.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                var result = _userService.Login(loginViewModel);
               return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterViewModel registerViewModel)
        {
            try
            {
                var user = _userService.Register(registerViewModel);
                CreateWordDoc(user.FirstName, user.LastName, user.Address, user.Id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public void CreateWordDoc(string firstName, string lastName, string address, int id)
        {
            var doc = new Aspose.Words.Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            builder.Writeln("Id: " + id);
            builder.Writeln(firstName + " " + lastName);
            builder.Writeln(address);

            // Issue: Could be a location, where we should not write if host it or if a hacker gets access to the source code
            var path = $"E:\\Repository\\CS-Algorithms\\Dynamic Programming\\Vulnarability_Showcase\\Vulnarability_Showcase\\wwwroot\\medicalRecords\\{id}.docx";
            doc.Save(path);
        }
    }
}
