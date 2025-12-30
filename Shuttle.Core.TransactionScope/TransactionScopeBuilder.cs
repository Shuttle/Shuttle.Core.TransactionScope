using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;

namespace Shuttle.Core.TransactionScope;

public class TransactionScopeBuilder(IServiceCollection services)
{
    public TransactionScopeBuilder Configure(Action<TransactionScopeOptions> configure)
    {
        Services.Configure(configure);
        return this;
    }

    public IServiceCollection Services { get; } = Guard.AgainstNull(services);
}