using System.Collections.Generic;
using System.Linq;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.Demo.Data.Models.Ticketing;
using CST.Demo.Data;

namespace CST.Demo.Ticketing.Repositories
{
    public class TicketingRepository : BaseStateMachineRepository<int, GraphEnum, TicketingEnum, Ticket>
    {
        private readonly DemoContext _context;

        public TicketingRepository(DemoContext context)
        {
            _context = context;
        }

        public override StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket> AddSubjectMoment(
            StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket> subjectMoment)
        {
            _context.TicketingHistory.Add(subjectMoment);
            _context.SaveChanges();
            return subjectMoment;
        }

        public override IEnumerable<Vertex<int, GraphEnum, TicketingEnum>> GetVertices()
        {
            return _context.TicketingVertex
                .DefaultIncludes()
                .AsEnumerable();
        }

        public override IEnumerable<Edge<int, GraphEnum, TicketingEnum>> GetEdges()
        {
            return _context.TicketingEdge
                .DefaultIncludes()
                .AsEnumerable();
        }

        public override IEnumerable<Edge<int, GraphEnum, TicketingEnum>> GetEdges(TicketingEnum previousState)
        {
            return _context.TicketingEdge
                .DefaultIncludes()
                .Where(edge => edge.Tail.VertexEnum == previousState);
        }

        public override Vertex<int, GraphEnum, TicketingEnum> GetVertex(TicketingEnum stateEnum)
        {
            return _context.TicketingVertex
                .DefaultIncludes()
                .FirstOrDefault(vertex => vertex.VertexEnum == stateEnum);
        }

        public override Vertex<int, GraphEnum, TicketingEnum> GetVertex(int currentStateId)
        {
            return _context.TicketingVertex
                .DefaultIncludes()
                .FirstOrDefault(vertex => vertex.Id == currentStateId);
        }

        public override Edge<int, GraphEnum, TicketingEnum> GetEdge(int transitionId)
        {
            return _context.TicketingEdge
                .DefaultIncludes()
                .FirstOrDefault(edge => edge.Id == transitionId);
        }

        public override Vertex<int, GraphEnum, TicketingEnum> GetRootVertex()
        {
            return _context.TicketingVertex
                .DefaultIncludes()
                .FirstOrDefault(vertex => vertex.VertexEnum == TicketingEnum.Open);
        }
    }
}