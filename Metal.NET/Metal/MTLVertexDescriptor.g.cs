using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLVertexDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector vertexDescriptor = Selector.Register("vertexDescriptor");
}

public class MTLVertexDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLVertexDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLVertexDescriptor o) => o.NativePtr;
    public static implicit operator MTLVertexDescriptor(nint ptr) => new MTLVertexDescriptor(ptr);

    ~MTLVertexDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVertexDescriptor");

    public static MTLVertexDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLVertexDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexDescriptor_Selectors.reset);
    }

    public static MTLVertexDescriptor VertexDescriptor()
    {
        var __r = new MTLVertexDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLVertexDescriptor_Selectors.vertexDescriptor));
        return __r;
    }

}
