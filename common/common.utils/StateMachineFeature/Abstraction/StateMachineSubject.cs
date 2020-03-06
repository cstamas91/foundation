using System;

namespace CST.Common.Utils.StateMachineFeature.Abstraction
{
    public abstract class StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject> 
        where TKey : struct, IEquatable<TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>
    {
        public abstract StateMachineSubjectMoment<TKey, TGraphEnum, TVertexEnum, TSubject> CurrentSubjectState
        {
            get;
            set;
        }
    }
}