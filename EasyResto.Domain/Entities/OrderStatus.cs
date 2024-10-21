using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
