using CleanCommander.Application.Features.Platform.Commands.CreatePlatform;
using CleanCommander.Application.Features.Platforms.Queries.GetPlatformById;
using CleanCommander.Application.Features.Platforms.Queries.GetPlatformsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCommander.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlatformController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //api/platform/{id}/commandlines

        //https://localhost:44363/api/platform/
        [HttpGet(Name = "GetAllPlatforms")]
        public async Task<ActionResult<List<GetPlatformsListReturnModel>>> Get()
        {
            var dtos = await _mediator.Send(new GetPlatformsListQuery());
            
            return Ok(dtos);
        }

        [HttpGet("{promptPlatformId:Guid}", Name = "GetPlatformById")]
        public async Task<ActionResult<List<GetPlatformsListReturnModel>>> Get(Guid promptPlatformId)
        {
            var platform = await _mediator.Send(new GetPlatformByIdQuery { PromptPlatformId  = promptPlatformId});

            if (platform == null)
                return NotFound($"The platform with id {promptPlatformId}, was not found");
            return Ok(platform);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePlatformCommandResponse>> Post(CreatePlatformCommand platform)
        {
            var response = await _mediator.Send(platform);

            if (response.Success)
                return CreatedAtRoute("GetPlatformById", new { PromptPlatformId = response.CreatePlatformCommandDto.PromptPlatformId }, response.CreatePlatformCommandDto);
            else
                return BadRequest($"Failed to save new Platform - {string.Join(", ", response.ValidationErrors)}");
        }
    }
}
