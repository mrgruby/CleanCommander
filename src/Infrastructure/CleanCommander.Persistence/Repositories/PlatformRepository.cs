﻿using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Persistence.Repositories
{
    public class PlatformRepository : GenericRepository<PromptPlatform>, IPlatformRepository
    {
        public PlatformRepository(CleanCommanderDbContext dbContext) : base(dbContext)
        {
        }

        //Return a list of all platforms, including their commands
        public async Task<IEnumerable<PromptPlatform>>GetPlatformsWithCommands()
        {
            return await _dbContext.PromptPlatforms.Include(x => x.CommandLineList).ToListAsync();
        }
    }
}
