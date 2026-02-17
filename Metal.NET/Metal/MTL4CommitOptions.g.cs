using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommitOptions_Selectors
{
    internal static readonly Selector addFeedbackHandler_ = Selector.Register("addFeedbackHandler:");
}

public class MTL4CommitOptions : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CommitOptions(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommitOptions o) => o.NativePtr;
    public static implicit operator MTL4CommitOptions(nint ptr) => new MTL4CommitOptions(ptr);

    ~MTL4CommitOptions() => Release();

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

    public void AddFeedbackHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommitOptions_Selectors.addFeedbackHandler_, function);
    }

}
