using System;

namespace CST.Common.Utils.Framework
{
    public class Fibo
    {
        public int GetNthNumber(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            var val = GetNthNumber(n - 1) + GetNthNumber(n - 2);
            return val;
        }
    }
}
