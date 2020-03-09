using System;
using System.Transactions;
using Microsoft.Extensions.Logging;

namespace Foundation.Core.Common
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