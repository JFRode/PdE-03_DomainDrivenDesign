using AutoMapper;
using CustomerHub.Application.Dto;
using CustomerHub.Application.Services.Interfaces;
using CustomerHub.Data.Context;
using CustomerHub.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerHub.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerService(CustomerHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> Get(CancellationToken cancellationToken)
        {
            var data = await _dbContext.Customers.ToListAsync(cancellationToken);
            return _mapper.Map<List<CustomerDto>>(data);
        }

        public async Task<CustomerDto> Add(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            _dbContext.Customers.Add(_mapper.Map<Customer>(customerDto));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return customerDto;
        }

        public async Task<CustomerDto> Update(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            _dbContext.Customers.Update(_mapper.Map<Customer>(customerDto));
            await _dbContext.SaveChangesAsync();
            return customerDto;
        }

        public async Task<CustomerDto> Remove(Guid customerId, CancellationToken cancellationToken)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}