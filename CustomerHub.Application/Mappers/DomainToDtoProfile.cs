using AutoMapper;
using CustomerHub.Application.Dto;
using CustomerHub.Domain.Customer;
using CustomerHub.Domain.User;

namespace CustomerHub.Application.Mappers
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}