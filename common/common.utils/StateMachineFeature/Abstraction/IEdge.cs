using System;

namespace CST.Common.Utils.StateMachineFeature.Abstraction
{
    public interface IEdge<out TGraphEnum, TVertexEnum, TKey, TVertex, TEdge> 
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TKey : IEquatable<TKey>
        where TVertex : IVertex<TGraphEnum, TVertexEnum, TEdge, TKey, TVertex>
        where TEdge : IEdge<TGraphEnum, TVertexEnum, TKey, TVertex, TEdge>
    {
        TKey Id { get; set; }
        TVertex Tail { get; set; }
        TVertex Head { get; set; }
        TGraphEnum Graph { get; }
        string Name { get; set; }
    }
}