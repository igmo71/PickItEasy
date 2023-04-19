using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Services.Warehouses.Commands.Create;
using PickItEasy.Application.Services.Warehouses.Commands.Delete;
using PickItEasy.Application.Services.Warehouses.Commands.Disable;
using PickItEasy.Application.Services.Warehouses.Queries.GetById;

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehousesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<WarehousesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = id });

            return Ok(result);
        }

        // POST api/<WarehousesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] WarehouseDto warehouseDto)
        {
            var createWarehouseCommand = new CreateCommand { WarehouseDto = warehouseDto };
            var result = await _mediator.Send(createWarehouseCommand);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // DELETE api/<WarehousesController>/5
        /// <summary>
        /// Disable - Set Active = false (Doesn't delete permanently )
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> Disable(Guid id)
        {
            var disableWarehouseCommand = new DisableCommand { Id = id };
            await _mediator.Send(disableWarehouseCommand);

            return NoContent();
        }

        // DELETE api/<WarehousesController>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> Delete([FromBody] WarehouseDto dto)
        {
            var deleteWarehouseCommand = new DeleteCommand { WarehouseDto = dto };
            await _mediator.Send(deleteWarehouseCommand);

            return NoContent();
        }
    }
}
