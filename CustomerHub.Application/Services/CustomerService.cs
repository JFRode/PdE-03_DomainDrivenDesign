using AutoMapper;
using CustomerHub.Application.Dto;
using CustomerHub.Application.Services.Interfaces;
using CustomerHub.Data.Context;
using CustomerHub.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerHub.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerService(CustomerHubDbContext dbContext, Mapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDto> Get()
        {
            return _mapper.Map<List<CustomerDto>>(_dbContext.Customers.ToList());
        }

        public void Add(CustomerDto customerDto)
        {
            _dbContext.Customers.Add(_mapper.Map<Customer>(customerDto));
            _dbContext.SaveChanges();
        }

        public void Update(CustomerDto customerDto)
        {
            _dbContext.Customers.Update(_mapper.Map<Customer>(customerDto));
            _dbContext.SaveChanges();
        }

        public void Remove(Guid customerId)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
            _dbContext.Customers.Remove(customer);
        }
    }
}