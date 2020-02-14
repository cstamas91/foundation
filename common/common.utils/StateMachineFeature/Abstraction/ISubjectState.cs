using System;

namespace CST.Common.Utils.StateMachineFeature.Abstraction
{
    public interface ISubjectState<out TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey> 
        where TGraphEnum : struct, IConvertible 
        where TVertexEnum : struct, IConvertible
        where TSubject : ISubject<TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>
        where TSubjectState : ISubjectState<TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>
        where TVertex : IVertex<TGraphEnum, TVertexEnum, TEdge, TKey, TVertex>
        where TEdge : IEdge<TGraphEnum, TVertexEnum, TKey, TVertex, TEdge>
        where TKey : IEquatable<TKey>
    {
        TVertex Vertex { get; set; }
        TSubject Subject { get; set; }
        TGraphEnum Graph { get; }
    }
}