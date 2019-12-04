using CustomerHub.Application.Dto;
using System;
using System.Collections.Generic;

namespace CustomerHub.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> Get();

        void Add(CustomerDto customerDto);

        void Update(CustomerDto customerDto);

        void Remove(Guid customerId);
    }
}