using System;
using System.Transactions;

namespace Shuttle.Core.TransactionScope;

public interface ITransactionScopeFactory
{
    ITransactionScope Create();
    ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout);
}