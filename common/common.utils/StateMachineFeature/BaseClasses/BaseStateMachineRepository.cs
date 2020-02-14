using System;
using System.Collections.Generic;
using CST.Common.Utils.StateMachineFeature.Abstraction;

namespace CST.Common.Utils.StateMachineFeature.BaseClasses
{
    public abstract class BaseStateMachineRepository<TGraphEnum, 
                                                     TVertexEnum, 
                                                     TSubject,
                                                     TSubjectState, 
                                                     TVertex,
                                                     TEdge,
                                                     TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TSubject : ISubject<TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>, new()
        where TSubjectState : ISubjectState<TGraphEnum, TVertexEnum, TSubject, TSubjectState, TVertex, TEdge, TKey>, new()
        where TVertex : IVertex<TGraphEnum, TVertexEnum, TEdge, TKey, TVertex>
        where TEdge : IEdge<TGraphEnum, TVertexEnum, TKey, TVertex, TEdge>
        where TKey : IEquatable<TKey>
    {
        public abstract TSubjectState AddSubjectState(TSubjectState subjectState);
        public abstract IEnumerable<TVertex> GetVertices();
        public abstract IEnumerable<TEdge> GetEdges();
        public abstract IEnumerable<TEdge> GetEdges(TVertexEnum previousState);
        public abstract TVertex GetVertex(TVertexEnum stateEnum);
        public abstract TEdge GetEdge(TKey transitionId);
        public abstract TVertex GetRootVertex();
    }
}