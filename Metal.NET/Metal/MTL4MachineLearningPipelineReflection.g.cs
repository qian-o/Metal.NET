using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4MachineLearningPipelineReflection_Selectors
{
}

public class MTL4MachineLearningPipelineReflection : IDisposable
{
    public nint NativePtr { get; }

    public MTL4MachineLearningPipelineReflection(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4MachineLearningPipelineReflection o) => o.NativePtr;
    public static implicit operator MTL4MachineLearningPipelineReflection(nint ptr) => new MTL4MachineLearningPipelineReflection(ptr);

    ~MTL4MachineLearningPipelineReflection() => Release();

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
