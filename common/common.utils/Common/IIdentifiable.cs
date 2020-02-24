using System;

namespace CST.Common.Utils.Common
{
    public interface IIdentifiable<TKey>
        where TKey: struct, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}