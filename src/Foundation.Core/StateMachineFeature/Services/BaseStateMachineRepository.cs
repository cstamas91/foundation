﻿using System;
using System.Collections.Generic;
using Foundation.Core.StateMachineFeature.Abstraction;

namespace Foundation.Core.StateMachineFeature.Services
{
    public abstract class BaseStateMachineRepository<TKey, TGraphEnum, TVertexEnum, TSubject>
        where TKey : struct, IEquatable<TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>
    {
        public abstract StateMachineSubjectMoment<TKey, TGraphEnum, TVertexEnum, TSubject> AddSubjectMoment(
            StateMachineSubjectMoment<TKey, TGraphEnum, TVertexEnum, TSubject> subjectMoment);
        public abstract IEnumerable<Vertex<TKey, TGraphEnum, TVertexEnum>> GetVertices();
        public abstract IEnumerable<Edge<TKey, TGraphEnum, TVertexEnum>> GetEdges();
        public abstract IEnumerable<Edge<TKey, TGraphEnum, TVertexEnum>> GetEdges(TVertexEnum previousState);
        public abstract Vertex<TKey, TGraphEnum, TVertexEnum> GetVertex(TVertexEnum stateEnum);
        public abstract Vertex<TKey, TGraphEnum, TVertexEnum> GetVertex(TKey currentStateId);
        public abstract Edge<TKey, TGraphEnum, TVertexEnum> GetEdge(TKey transitionId);
        public abstract Vertex<TKey, TGraphEnum, TVertexEnum> GetRootVertex();
        public abstract TSubject GetSubject(TKey subjectId);
    }
}