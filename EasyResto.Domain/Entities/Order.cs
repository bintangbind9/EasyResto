using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid DiningTableId { get; set; }
        public virtual DiningTable DiningTable { get; set; }

        public Guid OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        public Guid WaiterId { get; set; }
        public virtual AppUser Waiter { get; set; }

        public Guid? ChefId { get; set; }
        public virtual AppUser Chef { get; set; }

        public Guid? CashierId { get; set; }
        public virtual AppUser Cashier { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Tax { get; set; }

        public decimal BillAmount { get; set; }

        public string CashierNote { get; set; }

        public string CustomerNote { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
