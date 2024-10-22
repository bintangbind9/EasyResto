using EasyResto.Application.Service;
using Microsoft.AspNetCore.Identity;

namespace EasyResto.Infrastructure.Service
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<object> _passwordHasher;

        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<object>();
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(new object(), password);
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(new object(), hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
