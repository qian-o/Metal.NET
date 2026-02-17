using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionStitchingGraph_Selectors
{
    internal static readonly Selector setAttributes_ = Selector.Register("setAttributes:");
    internal static readonly Selector setFunctionName_ = Selector.Register("setFunctionName:");
    internal static readonly Selector setNodes_ = Selector.Register("setNodes:");
    internal static readonly Selector setOutputNode_ = Selector.Register("setOutputNode:");
}

public class MTLFunctionStitchingGraph : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionStitchingGraph(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionStitchingGraph o) => o.NativePtr;
    public static implicit operator MTLFunctionStitchingGraph(nint ptr) => new MTLFunctionStitchingGraph(ptr);

    ~MTLFunctionStitchingGraph() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingGraph");

    public static MTLFunctionStitchingGraph New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLFunctionStitchingGraph(ptr);
    }

    public void SetAttributes(NSArray attributes)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraph_Selectors.setAttributes_, attributes.NativePtr);
    }

    public void SetFunctionName(NSString functionName)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraph_Selectors.setFunctionName_, functionName.NativePtr);
    }

    public void SetNodes(NSArray nodes)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraph_Selectors.setNodes_, nodes.NativePtr);
    }

    public void SetOutputNode(MTLFunctionStitchingFunctionNode outputNode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingGraph_Selectors.setOutputNode_, outputNode.NativePtr);
    }

}
