using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPipelineBufferDescriptor_Selectors
{
    internal static readonly Selector setMutability_ = Selector.Register("setMutability:");
}

public class MTLPipelineBufferDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLPipelineBufferDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPipelineBufferDescriptor o) => o.NativePtr;
    public static implicit operator MTLPipelineBufferDescriptor(nint ptr) => new MTLPipelineBufferDescriptor(ptr);

    ~MTLPipelineBufferDescriptor() => Release();

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

    public void SetMutability(MTLMutability mutability)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPipelineBufferDescriptor_Selectors.setMutability_, (nint)(uint)mutability);
    }

}
