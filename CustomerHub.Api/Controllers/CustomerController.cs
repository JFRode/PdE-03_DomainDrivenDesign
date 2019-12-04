using CustomerHub.Application.Dto;
using CustomerHub.Application.Services.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CustomerHub.Api.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [EnableQuery()]
        public IEnumerable<CustomerDto> Get()
        {
            return _customerService.Get();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customerDto)
        {
            _customerService.Add(customerDto);
            return new NoContentResult();
        }

        [HttpPut]
        public IActionResult Put([FromBody] CustomerDto customerDto)
        {
            _customerService.Update(customerDto);
            return new NoContentResult();
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            _customerService.Remove(customerId);
            return new NoContentResult();
        }
    }
}