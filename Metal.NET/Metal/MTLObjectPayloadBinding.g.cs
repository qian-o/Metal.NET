using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLObjectPayloadBinding_Selectors
{
}

public class MTLObjectPayloadBinding : IDisposable
{
    public nint NativePtr { get; }

    public MTLObjectPayloadBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLObjectPayloadBinding o) => o.NativePtr;
    public static implicit operator MTLObjectPayloadBinding(nint ptr) => new MTLObjectPayloadBinding(ptr);

    ~MTLObjectPayloadBinding() => Release();

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
