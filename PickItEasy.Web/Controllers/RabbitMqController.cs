using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Interfaces.EventBus;

namespace PickItEasy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMqController : ControllerBase
    {
        private readonly IEventBusPublisher _eventBusPublisher;

        public RabbitMqController(IEventBusPublisher eventBusPublisher)
        {
            _eventBusPublisher = eventBusPublisher;
        }

        [Route("[action]/{message}")]
        [HttpGet]
        public IActionResult SendMessage(string message)
        {
            _eventBusPublisher.SendMessage(message);

            return Ok("Сообщение отправлено");
        }
    }
}
