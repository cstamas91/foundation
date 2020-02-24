using CST.Common.Utils.Common;
using CST.StateMachineTest.Data;

namespace CST.StateMachineTest.Ticketing.Dtos
{
    public class CommitDto : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Hash { get; set; }
    }
}