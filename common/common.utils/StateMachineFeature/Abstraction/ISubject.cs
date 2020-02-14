using System;

namespace CST.Common.Utils.StateMachineFeature.Abstraction
{
    public interface ISubject<out TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TSubject : ISubject<TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>
        where TSubjectState : ISubjectState<TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>
        where TKey : IEquatable<TKey>
        where TEdge : IEdge<TGraphEnum, TVertexEnum, TKey, TVertex, TEdge>
        where TVertex : IVertex<TGraphEnum, TVertexEnum, TEdge, TKey, TVertex>
    {
        TSubjectState CurrentSubjectState { get; set; }
        TGraphEnum StateMachine { get; }
    }
}