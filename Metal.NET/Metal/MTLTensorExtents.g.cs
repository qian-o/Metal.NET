using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTensorExtents_Selectors
{
    internal static readonly Selector extentAtDimensionIndex_ = Selector.Register("extentAtDimensionIndex:");
}

public class MTLTensorExtents : IDisposable
{
    public nint NativePtr { get; }

    public MTLTensorExtents(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTensorExtents o) => o.NativePtr;
    public static implicit operator MTLTensorExtents(nint ptr) => new MTLTensorExtents(ptr);

    ~MTLTensorExtents() => Release();

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

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        var __r = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTensorExtents_Selectors.extentAtDimensionIndex_, (nint)dimensionIndex);
        return __r;
    }

}
