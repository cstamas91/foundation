using System;
using System.Collections.Generic;
using System.Text;

namespace common.utils.ServiceStatusFeature
{
    public interface IServiceStatusSource
    {
        public string GetStatus();
    }
}
