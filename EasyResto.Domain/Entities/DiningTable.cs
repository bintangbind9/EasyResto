using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class DiningTable : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
