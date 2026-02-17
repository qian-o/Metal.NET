using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSArray pointer.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct NSArray
{
    public readonly IntPtr NativePtr;

    public NSArray(IntPtr ptr) => NativePtr = ptr;

    public static implicit operator IntPtr(NSArray a) => a.NativePtr;

    public bool IsNull => NativePtr == IntPtr.Zero;

    private static readonly Selector s_count = Selector.Register("count");
    private static readonly Selector s_objectAtIndex = Selector.Register("objectAtIndex:");

    public UIntPtr count => ObjectiveCRuntime.UIntPtr_objc_msgSend(NativePtr, s_count);

    public IntPtr objectAtIndex(UIntPtr index)
        => ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, s_objectAtIndex, (IntPtr)index);
}
