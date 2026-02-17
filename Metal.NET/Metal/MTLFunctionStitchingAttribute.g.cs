using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionStitchingAttribute_Selectors
{
}

public class MTLFunctionStitchingAttribute : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionStitchingAttribute(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionStitchingAttribute o) => o.NativePtr;
    public static implicit operator MTLFunctionStitchingAttribute(nint ptr) => new MTLFunctionStitchingAttribute(ptr);

    ~MTLFunctionStitchingAttribute() => Release();

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
