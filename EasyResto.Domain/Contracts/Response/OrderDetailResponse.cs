namespace EasyResto.Domain.Contracts.Response
{
    public class OrderDetailResponse
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public OrderResponse Order { get; set; }

        public Guid FoodItemId { get; set; }
        public FoodItemResponse FoodItem { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }
    }
}
