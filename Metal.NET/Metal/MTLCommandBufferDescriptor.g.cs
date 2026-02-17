using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCommandBufferDescriptor_Selectors
{
    internal static readonly Selector setErrorOptions_ = Selector.Register("setErrorOptions:");
    internal static readonly Selector setLogState_ = Selector.Register("setLogState:");
    internal static readonly Selector setRetainedReferences_ = Selector.Register("setRetainedReferences:");
}

public class MTLCommandBufferDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLCommandBufferDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCommandBufferDescriptor o) => o.NativePtr;
    public static implicit operator MTLCommandBufferDescriptor(nint ptr) => new MTLCommandBufferDescriptor(ptr);

    ~MTLCommandBufferDescriptor() => Release();

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

    public void SetErrorOptions(nuint errorOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferDescriptor_Selectors.setErrorOptions_, (nint)errorOptions);
    }

    public void SetLogState(MTLLogState logState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferDescriptor_Selectors.setLogState_, logState.NativePtr);
    }

    public void SetRetainedReferences(Bool8 retainedReferences)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandBufferDescriptor_Selectors.setRetainedReferences_, (nint)retainedReferences.Value);
    }

}
