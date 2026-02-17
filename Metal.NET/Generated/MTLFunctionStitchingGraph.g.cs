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

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFunctionStitchingGraph
{
    public readonly nint NativePtr;

    public MTLFunctionStitchingGraph(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionStitchingGraph o) => o.NativePtr;
    public static implicit operator MTLFunctionStitchingGraph(nint ptr) => new MTLFunctionStitchingGraph(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingGraph");

    public static MTLFunctionStitchingGraph Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLFunctionStitchingGraph(ptr);
    }

    public MTLFunctionStitchingGraph Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLFunctionStitchingGraph(ptr);
    }

    public static MTLFunctionStitchingGraph New()
    {
        return Alloc().Init();
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

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
