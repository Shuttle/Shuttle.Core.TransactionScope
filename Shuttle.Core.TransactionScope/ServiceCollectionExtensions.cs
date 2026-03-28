using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Shuttle.Core.TransactionScope;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddTransactionScope()
        {
            ArgumentNullException.ThrowIfNull(services);

            if (services.Contains(ServiceDescriptor.Singleton<ITransactionScopeFactory, TransactionScopeFactory>()))
            {
                throw new InvalidOperationException(Resources.AddTransactionScopeFactoryException);
            }

            services.TryAddSingleton<ITransactionScopeFactory, TransactionScopeFactory>();

            return services;
        }

        public IServiceCollection AddTransactionScope(Action<TransactionScopeOptions> configureOptions)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(configureOptions);

            services.AddTransactionScope();
            services.Configure(configureOptions);

            return services;
        }
    }
}