using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResidencySetDescriptor_Selectors
{
    internal static readonly Selector setInitialCapacity_ = Selector.Register("setInitialCapacity:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLResidencySetDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLResidencySetDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResidencySetDescriptor o) => o.NativePtr;
    public static implicit operator MTLResidencySetDescriptor(nint ptr) => new MTLResidencySetDescriptor(ptr);

    ~MTLResidencySetDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLResidencySetDescriptor");

    public static MTLResidencySetDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLResidencySetDescriptor(ptr);
    }

    public void SetInitialCapacity(nuint initialCapacity)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetDescriptor_Selectors.setInitialCapacity_, (nint)initialCapacity);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetDescriptor_Selectors.setLabel_, label.NativePtr);
    }

}
