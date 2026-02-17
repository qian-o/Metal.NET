using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLVertexBufferLayoutDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_index_ = Selector.Register("setObject:index:");
}

public class MTLVertexBufferLayoutDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLVertexBufferLayoutDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLVertexBufferLayoutDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLVertexBufferLayoutDescriptorArray(nint ptr) => new MTLVertexBufferLayoutDescriptorArray(ptr);

    ~MTLVertexBufferLayoutDescriptorArray() => Release();

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

    public MTLVertexBufferLayoutDescriptor Object(nuint index)
    {
        var __r = new MTLVertexBufferLayoutDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptorArray_Selectors.object_, (nint)index));
        return __r;
    }

    public void SetObject(MTLVertexBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptorArray_Selectors.setObject_index_, bufferDesc.NativePtr, (nint)index);
    }

}
