using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shuttle.Core.Contract;

namespace Shuttle.Core.TransactionScope;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddTransactionScope(Action<TransactionScopeBuilder>? builder = null)
        {
            Guard.AgainstNull(services);

            services.AddOptions<TransactionScopeOptions>();

            var transactionScopeBuilder = new TransactionScopeBuilder(services);

            builder?.Invoke(transactionScopeBuilder);

            if (services.Contains(ServiceDescriptor.Singleton<ITransactionScopeFactory, TransactionScopeFactory>()))
            {
                throw new InvalidOperationException(Resources.AddTransactionScopeFactoryException);
            }

            services.TryAddSingleton<ITransactionScopeFactory, TransactionScopeFactory>();

            return services;
        }
    }
}