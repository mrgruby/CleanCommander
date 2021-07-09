using AutoMapper;
using CleanCommander.Application.Features.Command.Commands.CreateCommand;
using CleanCommander.Application.Features.Command.Queries.GetCommandDetail;
using CleanCommander.Application.Features.Command.Queries.GetCommandsList;
using CleanCommander.Application.Features.Platforms.Queries.GetPlatformsList;
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
            CreateMap<CommandLine, GetCommandLineListByPlatformReturnModel>().ReverseMap();
            CreateMap<PromptPlatform, GetPlatformsListReturnModel>().ReverseMap();
            CreateMap<CommandLine, GetPlatformsListCommandDto>().ReverseMap();
            CreateMap<CommandLine, CommandDetailsReturnModel>().ReverseMap();
            CreateMap<CommandLine, CreateCommandLineDto>().ReverseMap();
            CreateMap<CommandLine, CreateCommandLineCommand>().ReverseMap();
        }
    }
}
