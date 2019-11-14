using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CST.Common.Utils.ServiceStatusFeature
{
    [ApiController, Route("api/[controller]")]
    internal class ServiceStatusController : ControllerBase
    {
        private readonly IEnumerable<IServiceStatusSource> serviceStatusSources;

        public ServiceStatusController(IEnumerable<IServiceStatusSource> serviceStatusSources)
        {
            this.serviceStatusSources = serviceStatusSources;
        }

        [HttpGet]
        public string Get()
        {
            static string aggregator(string state, IServiceStatusSource current)
            {
                return string.Join(Environment.NewLine, state, current.GetStatus());
            }

            return serviceStatusSources.Aggregate(string.Empty, aggregator);
        }
    }
}
