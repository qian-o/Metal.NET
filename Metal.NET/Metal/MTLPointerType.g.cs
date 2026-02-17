using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPointerType_Selectors
{
}

public class MTLPointerType : IDisposable
{
    public nint NativePtr { get; }

    public MTLPointerType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPointerType o) => o.NativePtr;
    public static implicit operator MTLPointerType(nint ptr) => new MTLPointerType(ptr);

    ~MTLPointerType() => Release();

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
