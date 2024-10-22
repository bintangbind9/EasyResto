using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class FoodItem : BaseEntity
    {
        public Guid FoodCategoryId { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
        public Guid FoodItemStatusId { get; set; }
        public virtual FoodItemStatus FoodItemStatus { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
