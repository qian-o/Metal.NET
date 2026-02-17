using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAttributeDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_index_ = Selector.Register("setObject:index:");
}

public class MTLAttributeDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLAttributeDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAttributeDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLAttributeDescriptorArray(nint ptr) => new MTLAttributeDescriptorArray(ptr);

    ~MTLAttributeDescriptorArray() => Release();

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

    public MTLAttributeDescriptor Object(nuint index)
    {
        var __r = new MTLAttributeDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLAttributeDescriptorArray_Selectors.object_, (nint)index));
        return __r;
    }

    public void SetObject(MTLAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAttributeDescriptorArray_Selectors.setObject_index_, attributeDesc.NativePtr, (nint)index);
    }

}
