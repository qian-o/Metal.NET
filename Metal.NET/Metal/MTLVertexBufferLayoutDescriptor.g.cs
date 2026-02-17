using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLVertexBufferLayoutDescriptor_Selectors
{
    internal static readonly Selector setStepFunction_ = Selector.Register("setStepFunction:");
    internal static readonly Selector setStepRate_ = Selector.Register("setStepRate:");
    internal static readonly Selector setStride_ = Selector.Register("setStride:");
}

public class MTLVertexBufferLayoutDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLVertexBufferLayoutDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLVertexBufferLayoutDescriptor o) => o.NativePtr;
    public static implicit operator MTLVertexBufferLayoutDescriptor(nint ptr) => new MTLVertexBufferLayoutDescriptor(ptr);

    ~MTLVertexBufferLayoutDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVertexBufferLayoutDescriptor");

    public static MTLVertexBufferLayoutDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLVertexBufferLayoutDescriptor(ptr);
    }

    public void SetStepFunction(MTLVertexStepFunction stepFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptor_Selectors.setStepFunction_, (nint)(uint)stepFunction);
    }

    public void SetStepRate(nuint stepRate)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptor_Selectors.setStepRate_, (nint)stepRate);
    }

    public void SetStride(nuint stride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptor_Selectors.setStride_, (nint)stride);
    }

}
