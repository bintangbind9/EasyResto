using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AppUserRole> AppUserRoles { get; set; } = new List<AppUserRole>();

        public ICollection<Order> WaiterOrders { get; set; } = new List<Order>();
        public ICollection<Order> ChefOrders { get; set; } = new List<Order>();
        public ICollection<Order> CashierOrders { get; set; } = new List<Order>();
    }
}
