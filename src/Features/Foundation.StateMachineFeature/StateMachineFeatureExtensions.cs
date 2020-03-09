using Foundation.StateMachineFeature.FeatureBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.StateMachineFeature
{
    public static class StateMachineFeatureExtensions
    {
        public static IStateMachineFeatureBuilder AddStateMachineFeature(this IServiceCollection services)
        {
            return new StateMachineFeatureBuilder(services);
        }
    }
}