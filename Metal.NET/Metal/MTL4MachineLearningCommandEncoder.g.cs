using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4MachineLearningCommandEncoder_Selectors
{
    internal static readonly Selector dispatchNetwork_ = Selector.Register("dispatchNetwork:");
    internal static readonly Selector setArgumentTable_ = Selector.Register("setArgumentTable:");
    internal static readonly Selector setPipelineState_ = Selector.Register("setPipelineState:");
}

public class MTL4MachineLearningCommandEncoder : IDisposable
{
    public nint NativePtr { get; }

    public MTL4MachineLearningCommandEncoder(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4MachineLearningCommandEncoder o) => o.NativePtr;
    public static implicit operator MTL4MachineLearningCommandEncoder(nint ptr) => new MTL4MachineLearningCommandEncoder(ptr);

    ~MTL4MachineLearningCommandEncoder() => Release();

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

    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningCommandEncoder_Selectors.dispatchNetwork_, heap.NativePtr);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningCommandEncoder_Selectors.setArgumentTable_, argumentTable.NativePtr);
    }

    public void SetPipelineState(MTL4MachineLearningPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningCommandEncoder_Selectors.setPipelineState_, pipelineState.NativePtr);
    }

}
