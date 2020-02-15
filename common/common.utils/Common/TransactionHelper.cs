using System;
using System.Transactions;
using Microsoft.Extensions.Logging;

namespace CST.Common.Utils.Common
{
    public static class TransactionHelper
    {
        public static Maybe<TOut> WithTransactionScope<TIn1, TIn2, TOut>(
            Func<TIn1, TIn2, TOut> f, 
            TIn1 param1, 
            TIn2 param2,
            ILogger logger = null)
        {
            try
            {
                using var tran = new TransactionScope();
                var result = f(param1, param2);
                tran.Complete();
                return Maybe<TOut>.FromSuccess(result);
            }
            catch (Exception e)
            {
                logger?.LogError(e, string.Empty);
                return Maybe<TOut>.FromException(e);
            }
        }

    }
}