using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Services.Products.Commands.Create;
using PickItEasy.Application.Services.Products.Commands.Delete;
using PickItEasy.Application.Services.Products.Commands.Disable;
using PickItEasy.Application.Services.Products.Commands.Update;
using PickItEasy.Application.Services.Products.Queries.GetById;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public IActionResult Get()
        {
            return StatusCode((int)HttpStatusCode.MethodNotAllowed);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = id });

            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            var createProductCommand = new CreateCommand { ProductDto = productDto };
            var result = await _mediator.Send(createProductCommand);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductDto productDto)
        {
            var updateProductCommand = new UpdateCommand { Id = id, ProductDto = productDto };
            await _mediator.Send(updateProductCommand);

            return NoContent();
        }

        // DELETE api/<ProductsController>/5
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
        public async Task<IActionResult> Delete(Guid id)
        {
            var disableProductCommand = new DisableCommand { Id = id };
            await _mediator.Send(disableProductCommand);

            return NoContent();
        }

        // DELETE api/<ProductsController>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> Delete([FromBody] ProductDto dto)
        {
            var deleteProductCommand = new DeleteCommand { ProductDto = dto };
            await _mediator.Send(deleteProductCommand);

            return NoContent();
        }
    }
}
