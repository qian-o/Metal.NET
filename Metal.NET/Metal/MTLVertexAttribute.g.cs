using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLVertexAttribute_Selectors
{
}

public class MTLVertexAttribute : IDisposable
{
    public nint NativePtr { get; }

    public MTLVertexAttribute(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLVertexAttribute o) => o.NativePtr;
    public static implicit operator MTLVertexAttribute(nint ptr) => new MTLVertexAttribute(ptr);

    ~MTLVertexAttribute() => Release();

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
