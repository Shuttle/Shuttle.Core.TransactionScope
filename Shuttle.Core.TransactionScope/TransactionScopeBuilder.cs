using System;
using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;

namespace Shuttle.Core.TransactionScope;

public class TransactionScopeBuilder
{
    private TransactionScopeOptions _transactionScopeOptions = new();

    public TransactionScopeBuilder(IServiceCollection services)
    {
        Services = Guard.AgainstNull(services);
    }

    public TransactionScopeOptions Options
    {
        get => _transactionScopeOptions;
        set => _transactionScopeOptions = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IServiceCollection Services { get; }
}