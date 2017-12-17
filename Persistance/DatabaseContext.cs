using Microsoft.EntityFrameworkCore;
using Entities;
using System;

namespace Persistance
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }

        public Account SingleOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasIndex(acc => new { acc.Id, acc.Email })
                .IsUnique(true);
        }
    }
}
