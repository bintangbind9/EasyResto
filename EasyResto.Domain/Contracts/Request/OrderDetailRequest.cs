using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class OrderDetailRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid FoodItemId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 100)]
        public int Qty { get; set; }
    }
}
