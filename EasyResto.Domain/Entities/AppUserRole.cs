namespace EasyResto.Domain.Entities
{
    public class AppUserRole
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
