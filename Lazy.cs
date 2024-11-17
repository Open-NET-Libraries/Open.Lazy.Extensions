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

/// <summary>
/// Factory for creating instances of <see cref="Lazy{T}"/>.
/// </summary>
public static class Lazy
{
    /// <summary>
    /// Creates a new instance of <see cref="Lazy{T}"/> with the specified value.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lazy<T> FromValue<T>(T value)
#if NETSTANDARD2_1
		=> new(value);
#else
		=> new(() => value);
#endif

    /// <remarks>
    /// Alias for <see cref="FromValue{T}(T)"/>.
    /// </remarks>
    /// <inheritdoc cref="FromValue{T}(T)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lazy<T> Create<T>(T value) => FromValue(value);

    /// <summary>
    /// Creates a new instance of <see cref="Lazy{T}"/> with the specified factory and thread safety mode.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lazy<T> Create<T>(Func<T> factory, LazyThreadSafetyMode mode = LazyThreadSafetyMode.ExecutionAndPublication)
		=> new (factory, mode);

    /// <summary>
    /// Returns a shared instance where the value is <see langword="default"/> of <typeparamref name="T"/>.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Lazy<T> Default<T>() => LazyHelper<T>.Default;
}
