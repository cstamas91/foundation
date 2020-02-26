using CST.Common.Utils.Common;

namespace CST.Demo.Ticketing.Dtos
{
    public class CommitDto : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Hash { get; set; }
    }
}