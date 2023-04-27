using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.Application.Interfaces.Services.WhsOrder.Out;
using PickItEasy.Application.Models.Products;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;
using PickItEasy.Application.Services.WhsOrder.Out.Search;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetList;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhsOrdersOutController : ControllerBase
    {
        //private readonly IMediator _mediator;
        private readonly IWhsOrderOutService _whsOrderOutService;
        private readonly IEventBusPublisher _eventPublisher;

        public WhsOrdersOutController(/*IMediator mediator,*/ IWhsOrderOutService whsOrderOutService, IEventBusPublisher eventPublisher)
        {
            //_mediator = mediator;
            _whsOrderOutService = whsOrderOutService;
            _eventPublisher = eventPublisher;
        }

        // GET: api/<WhsOrdersOutController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]

        //public async Task<IActionResult> Get([FromQuery] SearchParameters searchParameters)
        //{
        //    var getListWhsOrderOutQuery = new GetListQuery { SearchParameters = searchParameters };
        //    //var result = await _mediator.Send(getListWhsOrderOutQuery);
        //    return Ok(result);
        //}

        // GET api/<WhsOrdersOutController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById(Guid id)
        {
            //var result = await _mediator.Send(new GetByIdQuery { Id = id });
            var result = await _whsOrderOutService.GetByIdAsync(id);

            return Ok(result);
        }

        // POST api/<WhsOrdersOutController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] WhsOrderOutDto whsOrderOutDto)
        {
            //var createWhsOrderOutCommand = new CreateCommand { WhsOrderOutDto = whsOrderOutDto };
            //var result = await _mediator.Send(createWhsOrderOutCommand);
            var result = await _whsOrderOutService.CreateAsync(whsOrderOutDto);
            
            _eventPublisher.SendMessage($"{nameof(CreateCommand)}_{result.Id}");

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT api/<WhsOrdersOutController>/5
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        //public IActionResult Put(int Guid, [FromBody] string value)
        //{
        //    return StatusCode((int)HttpStatusCode.MethodNotAllowed);
        //}

        // DELETE api/<WhsOrdersOutController>/5
        /// <summary>
        /// Disable - Set Active = false (Doesn't delete permanently )
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Disable(Guid id)
        {
            //var deleteWhsOrderOutCommand = new DeleteCommand { Id = id };
            //await _mediator.Send(deleteWhsOrderOutCommand);
            await _whsOrderOutService.DisableAsync(id);

            return NoContent();
        }

        // DELETE api/<WhsOrdersOutController>/5
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete([FromBody] ProductDto dto)
        {
            //var deleteWhsOrderOutCommand = new DeleteCommand { Id = id };
            //await _mediator.Send(deleteWhsOrderOutCommand);
            await _whsOrderOutService.DeleteAsync(dto.Id);

            return NoContent();
        }
    }
}
