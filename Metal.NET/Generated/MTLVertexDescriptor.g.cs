using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLVertexDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector vertexDescriptor = Selector.Register("vertexDescriptor");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLVertexDescriptor
{
    public readonly nint NativePtr;

    public MTLVertexDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLVertexDescriptor o) => o.NativePtr;
    public static implicit operator MTLVertexDescriptor(nint ptr) => new MTLVertexDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVertexDescriptor");

    public static MTLVertexDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLVertexDescriptor(ptr);
    }

    public MTLVertexDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLVertexDescriptor(ptr);
    }

    public static MTLVertexDescriptor New()
    {
        return Alloc().Init();
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexDescriptor_Selectors.reset);
    }

    public static MTLVertexDescriptor VertexDescriptor()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLVertexDescriptor_Selectors.vertexDescriptor);
        return new MTLVertexDescriptor(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
