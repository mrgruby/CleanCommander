using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.UpdateCommandLine
{
    public class UpdateCommandLineCommandHandler : IRequestHandler<UpdateCommandLineCommand, UpdateCommandLineCommandResponse>
    {
        private readonly ICommandRepository _repo;
        private readonly IMapper _mapper;

        public UpdateCommandLineCommandHandler(ICommandRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public Task<UpdateCommandLineCommandResponse> Handle(UpdateCommandLineCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateCommandLineCommandResponse();
            var commandLineFromDbToUpdate = _repo.GetCommandLineByPlatform(request.PromptPlatformId, request.CommandLineId);

            if (commandLineFromDbToUpdate == null)
            {
                response.Success = false;
                response.Message = "Notfound";
            }

            var 
        }
    }
}
