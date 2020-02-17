using System;
using System.Transactions;
using Microsoft.Extensions.Logging;

namespace CST.Common.Utils.Common
{
    public static class TransactionHelper
    {
        public static void WithTransactionScope(Action f, ILogger logger = null)
        {
            try
            {
                using var tran = new TransactionScope();
                f();
                tran.Complete();
            }
            catch (Exception exception)
            {
                logger?.LogError(exception, string.Empty);
                throw;
            }
        }
    }
}