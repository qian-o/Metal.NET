using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLVertexAttributeDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_index_ = Selector.Register("setObject:index:");
}

public class MTLVertexAttributeDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLVertexAttributeDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLVertexAttributeDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLVertexAttributeDescriptorArray(nint ptr) => new MTLVertexAttributeDescriptorArray(ptr);

    ~MTLVertexAttributeDescriptorArray() => Release();

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

    public MTLVertexAttributeDescriptor Object(nuint index)
    {
        var __r = new MTLVertexAttributeDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLVertexAttributeDescriptorArray_Selectors.object_, (nint)index));
        return __r;
    }

    public void SetObject(MTLVertexAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptorArray_Selectors.setObject_index_, attributeDesc.NativePtr, (nint)index);
    }

}
