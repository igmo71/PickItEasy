﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Interfaces;
using PickItEasy.EventBus.RabbitMq;

namespace PickItEasy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMqController : ControllerBase
    {
        private readonly IEventBusPublisher _eventBusService;

        public RabbitMqController(IEventBusPublisher eventBusService)
        {
            _eventBusService = eventBusService;
        }

        [Route("[action]/{message}")]
        [HttpGet]
        public IActionResult SendMessage(string message)
        {
            _eventBusService.SendMessage(message);

            return Ok("Сообщение отправлено");
        }
    }
}
