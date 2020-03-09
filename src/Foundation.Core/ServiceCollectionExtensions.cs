using Foundation.Core.ServiceStatusFeature;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceStatusServices(this IServiceCollection services) =>
            services.AddServiceStatusFeature();
    }
}
