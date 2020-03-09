using System;

namespace Foundation.StateMachineFeature.Abstraction
{
    public interface IStateMachineService<TKey, TGraphEnum, TVertexEnum, TSubject>
        where TKey : struct, IEquatable<TKey>
        where TGraphEnum : struct, IConvertible
        where TVertexEnum : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>, new()
    {
        TGraphEnum Graph { get; }

        TSubject InitializeSubject();
        TSubject InitializeSubject(TSubject subject, TVertexEnum initialVertexEnum);
        TSubject InitializeSubject(TVertexEnum initialVertexEnum);
        TSubject StepSubject(TSubject subject, TKey edgeId);
        TSubject StepSubject(TSubject subject, TVertexEnum targetVertexEnum);
    }
}