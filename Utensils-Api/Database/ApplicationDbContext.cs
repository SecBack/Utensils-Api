using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Utensils_Api.Database.Models;

namespace Utensils_Api.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Event> Events { get; set; }
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<User> Users { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        public DbSet<Group> Groups { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // TODO: move this to appsettings
            options.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=mysecretpassword");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
