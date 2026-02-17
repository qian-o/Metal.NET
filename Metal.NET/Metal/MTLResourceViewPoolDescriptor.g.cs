using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResourceViewPoolDescriptor_Selectors
{
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setResourceViewCount_ = Selector.Register("setResourceViewCount:");
}

public class MTLResourceViewPoolDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLResourceViewPoolDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResourceViewPoolDescriptor o) => o.NativePtr;
    public static implicit operator MTLResourceViewPoolDescriptor(nint ptr) => new MTLResourceViewPoolDescriptor(ptr);

    ~MTLResourceViewPoolDescriptor() => Release();

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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceViewPoolDescriptor_Selectors.setLabel_, label.NativePtr);
    }

    public void SetResourceViewCount(nuint resourceViewCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceViewPoolDescriptor_Selectors.setResourceViewCount_, (nint)resourceViewCount);
    }

}
