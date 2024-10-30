namespace EasyResto.Domain.Contracts.Response
{
    public class FoodItemResponse
    {
        public Guid Id { get; set; }

        public Guid FoodCategoryId { get; set; }
        public FoodCategoryResponse FoodCategory { get; set; }

        public Guid FoodItemStatusId { get; set; }
        public FoodItemStatusResponse FoodItemStatus { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
