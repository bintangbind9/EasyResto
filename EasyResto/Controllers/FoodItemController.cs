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
    public class FoodItemController : ControllerBase
    {
        private readonly string _objName = "Food";
        private readonly ILogger<FoodItemController> _logger;
        private readonly FoodItemRepository _foodItemRepository;
        private readonly IMapper _mapper;

        public FoodItemController(ILogger<FoodItemController> logger, IBaseRepository<FoodItem> foodItemRepository, IMapper mapper)
        {
            _logger = logger;
            _foodItemRepository = (FoodItemRepository)foodItemRepository;
            _mapper = mapper;
        }

        [Authorize]
        [AuthPrivilege("ReadFoodItem")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<FoodItemResponse>>();
            response.Data = new List<FoodItemResponse>();

            try
            {
                var foodItems = await _foodItemRepository.GetAllAsync();

                if (foodItems == null || !foodItems.Any())
                {
                    response.Message = $"No {_objName}s found.";
                    return Ok(response);
                }

                response.Message = $"Successfully retrieved all {_objName}s.";
                response.Data = foodItems.Select(e => _mapper.Map<FoodItemResponse>(e));
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
        [AuthPrivilege("ReadFoodItem")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = new BaseResponse<FoodItemResponse>();

            try
            {
                var foodItem = await _foodItemRepository.GetByIdAsync(id);
                if (foodItem == null)
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = $"No {_objName} with Id {id} found.";
                    return NotFound(response);
                }

                response.Message = $"Successfully retrieved {_objName} with Id {id}.";
                response.Data = _mapper.Map<FoodItemResponse>(foodItem);
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
        [AuthPrivilege("CreateFoodItem")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateFoodItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var obj = _mapper.Map<FoodItem>(request);
                await _foodItemRepository.CreateAsync(obj);

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
        [AuthPrivilege("UpdateFoodItem")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateFoodItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var foodItem = await _foodItemRepository.GetByIdAsync(id);
                if (foodItem == null)
                {
                    response.Message = $"{_objName} with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                var obj = _mapper.Map<FoodItem>(request);
                await _foodItemRepository.UpdateAsync(id, obj);

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
        [AuthPrivilege("DeleteFoodItem")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var foodItem = await _foodItemRepository.GetByIdAsync(id);
                if (foodItem == null)
                {
                    response.Message = $"{_objName} with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                await _foodItemRepository.DeleteAsync(id);

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
        [AuthPrivilege("DeleteFoodItem")]
        [HttpPost]
        [Route("Deletes")]
        public async Task<IActionResult> DeletesAsync(DeleteItemsRequest request)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _foodItemRepository.DeletesAsync(request.Ids);

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
