using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Services.Products.Commands.Create;
using PickItEasy.Application.Services.Products.Queries.GetById;
using PickItEasy.Application.Services.Products.Commands.Update;
using AutoMapper;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdProductQuery { Id =  id });

            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto createProductDto)
        {
            var createProductCommand = new CreateProductCommand { CreateProductDto = createProductDto };
            var result = await _mediator.Send(createProductCommand);

            return CreatedAtAction(nameof(GetById), new {id = result.Id}, result);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            var updateProductCommand = new UpdateProductCommand { Id = id, UpdateProductDto = updateProductDto };
            await _mediator.Send(updateProductCommand);

            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
