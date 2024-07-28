using System;

namespace Shuttle.Core.TransactionScope
{
    public interface ITransactionScope : IDisposable
    {
        Guid Id { get; }
        void Complete();
    }
}