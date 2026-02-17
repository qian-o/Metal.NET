using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAttributeDescriptor_Selectors
{
    internal static readonly Selector setBufferIndex_ = Selector.Register("setBufferIndex:");
    internal static readonly Selector setFormat_ = Selector.Register("setFormat:");
    internal static readonly Selector setOffset_ = Selector.Register("setOffset:");
}

public class MTLAttributeDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLAttributeDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAttributeDescriptor o) => o.NativePtr;
    public static implicit operator MTLAttributeDescriptor(nint ptr) => new MTLAttributeDescriptor(ptr);

    ~MTLAttributeDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptor");

    public static MTLAttributeDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLAttributeDescriptor(ptr);
    }

    public void SetBufferIndex(nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAttributeDescriptor_Selectors.setBufferIndex_, (nint)bufferIndex);
    }

    public void SetFormat(MTLAttributeFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAttributeDescriptor_Selectors.setFormat_, (nint)(uint)format);
    }

    public void SetOffset(nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAttributeDescriptor_Selectors.setOffset_, (nint)offset);
    }

}
