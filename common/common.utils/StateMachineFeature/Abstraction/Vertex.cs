using System;
using System.Collections.Generic;
using CST.Common.Utils.ViewModel;

namespace CST.Common.Utils.StateMachineFeature.Abstraction
{
    public class Vertex<TKey, TGraphEnum, TVertexEnum> : ISelectableSource<TKey>
        where TKey : struct, IEquatable<TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public TGraphEnum Graph { get; set; }
        public TVertexEnum VertexEnum { get; set; }
        public ICollection<Edge<TKey, TGraphEnum, TVertexEnum>> OutEdges { get; set; }
        public ICollection<Edge<TKey, TGraphEnum, TVertexEnum>> InEdges { get; set; }
        public TKey GetId() => Id;

        public string GetName() => Name;
    }
}