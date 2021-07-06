﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Queries.GetPlatformsList
{
    public class GetPlatformsListReturnModel
    {
        public Guid PromptPlatformId { get; set; }
        public string PromptPlatformName { get; set; }
        public ICollection<GetPlatformsListCommandDto> CommandLineList { get; set; }
    }
}