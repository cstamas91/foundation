using System;

namespace CST.Common.Utils.Common
{
    public class Maybe<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public Exception Exception { get; set; }

        public static Maybe<T> FromSuccess(T result)
        {
            return new Maybe<T>
            {
                Success = true,
                Result = result,
                Exception = null
            };
        }

        public static Maybe<T> FromException(Exception e)
        {
            return new Maybe<T>
            {
                Success = false,
                Exception = e,
                Result = default
            };
        }
    }
}