using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLThreadgroupBinding_Selectors
{
}

public class MTLThreadgroupBinding : IDisposable
{
    public nint NativePtr { get; }

    public MTLThreadgroupBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLThreadgroupBinding o) => o.NativePtr;
    public static implicit operator MTLThreadgroupBinding(nint ptr) => new MTLThreadgroupBinding(ptr);

    ~MTLThreadgroupBinding() => Release();

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
