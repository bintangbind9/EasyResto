using EasyResto.Domain.Contracts.Response;
using EasyResto.Domain.Entities;

namespace EasyResto.Application.Service
{
    public interface IAuthService
    {
        public Task<AuthResponse> Login(string username, string password);

        public Task<AuthResponse> Register(AppUser appUser);

        public string GenerateJWTToken(AppUser user, ref AuthResponse authResponse);
    }
}
