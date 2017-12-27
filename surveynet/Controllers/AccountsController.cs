using System.Linq;
using System.Security.Claims;
using Entities;
using Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance;

namespace surveynet.Controllers
{
  [Route("api/[controller]")]
  public class AccountsController : Controller
  {
    private readonly AccountManager _accountManager;

    public AccountsController(DatabaseContext db)
    {
      _accountManager = new AccountManager(db);
    }

    // GET: api/accounts
    [Authorize]
    [HttpGet]
    public Account Get()
    {
      var currentUser = HttpContext.User;
      var acc = _accountManager.GetAccountByEmail(currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)
        .Value);
      return acc;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Post([FromBody] Account acc)
    {
      if (acc.Email == null || acc.Password == null)
      {
        return BadRequest();
      }
      if (_accountManager.Add(acc))
      {
        _accountManager.SaveChanges();
        return Ok();
      }
      return BadRequest();
    }
  }
}
