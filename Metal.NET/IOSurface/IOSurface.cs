using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps an IOSurface object.
/// </summary>
public partial class IOSurface : IDisposable
{
    private nint _handle;
    private bool _ownsHandle;

    private IOSurface(nint handle, bool ownsHandle)
    {
        _handle = handle;
        _ownsHandle = ownsHandle;
    }

    /// <summary>
    /// Gets the native IOSurfaceRef pointer.
    /// </summary>
    public nint NativePtr => _handle;

    /// <summary>
    /// Gets a value indicating whether this surface is null.
    /// </summary>
    public bool IsNull => _handle == 0;

    /// <summary>
    /// Creates a new IOSurface with the specified properties.
    /// </summary>
    /// <param name="properties">A CFDictionaryRef describing the IOSurface properties.</param>
    public static IOSurface Create(nint properties)
    {
        nint handle = IOSurfaceCreate_Native(properties);
        return new(handle, ownsHandle: true);
    }

    /// <summary>
    /// Gets the width of the IOSurface in pixels.
    /// </summary>
    public nuint Width => IOSurfaceGetWidth_Native(_handle);

    /// <summary>
    /// Gets the height of the IOSurface in pixels.
    /// </summary>
    public nuint Height => IOSurfaceGetHeight_Native(_handle);

    /// <summary>
    /// Gets the bytes per row of the IOSurface.
    /// </summary>
    public nuint BytesPerRow => IOSurfaceGetBytesPerRow_Native(_handle);

    /// <summary>
    /// Increments the use count of the IOSurface.
    /// </summary>
    public void IncrementUseCount() => IOSurfaceIncrementUseCount_Native(_handle);

    /// <summary>
    /// Decrements the use count of the IOSurface.
    /// </summary>
    public void DecrementUseCount() => IOSurfaceDecrementUseCount_Native(_handle);

    /// <summary>
    /// Creates an IOSurface wrapper from a native handle.
    /// </summary>
    public static IOSurface FromNativePtr(nint handle, bool ownsHandle) => new(handle, ownsHandle);

    public void Dispose()
    {
        if (_ownsHandle && _handle != 0)
        {
            CFRelease_Native(_handle);
            _handle = 0;
        }
        GC.SuppressFinalize(this);
    }

    ~IOSurface()
    {
        if (_ownsHandle && _handle != 0)
        {
            CFRelease_Native(_handle);
        }
    }

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceCreate")]
    private static partial nint IOSurfaceCreate_Native(nint properties);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetWidth")]
    private static partial nuint IOSurfaceGetWidth_Native(nint surface);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetHeight")]
    private static partial nuint IOSurfaceGetHeight_Native(nint surface);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceGetBytesPerRow")]
    private static partial nuint IOSurfaceGetBytesPerRow_Native(nint surface);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceIncrementUseCount")]
    private static partial void IOSurfaceIncrementUseCount_Native(nint surface);

    [LibraryImport("/System/Library/Frameworks/IOSurface.framework/IOSurface", EntryPoint = "IOSurfaceDecrementUseCount")]
    private static partial void IOSurfaceDecrementUseCount_Native(nint surface);

    [LibraryImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation", EntryPoint = "CFRelease")]
    private static partial void CFRelease_Native(nint cf);
}
