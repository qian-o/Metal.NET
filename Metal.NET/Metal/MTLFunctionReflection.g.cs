using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionReflection_Selectors
{
}

public class MTLFunctionReflection : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionReflection(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionReflection o) => o.NativePtr;
    public static implicit operator MTLFunctionReflection(nint ptr) => new MTLFunctionReflection(ptr);

    ~MTLFunctionReflection() => Release();

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
