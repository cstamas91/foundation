using System.Collections;
using System.Collections.Generic;
using CST.StateMachineTest.Services;
using CST.StateMachineTest.Ticketing.Dtos;
using CST.StateMachineTest.Ticketing.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CST.StateMachineTest.Ticketing.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet]
        public CreateTicketDto Get()
        {
            return new CreateTicketDto();
        }

        [HttpGet("{id}")]
        public TicketDto Get([FromQuery] int id)
        {
            return _service.GetTicket(id);
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

        [HttpPost("list")]
        public IEnumerable<TicketDto> List([FromBody] TicketFilter filter)
        {
            return _service.GetTickets(filter);
        }
    }
}