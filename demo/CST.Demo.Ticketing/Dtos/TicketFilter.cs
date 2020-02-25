using System;
using System.Linq;
using System.Linq.Expressions;
using CST.Common.Utils;
using CST.StateMachineTest.Data;

namespace CST.StateMachineTest.Ticketing.Dtos
{
    public class TicketFilter
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public int[] RelatedCommits { get; set; }
    }
}