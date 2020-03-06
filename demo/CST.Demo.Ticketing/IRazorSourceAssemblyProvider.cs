using CST.Common.Utils.Razor.Abstraction;
using System.Reflection;

namespace CST.Demo.Ticketing
{
    public class TicketingRazorAssemblyProvider : IComponentSource
    {
        public Assembly Assembly => typeof(TicketingRazorAssemblyProvider).Assembly;
    }
}
