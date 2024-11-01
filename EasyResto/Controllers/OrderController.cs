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
    public class OrderController : ControllerBase
    {
        private readonly string _objName = "Order";
        private readonly ILogger<OrderController> _logger;
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(ILogger<OrderController> logger, IBaseRepository<Order> orderRepository, IMapper mapper)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [Authorize]
        [AuthPrivilege("ReadOrder")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<OrderResponse>>();
            response.Data = new List<OrderResponse>();

            try
            {
                var orders = await _orderRepository.GetAllAsync();

                if (orders == null || !orders.Any())
                {
                    response.Message = $"No {_objName}s found.";
                    return Ok(response);
                }

                response.Message = $"Successfully retrieved all {_objName}s.";
                response.Data = orders.Select(e => _mapper.Map<OrderResponse>(e));
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
        [AuthPrivilege("ReadOrder")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = new BaseResponse<OrderResponse>();

            try
            {
                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null)
                {
                    response.Status = (int)HttpStatusCode.NotFound;
                    response.Message = $"No {_objName} with Id {id} found.";
                    return NotFound(response);
                }

                response.Message = $"Successfully retrieved {_objName} with Id {id}.";
                response.Data = _mapper.Map<OrderResponse>(order);
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
        [AuthPrivilege("CreateOrder")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var obj = _mapper.Map<Order>(request);
                await _orderRepository.CreateAsync(obj);

                response.Message = $"New {_objName} successfully created.";
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
        [AuthPrivilege("UpdateOrder")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = new BaseResponse<string>();

            try
            {
                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null)
                {
                    response.Message = $"{_objName} with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                var obj = _mapper.Map<Order>(request);
                await _orderRepository.UpdateAsync(id, obj);

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
        [AuthPrivilege("DeleteOrder")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null)
                {
                    response.Message = $"{_objName} with id {id} not found.";
                    response.Status = (int)HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                await _orderRepository.DeleteAsync(id);

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
        [AuthPrivilege("DeleteOrder")]
        [HttpPost]
        [Route("Deletes")]
        public async Task<IActionResult> DeletesAsync(DeleteItemsRequest request)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _orderRepository.DeletesAsync(request.Ids);

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
