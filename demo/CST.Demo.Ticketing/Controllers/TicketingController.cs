﻿using CST.Demo.Ticketing.Dtos;
using CST.Demo.Ticketing.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CST.Demo.Ticketing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketingController : ControllerBase
    {
        private readonly ILogger<TicketingController> _logger;
        private readonly TicketingService _service;

        public TicketingController(
            ILogger<TicketingController> logger,
            TicketingService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("proxy")]
        public CreateTicketDto Get() => new CreateTicketDto();

        [HttpGet]
        public IActionResult Get([FromQuery] TicketFilter filter)
        {
            return filter.Id.HasValue 
                ? Ok(_service.GetTicket(filter.Id.Value)) 
                : Ok(_service.GetTickets(filter));
        }

        [HttpPut]
        public TicketDto Create([FromBody] CreateTicketDto dto)
        {
            return _service.CreateTicket(dto);
        }

        [HttpPost]
        public TicketDto Update([FromBody] TicketDto dto, [FromQuery] int? transitionId = default)
        {
            return _service.UpdateTicket(dto, transitionId);
        }
    }
}