using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Managers;
using Persistance;

namespace Business
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {

        private IConfiguration _config;
        private AccountManager _accountManager;

        public TokenController(IConfiguration config, DatabaseContext db)
        {
            _config = config;
            _accountManager = new AccountManager(db);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken(Account user)
        {
            var claims = new[] {
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Account Authenticate(LoginModel login)
        {
            Account user = _accountManager.GetAccountByEmail(login.Email);

            if (_accountManager.CheckAccountCredentials(user.Email, login.Password))
            {
                return user;
            }
            return null;
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

    }
}
