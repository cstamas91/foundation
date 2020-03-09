using System;

namespace Foundation.Core.Common
{
    public interface IIdentifiable<TKey>
        where TKey: struct, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}