using common.utils.ServiceStatusFeature;
using Microsoft.Extensions.DependencyInjection;

namespace common.utils
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceStatusServices(this IServiceCollection services) =>
            services.AddServiceStatusFeature();
    }
}
