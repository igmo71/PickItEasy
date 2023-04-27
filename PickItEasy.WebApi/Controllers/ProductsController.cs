using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Interfaces.Services;
using PickItEasy.Application.Models.Products;
//using PickItEasy.Application.Services.Products.Commands.Create;
//using PickItEasy.Application.Services.Products.Commands.Delete;
//using PickItEasy.Application.Services.Products.Commands.Disable;
//using PickItEasy.Application.Services.Products.Commands.Update;
//using PickItEasy.Application.Services.Products.Queries.GetById;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly IMediator _mediator;
        private readonly IProductService _productService;

        public ProductsController(/*IMediator mediator,*/ IProductService productService)
        {
            //_mediator = mediator;
            _productService = productService;
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
            //var result = await _mediator.Send(new GetByIdQuery { Id = id });
            var result = await _productService.GetByIdAsync(id);

            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            //var createProductCommand = new CreateCommand { ProductDto = productDto };
            //var result = await _mediator.Send(createProductCommand);
            var result = await _productService.CreateAsync(productDto);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductDto productDto)
        {
            //var updateProductCommand = new UpdateCommand { Id = id, ProductDto = productDto };
            //await _mediator.Send(updateProductCommand);
            await _productService.UpdateAsync(productDto);

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
        public async Task<IActionResult> Disable(Guid id)
        {
            //var disableProductCommand = new DisableCommand { Id = id };
            //await _mediator.Send(disableProductCommand);
            await _productService.DisableAsync(id);

            return NoContent();
        }

        // DELETE api/<ProductsController>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete([FromBody] ProductDto dto)
        {
            //var deleteProductCommand = new DeleteCommand { ProductDto = dto };
            //await _mediator.Send(deleteProductCommand);
            await _productService.DeleteAsync(dto.Id);

            return NoContent();
        }
    }
}
