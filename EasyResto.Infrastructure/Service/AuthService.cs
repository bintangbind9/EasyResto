using EasyResto.Application.Repository;
using EasyResto.Application.Service;
using EasyResto.Domain.Contracts.Response;
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

        public async Task<AuthResponse> Login(string username, string password)
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

            var authResponse = new AuthResponse();
            authResponse.Name = appUser.Name;
            authResponse.Username = appUser.Username;

            string token = GenerateJWTToken(appUser, ref authResponse);

            authResponse.Token = token;

            return authResponse;
        }

        public async Task<AuthResponse> Register(AppUser appUser)
        {
            await _appUserRepository.CreateAsync(appUser);
            var newAppUser = await _appUserRepository.Get(appUser.Username);
            if (newAppUser == null)
            {
                throw new Exception("Register new User Failed.");
            }

            var authResponse = new AuthResponse();
            authResponse.Name = newAppUser.Name;
            authResponse.Username = newAppUser.Username;

            string token = GenerateJWTToken(newAppUser, ref authResponse);

            authResponse.Token = token;

            return authResponse;
        }

        public string GenerateJWTToken(AppUser user, ref AuthResponse authResponse)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Name, user.Username),
            };

            foreach (AppUserRole appUserRole in user.AppUserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, appUserRole.Role.Code));
                authResponse.Roles.Add(appUserRole.Role.Code);

                foreach (RolePrivilege rolePrivilege in appUserRole.Role.RolePrivileges)
                {
                    claims.Add(new Claim(AuthCode.Privilege.ToString(), rolePrivilege.Privilege.Code));
                    authResponse.Privileges.Add(rolePrivilege.Privilege.Code);
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
