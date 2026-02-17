using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCaptureScope_Selectors
{
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector beginScope = Selector.Register("beginScope");
    internal static readonly Selector endScope = Selector.Register("endScope");
}

public class MTLCaptureScope : IDisposable
{
    public nint NativePtr { get; }

    public MTLCaptureScope(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCaptureScope o) => o.NativePtr;
    public static implicit operator MTLCaptureScope(nint ptr) => new MTLCaptureScope(ptr);

    ~MTLCaptureScope() => Release();

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

    public void SetLabel(NSString pLabel)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureScope_Selectors.setLabel_, pLabel.NativePtr);
    }

    public void BeginScope()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureScope_Selectors.beginScope);
    }

    public void EndScope()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureScope_Selectors.endScope);
    }

}
