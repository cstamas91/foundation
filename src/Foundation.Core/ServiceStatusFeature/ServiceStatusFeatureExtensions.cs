using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Foundation.Core.ServiceStatusFeature
{
    internal static class ServiceStatusFeatureExtensions
    {
        public static IServiceCollection AddServiceStatusFeature(this IServiceCollection services)
        {
            var partManager = services.AddMvcCore()
                .PartManager;

            bool ImplementationSelector(TypeInfo t) => 
                t.ImplementedInterfaces.Contains(typeof(IServiceStatusSource));

            var serviceStatusSources = partManager.ApplicationParts
                .OfType<IApplicationPartTypeProvider>()
                .SelectMany(p => p.Types.Where(ImplementationSelector));
            
            foreach (var source in serviceStatusSources)
                services.AddScoped(typeof(IServiceStatusSource), source);

            partManager
                .FeatureProviders
                .Add(new ServiceStatusControllerFeatureProvider());

            return services;
        }
    }
}
