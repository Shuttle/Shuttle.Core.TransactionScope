﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Core.TransactionScope;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTransactionScope(this IServiceCollection services, Action<TransactionScopeBuilder>? builder = null)
    {
        Guard.AgainstNull(services);

        var transactionScopeBuilder = new TransactionScopeBuilder(services);

        builder?.Invoke(transactionScopeBuilder);

        services.AddOptions<TransactionScopeOptions>().Configure(options =>
        {
            options.IsolationLevel = transactionScopeBuilder.Options.IsolationLevel;
            options.Timeout = transactionScopeBuilder.Options.Timeout;
            options.Enabled = transactionScopeBuilder.Options.Enabled;
        });

        if (services.Contains(ServiceDescriptor.Singleton<ITransactionScopeFactory, TransactionScopeFactory>()))
        {
            throw new InvalidOperationException(Resources.AddTransactionScopeFactoryException);
        }

        services.AddSingleton<ITransactionScopeFactory, TransactionScopeFactory>();

        return services;
    }
}