﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList;
using PickItEasy.Domain.Entities;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhsOrdersOutController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEventBusPublisher _eventPublisher;

        public WhsOrdersOutController(IMediator mediator, IEventBusPublisher eventPublisher)
        {
            _mediator = mediator;
            _eventPublisher = eventPublisher;
        }

        // GET: api/<WhsOrdersOutController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> Get([FromQuery] WhsOrderOutSearchParameters searchParameters)
        {
            var getListWhsOrderOutQuery = new GetListWhsOrderOutQuery { SearchParameters = searchParameters };
            var result = await _mediator.Send(getListWhsOrderOutQuery);
            return Ok(result);
            //return StatusCode((int)HttpStatusCode.MethodNotAllowed);
        }

        // GET api/<WhsOrdersOutController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdWhsOrderOutQuery { Id = id });
            return Ok(result);
        }

        // POST api/<WhsOrdersOutController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] WhsOrderOutDto whsOrderOutDto)
        {
            var createWhsOrderOutCommand = new CreateWhsOrderOutCommand { WhsOrderOutDto = whsOrderOutDto };
            var result = await _mediator.Send(createWhsOrderOutCommand);
            _eventPublisher.SendMessage($"{nameof(CreateWhsOrderOutCommand)}_{result.Id}");
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT api/<WhsOrdersOutController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public IActionResult Put(int Guid, [FromBody] string value)
        {
            return StatusCode((int)HttpStatusCode.MethodNotAllowed);
        }

        // DELETE api/<WhsOrdersOutController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteWhsOrderOutCommand = new DeleteWhsOrderOutCommand { Id = id };
            await _mediator.Send(deleteWhsOrderOutCommand);
            return NoContent();
        }
    }
}
