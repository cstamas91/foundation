using System;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.Common.Utils.StateMachineFeature.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace CST.Common.Utils.StateMachineFeature
{
    public static class StateMachineFeatureExtensions
    {
        public static IServiceCollection AddStateMachineFeature(
            this IServiceCollection services,
            Action<StateMachineFeatureBuilder> buildAction)
        {
            var builder = new StateMachineFeatureBuilder(services);
            buildAction(builder);
            return services;
        }
    }
}