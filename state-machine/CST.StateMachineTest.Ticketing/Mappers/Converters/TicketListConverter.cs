using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Data;
using CST.StateMachineTest.Ticketing.Dtos;

namespace CST.StateMachineTest.Ticketing.Mappers.Converters
{
    public class TicketListConverter : ITypeConverter<IEnumerable<Ticket>, IEnumerable<TicketDto>>
    {
        public IEnumerable<TicketDto> Convert(
            IEnumerable<Ticket> source, 
            IEnumerable<TicketDto> destination, 
            ResolutionContext context)
        {
            return source.Select(ticket => context.Mapper.Map<TicketDto>(ticket));
        }
    }
}