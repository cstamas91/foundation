using System;
using CST.Common.Utils.StateMachineFeature.Abstraction;

namespace CST.Common.Utils.StateMachineFeature.BaseClasses
{
    public abstract class BaseSubjectState<TStateMachineEnum, TStateEnum, TSubject, TSubjectState, TVertex, TEdge, TKey> : 
        ISubjectState<TStateMachineEnum, TStateEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>
        where TStateMachineEnum : struct, IConvertible 
        where TStateEnum : struct, IConvertible
        where TSubject : ISubject<TStateMachineEnum, TStateEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>
        where TSubjectState : ISubjectState<TStateMachineEnum, TStateEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>
        where TKey : IEquatable<TKey>
        where TEdge : IEdge<TStateMachineEnum, TStateEnum, TKey, TVertex, TEdge>
        where TVertex : IVertex<TStateMachineEnum, TStateEnum, TEdge, TKey, TVertex>
    {
        public abstract TVertex Vertex { get; set; }
        public abstract TSubject Subject { get; set; }
        public abstract TStateMachineEnum Graph { get; }
    }
}