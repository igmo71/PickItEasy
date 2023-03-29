using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Services.Products.Commands.Create;
using PickItEasy.Application.Services.Products.Queries.GetById;
using PickItEasy.Application.Services.Products.Commands.Update;
using AutoMapper;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
            var result = await _mediator.Send(new GetByIdProductQuery { Id =  id });

            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] CreateProductDto createProductDto)
        {
            var createProductCommand = new CreateProductCommand { CreateProductDto = createProductDto };
            var result = await _mediator.Send(createProductCommand);

            return CreatedAtAction(nameof(GetById), new {id = result.Id}, result);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            var updateProductCommand = new UpdateProductCommand { Id = id, UpdateProductDto = updateProductDto };
            await _mediator.Send(updateProductCommand);

            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public IActionResult Delete(Guid id)
        {
            return StatusCode((int)HttpStatusCode.MethodNotAllowed);
        }
    }
}
