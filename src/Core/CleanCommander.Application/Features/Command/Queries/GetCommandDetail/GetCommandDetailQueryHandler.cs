using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.GetCommandDetail
{
    public class GetCommandDetailQueryHandler : IRequestHandler<GetCommandDetailQuery, CommandDetailsReturnModel>
    {
        public Task<CommandDetailsReturnModel> Handle(GetCommandDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
