using System.Reflection;

namespace Foundation.Razor.Abstraction
{
    public interface IComponentSource
    {
        Assembly Assembly { get; }
    }
}
