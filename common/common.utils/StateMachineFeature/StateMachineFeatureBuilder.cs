using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.Common.Utils.StateMachineFeature.ViewModel;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;

namespace CST.Common.Utils.StateMachineFeature
{
    public class StateMachineFeatureBuilder
    {
        protected readonly IMvcCoreBuilder MvcCoreBuilder;
        protected readonly IServiceCollection Services;

        public StateMachineFeatureBuilder(IServiceCollection services)
        {
            MvcCoreBuilder = services.AddMvcCore();
            Services = services;
        }

        public StateMachineFeatureBuilder<T> WithKeyType<T>()
            where T : struct, IEquatable<T>
        {
            return new StateMachineFeatureBuilder<T>(Services);
        }
    }

    public class StateMachineFeatureBuilder<T1> : StateMachineFeatureBuilder
        where T1 : struct, IEquatable<T1>
    {
        public StateMachineFeatureBuilder(IServiceCollection services) : base(services)
        {
        }

        public StateMachineFeatureBuilder<T1, T> WithGraphEnumType<T>()
            where T : struct, IConvertible
        {
            return new StateMachineFeatureBuilder<T1, T>(Services);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2> : StateMachineFeatureBuilder<T1>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
    {
        public StateMachineFeatureBuilder(IServiceCollection services) : base(services)
        {
        }

        public StateMachineFeatureBuilder<T1, T2, T> WithVertexEnumType<T>()
            where T : struct, IConvertible
        {
            return new StateMachineFeatureBuilder<T1, T2, T>(Services);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2, T3> : StateMachineFeatureBuilder<T1, T2>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
        where T3 : struct, IConvertible
    {
        public StateMachineFeatureBuilder(IServiceCollection services) : base(services)
        {
        }

        public StateMachineFeatureBuilder<T1, T2, T3, T> WithSubjectType<T>(string controllerName)
            where T : StateMachineSubject<T1, T2, T3, T>, new()
        {
            return new StateMachineFeatureBuilder<T1, T2, T3, T>(Services, controllerName);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2, T3, T4> : StateMachineFeatureBuilder<T1, T2, T3>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
        where T3 : struct, IConvertible
        where T4 : StateMachineSubject<T1, T2, T3, T4>, new()
    {
        protected readonly string SubjectControllerName;
        public StateMachineFeatureBuilder(IServiceCollection services, string subjectControllerName) : base(services)
        {
            SubjectControllerName = subjectControllerName;
        }

        public StateMachineFeatureBuilder<T1, T2, T3, T4, T> WithRepositoryType<T>()
            where T : BaseStateMachineRepository<T1, T2, T3, T4>
        {
            return new StateMachineFeatureBuilder<T1, T2, T3, T4, T>(Services, SubjectControllerName);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2, T3, T4, T5> : StateMachineFeatureBuilder<T1, T2, T3, T4>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
        where T3 : struct, IConvertible
        where T4 : StateMachineSubject<T1, T2, T3, T4>, new()
        where T5 : BaseStateMachineRepository<T1, T2, T3, T4>
    {
        public StateMachineFeatureBuilder(IServiceCollection services, string subjectControllerName) : base(services, subjectControllerName)
        {
        }

        public StateMachineFeatureBuilder<T1, T2, T3, T4, T5, T> WithStateMachineService<T>()
            where T : BaseStateMachineService<T1, T2, T3, T4, T5>
        {
            return new StateMachineFeatureBuilder<T1, T2, T3, T4, T5, T>(Services, SubjectControllerName);
        }
    }

    public class StateMachineFeatureBuilder<T1, T2, T3, T4, T5, T6> : StateMachineFeatureBuilder<T1, T2, T3, T4, T5>
        where T1 : struct, IEquatable<T1>
        where T2 : struct, IConvertible
        where T3 : struct, IConvertible
        where T4 : StateMachineSubject<T1, T2, T3, T4>, new()
        where T5 : BaseStateMachineRepository<T1, T2, T3, T4>
        where T6 : BaseStateMachineService<T1, T2, T3, T4, T5>
    {
        public StateMachineFeatureBuilder(IServiceCollection services, string subjectControllerName) : base(services, subjectControllerName)
        {
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
            MvcCoreBuilder.PartManager.FeatureProviders.Add(new StateMachineFeatureProvider<T1, T4>());
        }

        private void AddStateMachineRepository()
        {
            Services.AddScoped<T5>();
            Services.AddScoped<BaseStateMachineRepository<T1, T2, T3, T4>>((svc) => svc.GetService<T5>());
        }

        private void AddStateMachineMetaService()
        {
            Services.AddScoped<IStateMachineMetaService<T1>, StateMachineMetaService<T1, T2, T3, T5, T4>>();
            MvcCoreBuilder.AddMvcOptions(o =>
                {
                    o.Conventions.Add(new StateMachineControllerNameConvention<T1, T4>(SubjectControllerName));
                });
        }

        private void AddStateMachineService()
        {
            Services.AddScoped<T6>();
            Services.AddScoped<BaseStateMachineService<T1, T2, T3, T4, T5>>(
                serviceProvider => serviceProvider.GetRequiredService<T6>());
        }
    }
}