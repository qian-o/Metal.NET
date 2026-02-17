using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLVisibleFunctionTableDescriptor_Selectors
{
    internal static readonly Selector setFunctionCount_ = Selector.Register("setFunctionCount:");
    internal static readonly Selector visibleFunctionTableDescriptor = Selector.Register("visibleFunctionTableDescriptor");
}

public class MTLVisibleFunctionTableDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLVisibleFunctionTableDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLVisibleFunctionTableDescriptor o) => o.NativePtr;
    public static implicit operator MTLVisibleFunctionTableDescriptor(nint ptr) => new MTLVisibleFunctionTableDescriptor(ptr);

    ~MTLVisibleFunctionTableDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVisibleFunctionTableDescriptor");

    public void SetFunctionCount(nuint functionCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVisibleFunctionTableDescriptor_Selectors.setFunctionCount_, (nint)functionCount);
    }

    public static MTLVisibleFunctionTableDescriptor VisibleFunctionTableDescriptor()
    {
        var __r = new MTLVisibleFunctionTableDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLVisibleFunctionTableDescriptor_Selectors.visibleFunctionTableDescriptor));
        return __r;
    }

}
