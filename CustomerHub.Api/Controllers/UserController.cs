using CustomerHub.Application.Dto;
using CustomerHub.Application.Services.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IEnumerable<UserDto> Get()
        {
            return _userService.Get();
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            _userService.Add(userDto);
            return new NoContentResult();
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserDto userDto)
        {
            _userService.Update(userDto);
            return new NoContentResult();
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(Guid userId)
        {
            _userService.Remove(userId);
            return new NoContentResult();
        }
    }
}