using System;
using Foundation.StateMachineFeature.Abstraction;
using Foundation.StateMachineFeature.Services;

namespace Foundation.StateMachineFeature.FeatureBuilder
{
    public interface IStateMachineFeatureBuilder<TKey, TVe, TGe, TSubject, TRepository>
        where TKey : struct, IEquatable<TKey>
        where TVe : struct, IConvertible
        where TGe : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGe, TVe, TSubject>, new()
        where TRepository : BaseStateMachineRepository<TKey, TGe, TVe, TSubject>
    {
        void WithService<TService>(FeatureOptions options)
            where TService : BaseStateMachineService<TKey, TGe, TVe, TSubject, TRepository>;
    }

    public interface IStateMachineFeatureBuilder<TKey, TVe, TGe, TSubject>
        where TKey : struct, IEquatable<TKey>
        where TVe : struct, IConvertible
        where TGe : struct, IConvertible
        where TSubject : StateMachineSubject<TKey, TGe, TVe, TSubject>, new()
    {
        IStateMachineFeatureBuilder<TKey, TVe, TGe, TSubject, TRepository> WithRepository<TRepository>()
            where TRepository : BaseStateMachineRepository<TKey, TGe, TVe, TSubject>;
    }

    public interface IStateMachineFeatureBuilder
    {
        IStateMachineFeatureBuilder<TKey, TVe, TGe, TSubject> WithTypes<TKey, TVe, TGe, TSubject>()
            where TKey : struct, IEquatable<TKey>
            where TVe : struct, IConvertible
            where TGe : struct, IConvertible
            where TSubject : StateMachineSubject<TKey, TGe, TVe, TSubject>, new();
    }
}