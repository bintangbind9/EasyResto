namespace EasyResto.Domain.Entities
{
    public class RolePrivilege
    {
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public Guid PrivilegeId { get; set; }
        public virtual Privilege Privilege { get; set; }
    }
}
