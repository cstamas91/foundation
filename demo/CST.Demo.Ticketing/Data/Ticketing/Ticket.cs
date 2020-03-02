using System.Collections.Generic;
using CST.Common.Utils.Common;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.Common.Utils.ViewModel;
using CST.Demo.Data.Models.Identity;

namespace CST.Demo.Data.Ticketing
{
    public class Ticket : StateMachineSubject<int, GraphEnum, TicketingEnum, Ticket>, 
        IIdentifiable<int>, 
        IUpdateableItemCollectionDestination<Commit>
    {
        public override StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket>
            CurrentSubjectState { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Commit> RelatedCommits { get; set; }
        public ICollection<Commit> GetDestinationCollection() => RelatedCommits;
        public User User { get; set; }
    }
}