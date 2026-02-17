using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTensorBinding_Selectors
{
}

public class MTLTensorBinding : IDisposable
{
    public nint NativePtr { get; }

    public MTLTensorBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTensorBinding o) => o.NativePtr;
    public static implicit operator MTLTensorBinding(nint ptr) => new MTLTensorBinding(ptr);

    ~MTLTensorBinding() => Release();

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
