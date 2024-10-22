using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class Privilege : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RolePrivilege> RolePrivileges { get; set; } = new List<RolePrivilege>();
    }
}
