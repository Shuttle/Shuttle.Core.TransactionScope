using System;
using System.Transactions;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Core.TransactionScope
{
    public class TransactionScopeFactory : ITransactionScopeFactory
    {
        private readonly TransactionScopeOptions _options;

        public TransactionScopeFactory(IOptions<TransactionScopeOptions> options)
        {
            Guard.AgainstNull(options, nameof(options));
            
            _options = options.Value;
        }

        public ITransactionScope Create()
        {
            return Create(_options.IsolationLevel, _options.Timeout);
        }

        public ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout)
        {
            return _options.Enabled
                ? (ITransactionScope)new DefaultTransactionScope(isolationLevel, timeout)
                : new NullTransactionScope();
        }
    }
}