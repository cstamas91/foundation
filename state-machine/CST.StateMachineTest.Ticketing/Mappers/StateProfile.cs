using AutoMapper;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Data;
using CST.StateMachineTest.Ticketing.Mappers.Converters;

namespace CST.StateMachineTest.Ticketing.Mappers
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