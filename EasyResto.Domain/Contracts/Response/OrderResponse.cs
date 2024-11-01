namespace EasyResto.Domain.Contracts.Response
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public Guid DiningTableId { get; set; }
        public DiningTableResponse DiningTable { get; set; }

        public Guid OrderStatusId { get; set; }
        public OrderStatusResponse OrderStatus { get; set; }

        public Guid WaiterId { get; set; }
        public AppUserResponse Waiter { get; set; }

        public Guid? ChefId { get; set; }
        public AppUserResponse? Chef { get; set; }

        public Guid? CashierId { get; set; }
        public AppUserResponse? Cashier { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Tax { get; set; }

        public decimal BillAmount { get; set; }

        public string? CashierNote { get; set; }

        public string? CustomerNote { get; set; }

        public ICollection<OrderDetailResponse> OrderDetails { get; set; } = new List<OrderDetailResponse>();
    }
}
