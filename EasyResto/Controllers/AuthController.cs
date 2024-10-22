using AutoMapper;
using EasyResto.Application.Service;
using EasyResto.Domain.Common;
using EasyResto.Domain.Contracts.Request;
using EasyResto.Domain.Contracts.Response;
using EasyResto.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EasyResto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IMapper mapper, IAuthService authService)
        {
            _logger = logger;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AuthLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<AuthResponse>();

            try
            {
                string token = await _authService.Login(request.Username, request.Password);
                response.Data = new AuthResponse { Token = token };

                response.Message = "Successfully logged in.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred while logging in.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(AuthRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<AuthResponse>();

            try
            {
                var appUser = _mapper.Map<AppUser>(request);
                string token = await _authService.Register(appUser);
                response.Data = new AuthResponse { Token = token };

                response.Message = "Successfully Registered new User.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred while registering new User.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }
    }
}
