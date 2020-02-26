using AutoMapper;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.Demo.Ticketing.Data;

namespace CST.Demo.Ticketing.Mappers.Converters
{
    public class CurrentStateConverter : 
        ITypeConverter<StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket>, string>,
        ITypeConverter<StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket>, int>
    {
        public string Convert(
            StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket> source, 
            string destination, 
            ResolutionContext context)
        {
            return source.Vertex.Name;
        }

        public int Convert(
            StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket> source, 
            int destination, 
            ResolutionContext context)
        {
            return source.Vertex.Id;
        }
    }
}