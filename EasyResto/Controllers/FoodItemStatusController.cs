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
    public class FoodItemStatusController : ControllerBase
    {
        private readonly string _objName = "Food Item Status";
        private readonly ILogger<FoodItemStatusController> _logger;
        private readonly IBaseRepository<FoodItemStatus> _foodItemStatusRepository;
        private readonly IMapper _mapper;

        public FoodItemStatusController(ILogger<FoodItemStatusController> logger, IBaseRepository<FoodItemStatus> foodItemStatusRepository, IMapper mapper)
        {
            _logger = logger;
            _foodItemStatusRepository = foodItemStatusRepository;
            _mapper = mapper;
        }

        [Authorize]
        [AuthPrivilege("ReadFoodItemStatus")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<FoodItemStatusResponse>>();
            response.Data = new List<FoodItemStatusResponse>();

            try
            {
                var foodItemStatuses = await _foodItemStatusRepository.GetAllAsync();

                if (foodItemStatuses == null || !foodItemStatuses.Any())
                {
                    response.Message = $"No {_objName}s found.";
                    return Ok(response);
                }

                response.Message = $"Successfully retrieved all {_objName}s.";
                response.Data = foodItemStatuses.Select(e => _mapper.Map<FoodItemStatusResponse>(e));
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
