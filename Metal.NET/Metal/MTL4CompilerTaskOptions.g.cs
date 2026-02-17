using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CompilerTaskOptions_Selectors
{
    internal static readonly Selector setLookupArchives_ = Selector.Register("setLookupArchives:");
}

public class MTL4CompilerTaskOptions : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CompilerTaskOptions(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CompilerTaskOptions o) => o.NativePtr;
    public static implicit operator MTL4CompilerTaskOptions(nint ptr) => new MTL4CompilerTaskOptions(ptr);

    ~MTL4CompilerTaskOptions() => Release();

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

    public void SetLookupArchives(NSArray lookupArchives)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CompilerTaskOptions_Selectors.setLookupArchives_, lookupArchives.NativePtr);
    }

}
