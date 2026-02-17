using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4TileRenderPipelineDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setMaxTotalThreadsPerThreadgroup_ = Selector.Register("setMaxTotalThreadsPerThreadgroup:");
    internal static readonly Selector setRasterSampleCount_ = Selector.Register("setRasterSampleCount:");
    internal static readonly Selector setRequiredThreadsPerThreadgroup_ = Selector.Register("setRequiredThreadsPerThreadgroup:");
    internal static readonly Selector setStaticLinkingDescriptor_ = Selector.Register("setStaticLinkingDescriptor:");
    internal static readonly Selector setSupportBinaryLinking_ = Selector.Register("setSupportBinaryLinking:");
    internal static readonly Selector setThreadgroupSizeMatchesTileSize_ = Selector.Register("setThreadgroupSizeMatchesTileSize:");
    internal static readonly Selector setTileFunctionDescriptor_ = Selector.Register("setTileFunctionDescriptor:");
}

public class MTL4TileRenderPipelineDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4TileRenderPipelineDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4TileRenderPipelineDescriptor o) => o.NativePtr;
    public static implicit operator MTL4TileRenderPipelineDescriptor(nint ptr) => new MTL4TileRenderPipelineDescriptor(ptr);

    ~MTL4TileRenderPipelineDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4TileRenderPipelineDescriptor");

    public static MTL4TileRenderPipelineDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTL4TileRenderPipelineDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptor_Selectors.reset);
    }

    public void SetMaxTotalThreadsPerThreadgroup(nuint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptor_Selectors.setMaxTotalThreadsPerThreadgroup_, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetRasterSampleCount(nuint rasterSampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptor_Selectors.setRasterSampleCount_, (nint)rasterSampleCount);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptor_Selectors.setRequiredThreadsPerThreadgroup_, requiredThreadsPerThreadgroup);
    }

    public void SetStaticLinkingDescriptor(MTL4StaticLinkingDescriptor staticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptor_Selectors.setStaticLinkingDescriptor_, staticLinkingDescriptor.NativePtr);
    }

    public void SetSupportBinaryLinking(Bool8 supportBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptor_Selectors.setSupportBinaryLinking_, (nint)supportBinaryLinking.Value);
    }

    public void SetThreadgroupSizeMatchesTileSize(Bool8 threadgroupSizeMatchesTileSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptor_Selectors.setThreadgroupSizeMatchesTileSize_, (nint)threadgroupSizeMatchesTileSize.Value);
    }

    public void SetTileFunctionDescriptor(MTL4FunctionDescriptor tileFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4TileRenderPipelineDescriptor_Selectors.setTileFunctionDescriptor_, tileFunctionDescriptor.NativePtr);
    }

}
