using AutoMapper;
using CST.Common.Utils.StateMachineFeature.Abstraction;
using CST.Demo.Data.Models.Ticketing;
using CST.Demo.Ticketing.Mappers.Converters;

namespace CST.Demo.Ticketing.Mappers
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket>, string>()
                .ConvertUsing<CurrentStateConverter>();
            CreateMap<StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket>, int>()
                .ConvertUsing<CurrentStateConverter>();
        }
    }
}