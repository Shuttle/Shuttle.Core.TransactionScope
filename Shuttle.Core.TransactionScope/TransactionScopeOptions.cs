using System;
using System.Transactions;

namespace Shuttle.Core.TransactionScope;

public class TransactionScopeOptions
{
    public const string SectionName = "Shuttle:TransactionScope";

    public bool Enabled { get; set; } = true;
    public IsolationLevel IsolationLevel { get; set; } = IsolationLevel.ReadCommitted;
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}