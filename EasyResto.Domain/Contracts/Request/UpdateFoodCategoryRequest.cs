using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class UpdateFoodCategoryRequest
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
