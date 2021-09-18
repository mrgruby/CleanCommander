using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platform.Commands.CreatePlatform
{
    public class CreatePlatformCommand : IRequest<CreatePlatformCommandResponse>
    {
        public string PromptPlatformName { get; set; }
        public string PromptPlatformImageUrl { get; set; }
    }
}
