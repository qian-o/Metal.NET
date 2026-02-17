using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLDepthStencilState_Selectors
{
}

public class MTLDepthStencilState : IDisposable
{
    public nint NativePtr { get; }

    public MTLDepthStencilState(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLDepthStencilState o) => o.NativePtr;
    public static implicit operator MTLDepthStencilState(nint ptr) => new MTLDepthStencilState(ptr);

    ~MTLDepthStencilState() => Release();

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

}
