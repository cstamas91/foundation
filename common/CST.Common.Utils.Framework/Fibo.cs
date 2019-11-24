using System;

namespace CST.Common.Utils.Framework
{
    public class Fibo
    {
        private readonly FiboCache fiboCache;

        public Fibo(FiboCache fiboCache)
        {
            this.fiboCache = fiboCache;
        }

        public int GetNthNumber(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            var (found, val) = fiboCache.TryGetValue(n);
            if (found)
            {
                return val;
            }

            val = GetNthNumber(n - 1) + GetNthNumber(n - 2);
            fiboCache.Store(n, val);

            return val;
        }
    }
}
