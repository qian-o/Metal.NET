using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Lightweight value-type wrapper for an Objective-C native pointer.
/// No reference counting or IDisposable overhead.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct NativeObject(nint nativePtr)
{
    /// <summary>
    /// The underlying Objective-C pointer.
    /// </summary>
    public readonly nint NativePtr = nativePtr;
}
