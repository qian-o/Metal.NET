using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionStitchingFunctionNode_Selectors
{
    internal static readonly Selector setArguments_ = Selector.Register("setArguments:");
    internal static readonly Selector setControlDependencies_ = Selector.Register("setControlDependencies:");
    internal static readonly Selector setName_ = Selector.Register("setName:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFunctionStitchingFunctionNode
{
    public readonly nint NativePtr;

    public MTLFunctionStitchingFunctionNode(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionStitchingFunctionNode o) => o.NativePtr;
    public static implicit operator MTLFunctionStitchingFunctionNode(nint ptr) => new MTLFunctionStitchingFunctionNode(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingFunctionNode");

    public static MTLFunctionStitchingFunctionNode Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLFunctionStitchingFunctionNode(ptr);
    }

    public MTLFunctionStitchingFunctionNode Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLFunctionStitchingFunctionNode(ptr);
    }

    public static MTLFunctionStitchingFunctionNode New()
    {
        return Alloc().Init();
    }

    public void SetArguments(NSArray arguments)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingFunctionNode_Selectors.setArguments_, arguments.NativePtr);
    }

    public void SetControlDependencies(NSArray controlDependencies)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingFunctionNode_Selectors.setControlDependencies_, controlDependencies.NativePtr);
    }

    public void SetName(NSString name)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingFunctionNode_Selectors.setName_, name.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
