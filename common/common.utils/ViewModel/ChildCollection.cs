using System.Collections.Generic;
using System.Linq;

namespace CST.Common.Utils.ViewModel
{
    public class ChildCollection<T>
    {
        public ChildCollection()
        {
            Items = new List<UpdateableItem<T>>();
        }

        private ChildCollection(IEnumerable<UpdateableItem<T>> source)
        {
            Items = source.ToList();
        }

        private ChildCollection(IEnumerable<T> source)
        {
            Items = source
                .Select(UpdateableItem<T>.Unchanged)
                .ToList();
        }
        public IReadOnlyCollection<UpdateableItem<T>> Items { get; set; }

        public IEnumerable<T> GetItems(UpdateableItemState updateableItemState) =>
            Items
                .Where(updateableItem => updateableItem.UpdateableItemState == updateableItemState)
                .Select(updateableItem => updateableItem.Item);

        public static ChildCollection<T> Unchanged(IEnumerable<UpdateableItem<T>> source) => 
            new ChildCollection<T>(source);

        public static ChildCollection<T> Unchanged(IEnumerable<T> source) => 
            new ChildCollection<T>(source);
    }
}