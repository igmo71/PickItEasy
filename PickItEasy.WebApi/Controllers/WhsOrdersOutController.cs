using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete;
using PickItEasy.Application.Services.WhsOrdersOut.Queries;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhsOrdersOutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WhsOrdersOutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<WhsOrdersOutController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public IActionResult Get()
        {
            return StatusCode((int)HttpStatusCode.MethodNotAllowed);
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
        public async Task<IActionResult> Post([FromBody] CreateWhsOrderOutDto createWhsOrderOutDto)
        {
            var createWhsOrderOutCommand = new CreateWhsOrderOutCommand { CreateWhsOrderOutDto = createWhsOrderOutDto };
            var result = await _mediator.Send(createWhsOrderOutCommand);
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
