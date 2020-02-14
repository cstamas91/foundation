using System;
using CST.Common.Utils.StateMachineFeature.Abstraction;

namespace CST.Common.Utils.StateMachineFeature.BaseClasses
{
    public abstract class BaseEdge<TStateMachineEnum, TStateEnum, TKey, TVertex, TEdge> : 
        IEdge<TStateMachineEnum, TStateEnum, TKey, TVertex, TEdge>
        where TStateMachineEnum : struct, IConvertible 
        where TStateEnum : struct, IConvertible
        where TKey : IEquatable<TKey>
        where TEdge : IEdge<TStateMachineEnum, TStateEnum, TKey, TVertex, TEdge>
        where TVertex : IVertex<TStateMachineEnum, TStateEnum, TEdge, TKey, TVertex>
    {
        public abstract TKey Id { get; set; }
        public abstract TVertex Tail { get; set; }
        public abstract TVertex Head { get; set; }
        public abstract TStateMachineEnum Graph { get; }
        public abstract string Name { get; set; }
    }
}