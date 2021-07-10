using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Exceptions;
using CleanCommander.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.UpdateCommand
{
    public class UpdateCommandCommandHandler : IRequestHandler<UpdateCommandCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _repo;
        private readonly ILogger<UpdateCommandCommandHandler> _logger;

        public UpdateCommandCommandHandler(IMapper mapper, ICommandRepository repo, ILogger<UpdateCommandCommandHandler> logger)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateCommandCommand request, CancellationToken cancellationToken)
        {
            //Get the commandline entity to update
            var commandLineFromDb = await _repo.GetCommandLineByPlatform(request.PromptPlatformId, request.CommandLineId);

            //If it doesn't exist, throw exception
            if (commandLineFromDb == null)
            {
                throw new NotFoundException(nameof(CommandLine), request.CommandLineId);
            }

            //Convert the commandline entity to a commandLineDto, in order to add it to the json patch document.
            var commandLineDto = _mapper.Map<UpdateCommandLineDto>(commandLineFromDb);

            var validator = new UpdateCommandCommandValidator();
            var validationResult = await validator.ValidateAsync(commandLineDto);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            request.CommmandLineToUpdatePatch.ApplyTo(commandLineDto);

            //Map it back to a commandline entity, so it ccan be updated in the db 
            _mapper.Map(commandLineDto, commandLineFromDb);

            _repo.Update(commandLineFromDb);
            return Unit.Value;
        }
    }
}