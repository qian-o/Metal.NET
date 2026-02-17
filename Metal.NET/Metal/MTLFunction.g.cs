using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunction_Selectors
{
    internal static readonly Selector newArgumentEncoder_ = Selector.Register("newArgumentEncoder:");
    internal static readonly Selector newArgumentEncoder_reflection_ = Selector.Register("newArgumentEncoder:reflection:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLFunction : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunction(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunction o) => o.NativePtr;
    public static implicit operator MTLFunction(nint ptr) => new MTLFunction(ptr);

    ~MTLFunction() => Release();

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

    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex)
    {
        var __r = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFunction_Selectors.newArgumentEncoder_, (nint)bufferIndex));
        return __r;
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex, nint reflection)
    {
        var __r = new MTLArgumentEncoder(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFunction_Selectors.newArgumentEncoder_reflection_, (nint)bufferIndex, reflection));
        return __r;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunction_Selectors.setLabel_, label.NativePtr);
    }

}
