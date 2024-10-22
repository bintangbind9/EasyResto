using AutoMapper;
using EasyResto.Application.Repository;
using EasyResto.Domain.Common;
using EasyResto.Domain.Contracts.Request;
using EasyResto.Domain.Entities;
using EasyResto.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EasyResto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodCategoryController : ControllerBase
    {
        private readonly ILogger<FoodCategoryController> _logger;
        private readonly IBaseRepository<FoodCategory> _foodCategoryRepository;
        private readonly IMapper _mapper;

        public FoodCategoryController(ILogger<FoodCategoryController> logger, IBaseRepository<FoodCategory> foodCategoryRepository, IMapper mapper)
        {
            _logger = logger;
            _foodCategoryRepository = foodCategoryRepository;
            _mapper = mapper;
        }

        [Authorize]
        [AuthPrivilege("ReadFoodCategory")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<FoodCategory>>();

            try
            {
                var foodCategories = await _foodCategoryRepository.GetAllAsync();

                if (foodCategories == null || !foodCategories.Any())
                {
                    response.Message = "No Food Category Items found.";
                    return Ok(response);
                }

                response.Message = "Successfully retrieved all Food Categories.";
                response.Data = foodCategories;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred while retrieving all Food Categories.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }

        [Authorize]
        [AuthPrivilege("ReadFoodCategory")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = new BaseResponse<FoodCategory>();

            try
            {
                var foodCategory = await _foodCategoryRepository.GetByIdAsync(id);
                if (foodCategory == null)
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = $"No Food Category item with Id {id} found.";
                    return NotFound(response);
                }

                response.Message = $"Successfully retrieved Food Category item with Id {id}.";
                response.Data = foodCategory;
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                response.Message = $"An error occurred while retrieving the Food Category item with Id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = (int)HttpStatusCode.NotFound;
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.Message = $"An error occurred while retrieving the Food Category item with Id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }

        [Authorize]
        [AuthPrivilege("CreateFoodCategory")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateFoodCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var obj = _mapper.Map<FoodCategory>(request);
                await _foodCategoryRepository.CreateAsync(obj);

                response.Message = "Food Category successfully create";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred while creating the Food Category Item.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }

        [Authorize]
        [AuthPrivilege("UpdateFoodCategory")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateFoodCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var foodCategory = await _foodCategoryRepository.GetByIdAsync(id);
                if (foodCategory == null)
                {
                    response.Message = $"Food Category Item with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                var obj = _mapper.Map<FoodCategory>(request);
                await _foodCategoryRepository.UpdateAsync(id, obj);

                response.Message = $"Food Category Item with id {id} successfully updated.";
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                response.Message = $"An error occurred while retrieving the Food Category item with Id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = (int)HttpStatusCode.NotFound;
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.Message = $"An error occurred while updating Food Category with id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }

        [Authorize]
        [AuthPrivilege("DeleteFoodCategory")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var foodCategory = await _foodCategoryRepository.GetByIdAsync(id);
                if (foodCategory == null)
                {
                    response.Message = $"Food Category Item with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                await _foodCategoryRepository.DeleteAsync(id);

                response.Message = $"Food Category with id {id} successfully deleted.";
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                response.Message = $"An error occurred while retrieving the Food Category item with Id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = (int)HttpStatusCode.NotFound;
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.Message = $"An error occurred while deleting Food Category Item with id {id}.";
                response.Errors = new List<string> { ex.Message };
                response.Status = 500;
                return StatusCode(500, response);
            }
        }
    }
}
