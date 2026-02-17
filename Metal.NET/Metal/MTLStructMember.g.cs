using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLStructMember_Selectors
{
}

public class MTLStructMember : IDisposable
{
    public nint NativePtr { get; }

    public MTLStructMember(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLStructMember o) => o.NativePtr;
    public static implicit operator MTLStructMember(nint ptr) => new MTLStructMember(ptr);

    ~MTLStructMember() => Release();

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
