using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Persistence.Repositories
{
    public class CommandRepository : GenericRepository<Command>, ICommandRepository
    {
        public CommandRepository(CleanCommanderDbContext dbContext) : base(dbContext)
        {

        }
    }
}
