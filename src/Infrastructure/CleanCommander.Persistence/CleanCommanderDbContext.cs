using CleanCommander.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Persistence
{
    public class CleanCommanderDbContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }
        public DbSet<Platform> Platforms { get; set; }
    }
}
