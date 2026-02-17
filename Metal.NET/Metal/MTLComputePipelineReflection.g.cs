using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLComputePipelineReflection_Selectors
{
}

public class MTLComputePipelineReflection : IDisposable
{
    public nint NativePtr { get; }

    public MTLComputePipelineReflection(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLComputePipelineReflection o) => o.NativePtr;
    public static implicit operator MTLComputePipelineReflection(nint ptr) => new MTLComputePipelineReflection(ptr);

    ~MTLComputePipelineReflection() => Release();

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
