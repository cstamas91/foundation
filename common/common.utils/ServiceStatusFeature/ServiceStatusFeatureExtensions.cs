﻿using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace common.utils.ServiceStatusFeature
{
    internal static class ServiceStatusFeatureExtensions
    {
        public static IServiceCollection AddServiceStatusFeature(this IServiceCollection services)
        {
            var partManager = services.AddMvcCore()
                .PartManager;

            var serviceStatusSources = partManager.ApplicationParts
                .OfType<IApplicationPartTypeProvider>()
                .SelectMany(p => p.Types.Where(t => t.ImplementedInterfaces.Contains(typeof(IServiceStatusSource))));
            foreach (var source in serviceStatusSources)
                services.AddScoped(typeof(IServiceStatusSource), source);

            partManager
                .FeatureProviders
                .Add(new ServiceStatusControllerFeatureProvider());

            return services;
        }
    }
}
