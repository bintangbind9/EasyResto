using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class OrderDetail : BaseEntity, IEquatable<OrderDetail>
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Guid FoodItemId { get; set; }
        public virtual FoodItem FoodItem { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }

        public bool Equals(OrderDetail? other)
        {
            if (other == null) return false;

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OrderDetail);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
