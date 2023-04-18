using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain.Entities;

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueNumberController : ControllerBase
    {
        private readonly IApplicationDbContext _dbContext;

        public QueueNumberController(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var currentQueueNumber = await _dbContext.QueueNumber.FirstOrDefaultAsync()
                ?? throw new ApplicationException("QueueNumber no found.");

            QueueNumber newQueueNumber = currentQueueNumber.Next(currentQueueNumber);

            _dbContext.QueueNumber.Remove(currentQueueNumber);
            _dbContext.QueueNumber.Add(newQueueNumber);
            await _dbContext.SaveChangesAsync();

            return Ok(newQueueNumber.Value);
        }

        [HttpDelete]
        public async Task<IActionResult> Reset()
        {
            var currentQueueNumber = await _dbContext.QueueNumber.FirstOrDefaultAsync()
                ?? throw new ApplicationException("QueueNumber no found.");

            var newQueueNumber = new QueueNumber()
            {
                CharValue = 0,
                NumValue = 0,
                Value = "A00"
            };

            _dbContext.QueueNumber.Remove(currentQueueNumber);
            _dbContext.QueueNumber.Add(newQueueNumber);
            await _dbContext.SaveChangesAsync();

            return Ok(newQueueNumber.Value);
        }
    }
}
