using System.Collections.Generic;
using CST.Common.Utils.ViewModel;

namespace CST.Demo.Ticketing.Dtos
{
    public class TicketDto : CreateTicketDto, IUpdateableItemCollectionSource<CommitDto>
    {
        public int Id { get; set; }
        public List<UpdateableItem<CommitDto>> RelatedCommits { get; set; }
        public IEnumerable<UpdateableItem<CommitDto>> GetSourceCollection() => RelatedCommits;
    }
}