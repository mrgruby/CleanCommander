using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CreateCommandLineCommandHandler> _logger;

        public CreateCommandLineCommandHandler(IMapper mapper, ICommandRepository repo, ILogger<CreateCommandLineCommandHandler> logger)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }
        public async Task<CreateCommandLineCommandResponse> Handle(CreateCommandLineCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCommandLineCommandResponse();
            var validator = new CreateCommandLineCommandValidator();

            //If any of the validation rules, set up for the CreateCommandLineCommand class inside the CreateEventCommandValidator, are broken,
            //the validationResult will contain a list of these broken rules. 
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                var commandLine = _mapper.Map<CommandLine>(request);

                _repo.Add(commandLine);
                response.CommandLineDto = _mapper.Map<CreateCommandLineDto>(commandLine);
            }
            return response;
        }
    }
}
