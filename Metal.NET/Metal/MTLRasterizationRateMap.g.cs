using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRasterizationRateMap_Selectors
{
    internal static readonly Selector copyParameterDataToBuffer_offset_ = Selector.Register("copyParameterDataToBuffer:offset:");
    internal static readonly Selector physicalSize_ = Selector.Register("physicalSize:");
}

public class MTLRasterizationRateMap : IDisposable
{
    public nint NativePtr { get; }

    public MTLRasterizationRateMap(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRasterizationRateMap o) => o.NativePtr;
    public static implicit operator MTLRasterizationRateMap(nint ptr) => new MTLRasterizationRateMap(ptr);

    ~MTLRasterizationRateMap() => Release();

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

    public void CopyParameterDataToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMap_Selectors.copyParameterDataToBuffer_offset_, buffer.NativePtr, (nint)offset);
    }

}
