using System;

namespace CST.Common.Utils.StateMachineFeature.Abstraction
{
    public class StateMachineSubjectMoment<TKey, TGraphEnum, TVertexEnum, TSubject>
        where TKey : struct, IEquatable<TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>
    {
        public TKey Id { get; set; }
        public Vertex<TKey, TGraphEnum, TVertexEnum> Vertex { get; set; }
        public TSubject Subject { get; set; }
        public TKey SubjectId { get; set; }
    }
}