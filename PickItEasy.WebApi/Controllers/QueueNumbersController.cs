using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueNumbersController : ControllerBase
    {
        private readonly IApplicationDbContext _dbContext;

        public QueueNumbersController(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var queueNumber = _dbContext.QueueNumbers
                .AsNoTracking()
                .Where(e => e.Active)
                .OrderBy(e => e.Value)
                .FirstOrDefault();

            if (queueNumber == null)
            {
                await _dbContext.QueueNumbers.ExecuteUpdateAsync(e => e.SetProperty(p => p.Active, true));
                queueNumber = _dbContext.QueueNumbers
                .AsNoTracking()
                .Where(e => e.Active)
                .OrderBy(e => e.Value)
                .FirstOrDefault();
            }

            queueNumber.Active = false;
            _dbContext.QueueNumbers.Update(queueNumber);
            await _dbContext.SaveChangesAsync();

            return Ok(queueNumber.Value);
        }
    }
}
