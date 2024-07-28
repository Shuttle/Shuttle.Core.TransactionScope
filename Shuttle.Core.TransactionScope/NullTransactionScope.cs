using System;

namespace Shuttle.Core.TransactionScope
{
    public class NullTransactionScope : ITransactionScope
    {
        public Guid Id => Guid.Empty;

        public void Complete()
        {
        }

        public void Dispose()
        {
        }
    }
}