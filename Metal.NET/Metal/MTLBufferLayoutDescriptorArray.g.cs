using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBufferLayoutDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_index_ = Selector.Register("setObject:index:");
}

public class MTLBufferLayoutDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLBufferLayoutDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBufferLayoutDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLBufferLayoutDescriptorArray(nint ptr) => new MTLBufferLayoutDescriptorArray(ptr);

    ~MTLBufferLayoutDescriptorArray() => Release();

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

    public MTLBufferLayoutDescriptor Object(nuint index)
    {
        var __r = new MTLBufferLayoutDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBufferLayoutDescriptorArray_Selectors.object_, (nint)index));
        return __r;
    }

    public void SetObject(MTLBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferLayoutDescriptorArray_Selectors.setObject_index_, bufferDesc.NativePtr, (nint)index);
    }

}
