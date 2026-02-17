using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionStitchingAttributeAlwaysInline_Selectors
{
}

public class MTLFunctionStitchingAttributeAlwaysInline : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionStitchingAttributeAlwaysInline(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionStitchingAttributeAlwaysInline o) => o.NativePtr;
    public static implicit operator MTLFunctionStitchingAttributeAlwaysInline(nint ptr) => new MTLFunctionStitchingAttributeAlwaysInline(ptr);

    ~MTLFunctionStitchingAttributeAlwaysInline() => Release();

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
