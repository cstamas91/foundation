using System;
using System.Collections.Generic;

namespace CST.Common.Utils.StateMachineFeature.Abstraction
{
    public interface IVertex<out TGraphEnum, out TVertexEnum, TEdge, TKey, TVertex>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TEdge : IEdge<TGraphEnum, TVertexEnum, TKey, TVertex, TEdge>
        where TKey : IEquatable<TKey>
        where TVertex : IVertex<TGraphEnum, TVertexEnum, TEdge, TKey, TVertex>
    {
        string Name { get; set; }
        TGraphEnum Graph { get; }
        TVertexEnum VertexEnum { get; }
        ICollection<TEdge> OutEdges { get; set; }
        ICollection<TEdge> InEdges { get; set; }
    }
}