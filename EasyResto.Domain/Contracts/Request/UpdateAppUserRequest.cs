using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class UpdateAppUserRequest
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string? Password { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public List<Guid> RoleIdsToAdd { get; set; } = new List<Guid>();

        public List<Guid> RoleIdsToRemove { get; set; } = new List<Guid>();
    }
}
