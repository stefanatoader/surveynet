using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Entities;
using Managers;
using Persistance;
using System.Security.Claims;

namespace Business
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private AccountManager _accountManager;

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
            Account acc = _accountManager.GetAccountByEmail(currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);
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
