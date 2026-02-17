using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTileRenderPipelineDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setBinaryArchives_ = Selector.Register("setBinaryArchives:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setLinkedFunctions_ = Selector.Register("setLinkedFunctions:");
    internal static readonly Selector setMaxCallStackDepth_ = Selector.Register("setMaxCallStackDepth:");
    internal static readonly Selector setMaxTotalThreadsPerThreadgroup_ = Selector.Register("setMaxTotalThreadsPerThreadgroup:");
    internal static readonly Selector setPreloadedLibraries_ = Selector.Register("setPreloadedLibraries:");
    internal static readonly Selector setRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    internal static readonly Selector setRequiredThreadsPerThreadgroup_ = Selector.Register("setRequiredThreadsPerThreadgroup:");
    internal static readonly Selector setShaderValidation_ = Selector.Register("setShaderValidation:");
    internal static readonly Selector setSupportAddingBinaryFunctions_ = Selector.Register("setSupportAddingBinaryFunctions:");
    internal static readonly Selector setThreadgroupSizeMatchesTileSize_ = Selector.Register("setThreadgroupSizeMatchesTileSize:");
    internal static readonly Selector setTileFunction_ = Selector.Register("setTileFunction:");
}

public class MTLTileRenderPipelineDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLTileRenderPipelineDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTileRenderPipelineDescriptor o) => o.NativePtr;
    public static implicit operator MTLTileRenderPipelineDescriptor(nint ptr) => new MTLTileRenderPipelineDescriptor(ptr);

    ~MTLTileRenderPipelineDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTileRenderPipelineDescriptor");

    public static MTLTileRenderPipelineDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLTileRenderPipelineDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.reset);
    }

    public void SetBinaryArchives(NSArray binaryArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setBinaryArchives_, binaryArchives.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setLabel_, label.NativePtr);
    }

    public void SetLinkedFunctions(MTLLinkedFunctions linkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setLinkedFunctions_, linkedFunctions.NativePtr);
    }

    public void SetMaxCallStackDepth(nuint maxCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setMaxCallStackDepth_, (nint)maxCallStackDepth);
    }

    public void SetMaxTotalThreadsPerThreadgroup(nuint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setMaxTotalThreadsPerThreadgroup_, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetPreloadedLibraries(NSArray preloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setPreloadedLibraries_, preloadedLibraries.NativePtr);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setRequiredThreadsPerThreadgroup_, requiredThreadsPerThreadgroup);
    }

    public void SetShaderValidation(MTLShaderValidation shaderValidation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setShaderValidation_, (nint)(uint)shaderValidation);
    }

    public void SetSupportAddingBinaryFunctions(Bool8 supportAddingBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setSupportAddingBinaryFunctions_, (nint)supportAddingBinaryFunctions.Value);
    }

    public void SetThreadgroupSizeMatchesTileSize(Bool8 threadgroupSizeMatchesTileSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setThreadgroupSizeMatchesTileSize_, (nint)threadgroupSizeMatchesTileSize.Value);
    }

    public void SetTileFunction(MTLFunction tileFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTileRenderPipelineDescriptor_Selectors.setTileFunction_, tileFunction.NativePtr);
    }

}
