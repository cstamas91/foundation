using System.Collections.Generic;
using AutoMapper;
using CST.Demo.Ticketing.Data;
using CST.Demo.Ticketing.Dtos;
using CST.Demo.Ticketing.Mappers.Converters;

namespace CST.Demo.Ticketing.Mappers
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>()
                .ForMember(
                    dto => dto.RelatedCommits,
                    expression => UpdateableItemListConverter<Commit, CommitDto, int>.Define(expression, ticket => ticket.RelatedCommits));

            CreateMap<Ticket, TicketListDto>()
                .ForMember(
                    dto => dto.State,
                    expression => expression.MapFrom(ticket => ticket.CurrentSubjectState));

            CreateMap<IEnumerable<Ticket>, IEnumerable<TicketDto>>()
                .ConvertUsing<TicketListConverter>();
        }
    }
}