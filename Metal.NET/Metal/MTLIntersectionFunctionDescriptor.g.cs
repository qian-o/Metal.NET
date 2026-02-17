using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIntersectionFunctionDescriptor_Selectors
{
}

public class MTLIntersectionFunctionDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLIntersectionFunctionDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIntersectionFunctionDescriptor o) => o.NativePtr;
    public static implicit operator MTLIntersectionFunctionDescriptor(nint ptr) => new MTLIntersectionFunctionDescriptor(ptr);

    ~MTLIntersectionFunctionDescriptor() => Release();

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
