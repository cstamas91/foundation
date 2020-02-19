namespace CST.Common.Utils.ViewModel
{
    public class UpdateableItem<T>
    {
        public UpdateableItemState UpdateableItemState { get; set; }
        public T Item { get; set; }

        public static UpdateableItem<T> Unchanged(T item)
        {
            return new UpdateableItem<T>
            {
                UpdateableItemState = UpdateableItemState.Unchanged,
                Item = item
            };
        }
    }
}