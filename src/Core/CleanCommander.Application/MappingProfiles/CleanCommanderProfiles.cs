using AutoMapper;
using CleanCommander.Application.Features.Command.Queries.GetCommandsList;
using CleanCommander.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.MappingProfiles
{
    public class CleanCommanderProfiles : Profile
    {
        public CleanCommanderProfiles()
        {
            CreateMap<CommandLine, CommandsListReturnModel>().ReverseMap();
        }
    }
}
