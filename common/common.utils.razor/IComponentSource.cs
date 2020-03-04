using System.Reflection;

namespace CST.Common.Utils.Razor
{
    public interface IComponentSource
    {
        Assembly Assembly { get; }
    }
}
