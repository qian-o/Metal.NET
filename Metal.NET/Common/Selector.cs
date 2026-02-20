using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// A cached Objective-C selector (SEL).
/// Supports implicit conversion from <see cref="string"/> for convenient initialization.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct Selector(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator Selector(string name)
    {
        return ObjectiveCRuntime.RegisterName(name);
    }
}
