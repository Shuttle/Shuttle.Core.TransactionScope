using System.Transactions;

namespace Shuttle.Core.TransactionScope;

public class DefaultTransactionScope(IsolationLevel isolationLevel, TimeSpan timeout) : ITransactionScope
{
    private readonly bool _ignore = Transaction.Current != null;

    private readonly System.Transactions.TransactionScope _scope = new(TransactionScopeOption.RequiresNew,
        new TransactionOptions
        {
            IsolationLevel = isolationLevel,
            Timeout = timeout
        },
        TransactionScopeAsyncFlowOption.Enabled);

    public void Dispose()
    {
        try
        {
            _scope.Dispose();
        }
        catch
        {
            // _ignore --- may be a bug in TransactionScope
        }
    }

    public Guid Id { get; } = Guid.NewGuid();

    public void Complete()
    {
        if (_ignore)
        {
            return;
        }

        _scope.Complete();
    }
}