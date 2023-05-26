using BIGBANG_ASSESSMENT.DB;
using BIGBANG_ASSESSMENT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BIGBANG_ASSESSMENT.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly HotelContext _context;

        public TokenController(IConfiguration config, HotelContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer _userData)
        {
            if (_userData != null && _userData.CustomerEmail != null && _userData.CustomerPassword != null)
            {
                var user = await GetUser(_userData.CustomerEmail, _userData.CustomerPassword);

                if (user != null)
                {
                    
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("CustomerId", user.CustomerId.ToString()),
                         new Claim("CustomerEmail", user.CustomerEmail),
                        new Claim("CustomerPassword",user.CustomerPassword)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:ValidIssuer"],
                        _configuration["Jwt:ValidAudience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Customer> GetUser(string email, string password)
        {
            return await _context.Customers.FirstOrDefaultAsync(u => u.CustomerEmail == email && u.CustomerPassword == password);
        }
    }
}
