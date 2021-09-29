using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Queries.GetPlatformById
{
    public class GetPlatformByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, GetPlatformByIdQueryReturnModel>
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;

        public GetPlatformByIdQueryHandler(IPlatformRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GetPlatformByIdQueryReturnModel> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            var platformFormDb = await _repo.GetPlatformByIdWithCommands(request.PromptPlatformId);
            return _mapper.Map<GetPlatformByIdQueryReturnModel>(platformFormDb);
        }
    }
}
