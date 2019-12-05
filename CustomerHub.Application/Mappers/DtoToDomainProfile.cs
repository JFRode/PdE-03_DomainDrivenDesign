using AutoMapper;
using CustomerHub.Application.Dto;
using CustomerHub.Domain.Customer;
using CustomerHub.Domain.User;

namespace CustomerHub.Application.Mappers
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}