using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.CreateCommand
{
    public class CreateCommandLineCommandHandler : IRequestHandler<CreateCommandLineCommand, CreateCommandLineCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _repo;

        public CreateCommandLineCommandHandler(IMapper mapper, ICommandRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public Task<CreateCommandLineCommandResponse> Handle(CreateCommandLineCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
