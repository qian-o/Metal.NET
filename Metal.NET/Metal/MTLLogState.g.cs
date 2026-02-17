using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLLogState_Selectors
{
    internal static readonly Selector addLogHandler_ = Selector.Register("addLogHandler:");
}

public class MTLLogState : IDisposable
{
    public nint NativePtr { get; }

    public MTLLogState(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLLogState o) => o.NativePtr;
    public static implicit operator MTLLogState(nint ptr) => new MTLLogState(ptr);

    ~MTLLogState() => Release();

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

    public void AddLogHandler(nint handler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogState_Selectors.addLogHandler_, handler);
    }

}
