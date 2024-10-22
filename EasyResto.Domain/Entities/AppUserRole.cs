namespace EasyResto.Domain.Entities
{
    public class AppUserRole
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
