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
    public class OrderStatusController : ControllerBase
    {
        private readonly string _objName = "Order Status";
        private readonly ILogger<OrderStatusController> _logger;
        private readonly IBaseRepository<OrderStatus> _orderStatusRepository;
        private readonly IMapper _mapper;

        public OrderStatusController(ILogger<OrderStatusController> logger, IBaseRepository<OrderStatus> orderStatusRepository, IMapper mapper)
        {
            _logger = logger;
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
        }

        [Authorize]
        [AuthPrivilege("ReadOrderStatus")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<OrderStatusResponse>>();
            response.Data = new List<OrderStatusResponse>();

            try
            {
                var orderStatuses = await _orderStatusRepository.GetAllAsync();

                if (orderStatuses == null || !orderStatuses.Any())
                {
                    response.Message = $"No {_objName}es found.";
                    return Ok(response);
                }

                response.Message = $"Successfully retrieved all {_objName}es.";
                response.Data = orderStatuses.Select(e => _mapper.Map<OrderStatusResponse>(e));
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
