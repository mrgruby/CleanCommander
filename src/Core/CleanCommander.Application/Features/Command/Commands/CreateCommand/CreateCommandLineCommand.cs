using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.CreateCommand
{
    /// <summary>
    /// This is the request model, which is sent in the create request from the controller.
    /// </summary>
    public class CreateCommandLineCommand : IRequest<CreateCommandLineCommandResponse>
    {
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string PromptPlatformName { get; set; }
        public string Comment { get; set; }
        public Guid PromptPlatformId { get; set; }
    }
}
