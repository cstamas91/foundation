using System;
using Foundation.StateMachineFeature.Abstraction;
using Foundation.StateMachineFeature.Services;
using Foundation.StateMachineFeature.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.StateMachineFeature.FeatureBuilder
{
    internal class StateMachineFeatureBuilder : IStateMachineFeatureBuilder
    {
        private readonly IMvcCoreBuilder _mvcCoreBuilder;
        private readonly IServiceCollection _services;

        public StateMachineFeatureBuilder(IServiceCollection services)
        {
            _mvcCoreBuilder = services.AddMvcCore();
            _services = services;
        }

        public IStateMachineFeatureBuilder<TKey, TVertexEnum, TGraphEnum, TSubject> 
            WithTypes<TKey, TVertexEnum, TGraphEnum, TSubject>()
            where TKey : struct, IEquatable<TKey>
            where TVertexEnum : struct, IConvertible
            where TGraphEnum : struct, IConvertible
            where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>, new()
        {
            _mvcCoreBuilder.PartManager
                .FeatureProviders
                .Add(new StateMachineFeatureProvider<TKey, TSubject>());

            return new StateMachineFeatureBuilder1<TKey, TVertexEnum, TGraphEnum, TSubject>(_mvcCoreBuilder, _services);
        }

        private class StateMachineFeatureBuilder1<TKey, TVertexEnum, TGraphEnum, TSubject> :
            IStateMachineFeatureBuilder<TKey, TVertexEnum, TGraphEnum, TSubject>
            where TKey : struct, IEquatable<TKey>
            where TVertexEnum : struct, IConvertible
            where TGraphEnum : struct, IConvertible
            where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>, new()
        {
            private readonly IMvcCoreBuilder _mvcCoreBuilder;
            private readonly IServiceCollection _services;
            public StateMachineFeatureBuilder1(IMvcCoreBuilder mvcCoreBuilder, IServiceCollection services)
            {
                _mvcCoreBuilder = mvcCoreBuilder;
                _services = services;
            }

            public IStateMachineFeatureBuilder<TKey, TVertexEnum, TGraphEnum, TSubject, TRepository> 
                WithRepository<TRepository>()
                where TRepository : BaseStateMachineRepository<TKey, TGraphEnum, TVertexEnum, TSubject>
            {
                _services.AddScoped<TRepository>();
                _services.AddScoped<BaseStateMachineRepository<TKey, TGraphEnum, TVertexEnum, TSubject>>(
                    (svc) => svc.GetService<TRepository>());

                return new StateMachineFeatureBuilder2<TKey, TVertexEnum, TGraphEnum, TSubject, TRepository>(
                    _mvcCoreBuilder, _services);
            }

            private class StateMachineFeatureBuilder2<TK, TVe, TGe, TS, TR> :
                IStateMachineFeatureBuilder<TK, TVe, TGe, TS, TR>
                where TK : struct, IEquatable<TK>
                where TVe : struct, IConvertible
                where TGe : struct, IConvertible
                where TS : StateMachineSubject<TK, TGe, TVe, TS>, new()
                where TR : BaseStateMachineRepository<TK, TGe, TVe, TS>
            {
                public StateMachineFeatureBuilder2(IMvcCoreBuilder mvcCoreBuilder, IServiceCollection services)
                {
                    MvcCoreBuilder = mvcCoreBuilder;
                    Services = services;
                }

                private IMvcCoreBuilder MvcCoreBuilder { get; }
                private IServiceCollection Services { get; }

                public void WithService<TService>(FeatureOptions options)
                    where TService : BaseStateMachineService<TK, TGe, TVe, TS, TR>
                {
                    Services.AddScoped<TService>();
                    Services.AddScoped<BaseStateMachineService<TK, TGe, TVe, TS, TR>, TService>();
                    Services.AddScoped<IStateMachineMetaService<TK>>(
                        serviceProvider => serviceProvider.GetRequiredService<TService>());
                    MvcCoreBuilder.AddMvcOptions(o =>
                    {
                        o.Conventions.Add(
                            new StateMachineControllerNameConvention<TK, TS>(options.SubjectControllerName));
                    });
                }
            }
        }
    }
}