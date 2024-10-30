using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Contracts.Request
{
    public class UpdateRoleRequest
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public List<Guid> PrivilegeIdsToAdd { get; set; } = new List<Guid>();

        public List<Guid> PrivilegeIdsToRemove { get; set; } = new List<Guid>();
    }
}
