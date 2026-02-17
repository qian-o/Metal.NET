using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommitFeedback_Selectors
{
}

public class MTL4CommitFeedback : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CommitFeedback(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommitFeedback o) => o.NativePtr;
    public static implicit operator MTL4CommitFeedback(nint ptr) => new MTL4CommitFeedback(ptr);

    ~MTL4CommitFeedback() => Release();

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

}
