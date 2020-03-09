using System;
using Foundation.Core.StateMachineFeature.Abstraction;
using Foundation.Core.StateMachineFeature.Services;
using Foundation.Core.StateMachineFeature.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Core.StateMachineFeature.FeatureBuilder
{
    internal class StateMachineFeatureBuilder : IStateMachineFeatureBuilder
    {
        protected readonly IMvcCoreBuilder MvcCoreBuilder;
        protected readonly IServiceCollection Services;

        public StateMachineFeatureBuilder(IServiceCollection services)
        {
            MvcCoreBuilder = services.AddMvcCore();
            Services = services;
        }

        public IStateMachineFeatureBuilder<TKey, TVertexEnum, TGraphEnum, TSubject> WithTypes<TKey, TVertexEnum, TGraphEnum, TSubject>()
            where TKey : struct, IEquatable<TKey>
            where TVertexEnum : struct, IConvertible
            where TGraphEnum : struct, IConvertible
            where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>, new()
        {
            MvcCoreBuilder.PartManager
                .FeatureProviders
                .Add(new StateMachineFeatureProvider<TKey, TSubject>());

            return new StateMachineFeatureBuilder1<TKey, TVertexEnum, TGraphEnum, TSubject>(MvcCoreBuilder, Services);
        }

        class StateMachineFeatureBuilder1<TKey, TVertexEnum, TGraphEnum, TSubject> :
            IStateMachineFeatureBuilder<TKey, TVertexEnum, TGraphEnum, TSubject>
            where TKey : struct, IEquatable<TKey>
            where TVertexEnum : struct, IConvertible
            where TGraphEnum : struct, IConvertible
            where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>, new()
        {
            protected readonly IMvcCoreBuilder MvcCoreBuilder;
            protected readonly IServiceCollection Services;
            public StateMachineFeatureBuilder1(IMvcCoreBuilder mvcCoreBuilder, IServiceCollection services)
            {
                MvcCoreBuilder = mvcCoreBuilder;
                Services = services;
            }

            public IStateMachineFeatureBuilder<TKey, TVertexEnum, TGraphEnum, TSubject, TRepository> WithRepository<TRepository>()
                where TRepository : BaseStateMachineRepository<TKey, TGraphEnum, TVertexEnum, TSubject>
            {
                Services.AddScoped<TRepository>();
                Services.AddScoped<BaseStateMachineRepository<TKey, TGraphEnum, TVertexEnum, TSubject>>((svc) => svc.GetService<TRepository>());

                return new StateMachineFeatureBuilder2<TKey, TVertexEnum, TGraphEnum, TSubject, TRepository>(MvcCoreBuilder, Services);
            }

            class StateMachineFeatureBuilder2<TKey, TVertexEnum, TGraphEnum, TSubject, TRepository> :
                IStateMachineFeatureBuilder<TKey, TVertexEnum, TGraphEnum, TSubject, TRepository>
                where TKey : struct, IEquatable<TKey>
                where TVertexEnum : struct, IConvertible
                where TGraphEnum : struct, IConvertible
                where TSubject : StateMachineSubject<TKey, TGraphEnum, TVertexEnum, TSubject>, new()
                where TRepository : BaseStateMachineRepository<TKey, TGraphEnum, TVertexEnum, TSubject>
            {
                public StateMachineFeatureBuilder2(IMvcCoreBuilder mvcCoreBuilder, IServiceCollection services)
                {
                    MvcCoreBuilder = mvcCoreBuilder;
                    Services = services;
                }

                public IMvcCoreBuilder MvcCoreBuilder { get; }
                public IServiceCollection Services { get; }

                public void WithService<TService>(FeatureOptions options)
                    where TService : BaseStateMachineService<TKey, TGraphEnum, TVertexEnum, TSubject, TRepository>
                {
                    Services.AddScoped<TService>();
                    Services.AddScoped<BaseStateMachineService<TKey, TGraphEnum, TVertexEnum, TSubject, TRepository>, TService>();
                    Services.AddScoped<IStateMachineMetaService<TKey>>(serviceProvider => serviceProvider.GetRequiredService<TService>());
                    MvcCoreBuilder.AddMvcOptions(o =>
                    {
                        o.Conventions.Add(new StateMachineControllerNameConvention<TKey, TSubject>(options.SubjectControllerName));
                    });
                }
            }
        }
    }
}