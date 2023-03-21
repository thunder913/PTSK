using Azure.Identity;
using Vulnarability_Showcase.Common;
using Vulnarability_Showcase.Models;
using Vulnarability_Showcase.Services.Interfaces;
using Vulnarability_Showcase.ViewModels;

namespace Vulnarability_Showcase.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public HomeViewModel GetHomePageData(string username)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                throw new ArgumentNullException("User is not logged in");
            }

            var toReturn = new HomeViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FileName = user.Id + ".docx",
                IsLoggedIn = true
            };

            return toReturn;
        }

        public User Login(LoginViewModel loginViewModel)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(x => x.Username == loginViewModel.Username);
            
            if (user == null)
            {
                throw new ArgumentNullException("User is null!");
            }

            if (!PasswordManager.VerifyPassword(loginViewModel.Password, user.Password))
            {
                throw new InvalidDataException("Invalid password!");
            }

            return user;
        }

        public User Register(RegisterViewModel registerViewModel)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(x => x.Username == registerViewModel.Username);

            if (user != null)
            {
                throw new ArgumentException("User with username already exists!");
            }

            // Issue: Not validating, that everything is fine on the BE
            var newUser = new User()
            {
                Address = registerViewModel.Address,
                EGN = registerViewModel.EGN,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Password = PasswordManager.HashPassword(registerViewModel.Password),
                Username = registerViewModel.Username
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return newUser;
        }
    }
}
