using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CST.Common.Utils;
using CST.Demo.Ticketing.Data;
using CST.Demo.Ticketing.Dtos;

namespace CST.Demo.Ticketing.Mappers.Converters
{
    public class TicketFilterConverter : ITypeConverter<TicketFilter, Expression<Func<Ticket, bool>>>
    {
        public Expression<Func<Ticket, bool>> Convert(
            TicketFilter source, 
            Expression<Func<Ticket, bool>> destination, 
            ResolutionContext context)
        {
            destination = (ticket) => true;

            if (!string.IsNullOrEmpty(source.Description))
            {
                destination = destination.And(ticket => ticket.Description.Contains(source.Description));
            }

            if (source.RelatedCommits != null && source.RelatedCommits.Length != 0)
            {
                destination = destination.And(
                    ticket => ticket.RelatedCommits.Any(commit => source.RelatedCommits.Contains(commit.Id)));
            }

            return destination;
        }
    }
}