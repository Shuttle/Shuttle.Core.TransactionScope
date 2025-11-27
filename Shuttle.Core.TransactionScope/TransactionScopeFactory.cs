using System.Transactions;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Core.TransactionScope;

public class TransactionScopeFactory(IOptions<TransactionScopeOptions> options) : ITransactionScopeFactory
{
    private readonly TransactionScopeOptions _options = Guard.AgainstNull(Guard.AgainstNull(options).Value);

    public ITransactionScope Create()
    {
        return Create(_options.IsolationLevel, _options.Timeout);
    }

    public ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout)
    {
        return _options.Enabled
            ? new DefaultTransactionScope(isolationLevel, timeout)
            : new NullTransactionScope();
    }
}