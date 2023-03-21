using Vulnarability_Showcase.Models;

namespace Vulnarability_Showcase.Common
{
    public static class PasswordManager
    {
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public static bool VerifyPassword(string passwordOne, string passwordTwo) 
            => BCrypt.Net.BCrypt.Verify(passwordOne, passwordTwo);
    }
}
