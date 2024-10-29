using AutoMapper;
using EasyResto.Application.Repository;
using EasyResto.Domain.Common;
using EasyResto.Domain.Contracts.Response;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Repository;
using EasyResto.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyResto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly string _objName = "Role";
        private readonly ILogger<RoleController> _logger;
        private readonly IBaseRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public RoleController(ILogger<RoleController> logger, IBaseRepository<Role> roleRepository, IMapper mapper)
        {
            _logger = logger;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [Authorize]
        [AuthPrivilege("ReadRole")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<RoleResponse>>();
            response.Data = new List<RoleResponse>();

            try
            {
                var roles = await _roleRepository.GetAllAsync();

                if (roles == null || !roles.Any())
                {
                    response.Message = $"No {_objName}s found.";
                    return Ok(response);
                }

                response.Message = $"Successfully retrieved all {_objName}s.";
                response.Data = roles.Select(e => _mapper.Map<RoleResponse>(e));
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = $"An error occurred while retrieving all {_objName}s.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }
    }
}
