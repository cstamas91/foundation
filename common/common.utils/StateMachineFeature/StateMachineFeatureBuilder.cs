using System;
using System.Collections.Generic;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.Common.Utils.StateMachineFeature.ViewModel;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;

namespace CST.Common.Utils.StateMachineFeature
{
    public class StateMachineFeatureBuilder
    {
        private readonly IList<IApplicationFeatureProvider> _featureProviders;
        private readonly IServiceCollection _services;

        public StateMachineFeatureBuilder(IServiceCollection services)
        {
            _featureProviders = services.AddMvcCore().PartManager.FeatureProviders;
            _services = services;
        }

        public StateMachineFeatureBuilder<T> WithKeyType<T>()
            where T : struct, IEquatable<T>
        {
            return new StateMachineFeatureBuilder<T>(_featureProviders, _services);
        }
    }

    public class StateMachineFeatureBuilder<T1>
        where T1 : struct, IEquatable<T1>
    {
        private readonly IList<IApplicationFeatureProvider> _featureProviders;
        private readonly IServiceCollection _services;

        public StateMachineFeatureBuilder(
            IList<IApplicationFeatureProvider> featureProviders,
            IServiceCollection services)
        {
            _featureProviders = featureProviders;
            _services = services;
        }

        public StateMachineFeatureBuilder<T1, T> WithGraphEnumType<T>()
            where T : struct, IConvertible
        {
            return new StateMachineFeatureBuilder<T1, T>(_featureProviders, _services);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
    {
        private readonly IList<IApplicationFeatureProvider> _featureProviders;
        private readonly IServiceCollection _services;

        public StateMachineFeatureBuilder(
            IList<IApplicationFeatureProvider> featureProviders,
            IServiceCollection services)
        {
            _featureProviders = featureProviders;
            _services = services;
        }

        public StateMachineFeatureBuilder<T1, T2, T> WithVertexEnumType<T>()
            where T : struct, IConvertible
        {
            return new StateMachineFeatureBuilder<T1, T2, T>(_featureProviders, _services);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2, T3>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
        where T3 : struct, IConvertible
    {
        private readonly IList<IApplicationFeatureProvider> _featureProviders;
        private readonly IServiceCollection _services;

        public StateMachineFeatureBuilder(
            IList<IApplicationFeatureProvider> featureProviders,
            IServiceCollection services)
        {
            _featureProviders = featureProviders;
            _services = services;
        }

        public StateMachineFeatureBuilder<T1, T2, T3, T> WithSubjectType<T>()
            where T : StateMachineSubject<T1, T2, T3, T>, new()
        {
            return new StateMachineFeatureBuilder<T1, T2, T3, T>(_featureProviders, _services);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2, T3, T4>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
        where T3 : struct, IConvertible
        where T4 : StateMachineSubject<T1, T2, T3, T4>, new()
    {
        private readonly IList<IApplicationFeatureProvider> _featureProviders;
        private readonly IServiceCollection _services;

        public StateMachineFeatureBuilder(
            IList<IApplicationFeatureProvider> featureProviders,
            IServiceCollection services)
        {
            _featureProviders = featureProviders;
            _services = services;
        }

        public StateMachineFeatureBuilder<T1, T2, T3, T4, T> WithRepositoryType<T>()
            where T : BaseStateMachineRepository<T1, T2, T3, T4>
        {
            return new StateMachineFeatureBuilder<T1, T2, T3, T4, T>(_featureProviders, _services);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2, T3, T4, T5>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
        where T3 : struct, IConvertible
        where T4 : StateMachineSubject<T1, T2, T3, T4>, new()
        where T5 : BaseStateMachineRepository<T1, T2, T3, T4>
    {
        private readonly IList<IApplicationFeatureProvider> _featureProviders;
        private readonly IServiceCollection _services;

        public StateMachineFeatureBuilder(
            IList<IApplicationFeatureProvider> featureProviders,
            IServiceCollection services)
        {
            _featureProviders = featureProviders;
            _services = services;
        }

        public StateMachineFeatureBuilder<T1, T2, T3, T4, T5, T> WithStateMachineService<T>()
            where T : BaseStateMachineService<T1, T2, T3, T4, T5>
        {
            return new StateMachineFeatureBuilder<T1, T2, T3, T4, T5, T>(_featureProviders, _services);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2, T3, T4, T5, T6>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
        where T3 : struct, IConvertible
        where T4 : StateMachineSubject<T1, T2, T3, T4>, new()
        where T5 : BaseStateMachineRepository<T1, T2, T3, T4>
        where T6 : BaseStateMachineService<T1, T2, T3, T4, T5>
    {
        private readonly IList<IApplicationFeatureProvider> _featureProviders;
        private readonly IServiceCollection _services;

        public StateMachineFeatureBuilder(
            IList<IApplicationFeatureProvider> featureProviders,
            IServiceCollection services)
        {
            _featureProviders = featureProviders;
            _services = services;
        }

        public void Build()
        {
            AddFeatureProvider();
            AddStateMachineRepository();
            AddStateMachineMetaService();
            AddStateMachineService();
        }

        private void AddFeatureProvider()
        {
            _featureProviders.Add(new StateMachineFeatureProvider<T1>());
        }

        private void AddStateMachineRepository()
        {
            _services.AddScoped<T5>();
            _services.AddScoped<BaseStateMachineRepository<T1, T2, T3, T4>>((svc) => svc.GetService<T5>());
        }

        private void AddStateMachineMetaService()
        {
            _services.AddScoped<IStateMachineMetaService<T1>, StateMachineMetaService<T1, T2, T3, T5, T4>>();
        }

        private void AddStateMachineService()
        {
            _services.AddScoped<T6>();
            _services.AddScoped<BaseStateMachineService<T1, T2, T3, T4, T5>>(
                serviceProvider => serviceProvider.GetRequiredService<T6>());
        }
    }
}