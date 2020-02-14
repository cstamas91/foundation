using System;

namespace CST.Common.Utils.ViewModel
{
    public class Selectable<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
    }
}