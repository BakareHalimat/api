using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.DatabaseContext;
using Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        
      private const string SECRET_KEY = "dafas7dfsfsd9adsKXKwfd90iodslkklsdFSDjkdeefo887789489";
       public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticateController.SECRET_KEY));
        
        
        [HttpGet]
        [Route("api/Token/{username}/{password}")]
        public IActionResult Get(string username, string password)
        {
           if(username == password)
                return new ObjectResult(GenerateToken(username));
           else 
                return BadRequest();
       }

        private object GenerateToken(string username)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}