using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommandAllocatorDescriptor_Selectors
{
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTL4CommandAllocatorDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CommandAllocatorDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommandAllocatorDescriptor o) => o.NativePtr;
    public static implicit operator MTL4CommandAllocatorDescriptor(nint ptr) => new MTL4CommandAllocatorDescriptor(ptr);

    ~MTL4CommandAllocatorDescriptor() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandAllocatorDescriptor_Selectors.setLabel_, label.NativePtr);
    }

}
