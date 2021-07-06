using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Exceptions;
using CleanCommander.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.GetCommandDetail
{
    public class GetCommandDetailQueryHandler : IRequestHandler<GetCommandDetailQuery, CommandDetailsReturnModel>
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _repo;

        public GetCommandDetailQueryHandler(IMapper mapper, ICommandRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<CommandDetailsReturnModel> Handle(GetCommandDetailQuery request, CancellationToken cancellationToken)
        {
            var commandLineFromDb = await _repo.GetCommandLineByPlatform(request.PlatformId, request.CommandLineId);

            if (commandLineFromDb == null)
                throw new NotFoundException(nameof(CommandLine), request.CommandLineId);

            return _mapper.Map<CommandDetailsReturnModel>(commandLineFromDb);
        }
    }
}
