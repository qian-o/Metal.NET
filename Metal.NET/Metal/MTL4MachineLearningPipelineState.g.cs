using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4MachineLearningPipelineState_Selectors
{
}

public class MTL4MachineLearningPipelineState : IDisposable
{
    public nint NativePtr { get; }

    public MTL4MachineLearningPipelineState(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4MachineLearningPipelineState o) => o.NativePtr;
    public static implicit operator MTL4MachineLearningPipelineState(nint ptr) => new MTL4MachineLearningPipelineState(ptr);

    ~MTL4MachineLearningPipelineState() => Release();

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
