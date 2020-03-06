using System;
using CST.Common.Utils.ViewModel;

namespace CST.Common.Utils.StateMachineFeature.Abstraction
{
    public class Edge<TKey, TGraphEnum, TVertexEnum> : ISelectableSource<TKey>
        where TKey : struct, IEquatable<TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public Vertex<TKey, TGraphEnum, TVertexEnum> Tail { get; set; }
        public Vertex<TKey, TGraphEnum, TVertexEnum> Head { get; set; }
        public TGraphEnum Graph { get; set; }
        public TKey GetId() => Id;
        public string GetName() => Name;
    }
}