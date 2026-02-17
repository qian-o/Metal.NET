using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionStitchingNode_Selectors
{
}

public class MTLFunctionStitchingNode : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionStitchingNode(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionStitchingNode o) => o.NativePtr;
    public static implicit operator MTLFunctionStitchingNode(nint ptr) => new MTLFunctionStitchingNode(ptr);

    ~MTLFunctionStitchingNode() => Release();

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
