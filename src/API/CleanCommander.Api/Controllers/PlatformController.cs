﻿using CleanCommander.Application.Features.Command.Queries.FindCommand;
using CleanCommander.Application.Features.Platform.Commands.CreatePlatform;
using CleanCommander.Application.Features.Platforms.Commands.DeletePlatform;
using CleanCommander.Application.Features.Platforms.Commands.UpdatePlatform;
using CleanCommander.Application.Features.Platforms.Queries.GetPlatformById;
using CleanCommander.Application.Features.Platforms.Queries.GetPlatformsList;
using CleanCommander.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
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
        //https://localhost:44363/api/platform/6313179F-7837-473A-A4D5-A5571B43E6A6
        [HttpGet("{promptPlatformId:Guid}", Name = "GetPlatformById")]
        public async Task<ActionResult<List<GetPlatformsListReturnModel>>> Get(Guid promptPlatformId)
        {
            var platform = await _mediator.Send(new GetPlatformByIdQuery { PromptPlatformId = promptPlatformId });

            if (platform == null)
                return NotFound($"The platform with id {promptPlatformId}, was not found");
            return Ok(platform);
        }

        //https://localhost:44363/api/platform/{searchTerm}
        [HttpGet("{searchTerm}", Name = "FindCommands")]
        public async Task<ActionResult<List<FindCommandReturnModel>>> Find(string searchTerm)
        {
            var commands = await _mediator.Send(new FindCommandQuery { SearchTerm = searchTerm });

            if (commands == null)
                return NotFound($"No commands were found, when searching for the term {searchTerm} ");
            return Ok(commands);
        }

        //https://localhost:44363/api/platform/
        [HttpPost]
        public async Task<ActionResult<CreatePlatformCommandResponse>> Post(CreatePlatformCommand platform)
        {
            var response = await _mediator.Send(platform);

            if (response.Success)
                return CreatedAtRoute("GetPlatformById", new { PromptPlatformId = response.CreatePlatformCommandDto.PromptPlatformId }, response.CreatePlatformCommandDto);
            else
                return BadRequest($"Failed to save new Platform - {string.Join(", ", response.ValidationErrors)}");
        }

        [HttpPut]
        public async Task<ActionResult<UpdatePlatformCommandResponse>> Put(UpdatePlatformCommand platformToUpdate)
        {
            var response = await _mediator.Send(platformToUpdate);

            if (response.Success == false && response.Message == "Notfound")
                return NotFound($"Platform to upate, with Id {platformToUpdate.PromptPlatformId}, was not found!");
            if (response.Success == false && response.ValidationErrors.Count > 0)
                return BadRequest($"Failed to update Platform - {string.Join(", ", response.ValidationErrors)}");

            return NoContent();
        }

        [HttpDelete("{promptPlatformId:Guid}")]
        public async Task<ActionResult<DeletePlatformResponse>> Delete(Guid promptPlatformId)
        {
            var response = await _mediator.Send(new DeletePlatformCommand { PromptPlatformId = promptPlatformId });

            if (response.Success == false && response.Message == "NotFound")
                return NotFound($"Platform to delete, with Id {promptPlatformId}, was not found!");

            return NoContent();
        }
    }
}
