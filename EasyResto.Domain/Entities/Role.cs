using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AppUserRole> AppUserRoles { get; set; } = new List<AppUserRole>();

        public virtual ICollection<RolePrivilege> RolePrivileges { get; set; } = new List<RolePrivilege>();
    }
}
