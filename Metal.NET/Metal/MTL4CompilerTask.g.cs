using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CompilerTask_Selectors
{
    internal static readonly Selector waitUntilCompleted = Selector.Register("waitUntilCompleted");
}

public class MTL4CompilerTask : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CompilerTask(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CompilerTask o) => o.NativePtr;
    public static implicit operator MTL4CompilerTask(nint ptr) => new MTL4CompilerTask(ptr);

    ~MTL4CompilerTask() => Release();

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

    public void WaitUntilCompleted()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CompilerTask_Selectors.waitUntilCompleted);
    }

}
