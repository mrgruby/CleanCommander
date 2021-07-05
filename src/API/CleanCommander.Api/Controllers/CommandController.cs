using CleanCommander.Application.Features.Command.Queries.GetCommandsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCommander.Api.Controllers
{
    /*This is an association controller, in that it handles ressources that are related to the Platform controller. 
     Therefore, the controller base URI will be constructed this way: api/platform/{platformId}/commands. So, the actions in this controller will
     handle commandLines that are related to a specific platform. If the controller were handling commandLines by themselves, the URI would be: api/command or api/[controler]*/

    [Route("api/platform/{platformId}/command")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //https://localhost:44363/api/platform/6313179F-7837-473A-A4D5-A5571B43E6A6/command/
        [HttpGet(Name = "GetCommandsLinesByPlatform")]
        public async Task<ActionResult<GetCommandLineListByPlatformReturnModel>> Get(Guid platformId)
        {
            var getCommandLineListByPlatformReturnModel = await _mediator.Send(new GetCommandLineListByPlatformQuery { PlatformId = platformId });
            return Ok(getCommandLineListByPlatformReturnModel);
        }
    }
}
