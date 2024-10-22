using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class FoodCategory : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
    }
}
