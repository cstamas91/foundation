using System;
using CST.Common.Utils.StateMachineFeature.FeatureBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace CST.Common.Utils.StateMachineFeature
{
    public static class StateMachineFeatureExtensions
    {
        public static IStateMachineFeatureBuilder AddStateMachineFeature(this IServiceCollection services)
        {
            return new StateMachineFeatureBuilder(services);
        }
    }
}