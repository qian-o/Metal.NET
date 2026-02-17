using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4RenderPipelineDynamicLinkingDescriptor_Selectors
{
}

public class MTL4RenderPipelineDynamicLinkingDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4RenderPipelineDynamicLinkingDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4RenderPipelineDynamicLinkingDescriptor o) => o.NativePtr;
    public static implicit operator MTL4RenderPipelineDynamicLinkingDescriptor(nint ptr) => new MTL4RenderPipelineDynamicLinkingDescriptor(ptr);

    ~MTL4RenderPipelineDynamicLinkingDescriptor() => Release();

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

}
