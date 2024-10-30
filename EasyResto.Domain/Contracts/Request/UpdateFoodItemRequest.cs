using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class UpdateFoodItemRequest
    {
        [Required]
        public Guid FoodCategoryId { get; set; }

        [Required]
        public Guid FoodItemStatusId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
