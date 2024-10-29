using AutoMapper;
using EasyResto.Domain.Contracts.Response;
using EasyResto.Domain.Entities;

namespace EasyResto.Mapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleResponse>();
        }
    }
}
