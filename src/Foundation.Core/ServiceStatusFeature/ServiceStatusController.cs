using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Foundation.Core.ServiceStatusFeature
{
    [ApiController, Route("api/[controller]")]
    internal class ServiceStatusController : ControllerBase
    {
        private readonly IEnumerable<IServiceStatusSource> _serviceStatusSources;

        public ServiceStatusController(IEnumerable<IServiceStatusSource> serviceStatusSources)
        {
            this._serviceStatusSources = serviceStatusSources;
        }

        [HttpGet]
        public string Get()
        {
            string Aggregator(string state, IServiceStatusSource current)
            {
                return string.Join(Environment.NewLine, state, current.GetStatus());
            }

            return _serviceStatusSources.Aggregate(string.Empty, Aggregator);
        }
    }
}
