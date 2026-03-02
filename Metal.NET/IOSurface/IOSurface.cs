using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Provides P/Invoke bindings for IOSurface functions.
/// </summary>
public static partial class IOSurface
{
    /// <summary>
    /// Creates a new IOSurface with the specified properties.
    /// </summary>
    /// <param name="properties">A CFDictionaryRef describing the IOSurface properties.</param>
    /// <returns>An IOSurfaceRef. The caller must call <see cref="Release"/> when done.</returns>
    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceCreate")]
    public static partial nint Create(nint properties);

    /// <summary>
    /// Gets the width of the IOSurface in pixels.
    /// </summary>
    /// <param name="surface">The IOSurfaceRef to query.</param>
    /// <returns>The width in pixels.</returns>
    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetWidth")]
    public static partial nuint GetWidth(nint surface);

    /// <summary>
    /// Gets the height of the IOSurface in pixels.
    /// </summary>
    /// <param name="surface">The IOSurfaceRef to query.</param>
    /// <returns>The height in pixels.</returns>
    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetHeight")]
    public static partial nuint GetHeight(nint surface);

    /// <summary>
    /// Gets the bytes per row of the IOSurface.
    /// </summary>
    /// <param name="surface">The IOSurfaceRef to query.</param>
    /// <returns>The number of bytes per row.</returns>
    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetBytesPerRow")]
    public static partial nuint GetBytesPerRow(nint surface);

    /// <summary>
    /// Increments the reference count of the IOSurface.
    /// </summary>
    /// <param name="surface">The IOSurfaceRef to retain.</param>
    /// <returns>The same IOSurfaceRef.</returns>
    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceIncrementUseCount")]
    public static partial void IncrementUseCount(nint surface);

    /// <summary>
    /// Decrements the reference count of the IOSurface.
    /// </summary>
    /// <param name="surface">The IOSurfaceRef to release.</param>
    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceDecrementUseCount")]
    public static partial void DecrementUseCount(nint surface);
}
