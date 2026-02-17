using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLSamplerState_Selectors
{
}

public class MTLSamplerState : IDisposable
{
    public nint NativePtr { get; }

    public MTLSamplerState(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLSamplerState o) => o.NativePtr;
    public static implicit operator MTLSamplerState(nint ptr) => new MTLSamplerState(ptr);

    ~MTLSamplerState() => Release();

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
