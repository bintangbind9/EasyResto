using AutoMapper;
using EasyResto.Domain.Contracts.Response;
using EasyResto.Domain.Entities;

namespace EasyResto.Mapper
{
    public class FoodItemStatusProfile : Profile
    {
        public FoodItemStatusProfile()
        {
            CreateMap<FoodItemStatus, FoodItemStatusResponse>();
        }
    }
}
