using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class CreateFoodCategoryRequest
    {
        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
