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

        //api/platform
        [HttpGet(Name = "GetAllPlatforms")]
        public async Task<ActionResult<List<GetPlatformsListReturnModel>>> Get()
        {
            var dtos = await _mediator.Send(new GetPlatformsListQuery());
            return Ok(dtos);
        }
    }
}
