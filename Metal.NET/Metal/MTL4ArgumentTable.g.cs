using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4ArgumentTable_Selectors
{
    internal static readonly Selector setAddress_bindingIndex_ = Selector.Register("setAddress:bindingIndex:");
    internal static readonly Selector setAddress_stride_bindingIndex_ = Selector.Register("setAddress:stride:bindingIndex:");
}

public class MTL4ArgumentTable : IDisposable
{
    public nint NativePtr { get; }

    public MTL4ArgumentTable(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4ArgumentTable o) => o.NativePtr;
    public static implicit operator MTL4ArgumentTable(nint ptr) => new MTL4ArgumentTable(ptr);

    ~MTL4ArgumentTable() => Release();

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

    public void SetAddress(nuint gpuAddress, nuint bindingIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTable_Selectors.setAddress_bindingIndex_, (nint)gpuAddress, (nint)bindingIndex);
    }

    public void SetAddress(nuint gpuAddress, nuint stride, nuint bindingIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ArgumentTable_Selectors.setAddress_stride_bindingIndex_, (nint)gpuAddress, (nint)stride, (nint)bindingIndex);
    }

}
