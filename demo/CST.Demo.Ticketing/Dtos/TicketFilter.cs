namespace CST.Demo.Ticketing.Dtos
{
    public class TicketFilter
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public int[] RelatedCommits { get; set; }
    }
}