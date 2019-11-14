using CST.Common.Utils.ServiceStatusFeature;
using Microsoft.Extensions.DependencyInjection;

namespace CST.Common.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceStatusServices(this IServiceCollection services) =>
            services.AddServiceStatusFeature();
    }
}
