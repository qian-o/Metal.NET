using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTensorReferenceType_Selectors
{
}

public class MTLTensorReferenceType : IDisposable
{
    public nint NativePtr { get; }

    public MTLTensorReferenceType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTensorReferenceType o) => o.NativePtr;
    public static implicit operator MTLTensorReferenceType(nint ptr) => new MTLTensorReferenceType(ptr);

    ~MTLTensorReferenceType() => Release();

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
