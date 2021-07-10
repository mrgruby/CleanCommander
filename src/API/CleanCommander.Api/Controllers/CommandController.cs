using AutoMapper;
using CleanCommander.Application.Features.Command.Commands.CreateCommand;
using CleanCommander.Application.Features.Command.Commands.UpdateCommand;
using CleanCommander.Application.Features.Command.Queries.GetCommandDetail;
using CleanCommander.Application.Features.Command.Queries.GetCommandsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper;

        public CommandController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //api/platform/{platformId}/command
        //https://localhost:44363/api/platform/6313179F-7837-473A-A4D5-A5571B43E6A6/command/
        [HttpGet(Name = "GetCommandsLinesByPlatform")]
        public async Task<ActionResult<List<GetCommandLineListByPlatformReturnModel>>> Get(Guid platformId)
        {
            var getCommandLineListByPlatformReturnModel = await _mediator.Send(new GetCommandLineListByPlatformQuery { PlatformId = platformId });
            return Ok(getCommandLineListByPlatformReturnModel);
        }

        //api/platform/{platformId}/command/{commandLineId}
        //https://localhost:44363/api/platform/6313179F-7837-473A-A4D5-A5571B43E6A6/command/adc42c09-08c1-4d2c-9f96-2d15bb1af299
        [HttpGet("{commandLineId:Guid}", Name = "GetCommandLineByPlatform")]
        public async Task<ActionResult<CommandDetailsReturnModel>> Get(Guid platformId, Guid commandLineId)
        {
            var getCommandLineByPlatformReturnModel = await _mediator.Send(new GetCommandDetailQuery { PlatformId = platformId, CommandLineId = commandLineId });
            return Ok(getCommandLineByPlatformReturnModel);
        }

        /// <summary>
        /// Add a new command line
        /// </summary>
        /// <param name="platformId">Id of the platform on which to add the new command line</param>
        /// <param name="commandLine">The model object that is posted from the user/UI</param>
        /// <returns>The newly created ressource, along with a link to it.</returns>
        /// api/platform/{platformId}/command
        [HttpPost]
        public async Task<ActionResult<CreateCommandLineCommandResponse>> Post(Guid platformId, CreateCommandLineCommand commandLine)
        {
            var retunModel = await _mediator.Send(commandLine);

            if (retunModel.Success)
                //Return the newly created ressource, along with a link to it.
                return CreatedAtRoute("GetCommandLineByPlatform", new { platformId = platformId, commandLineId = retunModel.CommandLineDto.CommandLineId }, retunModel.CommandLineDto);
            else
                return BadRequest($"Failed to save new CommandLine - {string.Join(", ", retunModel.ValidationErrors)}");
        }

        //https://localhost:44363/api/platform/6313179F-7837-473A-A4D5-A5571B43E6A6/command/adc42c09-08c1-4d2c-9f96-2d15bb1af299
        [HttpPatch("{commandLineId:Guid}")]
        public async Task<ActionResult>Patch([FromBody] JsonPatchDocument<UpdateCommandLineDto> commmandLineToUpdate, Guid platformId, Guid commandLineId)
        {
            var patchCommand = new UpdateCommandCommand
            {
                CommmandLineToUpdatePatch = commmandLineToUpdate,
                CommandLineId = commandLineId,
                PromptPlatformId = platformId
            };

            var response = await _mediator.Send(patchCommand);

            return NoContent();

        }
    }
}
