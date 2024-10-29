using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class CreateDiningTableRequest
    {
        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(1, 10)]
        public int Capacity { get; set; }
    }
}
