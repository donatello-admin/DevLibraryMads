using DevLibraryMads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevLibraryMads.Infrastructure.Persistence
{
    public class DevLibraryMadsDbContext : DbContext
    {
        public DevLibraryMadsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; private set; }
        public DbSet<Book> Books { get; private set; }
        public DbSet<Order> Orders { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
