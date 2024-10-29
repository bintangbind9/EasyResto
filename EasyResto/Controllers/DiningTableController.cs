using AutoMapper;
using EasyResto.Application.Repository;
using EasyResto.Domain.Common;
using EasyResto.Domain.Contracts.Request;
using EasyResto.Domain.Contracts.Response;
using EasyResto.Domain.Entities;
using EasyResto.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EasyResto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiningTableController : ControllerBase
    {
        private readonly string _objName = "Dining Table";
        private readonly ILogger<DiningTableController> _logger;
        private readonly IBaseRepository<DiningTable> _diningTableRepository;
        private readonly IMapper _mapper;

        public DiningTableController(ILogger<DiningTableController> logger, IBaseRepository<DiningTable> diningTableRepository, IMapper mapper)
        {
            _logger = logger;
            _diningTableRepository = diningTableRepository;
            _mapper = mapper;
        }

        [Authorize]
        [AuthPrivilege("ReadDiningTable")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<DiningTableResponse>>();
            response.Data = new List<DiningTableResponse>();

            try
            {
                var diningTables = await _diningTableRepository.GetAllAsync();

                if (diningTables == null || !diningTables.Any())
                {
                    response.Message = $"No {_objName}s found.";
                    return Ok(response);
                }

                response.Message = $"Successfully retrieved all {_objName}s.";
                response.Data = diningTables.Select(e => _mapper.Map<DiningTableResponse>(e));
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
        [AuthPrivilege("ReadDiningTable")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = new BaseResponse<DiningTableResponse>();

            try
            {
                var diningTable = await _diningTableRepository.GetByIdAsync(id);
                if (diningTable == null)
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = $"No {_objName} with Id {id} found.";
                    return NotFound(response);
                }

                response.Message = $"Successfully retrieved {_objName} with Id {id}.";
                response.Data = _mapper.Map<DiningTableResponse>(diningTable);
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
        [AuthPrivilege("CreateDiningTable")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateDiningTableRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var obj = _mapper.Map<DiningTable>(request);
                await _diningTableRepository.CreateAsync(obj);

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
        [AuthPrivilege("UpdateDiningTable")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateDiningTableRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var diningTable = await _diningTableRepository.GetByIdAsync(id);
                if (diningTable == null)
                {
                    response.Message = $"{_objName} with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                var obj = _mapper.Map<DiningTable>(request);
                await _diningTableRepository.UpdateAsync(id, obj);

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
        [AuthPrivilege("DeleteDiningTable")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var diningTable = await _diningTableRepository.GetByIdAsync(id);
                if (diningTable == null)
                {
                    response.Message = $"{_objName} with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                await _diningTableRepository.DeleteAsync(id);

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
        [AuthPrivilege("DeleteDiningTable")]
        [HttpPost]
        [Route("Deletes")]
        public async Task<IActionResult> DeletesAsync(DeleteItemsRequest request)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _diningTableRepository.DeletesAsync(request.Ids);

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
