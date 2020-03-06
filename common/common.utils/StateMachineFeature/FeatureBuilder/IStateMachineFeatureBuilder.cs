using System;
using CST.Common.Utils.StateMachineFeature.Abstraction;
using CST.Common.Utils.StateMachineFeature.Services;

namespace CST.Common.Utils.StateMachineFeature.FeatureBuilder
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