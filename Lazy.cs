using System.Diagnostics.Contracts;
using System.Threading;

namespace System;

internal static class LazyHelper<T>
{
	public static T GetDefault() => default!;
	public static readonly Lazy<T> Default = Lazy.Create(GetDefault);
}

public static class Lazy
{
	public static Lazy<T> Create<T>(Func<T> factory, LazyThreadSafetyMode mode = LazyThreadSafetyMode.ExecutionAndPublication)
	{
		if (factory == null)
			throw new ArgumentNullException(nameof(factory));
		Contract.EndContractBlock();

		return new Lazy<T>(factory, mode);
	}

	public static Lazy<T> Default<T>() => LazyHelper<T>.Default;
}
