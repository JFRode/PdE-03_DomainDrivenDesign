using CustomerHub.Application.Dto;
using CustomerHub.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerHub.Api.Controllers
{
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public TokenController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RequestToken([FromBody] UserDto userDto, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmailAndPassword(userDto.Email, userDto.Password, cancellationToken);

            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Name, user.Password)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "CustomerHub",
                    audience: "CustomerHub",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credential);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Invalid request");
        }
    }
}