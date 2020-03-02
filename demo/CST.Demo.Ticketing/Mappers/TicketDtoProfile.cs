using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using CST.Demo.Data.Ticketing;
using CST.Demo.Ticketing.Dtos;
using CST.Demo.Ticketing.Mappers.Converters;

namespace CST.Demo.Ticketing.Mappers
{
    public class TicketDtoProfile : Profile
    {
        public TicketDtoProfile()
        {
            CreateMap<CreateTicketDto, Ticket>()
                .ForMember(
                    ticket => ticket.RelatedCommits,
                    expression => expression.MapFrom(dto => new List<Commit>()));

            CreateMap<TicketDto, Ticket>()
                .ForMember(
                    ticket => ticket.RelatedCommits, 
                    expression => expression.Ignore())
                .AfterMap<UpdateableItemResultResolver<TicketDto, Ticket, Commit, CommitDto,int >>();

            CreateMap<TicketFilter, Expression<Func<Ticket, bool>>>()
                .ConvertUsing<TicketFilterConverter>();
        }
    }
}