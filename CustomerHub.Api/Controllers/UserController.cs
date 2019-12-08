using CustomerHub.Application.Dto;
using CustomerHub.Application.Services.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerHub.Api.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.Get(cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something is wrong, check exception stack trace: {ex.StackTrace}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.Add(userDto, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something is wrong, check exception stack trace: {ex.StackTrace}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto userDto, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.Update(userDto, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something is wrong, check exception stack trace: {ex.StackTrace}");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.Remove(userId, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something is wrong, check exception stack trace: {ex.StackTrace}");
            }
        }
    }
}