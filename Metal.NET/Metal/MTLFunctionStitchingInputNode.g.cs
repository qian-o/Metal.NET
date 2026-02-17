using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionStitchingInputNode_Selectors
{
    internal static readonly Selector setArgumentIndex_ = Selector.Register("setArgumentIndex:");
}

public class MTLFunctionStitchingInputNode : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionStitchingInputNode(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionStitchingInputNode o) => o.NativePtr;
    public static implicit operator MTLFunctionStitchingInputNode(nint ptr) => new MTLFunctionStitchingInputNode(ptr);

    ~MTLFunctionStitchingInputNode() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFunctionStitchingInputNode");

    public static MTLFunctionStitchingInputNode New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLFunctionStitchingInputNode(ptr);
    }

    public void SetArgumentIndex(nuint argumentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunctionStitchingInputNode_Selectors.setArgumentIndex_, (nint)argumentIndex);
    }

}
