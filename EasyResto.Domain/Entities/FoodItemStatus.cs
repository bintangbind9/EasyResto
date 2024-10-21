using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class FoodItemStatus : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
    }
}
