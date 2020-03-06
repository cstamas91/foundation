using System.Linq;
using CST.Common.Utils.StateMachineFeature.Abstraction;
using CST.Demo.Data.Models.Ticketing;
using Microsoft.EntityFrameworkCore;

namespace CST.Demo.Ticketing.Repositories
{
    public static class IncludeExtensions
    {
        public static IQueryable<Vertex<int, GraphEnum, TicketingEnum>> DefaultIncludes(
            this IQueryable<Vertex<int, GraphEnum, TicketingEnum>> source)
        {
            return source
                .Include(vertex => vertex.InEdges)
                .Include(vertex => vertex.OutEdges);
        }

        public static IQueryable<Edge<int, GraphEnum, TicketingEnum>> DefaultIncludes(
            this IQueryable<Edge<int, GraphEnum, TicketingEnum>> source)
        {
            return source
                .Include(edge => edge.Head)
                .ThenInclude(vertex => vertex.InEdges)
                .Include(edge => edge.Head)
                .ThenInclude(vertex => vertex.OutEdges)
                .Include(edge => edge.Tail)
                .ThenInclude(vertex => vertex.InEdges)
                .Include(edge => edge.Tail)
                .ThenInclude(vertex => vertex.OutEdges);
        }

        public static IQueryable<Ticket> DefaultIncludes(
            this IQueryable<Ticket> source)
        {
            return source
                .Include(t => t.RelatedCommits)
                .Include(ticket => ticket.CurrentSubjectState)
                .ThenInclude(s => s.Vertex)
                .ThenInclude(v => v.OutEdges)
                .ThenInclude(e => e.Head);
            
        }
    }
}