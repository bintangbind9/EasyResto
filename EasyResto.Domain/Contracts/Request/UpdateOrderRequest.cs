using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class UpdateOrderRequest
    {
        [Required]
        public Guid DiningTableId { get; set; }

        [Required]
        public Guid OrderStatusId { get; set; }

        public Guid? ChefId { get; set; }

        public Guid? CashierId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Tax { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal BillAmount { get; set; }

        [MaxLength(255)]
        public string? CashierNote { get; set; }

        [MaxLength(255)]
        public string? CustomerNote { get; set; }

        public ICollection<OrderDetailRequest> OrderDetails { get; set; } = new List<OrderDetailRequest>();
    }
}
