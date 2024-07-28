using System;
using System.Transactions;

namespace Shuttle.Core.TransactionScope
{
    public class DefaultTransactionScope : ITransactionScope
    {
        private readonly bool _ignore;

        private readonly System.Transactions.TransactionScope _scope;

        public DefaultTransactionScope(IsolationLevel isolationLevel, TimeSpan timeout)
        {
            Id = Guid.NewGuid();

            _ignore = Transaction.Current != null;

            _scope = new System.Transactions.TransactionScope(TransactionScopeOption.RequiresNew,
                new TransactionOptions
                {
                    IsolationLevel = isolationLevel,
                    Timeout = timeout
                },
                TransactionScopeAsyncFlowOption.Enabled);
        }

        public void Dispose()
        {
            try
            {
                _scope?.Dispose();
            }
            catch
            {
                // _ignore --- may be a bug in TransactionScope
            }
        }

        public Guid Id { get; }

        public void Complete()
        {
            if (_ignore)
            {
                return;
            }

            _scope?.Complete();
        }
    }
}