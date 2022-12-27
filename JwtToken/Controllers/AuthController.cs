using JwtToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginModel userLogin)
        {
            var user = Authenticate(userLogin);
            if (user!=null)
            {
                var token = Generate(user);
                return Ok(new { token=token });
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        [Route("GovtInfoModel")]
        public async Task<IActionResult> GovtInfoModel([FromBody] GovtInfoAPIViewModel govtInfoAPIViewModel)
        {           
            return Ok(new { token = JsonConvert.SerializeObject(govtInfoAPIViewModel) });          
        }
        private string Generate(UserModel user)
        {
            var seuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(seuritykey, SecurityAlgorithms.HmacSha256);
            var claims = new[] { 
                new Claim(ClaimTypes.NameIdentifier,user.username),
                new Claim(ClaimTypes.Email,user.EmailAddress),
                new Claim(ClaimTypes.GivenName,user.FullName),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], 
                claims,expires:DateTime.Now.AddMinutes(15),signingCredentials:credentials);

           return new  JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(UserLoginModel userLogin)
        {
          var currentuser = UserConstants.Users.Where(e => e.username.ToLower() == userLogin.username.ToLower() && e.password == userLogin.password).FirstOrDefault();
            if (currentuser!=null)
            {
                return currentuser;
            }
            else
            {
                return null;
            }
        }
    }
}
