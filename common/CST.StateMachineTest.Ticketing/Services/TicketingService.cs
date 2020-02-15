using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using CST.Common.Utils.Common;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Services;
using CST.StateMachineTest.Ticketing.Dtos;
using CST.StateMachineTest.Ticketing.Repositories;
using Microsoft.Extensions.Logging;

namespace CST.StateMachineTest.Ticketing.Services
{
    
    public class TicketingService
    {
        private readonly TicketingStateMachineService _stateMachineService;
        private readonly TicketRepository _ticketRepository;
        private readonly ILogger<TicketingService> _logger;
        private readonly IMapper _mapper;
        
        public TicketingService(
            TicketingStateMachineService stateMachineService,
            TicketRepository ticketRepository,
            ILogger<TicketingService> logger,
            IMapper mapper)
        {
            _stateMachineService = stateMachineService;
            _ticketRepository = ticketRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public TicketDto GetTicket(int id)
        {
            var ticket = _ticketRepository.GetById(id);
            return _mapper.Map<TicketDto>(ticket);
        }

        public IEnumerable<TicketDto> GetTickets(TicketFilter filter)
        {
            var filterExpression = _mapper.Map<TicketFilter, Expression<Func<Ticket, bool>>>(filter);
            var ticketList = _ticketRepository.GetList(filterExpression);
            foreach (var ticket in ticketList)
            {
                yield return _mapper.Map<TicketDto>(ticket);
            }
        }
        
        public TicketDto CreateTicket(CreateTicketDto dto)
        {
            var result = TransactionHelper.WithTransactionScope(
                (t, e) => _stateMachineService.InitializeSubject(t, e),
                _mapper.Map<Ticket>(dto),
                TicketingEnum.Open,
                _logger);
            
            if (result.Success)
            {
                return _mapper.Map<TicketDto>(result.Result);    
            }

            throw result.Exception;
        }

        public TicketDto UpdateTicket(TicketDto dto, int? transitionId = null)
        {
            var result = TransactionHelper.WithTransactionScope((d, id) =>
            {
                var result = _ticketRepository.GetById(d.Id);
                result = _mapper.Map(dto, result);
                _ticketRepository.Update(result);
                if (id.HasValue)
                {
                    result = _stateMachineService.StepSubject(result, id.Value);
                }

                return result;
            }, dto, transitionId, _logger);

            if (result.Success)
            {
                return _mapper.Map<TicketDto>(result.Result);
            }

            throw result.Exception;
        }
    }
}