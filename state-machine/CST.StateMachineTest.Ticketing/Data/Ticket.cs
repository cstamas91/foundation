using System.Collections.Generic;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.StateMachineTest.Data;

namespace CST.StateMachineTest.Ticketing.Data
{
    public class Ticket : StateMachineSubject<int, GraphEnum, TicketingEnum, Ticket>
    {
        public override StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket>
            CurrentSubjectState { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Commit> RelatedCommits { get; set; }
    }
}