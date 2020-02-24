﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using CST.Common.Utils.Common;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Services;
using CST.StateMachineTest.Ticketing.Data;
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
            var ticketDto = _mapper.Map<TicketDto>(ticket);
            return ticketDto;
        }

        public IEnumerable<TicketListDto> GetTickets(TicketFilter filter)
        {
            var filterExpression = _mapper.Map<TicketFilter, Expression<Func<Ticket, bool>>>(filter);
            var ticketEnumerable = _ticketRepository.GetList(filterExpression);
            return _mapper.Map<IEnumerable<TicketListDto>>(ticketEnumerable);
        }

        public TicketDto CreateTicket(CreateTicketDto dto)
        {
            var newTicket = _mapper.Map<Ticket>(dto);
            TransactionHelper.WithTransactionScope(
                () =>
                {
                    newTicket = _stateMachineService
                        .InitializeSubject(newTicket, TicketingEnum.Open);
                },
                _logger);
            return _mapper.Map<TicketDto>(newTicket);
        }

        public TicketDto UpdateTicket(TicketDto dto, int? transitionId = null)
        {
            Ticket ticket = default;
            TransactionHelper.WithTransactionScope(() =>
                {
                    ticket = _ticketRepository.GetById(dto.Id);
                    _mapper.Map(dto, ticket);
                    _ticketRepository.Update(ticket);
                    if (transitionId.HasValue)
                    {
                        ticket = _stateMachineService.StepSubject(ticket, transitionId.Value);
                    }
                },
                _logger);

            return _mapper.Map<TicketDto>(ticket);
        }
    }
}