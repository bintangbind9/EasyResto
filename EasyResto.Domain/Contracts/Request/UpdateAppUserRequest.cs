using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class UpdateAppUserRequest
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
