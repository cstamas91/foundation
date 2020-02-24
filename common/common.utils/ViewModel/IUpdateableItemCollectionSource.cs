using System.Collections;
using System.Collections.Generic;

namespace CST.Common.Utils.ViewModel
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