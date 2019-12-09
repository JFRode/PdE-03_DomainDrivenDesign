using CustomerHub.Application.Dto;
using CustomerHub.Application.Services.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerHub.Api.Controllers
{
    [Route("[controller]")]
    [Authorize()]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerService.Get(cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something is wrong, check exception stack trace: {ex.StackTrace}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDto customerDto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerService.Add(customerDto, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something is wrong, check exception stack trace: {ex.StackTrace}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerDto customerDto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerService.Update(customerDto, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something is wrong, check exception stack trace: {ex.StackTrace}");
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(Guid customerId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _customerService.Remove(customerId, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something is wrong, check exception stack trace: {ex.StackTrace}");
            }
        }
    }
}