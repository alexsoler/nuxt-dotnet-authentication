using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Domain.Entities.Auth;
using core.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace core.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<AuthClient> AuthClients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);            

            builder.Entity<AuthClient>().HasData(
                new AuthClient()
                {
                    Id = 1,
                    Name = "NuxtSPA",
                    Active = true
                }
            );
        }
    }
}