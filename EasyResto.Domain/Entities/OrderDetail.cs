using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }
    }
}
