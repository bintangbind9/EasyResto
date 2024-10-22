using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; } = new List<AppUserRole>();

        public virtual ICollection<Order> WaiterOrders { get; set; } = new List<Order>();
        public virtual ICollection<Order> ChefOrders { get; set; } = new List<Order>();
        public virtual ICollection<Order> CashierOrders { get; set; } = new List<Order>();
    }
}
