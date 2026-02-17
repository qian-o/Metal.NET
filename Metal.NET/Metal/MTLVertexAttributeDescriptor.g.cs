using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLVertexAttributeDescriptor_Selectors
{
    internal static readonly Selector setBufferIndex_ = Selector.Register("setBufferIndex:");
    internal static readonly Selector setFormat_ = Selector.Register("setFormat:");
    internal static readonly Selector setOffset_ = Selector.Register("setOffset:");
}

public class MTLVertexAttributeDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLVertexAttributeDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLVertexAttributeDescriptor o) => o.NativePtr;
    public static implicit operator MTLVertexAttributeDescriptor(nint ptr) => new MTLVertexAttributeDescriptor(ptr);

    ~MTLVertexAttributeDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptor");

    public static MTLVertexAttributeDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLVertexAttributeDescriptor(ptr);
    }

    public void SetBufferIndex(nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptor_Selectors.setBufferIndex_, (nint)bufferIndex);
    }

    public void SetFormat(MTLVertexFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptor_Selectors.setFormat_, (nint)(uint)format);
    }

    public void SetOffset(nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptor_Selectors.setOffset_, (nint)offset);
    }

}
