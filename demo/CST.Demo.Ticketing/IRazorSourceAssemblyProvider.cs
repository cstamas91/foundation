using CST.Common.Utils.Razor;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CST.Demo.Ticketing
{
    public class TicketingRazorAssemblyProvider : IComponentSource
    {
        public Assembly Assembly => typeof(TicketingRazorAssemblyProvider).Assembly;
    }
}
