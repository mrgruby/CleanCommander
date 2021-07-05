using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.GetCommandsList
{
    public class GetCommandLineListByPlatformQuery : IRequest<List<GetCommandLineListByPlatformReturnModel>>
    {
        public Guid PlatformId { get; set; }
    }
}
