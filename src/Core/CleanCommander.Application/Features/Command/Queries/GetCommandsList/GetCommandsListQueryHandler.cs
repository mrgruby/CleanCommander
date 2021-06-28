using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.GetCommandsList
{
    public class GetCommandsListQueryHandler : IRequestHandler<GetCommandsListQuery, List<CommandsListReturnModel>>
    {
        private readonly IGenericRepository<CommandLine> _repo;
        private readonly IMapper _mapper;

        public GetCommandsListQueryHandler(IGenericRepository<CommandLine> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<List<CommandsListReturnModel>> Handle(GetCommandsListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
