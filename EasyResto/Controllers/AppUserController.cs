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
    public class AppUserController : ControllerBase
    {
        private readonly string _objName = "App User";
        private readonly ILogger<AppUserController> _logger;
        private readonly IBaseRepository<AppUser> _appUserRepository;
        private readonly IMapper _mapper;

        public AppUserController(ILogger<AppUserController> logger, IBaseRepository<AppUser> appUserRepository, IMapper mapper)
        {
            _logger = logger;
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        [Authorize]
        [AuthPrivilege("ReadAppUser")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<AppUserResponse>>();

            try
            {
                var appUsers = await _appUserRepository.GetAllAsync();

                if (appUsers == null || !appUsers.Any())
                {
                    response.Message = $"No {_objName}s found.";
                    return Ok(response);
                }

                response.Message = $"Successfully retrieved all {_objName}s.";
                response.Data = appUsers.Select(e => _mapper.Map<AppUserResponse>(e));
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
        [AuthPrivilege("ReadAppUser")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = new BaseResponse<AppUserResponse>();

            try
            {
                var appUser = await _appUserRepository.GetByIdAsync(id);
                if (appUser == null)
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = $"No {_objName} with Id {id} found.";
                    return NotFound(response);
                }

                response.Message = $"Successfully retrieved {_objName} with Id {id}.";
                response.Data = _mapper.Map<AppUserResponse>(appUser);
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
        [AuthPrivilege("CreateAppUser")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var obj = _mapper.Map<AppUser>(request);
                await _appUserRepository.CreateAsync(obj);

                response.Message = $"{_objName} successfully created.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = $"An error occurred while creating the {_objName}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }

        [Authorize]
        [AuthPrivilege("UpdateAppUser")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateAppUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var appUser = await _appUserRepository.GetByIdAsync(id);
                if (appUser == null)
                {
                    response.Message = $"{_objName} with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                var obj = _mapper.Map<AppUser>(request);
                await _appUserRepository.UpdateAsync(id, obj);

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

        [Authorize]
        [AuthPrivilege("DeleteAppUser")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var appUser = await _appUserRepository.GetByIdAsync(id);
                if (appUser == null)
                {
                    response.Message = $"{_objName} with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                await _appUserRepository.DeleteAsync(id);

                response.Message = $"{_objName} with id {id} successfully deleted.";
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
                response.Message = $"An error occurred while deleting {_objName} with id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }

        [Authorize]
        [AuthPrivilege("DeleteAppUser")]
        [HttpPost]
        [Route("Deletes")]
        public async Task<IActionResult> DeletesAsync(DeleteItemsRequest request)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _appUserRepository.DeletesAsync(request.Ids);

                response.Message = $"{_objName}s successfully deleted.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = $"An error occurred while deleting {_objName}s.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }
    }
}
