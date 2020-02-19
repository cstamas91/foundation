using System.Collections.Generic;
using System.Linq;
using CST.Common.Utils.ViewModel;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Services;

namespace CST.StateMachineTest.Ticketing.Dtos
{
    public class TicketDto : CreateTicketDto
    {
        public int Id { get; set; }
        public ChildCollection<CommitDto> RelatedCommits { get; set; }
    }
}