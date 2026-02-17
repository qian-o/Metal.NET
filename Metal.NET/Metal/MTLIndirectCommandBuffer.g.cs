using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIndirectCommandBuffer_Selectors
{
    internal static readonly Selector indirectComputeCommand_ = Selector.Register("indirectComputeCommand:");
    internal static readonly Selector indirectRenderCommand_ = Selector.Register("indirectRenderCommand:");
}

public class MTLIndirectCommandBuffer : IDisposable
{
    public nint NativePtr { get; }

    public MTLIndirectCommandBuffer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIndirectCommandBuffer o) => o.NativePtr;
    public static implicit operator MTLIndirectCommandBuffer(nint ptr) => new MTLIndirectCommandBuffer(ptr);

    ~MTLIndirectCommandBuffer() => Release();

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

    public MTLIndirectComputeCommand IndirectComputeCommand(nuint commandIndex)
    {
        var __r = new MTLIndirectComputeCommand(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIndirectCommandBuffer_Selectors.indirectComputeCommand_, (nint)commandIndex));
        return __r;
    }

    public MTLIndirectRenderCommand IndirectRenderCommand(nuint commandIndex)
    {
        var __r = new MTLIndirectRenderCommand(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIndirectCommandBuffer_Selectors.indirectRenderCommand_, (nint)commandIndex));
        return __r;
    }

}
