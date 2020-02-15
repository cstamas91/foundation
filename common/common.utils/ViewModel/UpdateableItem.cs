namespace CST.Common.Utils.ViewModel
{
    public enum StateFlag
    {
        Unchanged,
        Added,
        Deleted,
        Modified
    }
    
    public class UpdateableItem<T>
    {
        public StateFlag State { get; set; }
        public T Item { get; set; }

        public static UpdateableItem<T> Unchanged(T item)
        {
            return new UpdateableItem<T>
            {
                State = StateFlag.Unchanged,
                Item = item
            };
        }
    }
}