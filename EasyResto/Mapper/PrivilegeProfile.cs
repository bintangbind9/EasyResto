using AutoMapper;
using EasyResto.Domain.Contracts.Response;
using EasyResto.Domain.Entities;

namespace EasyResto.Mapper
{
    public class PrivilegeProfile : Profile
    {
        public PrivilegeProfile()
        {
            CreateMap<Privilege, PrivilegeResponse>();
        }
    }
}
