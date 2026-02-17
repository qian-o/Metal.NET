using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4BinaryFunction_Selectors
{
}

public class MTL4BinaryFunction : IDisposable
{
    public nint NativePtr { get; }

    public MTL4BinaryFunction(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4BinaryFunction o) => o.NativePtr;
    public static implicit operator MTL4BinaryFunction(nint ptr) => new MTL4BinaryFunction(ptr);

    ~MTL4BinaryFunction() => Release();

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
