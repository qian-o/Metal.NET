using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCommandBufferEncoderInfo_Selectors
{
}

public class MTLCommandBufferEncoderInfo : IDisposable
{
    public nint NativePtr { get; }

    public MTLCommandBufferEncoderInfo(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCommandBufferEncoderInfo o) => o.NativePtr;
    public static implicit operator MTLCommandBufferEncoderInfo(nint ptr) => new MTLCommandBufferEncoderInfo(ptr);

    ~MTLCommandBufferEncoderInfo() => Release();

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
