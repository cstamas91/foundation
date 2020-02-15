using AutoMapper;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.StateMachineTest.Data;

namespace CST.StateMachineTest.Ticketing.Mappers.Converters
{
    public class CurrentStateConverter : 
        ITypeConverter<StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket>, string>
    {
        public string Convert(
            StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket> source, 
            string destination, 
            ResolutionContext context)
        {
            return source.Vertex.Name;
        }
    }
}