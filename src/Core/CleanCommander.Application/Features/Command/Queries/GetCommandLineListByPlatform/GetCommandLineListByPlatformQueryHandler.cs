using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Domain.Entities;
using CleanCommander.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.GetCommandsList
{
    public class GetCommandLineListByPlatformQueryHandler : IRequestHandler<GetCommandLineListByPlatformQuery, List<GetCommandLineListByPlatformReturnModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _commandRepo;

        public GetCommandLineListByPlatformQueryHandler(IMapper mapper, ICommandRepository commandRepo)
        {
            _mapper = mapper;
            _commandRepo = commandRepo;
        }
        public async Task<List<GetCommandLineListByPlatformReturnModel>> Handle(GetCommandLineListByPlatformQuery request, CancellationToken cancellationToken)
        {
            var commandLineListFromDb = await _commandRepo.GetCommandLineListByPlatform(request.PlatformId);
            if (commandLineListFromDb == null)
                throw new NotFoundException(nameof(GetCommandLineListByPlatformReturnModel), request.PlatformId);

            return _mapper.Map<List<GetCommandLineListByPlatformReturnModel>>(commandLineListFromDb);
        }
    }
}
