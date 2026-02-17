using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionConstant_Selectors
{
}

public class MTLFunctionConstant : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionConstant(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionConstant o) => o.NativePtr;
    public static implicit operator MTLFunctionConstant(nint ptr) => new MTLFunctionConstant(ptr);

    ~MTLFunctionConstant() => Release();

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
