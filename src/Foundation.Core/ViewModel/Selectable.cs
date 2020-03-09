using System;
using System.Diagnostics.CodeAnalysis;

namespace Foundation.Core.ViewModel
{
    public interface ISelectableSource<out TKey>
        where TKey : struct, IEquatable<TKey>
    {
        TKey GetId();
        string GetName();
    }
    
    public class Selectable<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public TKey Id { get; set; }
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public string Name { get; set; }

        public static Selectable<TKey> Create(ISelectableSource<TKey> source)
        {
            return new Selectable<TKey>
            {
                Id = source.GetId(),
                Name = source.GetName()
            };
        }
    }
}