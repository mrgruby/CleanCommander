using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Features.Platforms.Commands.CreatePlatform;
using CleanCommander.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platform.Commands.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, CreatePlatformCommandResponse>
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;

        public CreatePlatformCommandHandler(IPlatformRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<CreatePlatformCommandResponse> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var response = new CreatePlatformCommandResponse();
            var validator = new CreatePlatformCommandValidator();

            //Check the request to see if any of the validation rules, set up for the CreateCommandLineCommand class inside the CreateEventCommandValidator, are broken.
            //If so, add the error message to the ValidationErrors list in the validationResult.
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
                var platformToAdd =_mapper.Map<PromptPlatform>(request);

                _repo.Add(platformToAdd);

                response.CreatePlatformCommandDto = _mapper.Map<CreatePlatformCommandDto>(platformToAdd);
            }

            return response;
        }
    }
}
