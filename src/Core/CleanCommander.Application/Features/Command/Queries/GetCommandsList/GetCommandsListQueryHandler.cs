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
        public Task<List<CommandsListReturnModel>> Handle(GetCommandsListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
