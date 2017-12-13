using Microsoft.EntityFrameworkCore;
using Entities;

namespace Persistance
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
    }
}
