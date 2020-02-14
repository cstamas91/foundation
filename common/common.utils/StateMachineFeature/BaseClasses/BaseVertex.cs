using System;
using System.Collections.Generic;
using System.Reflection;
using CST.Common.Utils.StateMachineFeature.Abstraction;
using Microsoft.AspNetCore.Routing.Matching;

namespace CST.Common.Utils.StateMachineFeature.BaseClasses
{
    public abstract class BaseVertex<TGraphEnum, TVertexEnum, TEdge, TKey, TVertex> : 
        IVertex<TGraphEnum, TVertexEnum, TEdge, TKey, TVertex>
        where TGraphEnum : struct, IConvertible 
        where TVertexEnum : struct, IConvertible
        where TVertex : IVertex<TGraphEnum, TVertexEnum, TEdge, TKey, TVertex>
        where TKey : IEquatable<TKey>
        where TEdge : IEdge<TGraphEnum, TVertexEnum, TKey, TVertex, TEdge>
    {
        public abstract string Name { get; set; }
        public abstract TGraphEnum Graph { get; }
        public abstract TVertexEnum VertexEnum { get; }
        public abstract ICollection<TEdge> OutEdges { get; set; }
        public abstract ICollection<TEdge> InEdges { get; set; }
    }
}