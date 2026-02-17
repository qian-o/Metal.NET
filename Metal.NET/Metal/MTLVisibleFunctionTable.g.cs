using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLVisibleFunctionTable_Selectors
{
    internal static readonly Selector setFunction_index_ = Selector.Register("setFunction:index:");
}

public class MTLVisibleFunctionTable : IDisposable
{
    public nint NativePtr { get; }

    public MTLVisibleFunctionTable(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLVisibleFunctionTable o) => o.NativePtr;
    public static implicit operator MTLVisibleFunctionTable(nint ptr) => new MTLVisibleFunctionTable(ptr);

    ~MTLVisibleFunctionTable() => Release();

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

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVisibleFunctionTable_Selectors.setFunction_index_, function.NativePtr, (nint)index);
    }

}
