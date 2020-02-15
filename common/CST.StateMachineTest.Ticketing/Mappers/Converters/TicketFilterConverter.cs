using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CST.Common.Utils;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Dtos;

namespace CST.StateMachineTest.Ticketing.Mappers.Converters
{
    public class TicketFilterConverter : ITypeConverter<TicketFilter, Expression<Func<Ticket, bool>>>
    {
        public Expression<Func<Ticket, bool>> Convert(
            TicketFilter source, 
            Expression<Func<Ticket, bool>> destination, 
            ResolutionContext context)
        {
            destination = (Ticket t) => true;

            if (!string.IsNullOrEmpty(source.Description))
            {
                destination = destination.And(t => t.Description.Contains(source.Description));
            }

            if (source.RelatedCommits != null && source.RelatedCommits.Length != 0)
            {
                destination = destination.And(
                    t => t.RelatedCommits.Any(c => source.RelatedCommits.Contains(c.Id)));
            }

            return destination;
        }
    }
}