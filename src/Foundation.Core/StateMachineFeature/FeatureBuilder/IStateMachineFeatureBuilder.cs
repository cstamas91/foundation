using System;
using Foundation.Core.StateMachineFeature.Abstraction;
using Foundation.Core.StateMachineFeature.Services;

namespace Foundation.Core.StateMachineFeature.FeatureBuilder
{
    public interface IStateMachineFeatureBuilder<TKey, TVE, TGE, TSubject, TRepository>
        where TKey : struct, IEquatable<TKey>
        where TVE : struct, IConvertible
        where TGE : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGE, TVE, TSubject>, new()
        where TRepository : BaseStateMachineRepository<TKey, TGE, TVE, TSubject>
    {
        void WithService<TService>(FeatureOptions options)
            where TService : BaseStateMachineService<TKey, TGE, TVE, TSubject, TRepository>;
    }

    public interface IStateMachineFeatureBuilder<TKey, TVE, TGE, TSubject>
        where TKey : struct, IEquatable<TKey>
        where TVE : struct, IConvertible
        where TGE : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGE, TVE, TSubject>, new()
    {
        IStateMachineFeatureBuilder<TKey, TVE, TGE, TSubject, TRepository> WithRepository<TRepository>()
            where TRepository : BaseStateMachineRepository<TKey, TGE, TVE, TSubject>;
    }

    public interface IStateMachineFeatureBuilder
    {
        IStateMachineFeatureBuilder<TKey, TVE, TGE, TSubject> WithTypes<TKey, TVE, TGE, TSubject>()
            where TKey : struct, IEquatable<TKey>
            where TVE : struct, IConvertible
            where TGE : struct, IConvertible
            where TSubject : StateMachineSubject<TKey, TGE, TVE, TSubject>, new();
    }
}