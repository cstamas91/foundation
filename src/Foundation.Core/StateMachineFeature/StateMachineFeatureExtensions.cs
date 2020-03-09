using System;
using Foundation.Core.StateMachineFeature.FeatureBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Core.StateMachineFeature
{
    public static class StateMachineFeatureExtensions
    {
        public static IStateMachineFeatureBuilder AddStateMachineFeature(this IServiceCollection services)
        {
            return new StateMachineFeatureBuilder(services);
        }
    }
}