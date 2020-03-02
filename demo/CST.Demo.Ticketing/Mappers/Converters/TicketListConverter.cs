using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CST.Demo.Data.Ticketing;
using CST.Demo.Ticketing.Dtos;

namespace CST.Demo.Ticketing.Mappers.Converters
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