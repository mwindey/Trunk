using System.Data.Entity;
using Definco.Models;

namespace SimpleMembershipExample
{
    public class DefincoDbContext : DbContext
    {
        public DefincoDbContext() : base(nameOrConnectionString: "DefaultConnection") { }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}