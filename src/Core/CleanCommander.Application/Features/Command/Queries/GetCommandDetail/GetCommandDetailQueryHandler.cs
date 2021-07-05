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
        private readonly IGenericRepository<CommandLine> _repo;

        public GetCommandDetailQueryHandler(IMapper mapper, IGenericRepository<CommandLine> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<CommandDetailsReturnModel> Handle(GetCommandDetailQuery request, CancellationToken cancellationToken)
        {
            var commandLineFromDb = await _repo.Get(request.CommandId);

            if (commandLineFromDb == null)
                throw new NotFoundException(nameof(CommandLine), request.CommandId);

            return _mapper.Map<CommandDetailsReturnModel>(commandLineFromDb);
        }
    }
}
