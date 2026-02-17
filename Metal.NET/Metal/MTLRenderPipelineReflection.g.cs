using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRenderPipelineReflection_Selectors
{
}

public class MTLRenderPipelineReflection : IDisposable
{
    public nint NativePtr { get; }

    public MTLRenderPipelineReflection(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRenderPipelineReflection o) => o.NativePtr;
    public static implicit operator MTLRenderPipelineReflection(nint ptr) => new MTLRenderPipelineReflection(ptr);

    ~MTLRenderPipelineReflection() => Release();

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
