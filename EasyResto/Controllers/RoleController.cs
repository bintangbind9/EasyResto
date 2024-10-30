using AutoMapper;
using EasyResto.Application.Repository;
using EasyResto.Domain.Common;
using EasyResto.Domain.Contracts.Request;
using EasyResto.Domain.Contracts.Response;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Repository;
using EasyResto.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EasyResto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly string _objName = "Role";
        private readonly ILogger<RoleController> _logger;
        private readonly RoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleController(ILogger<RoleController> logger, IBaseRepository<Role> roleRepository, IMapper mapper)
        {
            _logger = logger;
            _roleRepository = (RoleRepository)roleRepository;
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

        [Authorize]
        [AuthPrivilege("ReadRole")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = new BaseResponse<RoleResponse>();

            try
            {
                var role = await _roleRepository.GetByIdAsync(id);
                if (role == null)
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = $"No {_objName} with Id {id} found.";
                    return NotFound(response);
                }

                var roleResponse = _mapper.Map<RoleResponse>(role);
                foreach (var rolePrivilege in role.RolePrivileges)
                {
                    roleResponse.Privileges.Add(_mapper.Map<PrivilegeResponse>(rolePrivilege.Privilege));
                }

                response.Message = $"Successfully retrieved {_objName} with Id {id}.";
                response.Data = roleResponse;
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                response.Message = $"An error occurred while retrieving the {_objName} with Id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = (int)HttpStatusCode.NotFound;
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.Message = $"An error occurred while retrieving the {_objName} with Id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }

        [Authorize]
        [AuthPrivilege("UpdateRole")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateRoleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var role = await _roleRepository.GetByIdAsync(id);
                if (role == null)
                {
                    response.Message = $"{_objName} with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                var obj = _mapper.Map<Role>(request);
                await _roleRepository.UpdateAsync(id, obj, request.PrivilegeIdsToAdd, request.PrivilegeIdsToRemove);

                response.Message = $"{_objName} with id {id} successfully updated.";
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                response.Message = $"An error occurred while retrieving the {_objName} with Id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = (int)HttpStatusCode.NotFound;
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.Message = $"An error occurred while updating {_objName} with id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }
    }
}
