using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCoreReact.Core.Common;
using NetCoreReact.Models;
using NetCoreReact.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreReact.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace NetCoreReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> authOptions;
        private readonly IUserService userService;

        public AuthController(IOptions<AuthOptions> authOptions, IUserService userService)
        {
            this.authOptions = authOptions;
            this.userService = userService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var user = await userService.AuthentificateUserAsync(request.Email, request.Password);
            if (user != null)
            {
              var token =  GenerateJWT(user);

                return Ok(new { access_token = token });
            }

            return Unauthorized();
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Register request)
        {
            var userModel = new UserModel()
            {
                Email = request.Email,
                Username = request.Username,
                Password = request.Password
            };

            if (userService.GetUsersAsync().Result.Any(u => u.Email == userModel.Email))
            {
                //return Content("User with such Email already exist");
                return Conflict(); 
            }

            var user = await userService.CreateUserAsync(userModel);

            if (user != null) {
                return Ok();
            }

            return Unauthorized();
        }

        private string GenerateJWT(UserModel user)
        {
            var authParms = authOptions.Value;

            var securityKey = authParms.GetSymetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var token = new JwtSecurityToken(authParms.Issuer, authParms.Audience, claims, 
                expires: DateTime.Now.AddSeconds(authParms.TokenLifeTime), 
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
