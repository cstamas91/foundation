using System;
using CST.Common.Utils.StateMachineFeature.Abstraction;

namespace CST.Common.Utils.StateMachineFeature.BaseClasses
{
    public abstract class BaseSubject<TStateMachineEnum, TStateEnum, TSubject, TSubjectState, TEdge, TKey, TVertex> : 
        ISubject<TStateMachineEnum, TStateEnum, TSubject, TSubjectState, TEdge, TKey, TVertex> 
        where TStateMachineEnum : struct, IConvertible 
        where TStateEnum : struct, IConvertible
        where TSubject : ISubject<TStateMachineEnum, TStateEnum, TSubject, TSubjectState, TEdge, TKey, TVertex>
        where TSubjectState : ISubjectState<TStateMachineEnum, TStateEnum, TSubject, TSubjectState, TEdge, TKey, TVertex>
        where TVertex : IEquatable<TVertex>
        where TKey : IEdge<TStateMachineEnum, TStateEnum, TVertex, TEdge, TKey>
        where TEdge : IVertex<TStateMachineEnum, TStateEnum, TKey, TVertex, TEdge>
    {
        public abstract TSubjectState CurrentSubjectState { get; set; }
        public abstract TStateMachineEnum StateMachine { get; }
    }
}