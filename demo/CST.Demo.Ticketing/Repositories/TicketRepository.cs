using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CST.Demo.Data;
using CST.Demo.Data.Models.Ticketing;

namespace CST.Demo.Ticketing.Repositories
{
    public class TicketRepository
    {
        private readonly DemoContext _context;

        public TicketRepository(DemoContext context)
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