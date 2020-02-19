using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Data;
using CST.StateMachineTest.Ticketing.Dtos;
using CST.StateMachineTest.Ticketing.Mappers.Converters;

namespace CST.StateMachineTest.Ticketing.Mappers
{
    public class TicketDtoProfile : Profile
    {
        public TicketDtoProfile()
        {
            CreateMap<CreateTicketDto, Ticket>()
                .ForMember(
                    ticket => ticket.RelatedCommits,
                    expression => expression.MapFrom(dto => new List<Commit>()));

            CreateMap<TicketFilter, Expression<Func<Ticket, bool>>>()
                .ConvertUsing<TicketFilterConverter>();

            CreateMap<IEnumerable<Ticket>, IEnumerable<TicketDto>>()
                .ConvertUsing<TicketListConverter>();
        }
    }
}