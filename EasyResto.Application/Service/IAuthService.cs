using EasyResto.Domain.Entities;

namespace EasyResto.Application.Service
{
    public interface IAuthService
    {
        public Task<string> Login(string username, string password);

        public Task<string> Register(AppUser appUser);

        public string GenerateJWTToken(AppUser user);
    }
}
