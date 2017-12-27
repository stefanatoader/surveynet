using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities;
using Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistance;

namespace surveynet.Controllers
{
  [Route("api/[controller]")]
  public class TokenController : Controller
  {
    private readonly AccountManager _accountManager;

    private readonly IConfiguration _config;

    public TokenController(IConfiguration config, DatabaseContext db)
    {
      _config = config;
      _accountManager = new AccountManager(db);
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult CreateToken([FromBody] LoginModel login)
    {
      IActionResult response = Unauthorized();
      var user = Authenticate(login);

      if (user != null)
      {
        var tokenString = BuildToken(user);
        response = Ok(new {token = tokenString});
      }

      return response;
    }

    private string BuildToken(Account user)
    {
      var claims = new[]
      {
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
      var user = _accountManager.GetAccountByEmail(login.Email);

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
