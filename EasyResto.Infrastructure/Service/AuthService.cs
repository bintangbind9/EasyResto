using EasyResto.Application.Repository;
using EasyResto.Application.Service;
using EasyResto.Domain.Entities;
using EasyResto.Domain.Enums;
using EasyResto.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyResto.Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IPasswordService _passwordService;
        private readonly AppUserRepository _appUserRepository;

        public AuthService(IConfiguration configuration, IPasswordService passwordService, IBaseRepository<AppUser> appUserRepository)
        {
            _configuration = configuration;
            _passwordService = passwordService;
            _appUserRepository = (AppUserRepository)appUserRepository;
        }

        public async Task<string> Login(string username, string password)
        {
            var appUser = await _appUserRepository.Get(username);
            if (appUser == null)
            {
                throw new Exception("Username or password is not valid.");
            }

            bool isPasswordValid = _passwordService.VerifyPassword(appUser.Password, password);
            if (!isPasswordValid)
            {
                throw new Exception("Username or password is not valid.");
            }

            string token = GenerateJWTToken(appUser);

            return token;
        }

        public async Task<string> Register(AppUser appUser)
        {
            await _appUserRepository.CreateAsync(appUser);
            var newAppUser = await _appUserRepository.Get(appUser.Username);
            if (newAppUser == null)
            {
                throw new Exception("Register new User Failed.");
            }

            string token = GenerateJWTToken(newAppUser);

            return token;
        }

        public string GenerateJWTToken(AppUser user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Name, user.Username),
            };

            foreach (AppUserRole appUserRole in user.AppUserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, appUserRole.Role.Code));

                foreach (RolePrivilege rolePrivilege in appUserRole.Role.RolePrivileges)
                {
                    claims.Add(new Claim(AuthCode.Privilege.ToString(), rolePrivilege.Privilege.Code));
                }
            }

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!)
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
