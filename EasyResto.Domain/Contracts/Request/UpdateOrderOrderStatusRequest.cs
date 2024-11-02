using EasyResto.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class UpdateOrderOrderStatusRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string StatusCode { get; set; }

        public OrderStatusCode OrderStatusCode
        {
            get
            {
                if (Enum.TryParse<OrderStatusCode>(StatusCode, true, out OrderStatusCode orderStatusCode))
                {
                    return orderStatusCode;
                }
                else
                {
                    throw new InvalidOperationException($"StatusCode {StatusCode} is not valid!");
                }
            }
        }

        public bool IsValidStatusCode {
            get
            {
                return Enum.TryParse<OrderStatusCode>(StatusCode, true, out OrderStatusCode _);
            }
        }
    }
}
