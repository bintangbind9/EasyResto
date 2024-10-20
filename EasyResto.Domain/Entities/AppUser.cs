using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
