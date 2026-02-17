using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRasterizationRateSampleArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_index_ = Selector.Register("setObject:index:");
}

public class MTLRasterizationRateSampleArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLRasterizationRateSampleArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRasterizationRateSampleArray o) => o.NativePtr;
    public static implicit operator MTLRasterizationRateSampleArray(nint ptr) => new MTLRasterizationRateSampleArray(ptr);

    ~MTLRasterizationRateSampleArray() => Release();

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

    public nint Object(nuint index)
    {
        var __r = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRasterizationRateSampleArray_Selectors.object_, (nint)index);
        return __r;
    }

    public void SetObject(nint value, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateSampleArray_Selectors.setObject_index_, value, (nint)index);
    }

}
