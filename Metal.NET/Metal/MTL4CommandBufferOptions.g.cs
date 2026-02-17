using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommandBufferOptions_Selectors
{
    internal static readonly Selector setLogState_ = Selector.Register("setLogState:");
}

public class MTL4CommandBufferOptions : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CommandBufferOptions(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommandBufferOptions o) => o.NativePtr;
    public static implicit operator MTL4CommandBufferOptions(nint ptr) => new MTL4CommandBufferOptions(ptr);

    ~MTL4CommandBufferOptions() => Release();

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

    public void SetLogState(MTLLogState logState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferOptions_Selectors.setLogState_, logState.NativePtr);
    }

}
