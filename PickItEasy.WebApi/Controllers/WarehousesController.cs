using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Interfaces.Services;
using PickItEasy.Application.Models.Warehouses;
//using PickItEasy.Application.Services.Warehouses.Commands.Create;
//using PickItEasy.Application.Services.Warehouses.Commands.Delete;
//using PickItEasy.Application.Services.Warehouses.Commands.Disable;
//using PickItEasy.Application.Services.Warehouses.Queries.GetById;

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        //private readonly IMediator _mediator;
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(/*IMediator mediator,*/ IWarehouseService warehouseService)
        {
            //_mediator = mediator;
            _warehouseService = warehouseService;
        }

        // GET api/<WarehousesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById(Guid id)
        {
            //var result = await _mediator.Send(new GetByIdQuery { Id = id });
            var result = await _warehouseService.GetByIdAsync(id);

            return Ok(result);
        }

        // POST api/<WarehousesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] WarehouseDto warehouseDto)
        {
            //var createWarehouseCommand = new CreateCommand { WarehouseDto = warehouseDto };
            //var result = await _mediator.Send(createWarehouseCommand);
            var result = await _warehouseService.CreateAsync(warehouseDto);

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
        public async Task<IActionResult> Disable(Guid id)
        {
            //var disableWarehouseCommand = new DisableCommand { Id = id };
            //await _mediator.Send(disableWarehouseCommand);
            await _warehouseService.DisableAsync(id);

            return NoContent();
        }

        // DELETE api/<WarehousesController>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete([FromBody] WarehouseDto dto)
        {
            //var deleteWarehouseCommand = new DeleteCommand { WarehouseDto = dto };
            //await _mediator.Send(deleteWarehouseCommand);
            await _warehouseService.DeleteAsync(dto.Id);

            return NoContent();
        }
    }
}
