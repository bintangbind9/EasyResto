using AutoMapper;
using EasyResto.Application.Repository;
using EasyResto.Domain.Common;
using EasyResto.Domain.Contracts.Response;
using EasyResto.Domain.Entities;
using EasyResto.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyResto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivilegeController : ControllerBase
    {
        private readonly string _objName = "Privilege";
        private readonly ILogger<PrivilegeController> _logger;
        private readonly IBaseRepository<Privilege> _privilegeRepository;
        private readonly IMapper _mapper;

        public PrivilegeController(ILogger<PrivilegeController> logger, IBaseRepository<Privilege> privilegeRepository, IMapper mapper)
        {
            _logger = logger;
            _privilegeRepository = privilegeRepository;
            _mapper = mapper;
        }

        [Authorize]
        [AuthPrivilege("ReadPrivilege")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<PrivilegeResponse>>();
            response.Data = new List<PrivilegeResponse>();

            try
            {
                var privileges = await _privilegeRepository.GetAllAsync();

                if (privileges == null || !privileges.Any())
                {
                    response.Message = $"No {_objName}s found.";
                    return Ok(response);
                }

                response.Message = $"Successfully retrieved all {_objName}s.";
                response.Data = privileges.Select(e => _mapper.Map<PrivilegeResponse>(e));
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
