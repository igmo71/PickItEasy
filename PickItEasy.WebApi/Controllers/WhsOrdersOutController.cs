using MediatR;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Services.WhsOrdersExpense.Commands.CreateWhsOrderExpense;
using PickItEasy.Application.Services.WhsOrdersOut.Commands.Create;
using PickItEasy.Application.Services.WhsOrdersOut.Queries;
using PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WhsOrdersOutController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetByIdWhsOrderOutQuery { Id = id });

            return Ok(result);
        }

        // POST api/<WhsOrdersOutController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWhsOrderOutDto createWhsOrderOutDto)
        {
            var result = await _mediator.Send(new CreateWhsOrderOutCommand { CreateWhsOrderOutDto = createWhsOrderOutDto });

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT api/<WhsOrdersOutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WhsOrdersOutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
