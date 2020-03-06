using System.Reflection;

namespace CST.Common.Utils.Razor.Abstraction
{
    public interface IComponentSource
    {
        Assembly Assembly { get; }
    }
}
