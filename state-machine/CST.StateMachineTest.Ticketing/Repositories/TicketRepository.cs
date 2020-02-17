using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Services;
using CST.StateMachineTest.Ticketing.Data;

namespace CST.StateMachineTest.Ticketing.Repositories
{
    public class TicketRepository
    {
        private readonly StateMachineContext _context;

        public TicketRepository(StateMachineContext context)
        {
            _context = context;
        }

        public Ticket GetById(int id) =>
            _context.Tickets
                .DefaultIncludes()
                .FirstOrDefault(ticket => ticket.Id == id) ??
            throw new Exception();

        public IEnumerable<Ticket> GetList(Expression<Func<Ticket, bool>> filterExpression) =>
            _context.Tickets
                .DefaultIncludes()
                .Where(filterExpression)
                .AsEnumerable() ??
            throw new Exception();
        
        public Ticket Update(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
            return ticket;
        }
    }
}