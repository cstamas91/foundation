using AutoMapper;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Data;
using CST.StateMachineTest.Ticketing.Dtos;
using CST.StateMachineTest.Ticketing.Mappers.Converters;

namespace CST.StateMachineTest.Ticketing.Mappers
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>()
                .ForMember(
                    dto => dto.RelatedCommits,
                    ChildCollectionConverter<Commit, CommitDto>.Define);

            CreateMap<Ticket, TicketListDto>()
                .ForMember(
                    dto => dto.State,
                    expression => expression.MapFrom(ticket => ticket.CurrentSubjectState));
        }
    }
}