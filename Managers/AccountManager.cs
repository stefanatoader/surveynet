using Entities;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Managers
{
    public class AccountManager
    {
        private readonly DatabaseContext _context;

        public AccountManager(DatabaseContext context)
        {
            _context = context;
        }

        public DbSet<Account> GetAccounts()
        {
            return _context.Accounts;
        }

        public Account GetAccountById(Guid Id)
        {
            return _context.Accounts.Find(Id);
        }

        public Account GetAccountByEmail(string Email)
        {
            return _context.Accounts.SingleOrDefault(acc => acc.Email == Email);
        }

        public Boolean Add(Account account)
        {
            Boolean testAccount = _context.Accounts.Any(acc => acc.Email == account.Email);
            if (testAccount)
            {
                return false;
            }
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(account.Password));
                // Get the hashed string.  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                account.Password = hash;
            }
            _context.Add(account);
            return true;
        }


        public void Update(Account account)
        {
            _context.Update(account);
        }

        public void Delete(Account account)
        {
            _context.Remove(account);
        }

        public Boolean CheckAccountCredentials(string Email, string Password)
        {
            Account acc = _context.Accounts.SingleOrDefault(r => r.Email == Email);
            var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
     
            return acc.Password == hash;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
