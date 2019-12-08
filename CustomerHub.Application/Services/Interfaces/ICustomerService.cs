using CustomerHub.Application.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerHub.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> Get(CancellationToken cancellationToken);

        Task<CustomerDto> Add(CustomerDto customerDto, CancellationToken cancellationToken);

        Task<CustomerDto> Update(CustomerDto customerDto, CancellationToken cancellationToken);

        Task<CustomerDto> Remove(Guid customerId, CancellationToken cancellationToken);
    }
}