using System.Reflection;
using System.Runtime.InteropServices;

#if NETSTANDARD
[assembly: AssemblyTitle(".NET Standard")]
#endif

#if NET6_0_OR_GREATER
[assembly: AssemblyTitle(".NET 6.0 (or greater)")]
#endif

[assembly: AssemblyVersion("11.1.0.0")]
[assembly: AssemblyCopyright("Copyright (c) 2024, Eben Roux")]
[assembly: AssemblyProduct("Shuttle.Core.TransactionScope")]
[assembly: AssemblyCompany("Eben Roux")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyInformationalVersion("11.1.0")]
[assembly: ComVisible(false)]