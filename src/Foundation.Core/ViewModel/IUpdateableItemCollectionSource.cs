using System.Collections.Generic;

namespace Foundation.Core.ViewModel
{
    public interface IUpdateableItemCollectionSource<TItem>
    {
        IEnumerable<UpdateableItem<TItem>> GetSourceCollection();
    }

    public interface IUpdateableItemCollectionDestination<TItem>
    {
        ICollection<TItem> GetDestinationCollection();
    }
}