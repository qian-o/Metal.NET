using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionStitchingInputNode_Selectors
{
    internal static readonly Selector setArgumentIndex_ = Selector.Register("setArgumentIndex:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFunctionStitchingInputNode
{
    public readonly nint NativePtr;

    public MTLFunctionStitchingInputNode(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionStitchingInputNode o) => o.NativePtr;
    public static implicit operator MTLFunctionStitchingInputNode(nint ptr) => new MTLFunctionStitchingInputNode(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingInputNode");

    public static MTLFunctionStitchingInputNode Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLFunctionStitchingInputNode(ptr);
    }

    public MTLFunctionStitchingInputNode Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLFunctionStitchingInputNode(ptr);
    }

    public static MTLFunctionStitchingInputNode New()
    {
        return Alloc().Init();
    }

    public void SetArgumentIndex(nuint argumentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingInputNode_Selectors.setArgumentIndex_, (nint)argumentIndex);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
