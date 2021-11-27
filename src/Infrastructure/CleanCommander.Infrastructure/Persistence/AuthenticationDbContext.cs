using CleanCommander.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Infrastructure.Identity.Persistence
{
    public class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
           : base(options)
        {
        }

        public DbSet<CommanderUser> CommanderUser { get; set; }
    }
}
