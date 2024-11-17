using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lazy<T> FromValue<T>(T value)
#if NETSTANDARD2_1
		=> new(value);
#else
		=> new(() => value);
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lazy<T> Create<T>(Func<T> factory, LazyThreadSafetyMode mode = LazyThreadSafetyMode.ExecutionAndPublication)
		=> new (factory, mode);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lazy<T> Default<T>() => LazyHelper<T>.Default;
}
