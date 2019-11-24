using System.Collections.Generic;

namespace CST.Common.Utils.Framework
{
    public class FiboCache
    {
        private readonly Dictionary<int, int> values;
        public FiboCache()
        {
            values = new Dictionary<int, int>();
        }

        public (bool found, int val) TryGetValue(int n)
        {
            if (values.ContainsKey(n))
            {
                return (true, values[n]);
            }

            return (false, default(int));
        }

        public void Store(int n, int val)
        {
            values.Add(n, val);
        }
    }
}
