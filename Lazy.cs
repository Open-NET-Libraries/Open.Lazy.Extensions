using System.Diagnostics.Contracts;
using System.Threading;

namespace System;

internal static class LazyHelper<T>
{
#if NETSTANDARD2_1
	public static readonly Lazy<T> Default = new(default(T)!);
#else

	public static readonly Lazy<T> Default = new(() => default!);
#endif
}

public static class Lazy
{
	public static Lazy<T> FromValue<T>(T value)
#if NETSTANDARD2_1
		=> new(value);
#else
		=> new(() => value);
#endif

	public static Lazy<T> Create<T>(Func<T> factory, LazyThreadSafetyMode mode = LazyThreadSafetyMode.ExecutionAndPublication)
	{
		if (factory == null)
			throw new ArgumentNullException(nameof(factory));
		Contract.EndContractBlock();

		return new Lazy<T>(factory, mode);
	}

	public static Lazy<T> Default<T>() => LazyHelper<T>.Default;
}
