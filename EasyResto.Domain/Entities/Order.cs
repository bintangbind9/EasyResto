using EasyResto.Domain.Common;

namespace EasyResto.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid DiningTableId { get; set; }
        public DiningTable DiningTable { get; set; }

        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public Guid WaiterId { get; set; }
        public AppUser Waiter { get; set; }

        public Guid? ChefId { get; set; }
        public AppUser Chef { get; set; }

        public Guid? CashierId { get; set; }
        public AppUser Cashier { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Tax { get; set; }

        public decimal BillAmount { get; set; }

        public string CashierNote { get; set; }

        public string CustomerNote { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
