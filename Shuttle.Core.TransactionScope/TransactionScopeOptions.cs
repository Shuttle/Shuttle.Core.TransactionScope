using System;
using System.Transactions;

namespace Shuttle.Core.TransactionScope
{
    public class TransactionScopeOptions
    {
        public const string SectionName = "Shuttle:TransactionScope";

        public TransactionScopeOptions()
        {
            Enabled = true;
            IsolationLevel = IsolationLevel.ReadCommitted;
            Timeout = TimeSpan.FromSeconds(30);
        }

        public bool Enabled { get; set; }
        public IsolationLevel IsolationLevel { get; set; }
        public TimeSpan Timeout { get; set; }
    }
}